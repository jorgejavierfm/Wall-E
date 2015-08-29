using System;
using System.Collections.Generic;
using System.Text;

namespace FlowChartDesigner.Builders{
   /// <summary>
   /// Clase abstracta que agrupa la funcionalidad de los ChartElement que aceptan solo valores predefinidos.
   /// </summary>
   public abstract class PredefinedChartBuilder : ChartElementBuilder
   {
      List<string> validValuesList = new List<string>();
      
      /// <summary>
      /// Almacena los posibles valores que este ChartElement puede tomar.
      /// </summary>
      public List<string> ValuesList
      {
         get { return validValuesList; }
         set { this.validValuesList = value;}
      }
   }
}