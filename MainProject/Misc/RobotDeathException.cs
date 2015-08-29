using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Walle.UI
{
   /// <summary>
   /// Excepcion lanzada cuando el robot muere.
   /// </summary>
   class RobotDeathException : Exception
   {
      public RobotDeathException(string message) : base(message) { }
   }
}
