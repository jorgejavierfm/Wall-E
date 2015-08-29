using System;
using System.Drawing;
using Walle.Scenario;

namespace Walle.Components.Sensors
{
   /// <summary>
   /// Este sensor se utiliza para pesar objetos.
   /// </summary>
   [Serializable]
   public class Scale : ISensor
   {
      public Scale(Map map)
      {
         this.Map = map;
      }
      
      /// <summary>
      /// Devuelve el peso del objeto cargado. Devuelve -1 si no hay ningun objeto cargado.
      /// </summary>
      public int LoadedItemWeight{
         get{
            if (this.Map.Robot.LoadedItem != null){
               return Map.Robot.LoadedItem.Weight;
            }
            return -1;
         }
      }

      /// <summary>
      /// Devuelve el peso del objeto enfrente del robot. Devuelve -1 si no hay ninguno.
      /// </summary>
      public int ItemInFrontWeight
      {
         get
         {
            Robot robot = Map.Robot;

               Direction direction = robot.Direction;
               Point moveVector = robot.Motor.directionDict[direction];
               Point posInFront = new Point(Map.RobotLocation.X + moveVector.X, Map.RobotLocation.Y + moveVector.Y);

               if (Map.PosInRange(posInFront) && Map[posInFront].Item != null)
                  return Map[posInFront].Item.Weight;
               else return -1;
         }
      }

      #region ISensor Members

      public Map Map
      { get; set; }

      #endregion
   }
}
