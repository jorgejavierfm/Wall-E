using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Operators
{
    /// <summary>
    /// Determina el comportamiento de los operadores.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface Operator<TOperand,TReturns> 
    {
       TReturns Eval(TOperand op1, TOperand op2);
    }

    /// <summary>
    /// Realiza la suma de dos operandos como enteros.
    /// </summary>
    public class Add : Operator<Operand<int>,Operand<int>> 
    {
        public Operand<int> Eval(Operand<int> op1, Operand<int> op2)
        {
            return new Operand<int>(op1.Value + op2.Value);
        }
    }
    /// <summary>
    /// Realiza la resta de dos operandos como enteros.
    /// </summary>
    public class Substract : Operator<Operand<int>, Operand<int>> 
    {
        public Operand<int> Eval(Operand<int> op1, Operand<int> op2)
        {
            return new Operand<int>(op1.Value - op2.Value);
        }
    }
    /// <summary>
    /// Realiza el producto de dos operandos como enteros.
    /// </summary>
    public class Multiply : Operator<Operand<int>, Operand<int>> 
    {
        public Operand<int> Eval(Operand<int> op1, Operand<int> op2)
        {
            return new Operand<int>(op1.Value * op2.Value);
        }
    }
    /// <summary>
    /// Realiza el cociente de dos operandos como enteros.
    /// </summary>
    public class Divide : Operator<Operand<int>, Operand<int>> 
    {
        public Operand<int> Eval(Operand<int> op1, Operand<int> op2)
        {
            if (op2.Value == 0) throw new InvalidOperationException("Division by zero.");
            return new Operand<int>(op1.Value / op2.Value);
        }
    }
    /// <summary>
    /// Calcula el resto entre dos operadores como enteros.
    /// </summary>
    public class Modulo : Operator<Operand<int>, Operand<int>> 
    {
        public Operand<int> Eval(Operand<int> op1, Operand<int> op2)
        {
            if (op2.Value == 0) throw new Exception("No se puede efectuar la division por 0");
            return new Operand<int>(op1.Value % op2.Value);
        }
    }
    /// <summary>
    /// Determina la evaluacion de && de dos operadores como bool.
    /// </summary>
    public class And : Operator<Operand<bool>, Operand<bool>> 
    {
        public Operand<bool> Eval(Operand<bool> op1, Operand<bool> op2)
        {
            return new Operand<bool>(op1.Value && op2.Value); ;
        }
    }
    /// <summary>
    /// Determina la evaluacion de || de dos operadores como bool.
    /// </summary>
    public class Or : Operator<Operand<bool>, Operand<bool>> 
    {
        public Operand<bool> Eval(Operand<bool> op1, Operand<bool> op2)
        {
            return new Operand<bool>(op1.Value || op2.Value);
        }
    }
    /// <summary>
    /// Compara dos operandos con el operador de <.
    /// </summary>
    public class LessThan : Operator<Operand<int>, Operand<bool>> 
    {
        public Operand<bool> Eval(Operand<int> op1, Operand<int> op2)
        {
            return new Operand<bool>(op1.Value < op2.Value);
        }
    }
    /// <summary>
    /// Compara dos operandos con el operador de >.
    /// </summary>
    public class GreaterThan : Operator<Operand<int>, Operand<bool>> 
    {
        public Operand<bool> Eval(Operand<int> op1, Operand<int> op2)
        {
            return new Operand<bool>(op1.Value > op2.Value);
        }
    }
    /// <summary>
    /// Compara dos operandos con el operador de <=.
    /// </summary>
    public class LessEqualThan : Operator<Operand<int>, Operand<bool>> 
    {
        public Operand<bool> Eval(Operand<int> op1, Operand<int> op2)
        {
            return new Operand<bool>(op1.Value <= op2.Value);
        }
    }
    /// <summary>
    /// Compara dos operandos con el operador de >=.
    /// </summary>
    public class GreaterEqualThan : Operator<Operand<int>, Operand<bool>> 
    {
        public Operand<bool> Eval(Operand<int> op1, Operand<int> op2)
        {
            return new Operand<bool>(op1.Value >= op2.Value);
        }
    }
    /// <summary>
    /// Compara dos operandos con el operador de ==.
    /// </summary>
    public class Equals<T> : Operator<Operand<T>,Operand<bool>>
    {
        public Operand<bool> Eval(Operand<T> op1, Operand<T> op2)
        {
            return new Operand<bool>(op1.Value.Equals(op2.Value));
        }
    }
    /// <summary>
    /// Compara dos operandos con el operador de !=.
    /// </summary>
    public class NotEquals<T> : Operator<Operand<T>, Operand<bool>>
    {
        public Operand<bool> Eval(Operand<T> op1, Operand<T> op2)
        {
            return new Operand<bool>(!op1.Value.Equals(op2.Value));
        }
    }
}
