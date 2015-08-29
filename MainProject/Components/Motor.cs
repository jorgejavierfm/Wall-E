using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Walle.Scenario;

namespace Walle.Components{
   /// <summary>
   /// Clase encargada de mover al robot que la contiene.
   /// </summary>
   [Serializable]
   public class Motor
   {
      public readonly Dictionary<Direction, Point> directionDict = new Dictionary<Direction, Point>();

      private Robot ManagedRobot { get; set; }

      // Eventos lanzados en caso de que el robot intente infructuosamente de realizar alguna accion.
      public event EventHandler UnableToMove;
      public event EventHandler UnableToLoad;
      public event EventHandler UnableToUnload;

      public Motor(Map map, Robot managedRobot)
      {
         Map = map;
         ManagedRobot = managedRobot;
         managedRobot.MoveOrTurn += map.OnSomethingMoves;

         directionDict.Add(Direction.North, new Point(-1, 0));
         directionDict.Add(Direction.East, new Point(0, 1));
         directionDict.Add(Direction.West, new Point(0, -1));
         directionDict.Add(Direction.South, new Point(1, 0));
      }

      private Map Map { get; set; }

      /// <summary>
      /// Mueve el robot hacia adelante.
      /// </summary>
      public void MoveForward()
      {
         Direction direction = ManagedRobot.Direction;

         Point currentPos = Map.RobotLocation;
         Point moveVector = directionDict[direction];

         Point newPos = new Point(currentPos.X + moveVector.X, currentPos.Y + moveVector.Y);

         if (!Map.PosInRange(newPos))
         {
            if (UnableToMove != null) UnableToMove(this, EventArgs.Empty);
            return;
         }
         else if (Map[newPos.X, newPos.Y].Item != null)
         {
            bool couldPush = PushItem();
            if (couldPush)
            {
               Map[currentPos.X, currentPos.Y].Item = null;
               Map[newPos.X, newPos.Y].Item = ManagedRobot;
               Map.RobotLocation = newPos;
            }
            else
            {
               if (UnableToMove != null) UnableToMove(this, EventArgs.Empty);
            }
         }
         else
         {
            Map[currentPos.X, currentPos.Y].Item = null;
            Map[newPos.X, newPos.Y].Item = ManagedRobot;
            Map.RobotLocation = newPos;
         }

      }

      /// <summary>
      /// Gira el robot hacia la izquierda.
      /// </summary>
      public void TurnLeft()
      {
         switch (ManagedRobot.Direction)
         {
            case Direction.North:
               ManagedRobot.Turn(Direction.West);
               break;
            case Direction.South:
               ManagedRobot.Turn(Direction.East);
               break;
            case Direction.East:
               ManagedRobot.Turn(Direction.North);
               break;
            case Direction.West:
               ManagedRobot.Turn(Direction.South);
               break;
         }
      }

      /// <summary>
      /// Gira el robot hacia la derecha.
      /// </summary>
      public void TurnRight()
      {
         switch (ManagedRobot.Direction)
         {
            case Direction.North:
               ManagedRobot.Turn(Direction.East);
               break;
            case Direction.South:
               ManagedRobot.Turn(Direction.West);
               break;
            case Direction.East:
               ManagedRobot.Turn(Direction.South);
               break;
            case Direction.West:
               ManagedRobot.Turn(Direction.North);
               break;
         }
      }

      /// <summary>
      /// Carga un objeto, si existe alguno en la celda siguiente. 
      /// Ocupa la posicion del objeto, a no ser que sea un hueco.
      /// </summary>
      public void LoadItem()
      {
         if (ManagedRobot.LoadedItem == null)
         {

            Direction direction = ManagedRobot.Direction;

            Point currentPos = Map.RobotLocation;
            Point moveVector = directionDict[direction];

            Point posInFront = new Point(currentPos.X + moveVector.X, currentPos.Y + moveVector.Y);

            if (Map.PosInRange(posInFront))
            {
               Cell cell = Map[posInFront];


               if (cell.Item != null)
               {
                  // Hay un objeto en la celda enfrente?
                  if (ManagedRobot.Power >= cell.Item.Weight && ManagedRobot.Capacity >= cell.Item.Volume)
                  {
                     // Puedo cargar el objeto?
                     ManagedRobot.LoadedItem = cell.Item; // Carga el objeto
                     cell.Item = null; // Quitalo de donde estaba
                     this.MoveForward();
                  }
                  else if (UnableToLoad != null)
                     UnableToLoad(ManagedRobot, EventArgs.Empty); // Pesa demasiado o es muy grande
               }
                  //TODO VERIFICAR SI SE SUPONE QUE EL ROBOT RECOJA OBJETOS DE HUECOS.
               else if (cell.FilledBy != null)
               {
                  // Si es un hueco, hay algo? Entonces...
                  if (ManagedRobot.Power >= cell.FilledBy.Weight && ManagedRobot.Capacity >= cell.FilledBy.Volume)
                  {
                     // Puedo cargar el objeto?
                     ManagedRobot.LoadedItem = cell.FilledBy; // Carga el objeto
                     cell.FilledBy = null; // Quitalo de donde estaba
                     cell.IsHole = true;
                  }
                  else if (UnableToLoad != null)
                     UnableToLoad(ManagedRobot, EventArgs.Empty); // Pesa demasiado o es muy grande
               }

               else
               {
                  // No se puede cargar algo que no existe
                  if (UnableToLoad != null){
                     UnableToLoad(ManagedRobot, EventArgs.Empty);
                     return;
                  }
               }
            }
         }
         else // Ya hay un objeto cargado
         {
            if (UnableToLoad != null) UnableToLoad(ManagedRobot, EventArgs.Empty);
         } 
      }

      /// <summary>
      /// Intenta descargar un objeto en la celda siguiente.
      /// </summary>
      public void UnloadItem()
      {
         if (ManagedRobot.LoadedItem != null)
         {
            Direction direction = ManagedRobot.Direction;

            Point currentPos = Map.RobotLocation;
            Point moveVector = directionDict[direction];

            Point posInFront = new Point(currentPos.X + moveVector.X, currentPos.Y + moveVector.Y);

            if (Map.PosInRange(posInFront) && Map[posInFront].Item == null)
            {
               Map[posInFront].Item = ManagedRobot.LoadedItem;
               ManagedRobot.LoadedItem = null;
            }
            else if (UnableToUnload != null) UnableToUnload.Invoke(ManagedRobot, EventArgs.Empty); // Hay algo en el lugar
         }
         else
         {
            if (UnableToUnload != null) UnableToUnload.Invoke(ManagedRobot, EventArgs.Empty); // No se puede soltar lo que no se tiene...
         }
      }

      /// <summary>
      /// Empuja el objeto que esta enfrente. Este metodo se llama automaticamente en MoveForward.
      /// </summary>
      /// <returns></returns>
      private bool PushItem()
      {

         Direction direction = ManagedRobot.Direction;
         Point moveVector = directionDict[direction];

         Point currentPos = Map.RobotLocation;
         Point newPos = new Point(currentPos.X + moveVector.X, currentPos.Y + moveVector.Y);

         Stack<Item> itemsToMove = new Stack<Item>();
         int totalPowerNeeded = 0;

         while (Map.PosInRange(newPos) && this.Map[newPos.X, newPos.Y].Item != null)
         {
            itemsToMove.Push(Map[newPos.X, newPos.Y].Item);
            totalPowerNeeded += Map[newPos.X, newPos.Y].Item.Weight;
            newPos = new Point(newPos.X + moveVector.X, newPos.Y + moveVector.Y);
         }

         if (!Map.PosInRange(newPos) || totalPowerNeeded > ManagedRobot.Power) return false;

         while (itemsToMove.Count > 0)
         {
            Map[newPos.X, newPos.Y].Item = null;
            Map[newPos.X, newPos.Y].Item = itemsToMove.Pop();
            newPos = new Point(newPos.X - moveVector.X, newPos.Y - moveVector.Y);
         }
         return true;
      }

      /// <summary>
      /// Hace retroceder al robot.
      /// </summary>
      public void MoveBackward()
      {
         Direction direction = ManagedRobot.Direction;

         Point currentPos = Map.RobotLocation;
         Point moveVector = directionDict[direction];

         Point newPos = new Point(currentPos.X - moveVector.X, currentPos.Y - moveVector.Y);

         if (!Map.PosInRange(newPos) || Map[newPos.X, newPos.Y].Item != null)
         {
            if (UnableToMove != null) UnableToMove(this, EventArgs.Empty);
            return;
         }

         Map[currentPos.X, currentPos.Y].Item = null;
         Map[newPos.X, newPos.Y].Item = ManagedRobot;
         Map.RobotLocation = newPos;

      }
   }
}