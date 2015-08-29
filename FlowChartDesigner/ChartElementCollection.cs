using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace FlowChartDesigner
{
   /// <summary>
   /// Representa una coleccion de elementos de diagrama.
   /// Un ObservableCollection es un tipo de coleccion con eventos que permiten notificar cualquier cambio sobre los elementos de la coleccion.
   /// </summary>
   [Serializable]
   public class ChartElementCollection : Collection<ChartElement>
   {
      protected override void InsertItem(int index, ChartElement item)
      {
         base.InsertItem(index, item);

         if (item is BeginChartElement)
            First = item;

         //if (CollectionChanged != null)
            //CollectionChanged(this, EventArgs.Empty);
      }

      protected override void RemoveItem(int index)
      {
         base.RemoveItem(index);

         //if (CollectionChanged != null)
            //CollectionChanged(this, EventArgs.Empty);
      }

      public ChartElement First { get; set;}

      //public event EventHandler CollectionChanged;
   }
}
