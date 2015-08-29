using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Walle.Scenario;

namespace Walle.Components.Sensors
{
   /// <summary>
   /// Permite al robot reconocer varias de las propiedades del terreno.
   /// </summary>
   [Serializable]
   public class Webcam : ISensor
   {
      public Webcam(Map map)
      {
         this.Map = map;
      }

      /// <summary>
      /// Devuelve un entero que representa el color del objeto mas cercano visible. Devuelve 0 si no hay ninguno objeto a la vista.
      /// </summary>
      public int NearestItemColor
      {
         get
         {
            Robot rob = (Robot)Map[Map.RobotLocation].Item;

            //Color c = Color.FromArgb()

            Direction direction = rob.Direction;
            Point moveVector = rob.Motor.directionDict[direction];
            Point nearestItemPos = new Point(Map.RobotLocation.X + moveVector.X, Map.RobotLocation.Y + moveVector.Y);

            while (Map.PosInRange(nearestItemPos) && Map[nearestItemPos].Item == null)
               nearestItemPos = new Point(nearestItemPos.X + moveVector.X, nearestItemPos.Y + moveVector.Y);

            if (!Map.PosInRange(nearestItemPos))
            {
               return 0;
            }
            else if (Map[nearestItemPos].Item != null)
            {
               return Map[nearestItemPos].Item.Color.ToArgb();
            }
            else return 0;
         }
      }
      
      /// <summary>
      /// Devuelve un entero que representa el tamaño del objeto mas cercano visible. Devuelve 0 si no hay ninguno objeto a la vista.
      /// </summary>
      public int NearestItemSize
      {
         get
         {
            Robot rob = (Robot)Map[Map.RobotLocation].Item;

            Direction direction = rob.Direction;
            Point moveVector = rob.Motor.directionDict[direction];
            Point nearestItemPos = new Point(Map.RobotLocation.X + moveVector.X, Map.RobotLocation.Y + moveVector.Y);

            while (Map.PosInRange(nearestItemPos) && Map[nearestItemPos].Item == null)
               nearestItemPos = new Point(nearestItemPos.X + moveVector.X, nearestItemPos.Y + moveVector.Y);

            if (!Map.PosInRange(nearestItemPos))
            {
               return 0;
            }
            else
            {
               return Map[nearestItemPos].Item.Volume;
            }
         }
      }

      /// <summary>
      /// Devuelve un entero que representa el color del objeto cargado. Devuelve 0 si el robot no tiene ningun objeto cargado.
      /// </summary>
      public int LoadedItemColor
      {
         get
         {
            if (Map.Robot.LoadedItem != null)
               return Map.Robot.LoadedItem.Color.ToArgb();
            return 0;
            
         }
      }

      /// <summary>
      /// Devuelve un entero que representa el tamaño del objeto que el robot tiene cargado. Si no tiene ningun objeto, devuelve 0.
      /// </summary>
      public int LoadedItemSize
      {
         get
         {
            if (Map.Robot.LoadedItem != null)
               return Map.Robot.LoadedItem.Volume;
            return 0;
         }
      }

      /// <summary>
      /// Devuelve un valor booleano que determina si la proxima celda es un hueco.
      /// </summary>
      public bool NextIsHole
      {
         get
         {
            Robot rob = Map[Map.RobotLocation].Item as Robot;

            Direction direction = rob.Direction;
            Point moveVector = rob.Motor.directionDict[direction];
            Point posInFront = new Point(Map.RobotLocation.X + moveVector.X, Map.RobotLocation.Y + moveVector.Y);

            if (Map.PosInRange(posInFront))
               return Map[posInFront].IsHole;
            else return false;
         }
      }

      /// <summary>
      /// Devuelve un valor booleano que determina si la proxima celda es liquida.
      /// </summary>
      public bool NextIsLiquid
      {
         get
         {
            Robot rob = Map[Map.RobotLocation].Item as Robot;

            Direction direction = rob.Direction;
            Point moveVector = rob.Motor.directionDict[direction];
            Point posInFront = new Point(Map.RobotLocation.X + moveVector.X, Map.RobotLocation.Y + moveVector.Y);

            if (Map.PosInRange(posInFront))
               return Map[posInFront].IsLiquid;
            else return false;
         }
      }

      #region ISensor Members

      public Map Map
      {
         get;
         set;
      }

      #endregion
   }
}