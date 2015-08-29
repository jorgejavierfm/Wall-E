using System;
using System.Collections.Generic;
using Walle.ExpressionEvaluator.Structures;
using Components;

namespace Walle.ExpressionEvaluator{
   public class Evaluator
   {
      private VariableStorage Variables = new VariableStorage(); // Aqui se almacenan las variables.
      private ArrayStorage Arrays = new ArrayStorage(); // El mismo texto anterior, pero con arrays.
      private Dictionary<string, IOperator> Operations = new Dictionary<string, IOperator>();  // A cada token de operacion le corresponde un tipo de operador.

      public Evaluator()
      {
         // Inicializa el diccionario de operaciones.
         Operations.Add("+", new Plus());
         Operations.Add("-", new Minus());
         Operations.Add("*", new Multiply());
         Operations.Add("/", new Divide());
         Operations.Add("%", new Mod());
         Operations.Add("&&", new And());
         Operations.Add("||", new Or());
         Operations.Add("<", new LessThan());
         Operations.Add("<=", new LessEqualThan());
         Operations.Add(">", new GreaterThan());
         Operations.Add(">=", new GreaterEqualThan());
         Operations.Add("==", new Equal());
         Operations.Add("!=", new NotEqual());
      }

      #region Public
      /// <summary>
      /// Evalua una expresion aritmetica determinada.
      /// </summary>
      /// <param name="expression">La expresion a evaluar.</param>
      /// <returns>Un string que representa el valor de la expresion evaluada.</returns>
      public string Evaluate(string expression)
      {
          if (expression == null)
            throw new InvalidOperationException("Nothing to evaluate.");
         if (expression == "") return expression;

         Stack<Token> operatorStack = new Stack<Token>();
         string postfixExpression = "";
         Tokenizer tokenizer = new Tokenizer(expression);
         IEnumerable<Token> tokens = tokenizer.GetTokens();

         IEnumerator<Token> enumerator = tokens.GetEnumerator();

         Token prevToken = null;
         while (enumerator.MoveNext())
         {
            Token currentToken = enumerator.Current;
            bool unaryMinusBeforeParenthesis = false;
            switch (currentToken.Type){
               case TokenType.OpenedParenthesis: // Si hay un parentesis, recupera la expresion completa y la evalua recursivamente.
                  string auxExp = "";

                  int openPCount = 1;
                  int closedPCount = 0;

                  do{
                     if (!enumerator.MoveNext()) throw new InvalidOperationException("Unbalanced parenthesis");
                     if (enumerator.Current.Type == TokenType.OpenedParenthesis) openPCount++;
                     else if (enumerator.Current.Type == TokenType.ClosedParenthesis) closedPCount++;

                     if (enumerator.Current.Type != TokenType.ClosedParenthesis || closedPCount < openPCount)
                        auxExp += enumerator.Current.Value + " ";

                  } while (closedPCount != openPCount);

                  string extra = unaryMinusBeforeParenthesis ? "-1 * " : " ";

                  postfixExpression += Evaluate(auxExp) + extra;
                  break;

               case TokenType.ClosedParenthesis:
                  throw new InvalidOperationException("Unbalanced parenthesis");

               case TokenType.Name: // Si es un nombre, pregunta por su tipo y lo sustituye por su valor
                  string name = currentToken.Value;
                  if (Variables.ContainsVariable(name)) // Es una variable?
                  {
                     Variable v = Variables[name];
                     if (v.Type != VariableType.Empty)
                        postfixExpression += Variables[name] + " ";   
                  }
                  else if (Arrays.ArrayExists(currentToken.Value)) // Es un array?
                  {
                     string array = name;

                     while (enumerator.MoveNext() && enumerator.Current.Type!=TokenType.ClosedBracket)
                        array += enumerator.Current.Value;

                     array += "]";

                     postfixExpression += GetArrayValue(array) + " ";
                  }
                  else throw new InvalidOperationException(string.Format("Unknown name token: \"{0}\".",name));
                  break;

                  // Si es un valor, simplemente lo agrega a la expresion en postfijo
               case TokenType.True:
               case TokenType.False:
               case TokenType.Constant:
                  postfixExpression += currentToken.Value + " ";
                  break;

               case TokenType.Minus:
                  if (GetTokenPriority(prevToken) > 0){
                     enumerator.MoveNext();
                     currentToken = enumerator.Current;
                     if (currentToken.Type == TokenType.Constant){
                        postfixExpression += "-" + currentToken.Value + " ";
                     }
                     else if (currentToken.Type == TokenType.OpenedParenthesis){
                        unaryMinusBeforeParenthesis = !unaryMinusBeforeParenthesis;
                        goto case TokenType.OpenedParenthesis;
                     }

                  }
                  else
                     goto case TokenType.Plus;
                  break;

                  // Si es un operador...
               case TokenType.Plus:
               case TokenType.Asterisk:
               case TokenType.Slash:
               case TokenType.Percent:
               case TokenType.Ampersand:
               case TokenType.Caret:
               case TokenType.Greater:
               case TokenType.GreaterEqual:
               case TokenType.Less:
               case TokenType.LessEqual:
               case TokenType.Equal:
               case TokenType.NotEqual:
                  if (operatorStack.Count == 0)
                     operatorStack.Push(currentToken); // ... se agrega al stack si no habian otros operadores.
                  else{ // Si habian otros, los agrega a la expresion en postfijo hasta que no haya ninguno de menor prioridad.
                     int topOperPriority = GetTokenPriority(operatorStack.Peek());
                     int currentTokenPriority = GetTokenPriority(currentToken);
                     while (operatorStack.Count > 0 && topOperPriority >= currentTokenPriority){
                        postfixExpression += operatorStack.Pop().Value + " ";
                        if (operatorStack.Count > 0) topOperPriority = GetTokenPriority(operatorStack.Peek());
                     }
                     operatorStack.Push(currentToken);
                  }
                  break;

               case TokenType.Invalid:
                  throw new InvalidOperationException("Invalid token in expression.");
            }
            prevToken = enumerator.Current;
         }
         // Si la expresion termino de parsearse, agrega los operadores restantes a la expresion en postfijo.
         while (operatorStack.Count > 0)
         {
            postfixExpression += operatorStack.Pop().Value + " ";
         }

         return EvaluatePostfix(postfixExpression); // Pasa la expresion construida al metodo que evalua en si.
      }

      /// <summary>
      /// Guarda un valor determinado, entero o booleano.
      /// </summary>
      /// <param name="where">Donde guardar el valor. La expresion puede ser una variable, o un arreglo.</param>
      /// <param name="what">La expresion que contiene el valor a guardar. Es evaluada, y el valor resultante guardado.</param>
      public void Assign(string where, string what)
      {
         what = what.ToLower();
         where = where.ToLower();
         if (where.Contains("[") && where.Contains("]")) // Es un array?
         {

            Tokenizer t = new Tokenizer(where);
            var enumerator = t.GetTokens().GetEnumerator();
            enumerator.MoveNext();

            if (enumerator.Current.Type != TokenType.Name)
            {
               throw new InvalidOperationException(string.Format("{0} is not either a valid variable or array expression.", where));
            }
            else if (Variables.ContainsVariable(enumerator.Current.Value))
            {
               throw new InvalidOperationException(string.Format("There is another variable with the name {0}.", enumerator.Current.Value));
            }

            SaveToArray(where, Evaluate(what));
         }
         else // Es una variable entonces...
         {
            Tokenizer t = new Tokenizer(where);

            var enumerator = t.GetTokens().GetEnumerator();
            enumerator.MoveNext();
            if (!enumerator.MoveNext())
            {
               Variable v = new Variable(Evaluate(what));
               Variables[where] = v;
            }
            else throw new InvalidOperationException(string.Format("{0} is not either a valid variable or array expression.", where));
         }

      }

      /// <summary>
      /// Devuelve un valor guardado en memoria, entero o booleano.
      /// </summary>
      /// <param name="name">Nombre de variable o array.</param>
      /// <returns>El valor guardado en la variable o array solicitados. </returns>
      public Variable GetValue(string name) 
      {
         name = name.ToLower();
         if (name.Contains("[") && name.Contains("]")) // Es un array?
            return GetArrayValue(name);
         // Es una variable
         return GetVariable(name);
      }
      #endregion

      #region Private
      private Variable GetVariable(string variableName)
      {
         return Variables[variableName];
      }

      /// <summary>
      /// Separa el nombre del array de sus indices.
      /// </summary>
      /// <param name="arrayWithIndices"></param>
      /// <returns></returns>
      private Variable GetArrayValue(string arrayWithIndices)
      {
         string arrayName = "";
         Tokenizer t = new Tokenizer(arrayWithIndices);
         
         var enumerator = t.GetTokens().GetEnumerator();

         enumerator.MoveNext(); // Pone el cursor en el nombre
         arrayName = enumerator.Current.Value;

         string preIndex = "";

         enumerator.MoveNext(); // Pone el cursor en el [

         while (enumerator.MoveNext() && enumerator.Current.Type!= TokenType.ClosedBracket){
            preIndex += enumerator.Current.Value + " ";
         }
         enumerator.MoveNext();

         string index = ParseArrayIndex(preIndex);

         return Arrays.GetValueInArray(arrayName, index);
      }

      /// <summary>
      /// Guarda un valor en el array dado.
      /// </summary>
      /// <param name="arrayWithIndices">Array donde guardar el valor.</param>
      /// <param name="expression">Expresion a evaluar.</param>
      private void SaveToArray(string arrayWithIndices, string expression)
      {
         Tokenizer t = new Tokenizer(arrayWithIndices);

         var enumerator = t.GetTokens().GetEnumerator();
         string arrayName = "";

         enumerator.MoveNext();
         if (enumerator.Current.Type == TokenType.Name)
            arrayName = enumerator.Current.Value;
         else throw new Exception("Invalid array name.");

         enumerator.MoveNext();
         if (enumerator.Current.Type != TokenType.OpenedBracket) throw new Exception("Invalid array name.");

         string preIndex = "";
         while (enumerator.MoveNext()){
            preIndex += enumerator.Current.Value;
         }
         preIndex.Replace("]", ""); // Quitar el último corchete
         
         string index = ParseArrayIndex(preIndex);

         index = index.Trim();
         Arrays.AssignToArray(arrayName, index, new Variable(Evaluate(expression)));

      }

      /// <summary>
      /// Evalua una expresion dada en notacion postfijo.
      /// </summary>
      /// <param name="postfixExp">Expresion en postfijo a evaluar.</param>
      /// <returns>El valor resultante de la evaluacion.</returns>
      private string EvaluatePostfix(string postfixExp)
      {
         Stack<Operand> operandStack = new Stack<Operand>();

         string[] tokenArray = postfixExp.Split(' ');

         foreach (string pretoken in tokenArray)
         {
            Tokenizer token = new Tokenizer(pretoken);
            IEnumerator<Token> enumerator = token.GetTokens().GetEnumerator();

            while (enumerator.MoveNext())
            {
               Token item = enumerator.Current;
               switch (item.Type)
               {
                  case TokenType.True:
                     operandStack.Push(new Operand(true));
                     break;
                  case TokenType.False:
                     operandStack.Push(new Operand(false));
                     break;
                  case TokenType.Constant:
                     operandStack.Push(new Operand(int.Parse(item.Value)));
                     break;

                  case TokenType.Minus:
                     if (enumerator.MoveNext() && enumerator.Current.Type != TokenType.Minus) operandStack.Push(new Operand(int.Parse(enumerator.Current.Value) * -1));
                     else goto case TokenType.Plus;

                     break;

                  case TokenType.Plus:
                  case TokenType.Asterisk:
                  case TokenType.Slash:
                  case TokenType.Percent:
                  case TokenType.Ampersand:
                  case TokenType.Caret:
                  case TokenType.Greater:
                  case TokenType.GreaterEqual:
                  case TokenType.Less:
                  case TokenType.LessEqual:
                  case TokenType.Equal:
                  case TokenType.NotEqual:
                     try
                     {
                        IOperator oper = Operations[item.Value];
                        Operand op2 = operandStack.Pop();
                        Operand op1 = operandStack.Pop();
                        operandStack.Push(oper.Eval(op1, op2));
                     }
                     catch (InvalidCastException e)
                     {
                        throw new InvalidOperationException("Incorrect expression.", e);
                     }
                     break;
                  default:
                     throw new InvalidOperationException("Incorrect input expression.");
               }
            }

         }

         if (operandStack.Count == 1)
         {
            string result = operandStack.Pop().Value.ToString();
            return result;
         }
         else throw new Exception("Unknown error.");
      }

      /// <summary>
      /// Devuelve un valor entero que representa la prioridad de un token determinado.
      /// </summary>
      /// <param name="token"></param>
      /// <returns></returns>
      private static int GetTokenPriority(Token token)
      {
         if (token == null) return 10;
         switch (token.Type)
         {
            case TokenType.Asterisk:
            case TokenType.Slash:
            case TokenType.Percent:
               return 4;
            case TokenType.Plus:
            case TokenType.Minus:
               return 3;
            case TokenType.Equal:
            case TokenType.NotEqual:
            case TokenType.Greater:
            case TokenType.GreaterEqual:
            case TokenType.Less:
            case TokenType.LessEqual:
               return 2;
            case TokenType.Ampersand:
            case TokenType.Caret:
               return 1;
            case TokenType.Invalid:
               return -1;
            default:
               return 0;
         }
      }

      /// <summary>
      /// Parsea y evalua los indices de los arrays. Expresiones del tipo "a[a[2,3],5]" no estan soportadas actualmente. 
      /// Para usar esta funcionalidad, declare una variable "b = a[2,3]" y luego evalue a[b,5].
      /// </summary>
      /// <param name="indexExpression"></param>
      /// <returns></returns>
      private string ParseArrayIndex(string indexExpression)
      {
         string[] indexes = indexExpression.Split(',');
         string result = "";

         foreach (string s in indexes){
            result += Evaluate(s) + " ";
         }

         return result.Trim();
      }
      #endregion
   }
}