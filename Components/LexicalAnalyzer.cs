using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.IO;


namespace Components
{
    /// <summary>
    /// Reconoce cada componente del texto.
    /// </summary>
    public class LexicalAnalyzer
    {
        protected string text;
        protected int position;
        protected Token current;
        protected StringReader reader;

        public LexicalAnalyzer(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            this.text = text;
            reader = new StringReader(text);
        }

        /// <summary>
        /// Devuelve si un caracter en particular es espacio en blanco.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsWhiteSpace(char c)
        {
            return (" \t\n\r".IndexOf(c) >= 0);
        }

        /// <summary>
        /// Se mueve siempre que pueda al proximo token.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual void NextToken()
        {
            Token next = null;
            if (HasMoreTokens())
            {
                char c = Read();
                switch (c)
                {
                    case '+':
                        next = new Token(TokenType.Plus, "+");
                        break;

                    case '-':
                        next = new Token(TokenType.Minus, "-");
                        break;

                    case '*':
                        next = new Token(TokenType.Asterisk, "*");
                        break;

                    case '/':
                        next = new Token(TokenType.Slash, "/");
                        break;

                    case '%':
                        next = new Token(TokenType.Percent, "%");
                        break;

                    case '&':
                        if (Peek() != '&')
                            next = new Token(TokenType.Invalid, c.ToString());
                        else
                        {
                            Read();
                            next = new Token(TokenType.Ampersand, "&&");
                        }
                        break;

                    case '|':
                        if (Peek() != '|')
                            next = new Token(TokenType.Invalid, c.ToString());
                        else
                        {
                            Read();
                            next = new Token(TokenType.Caret, "||");
                        }
                        break;

                    case '(':
                        next = new Token(TokenType.OpenedParenthesis, "(");
                        break;

                    case ')':
                        next = new Token(TokenType.ClosedParenthesis, ")");
                        break;

                    case '[':
                        next = new Token(TokenType.OpenedBracket, "[");
                        break;

                    case ']':
                        next = new Token(TokenType.ClosedBracket, "]");
                        break;

                    case '.':
                        next = new Token(TokenType.Dot, ".");
                        break;

                    case ',':
                        next = new Token(TokenType.Comma, ",");
                        break;

                    case '=':
                        if (Peek() == '=')
                        {
                            Read();
                            next = new Token(TokenType.Equal, "==");
                        }
                        else
                            next = new Token(TokenType.Assign, "=");
                        break;

                    case '!':
                        if (Peek() == '=')
                        {
                            Read();
                            next = new Token(TokenType.NotEqual, "!=");
                        }
                        else next = new Token(TokenType.Invalid, "!");
                        break;

                    case '>':
                        if (Peek() == '=')
                        {
                            Read();
                            next = new Token(TokenType.GreaterEqual, ">=");
                        }
                        else
                            next = new Token(TokenType.Greater, ">");
                        break;

                    case '<':
                        if (Peek() == '=')
                        {
                            Read();
                            next = new Token(TokenType.LessEqual, "<=");
                        }
                        else
                            next = new Token(TokenType.Less, "<");
                        break;

                    default:
                        if (char.IsLetter(c))
                        {
                            string nextValue = ReadWord(c);
                            if (nextValue == "true" || nextValue == "True")
                                next = new Token(TokenType.True, nextValue.ToLowerInvariant());
                            else if (nextValue == "false" || nextValue == "False")
                                next = new Token(TokenType.False, nextValue.ToLowerInvariant());
                            else
                                next = new Token(TokenType.Name, nextValue);
                        }
                        else if (char.IsDigit(c))
                            next = new Token(TokenType.Constant, ReadNumber(c));
                        break;
                }
                if (next == null)
                    next = new Token(TokenType.Invalid, c.ToString());
            }
            current = next;
        }

        /// <summary>
        /// Lee el proximo caracter de la cadena
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected virtual char Read()
        {
            position++;
            return (char)reader.Read();
        }

        /// <summary>
        /// Consulta el proximo caracter de la cadena pero sin leerlo
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected virtual char Peek()
        {
            return (char)reader.Peek();
        }

        /// <summary>
        /// Lee la proxima palabra de la cadena.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected virtual string ReadWord(char c)
        {
            string res = "" + c;
            c = Peek();
            while (char.IsLetter(c) || char.IsDigit(c))
            {
                res += Read();
                c = Peek(); ;
            }
            return res;
        }

        /// <summary>
        /// Lee el proximo número de la cadena.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected virtual string ReadNumber(char c)
        {
            string res = "" + c;
            c = Peek();
            while (char.IsDigit(c))
            {
                res += Read();
                c = Peek(); ;
            }
            return res;
        }

        /// <summary>
        /// Devuelve si existen todavia tokens por procesar.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public virtual bool HasMoreTokens()
        {
            SkipSpaces();
            return reader.Peek() != -1;
        }

        /// <summary>
        /// Salta los espacios
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        protected virtual void SkipSpaces()
        {
            char c = Peek();
            while (IsWhiteSpace(c))
            {
                Read();
                c = Peek();
            }
        }

        /// <summary>
        /// El token que actualmente se está procesando.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public Token Current
        {
            get { return current; }
        }

        /// <summary>
        /// Posición actual.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public int Position
        {
            get { return position; }
        }

        /// <summary>
        /// Texto que se está procesando.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public string Text
        {
            get { return text; }
        }
    }
}
