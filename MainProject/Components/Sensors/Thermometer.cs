using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Walle.Scenario;

namespace Walle.Components.Sensors
{
   /// <summary>
   /// Este sensor puede utilizarse para medir temperaturas.
   /// </summary>
   [Serializable]
   public class Thermometer : ISensor
   {
      public Thermometer(Map map)
      {
         this.Map = map;
      }

      /// <summary>
      /// Devuelve la temperatura de la celda siguiente. Si la posicion siguiente no esta en el mapa, devuelve 0.
      /// </summary>
      public int NextCellTemp
      {
         get
         {
            Robot rob = Map[Map.RobotLocation].Item as Robot;

            if (rob != null)
            {
               Direction direction = rob.Direction;
               Point moveVector = rob.Motor.directionDict[direction];
               Point posInFront = new Point(Map.RobotLocation.X + moveVector.X, Map.RobotLocation.Y + moveVector.Y);

               if (Map.PosInRange(posInFront))
               {
                  return Map[posInFront].Temperature;
               }
               else return 0;

            }
            else throw new Exception("This really shouldn't happen...");

         }
      }

      /// <summary>
      /// Devuelve un valor booleano que indica si la siguiente celda representa un peligro en cuanto a temperatura para el robot.
      /// </summary>
      public bool NextCellIsTooHot
      {
         get { return (Map[Map.RobotLocation].Item).TempToMelt <= NextCellTemp; }
      }

      #region ISensor Members

      public Map Map { get; set; }

      #endregion
   }
}