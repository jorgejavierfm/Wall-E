using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Walle.Scenario;

namespace Walle.Components.Sensors
{
   [Serializable]
   public class GPS : ISensor
   {
      public readonly Dictionary<Direction, Point> directionDict = new Dictionary<Direction, Point>();

      public GPS(Map map)
      {
         this.Map = map;

         directionDict.Add(Components.Direction.North, new Point(-1, 0));
         directionDict.Add(Components.Direction.East, new Point(0, 1));
         directionDict.Add(Components.Direction.West, new Point(0, -1));
         directionDict.Add(Components.Direction.South, new Point(1, 0));
      }

      /// <summary>
      /// Devuelve la fila en la que se encuentra el robot. 
      /// </summary>
      public int X
      {
         get
         {
            return Map.RobotLocation.X;
         }
      }

      /// <summary>
      /// Devuelve la columna en la que se encuentra el robot.
      /// </summary>
      public int Y
      {
         get
         {
            return Map.RobotLocation.Y;
         }
      }

      /// <summary>
      /// Puede utilizarse para obtener la posicion enfrente del robot.
      /// </summary>
      public int MoveVectorX
      {
         get
         {
            return directionDict[Map.Robot.Direction].X;
         }
      }

      /// <summary>
      /// Puede utilizarse para obtener la posicion enfrente del robot.
      /// </summary>
      public int MoveVectorY
      {
         get
         {
            return directionDict[Map.Robot.Direction].Y;
         }
      }

      /// <summary>
      /// Devuelve 1,2,3 y 4 respectivamente para cada una de las direcciones posibles en sentido horario.
      /// </summary>
      public int Direction
      {
         get
         {
            return (int)Map.Robot.Direction;
         }
      }

      #region ISensor Members

      public Map Map
      { get; set; }

      #endregion

   }
}