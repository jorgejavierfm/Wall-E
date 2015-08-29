namespace Components
{
    /// <summary>
    /// Representa un elemento "significativo" para la sintaxis del lenguaje.
    /// <remarks>
    /// El tipo Token solamente puede ser usado para las expresiones especificado en la tarea. 
    /// Una instancia de Token representa un elemento "significativo" (palabra clave, símbolo o identificador) 
    /// para la sintaxis de las expresiones. 
    /// </remarks>
    /// <example>
    /// Ejemplo: La variable "marcas" no se reconoce con cada caracter por separado,
    /// sino como el identificador en su conjunto "marcas".
    /// </example>
    /// </summary>
    public class Token
    {
        protected string tValue;
        protected TokenType type;

        public Token(TokenType type, string tokenValue)
        {
            this.type = type;
            this.tValue = tokenValue;
        }

        /// <summary>
        /// Tipo del token.
        /// </summary>
        public virtual TokenType Type
        {
            get
            {
                return this.type;
            }
        }

        /// <summary>
        /// Valor string del token.
        /// <example>
        /// El token que tiene tipo TokenType.OpenedParenthesis tiene como valor "("
        /// </example>
        /// </summary>
        public virtual string Value
        {
            get
            {
                return this.tValue;
            }
        }
    }
}
