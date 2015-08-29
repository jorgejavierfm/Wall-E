using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Walle.ExpressionEvaluator.Structures{
   /// <summary>
   /// Encapsula la funcionalidad de una variable sencilla.
   /// </summary>
   public class Variable
   {
      public VariableType Type { get; private set; }
      public object Value { get; private set; }

      public Variable(string simpleExp)
      {
         int valueInInt;
         bool valueInBool;
         if (int.TryParse(simpleExp, out valueInInt))
         {
            this.Value = valueInInt;
            this.Type = VariableType.Integer;
         }
         else if (bool.TryParse(simpleExp, out valueInBool))
         {
            this.Value = valueInBool;
            this.Type = VariableType.Boolean;
         }
         else
         {
            this.Value = "";
            this.Type = VariableType.Empty;
         }
      }

      public static Variable GetDefaultValue(VariableType v)
      {
         switch (v)
         {
            case VariableType.Boolean:
               return new Variable(bool.FalseString);
            case VariableType.Integer:
               return new Variable("0 ");
            default:
               throw new Exception("Invalid variable type.");
         }
      }

      public override string ToString()
      {
         switch (Type)
         {
            case VariableType.Boolean:
               return ((bool)Value).ToString();
            case VariableType.Integer:
               return ((int)Value).ToString();
            default:
               return Value.ToString();
         }
      }
   }

   /// <summary>
   /// Encapsula un el funcionamiento de un almacen de variables.
   /// </summary>
   public class VariableStorage
   {
      Dictionary<string, Variable> dic = new Dictionary<string, Variable>();

      public void Add(string variableName, object value)
      {
         Variable v = new Variable(value.ToString());
         dic.Add(variableName, v);
      }

      public Variable this[string name]
      {
         get
         {
            if (ContainsVariable(name))
            {
               return dic[name];
            }else return new Variable("");
         }
         set
         {
            if (dic.ContainsKey(name) && dic[name].Type != value.Type)
               throw new Exception("Mismatching type assignment.");
            dic[name] = value;
         }
      }


      public bool ContainsVariable(string p)
      {
         return dic.ContainsKey(p.ToLower());
      }
   }

   public enum VariableType
   {
      Boolean,
      Integer,
      Empty
   }
}