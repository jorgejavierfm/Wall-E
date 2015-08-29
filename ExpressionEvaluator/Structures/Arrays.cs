using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Walle.ExpressionEvaluator.Structures{
   /// <summary>
   /// Clase que encapsula el funcionamiento de un array.
   /// </summary>
   public class Array
   {
      public VariableType Type { get; set; }
      public string Name { get; set; }

      Dictionary<string, Variable> array = new Dictionary<string, Variable>();

      public Array(VariableType type, string name)
      {
         this.Type = type;
         this.Name = name;
      }

      public Variable this[string index]
      {
         get
         {
            if (array.ContainsKey(index))
               return array[index];
            else
               return GetDefaultValue();
         }
         set
         {
            if (value.Type != this.Type) throw new Exception(String.Format("Cannot assign variable of type {0} to array {1} of type {2}.", value.Type, this.Name, this.Type));
            else
               array[index] = value;
         }
      }

      public bool VariableIsDeclarated(string key)
      {
         return array.ContainsKey(key);
      }

      public void Add(string key, Variable v)
      {
         array[key] = v;
      }

      public Variable GetDefaultValue()
      {
         return Variable.GetDefaultValue(Type);
      }
   }

   /// <summary>
   /// Encapsula un conjunto de arrays.
   /// </summary>
   public class ArrayStorage
   {
      public Dictionary<string, Array> arrays = new Dictionary<string, Array>();

      public void AssignToArray(string arrayName, string key, Variable v)
      {
         key = key.Trim();
         if (arrays.ContainsKey(arrayName)) // El array existe?
         {
            if (v.Type == arrays[arrayName].Type)
            {
               if (arrays[arrayName].VariableIsDeclarated(key)) arrays[arrayName][key] = v; // Si el array esta asignado en ese indice, cambia su valor
               else arrays[arrayName].Add(key, v); // Sino, agrega el nuevo indice
            }
            else throw new InvalidOperationException(string.Format("Cannot assign a {0} to an array of {1}.", v.Type, arrays[arrayName].Type));

         }
         else // Si el array no existe, crearlo
         {
            Array newArray = new Array(v.Type, arrayName);
            newArray[key] = new Variable(v.Value.ToString());
            arrays[arrayName] = newArray;
         }
      }

      public Array this[string arrayName]
      {
         get
         {
            if (ArrayExists(arrayName))
               return arrays[arrayName];
            throw new InvalidOperationException(string.Format("Array {0} is not declarated.", arrayName));
         }
         set { arrays[arrayName] = value; }
      }

      public bool ArrayExists(string p)
      {
         p = p.Trim();
         return arrays.ContainsKey(p);
      }

      public Variable GetValueInArray(string arrayName, string index)
      {
         if (ArrayExists(arrayName))
         {
            return this[arrayName][index];
         } else return new Variable("");
      }

   }
}