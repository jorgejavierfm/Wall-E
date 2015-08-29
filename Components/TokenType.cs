using System;
using System.Collections.Generic;
using System.Text;

namespace Components
{
    /// <summary>
    /// Define los tipos de token que pueden encontrarse en un expresión.
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// Representa un nombre de variable o propiedad.
        /// </summary>
        Name,
        /// <summary>
        /// Representa la palabra clave 'true'
        /// </summary>
        True,
        /// <summary>
        /// Representa la palabra clave 'false'
        /// </summary>
        False,
        /// <summary>
        /// Representa una constante entera
        /// </summary>
        Constant,
        /// <summary>
        /// Representa el token '+'
        /// </summary>
        Plus,
        /// <summary>
        /// Representa el token '-'
        /// </summary>
        Minus,
        /// <summary>
        /// Representa el token '*'
        /// </summary>
        Asterisk,
        /// <summary>
        /// Representa el token '/'
        /// </summary>
        Slash,
        /// <summary>
        /// Representa el token '%'
        /// </summary>
        Percent,
        /// <summary>
        /// Representa el token '&amp;&amp;'
        /// </summary>
        Ampersand,
        /// <summary>
        /// Representa el token '||'
        /// </summary>
        Caret,
        /// <summary>
        /// Representa el token '>'
        /// </summary>
        Greater,
        /// <summary>
        /// Representa el token '>='
        /// </summary>
        GreaterEqual,
        /// <summary>
        /// Representa el token '&lt;'
        /// </summary>
        Less,
        /// <summary>
        /// Representa el token '&lt;='
        /// </summary>
        LessEqual,
        /// <summary>
        /// Representa el token '='
        /// </summary>
        Equal,
        /// <summary>
        /// Representa el token '!='
        /// </summary>
        NotEqual,
        /// <summary>
        /// Representa el token '.'
        /// </summary>
        Dot,
        /// <summary>
        /// Representa el token ','
        /// </summary>
        Comma,
        /// <summary>
        /// Representa el token '='
        /// </summary>
        Assign,
        /// <summary>
        /// Representa el token '('
        /// </summary>
        OpenedParenthesis,
        /// <summary>
        /// Representa el token ')'
        /// </summary>
        ClosedParenthesis,
        /// <summary>
        /// Representa el token '['
        /// </summary>
        OpenedBracket,
        /// <summary>
        /// Representa el token ']'
        /// </summary>
        ClosedBracket,
        /// <summary>
        /// Representa un token invalido dentro de la expresión.
        /// </summary>
        Invalid
    }
}
