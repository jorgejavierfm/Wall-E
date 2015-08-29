using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Walle.Scenario;

namespace Walle.Components.Sensors
{
   /// <summary>
   /// Este sensor mide la distancia al objeto mas cercano.
   /// </summary>
   [Serializable]
   public class Ultrasonic : ISensor
   {
      public Ultrasonic(Map map)
      {
         this.Map = map;
      }

      /// <summary>
      /// Devuelve la distancia al objeto mas cercano.
      /// </summary>
      public int Distance
      {
         get
         {
            Robot rob = Map.Robot;

            Direction direction = rob.Direction;
            Point moveVector = rob.Motor.directionDict[direction];
            Point posInFront = new Point(Map.RobotLocation.X + moveVector.X, Map.RobotLocation.Y + moveVector.Y);

            int count = 0;
            while (Map.PosInRange(posInFront) && Map[posInFront].Item == null)
            {
               posInFront = new Point(posInFront.X + moveVector.X, posInFront.Y + moveVector.Y);
               count++;
            }
            return count;
         }
      }

      #region ISensor Members

      public Map Map { get; set; }

      #endregion
   }
}