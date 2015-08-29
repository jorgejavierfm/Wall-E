using System;
using System.Collections.Generic;
using System.Text;
using Walle.Scenario;

namespace Walle.Components.Sensors{
   /// <summary>
   /// Define un sensor.
   /// </summary>
   public interface ISensor
   {
      Map Map
      {
         get;
         set;
      }
   }
}