using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Walle.ExpressionEvaluator.Structures{
   /// <summary>
   /// Determina el comportamiento de los operadores.
   /// </summary>
    
   public interface IOperator
   {
      Operand Eval(Operand op1, Operand op2);
   }

   /// <summary>
   /// Realiza la suma de dos operandos como enteros.
   /// </summary>
   public class Plus : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         return new Operand(int.Parse(op1.Value.ToString()) + int.Parse(op2.Value.ToString()));
      }
   }

   /// <summary>
   /// Realiza la resta de dos operandos como enteros.
   /// </summary>
   public class Minus : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         return new Operand((int)op1.Value - (int)op2.Value);
      }
   }

   /// <summary>
   /// Realiza el producto de dos operandos como enteros.
   /// </summary>
   public class Multiply : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         return new Operand((int)op1.Value * (int)op2.Value);
      }
   }

   /// <summary>
   /// Realiza el cociente de dos operandos como enteros.
   /// </summary>
   public class Divide : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         if ((int)op2.Value == 0) throw new Exception("No se puede efectuar la division por 0");
         return new Operand((int)op1.Value / (int)op2.Value);
      }
   }

   /// <summary>
   /// Calcula el resto entre dos operadores como enteros.
   /// </summary>
   public class Mod : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         if ((int)op2.Value == 0) throw new Exception("No se puede efectuar la division por 0");
         return new Operand((int)op1.Value % (int)op2.Value);
      }
   }

   /// <summary>
   /// Determina la evaluacion de && de dos operadores como bool.
   /// </summary>
   public class And : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         return new Operand((bool)op1.Value && (bool)op2.Value);
      }
   }

   /// <summary>
   /// Determina la evaluacion de || de dos operadores como bool.
   /// </summary>
   public class Or : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         return new Operand((bool)op1.Value || (bool)op2.Value);
      }
   }

   /// <summary>
   /// Compara dos operandos con el operador de <.
   /// </summary>
   public class LessThan : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         return new Operand((int)op1.Value < (int)op2.Value);
      }
   }

   /// <summary>
   /// Compara dos operandos con el operador de >.
   /// </summary>
   public class GreaterThan : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         return new Operand((int)op1.Value > (int)op2.Value);
      }
   }

   /// <summary>
   /// Compara dos operandos con el operador de <=.
   /// </summary>
   public class LessEqualThan : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         return new Operand((int)op1.Value <= (int)op2.Value);
      }
   }

   /// <summary>
   /// Compara dos operandos con el operador de >=.
   /// </summary>
   public class GreaterEqualThan : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         return new Operand((int)op1.Value >= (int)op2.Value);
      }
   }

   /// <summary>
   /// Compara dos operandos con el operador de ==.
   /// </summary>
   public class Equal : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         return new Operand(op1.Value.Equals(op2.Value));
      }
   }

   /// <summary>
   /// Compara dos operandos con el operador de !=.
   /// </summary>
   public class NotEqual : IOperator
   {
      public Operand Eval(Operand op1, Operand op2)
      {
         return new Operand(!op1.Value.Equals(op2.Value));
      }
   }

   /// <summary>
   /// Crea un tipo que puede ser usado como un operando.
   /// </summary>
   public class Operand
   {
      public Operand(object operand)
      {
         this.Value = operand;
      }
      public object Value { get; set; }

      public OperandType Type;

   }

   /// <summary>
   /// Tipos de operandos posibles.
   /// </summary>
   public enum OperandType
   {
      Number,
      True,
      False
   }
}