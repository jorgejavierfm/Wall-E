using System;
using System.Drawing;
using Walle.Components;
using Walle.UI;

namespace Walle.Scenario{
   /// <summary>
   /// Clase que encapsula el comportamiento de un tipo de celda. 
   /// </summary>
   [Serializable]
   public class Cell : ICloneable
   {

      private Item item;

      /// <summary>
      /// Nombre del tipo de celda.
      /// </summary>
      public string Name { get; set; }
      /// <summary>
      /// Temperatura de la celda.
      /// </summary>
      public int Temperature { get; set; }
      /// <summary>
      /// Imagen correspondiente a la celda.
      /// </summary>
      public Image Image { get; set; }
      /// <summary>
      /// Determina si la celda es un hueco o no.
      /// </summary>
      public bool IsHole { get; set; }
      /// <summary>
      /// Determina si la celda es liquida o no.
      /// </summary>
      public bool IsLiquid { get; set; }
      /// <summary>
      /// Determina si la celda esta llenada por algun objeto, y por tanto es pasable.
      /// </summary>
      public Item FilledBy { get; set; }
      /// <summary>
      /// Crea un nuevo tipo de celda.
      /// </summary>
      /// <param name="name">El nombre del tipo a crear.</param>
      /// <param name="temp">Su temperatura.</param>
      /// <param name="image">La imagen asociada al tipo.</param>
      /// <param name="isHole">Si es un hueco o no...</param>
      /// <param name="isLiquid">...y si es liquida o no.</param>
      public Cell(string name, int temp, Image image, bool isHole, bool isLiquid)
      {
         Name = name;
         Temperature = temp;
         Image = image;
         IsHole = isHole;
         IsLiquid = isLiquid;
      }
      /// <summary>
      /// Evento lanzado en caso de interaccion entre la celda y el objeto que se le asigna.
      /// </summary>
      public event InteractionEventHandler Interaction;
      /// <summary>
      /// Devuelve una copia de este tipo de celda.
      /// </summary>
      /// <returns></returns>
      public object Clone()
      {
         return MemberwiseClone();
      }
      /// <summary>
      /// Devuelve o asigna el objeto que hay en la celda. Esta propiedad es la encargada de determinar
      /// las posibles interacciones objeto-celda.
      /// </summary>
      public Item Item
      {
         get { return item; }
         set
         {
            Item itemToPlace = value;
            InteractionEventArgs e = null;

            e = new InteractionEventArgs(this, itemToPlace);

            if (itemToPlace != null)
            {
               if (this.IsHole)
               {
                  if (itemToPlace.CanFillHoles) // Se llena el hueco
                  {
                     this.IsHole = false;
                     this.FilledBy = itemToPlace;
                  }
               }

               if (e.EventDescription != InteractionEventArgs.NothingHappened){
                  Map_Interaction(e);
                  if (value is Robot)
                  {
                     this.item = null;
                     throw new RobotDeathException(string.Format("The robot has fell in a {0} cell!", this.Name));
                  }
               }
               else
                  item = itemToPlace;
            }
            else
            { // Se está vaciando la casilla
               item = null;
            }
         }
      }
      /// <summary>
      /// Lanza el evento Interaction.
      /// </summary>
      /// <param name="e">Mensaje de la interaccion.</param>
      private void Map_Interaction(InteractionEventArgs e)
      {
         InteractionEventHandler handler = this.Interaction;
         if (handler != null)
            handler(this, e);
      }
      /// <summary>
      /// Devuelve una representacion en string de esta celda y sus propiedades mas relevantes.
      /// </summary>
      /// <returns></returns>
      public override string ToString()
      {
         string toReturn = "";

         toReturn = string.Format("Field type: {0}\n Temperature: {1}\n Hole:{2}\n Liquid:{3}",Name,Temperature,IsHole,IsLiquid);

         return toReturn;
      }
   }

   /// <summary>
   /// Clase encargada de construir y transmitir el mensaje de interaccion celda-objeto.
   /// </summary>
   public class InteractionEventArgs : EventArgs
   {
      public const string NothingHappened = "Nothing happened";
      public string EventDescription { get; private set; }

      public InteractionEventArgs(Cell happenedAt, Item happenedTo)
      {
         if (happenedTo != null)
         {
            string who = happenedTo.Name;
            string action = "";
            string where = happenedAt.Name;

            if (happenedAt.IsHole)
            {
               if (happenedTo.CanFillHoles)
                  action = "fills";
               else action = "falls in";
            }
            else if (happenedAt.Temperature >= happenedTo.TempToMelt)
               action = "melts in";
            else if (happenedAt.IsLiquid && !happenedTo.Floats){
               action = "sinks in";
            }

            if (action != "")
               this.EventDescription = string.Format("{0} {1} {2}", who, action, where);
            else this.EventDescription = InteractionEventArgs.NothingHappened;
         }
         else
         {
            this.EventDescription = InteractionEventArgs.NothingHappened;
         }
      }
   }
}