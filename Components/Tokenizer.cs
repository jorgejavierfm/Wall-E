using System;
using System.Collections.Generic;

namespace Components
{
    /// <summary>
    /// Representa un objeto que separa una expresión en tokens.
    /// <remarks>
    /// Este tipo puede ser usado para las expresiones de la tarea. 
    /// El texto que desea separar en tokens debe ser pasado por el constructor. 
    /// Use el metodo GetTokens para obtener los tokens a partir del texto dado en el constructor. 
    /// </remarks>
    /// </summary>
    public class Tokenizer
    {
        protected LexicalAnalyzer lex;
        /// <summary>
        /// Construye un Tokenizer.
        /// </summary>
        /// <param name="text">Texto que se quiere separar en tokens.</param>
        public Tokenizer(string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");
            lex = new LexicalAnalyzer(text);
        }

        /// <summary>
        /// Separa una expresión en tokens.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<Token> GetTokens()
        {
            while (lex.HasMoreTokens())
            {
                lex.NextToken();
                yield return lex.Current;
            }
        }
    }
}
    
