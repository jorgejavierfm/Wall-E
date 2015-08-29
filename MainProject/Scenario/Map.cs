using System;
using System.Collections.Generic;
using System.Drawing;

namespace Walle.Scenario{
   /// <summary>
   /// Clase que encapsula un mapa.
   /// </summary>
   [Serializable]
   public class Map
   {
      Cell[,] map;

      //Paletas asociadas al mapa.
      public List<Cell> FieldPalette = new List<Cell>();
      public List<Item> ItemPalette = new List<Item>();

      private Point _RobotLocation = new Point(-1, -1);
      public Point RobotLocation
      {
         get { return this._RobotLocation; }
         set
         {
            if (this.Movement != null) this.Movement.Invoke(this,EventArgs.Empty);
            this._RobotLocation = value;
         }
      }

      public bool HasRobot
      {
         get
         {
            return PosInRange(RobotLocation);
         }
      }

      public Walle.Components.Robot Robot{
         get{
            if (PosInRange(RobotLocation)){
               return (Walle.Components.Robot)map[RobotLocation.X,RobotLocation.Y].Item;
            } else return null;
         }
      }

      /// <summary>
      /// Devuelve un valor booleano que indica si la posicion dada esta dentro del mapa.
      /// </summary>
      /// <param name="pos">Posicion a examinar.</param>
      /// <returns>True si la posicion esta en rango, False de otra manera.</returns>
      public bool PosInRange(Point pos)
      {
         return (pos.Y>= 0 && pos.Y < this.GetLength(1) && pos.X >= 0 && pos.X < this.GetLength(0));
      }

      /// <summary>
      /// Este evento se lanza cuando hay una interaccion terreno-objeto.
      /// </summary>
      public event InteractionEventHandler Interaction;

      public Map(int dimX, int dimY, Cell defaultCell)
      {
         map = new Cell[dimX, dimY];
         for (int i = 0; i < dimX; i++)
         {
            for (int j = 0; j < dimY; j++)
            {
               map[i, j] = (Cell)defaultCell.Clone();
            }
         }
      }

      public Cell this[int i, int j]
      {
         get { return map[i, j]; }
         set
         {
            if (value != null)
            {
               map[i, j] = value;
               map[i, j].Interaction += Map_Interaction; // Hace que las celdas avisen al mapa si ocurre algo en ellas.
            }
            else throw new Exception("Error asigning null cell type to grid.");
         }
      }

      public Cell this[Point p]
      {
         get { return map[p.X, p.Y]; }
         set
         {
            if (value != null)
            {
               map[p.X, p.Y] = value;
               map[p.X, p.Y].Interaction += Map_Interaction; // Hace que las celdas avisen al mapa si ocurre algo en ellas.
            }
            else throw new Exception("Error asigning null cell type to grid.");
         }
      }

      void Map_Interaction(object sender, InteractionEventArgs e)
      {
         if (Interaction != null)
            Interaction(this, e);
      }

      /// <summary>
      /// Lanza el evento Movement.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      public void OnSomethingMoves(object sender, EventArgs e)
      {
         if (Movement != null){
            Movement(sender, e);
         }
      }

      public int GetLength(int dim)
      {
         return map.GetLength(dim);
      }

      /// <summary>
      /// Avisa cuando algo se mueve en el mapa.
      /// </summary>
      public event EventHandler Movement;
   }
}