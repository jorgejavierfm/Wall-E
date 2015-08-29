using System;
using System.Drawing;
using Walle.Components.Sensors;
using Walle.Scenario;

namespace Walle.Components{
   public enum Direction { North = 1, East = 2, South = 3, West = 4 };
   
   /// <summary>
   /// Representa un robot.
   /// </summary>
   [Serializable]
   public class Robot : Item
   {
      // La imagen mostrada depende de la direccion a la que mira el robot.
      public Bitmap LookingUp;
      public Bitmap LookingLeft;
      public Bitmap LookingDown;
      public Bitmap LookingRight;

      // Este evento se lanza cada vez que el robot se mueve o gira.
      public event EventHandler MoveOrTurn;

      /// <summary>
      /// Lanza el evento MoveOrTurn.
      /// </summary>
      public void OnMove(){
         if (MoveOrTurn != null) MoveOrTurn.Invoke(this,EventArgs.Empty);
      }

      /// <summary>
      /// Devuelve la imagen del robot teniendo en cuenta la direccion en que mira.
      /// </summary>
      public override Bitmap Image
      {
         get
         {
            switch (this.Direction){
               case Direction.North:
                  return LookingUp;
               case Direction.South:
                  return LookingDown;
               case Direction.East:
                  return LookingRight;
               case Direction.West:
                  return LookingLeft;
               default:
                  return LookingDown;
            }
         }
         set
         {
         }
      }

      /// <summary>
      /// Devuelve o asigna el objeto que el robot esta cargando.
      /// </summary>
      public Item LoadedItem { get; set; }

      /// <summary>
      /// Propiedad del robot. Determina el peso maximo total que puede mover o cargar.
      /// </summary>
      public int Power { get; set; }

      /// <summary>
      /// Propiedad del robot. Determina el tamaño maximo de los objetos que puede cargar.
      /// </summary>
      public int Capacity { get; set; }

      /// <summary>
      /// Motor encargado de mover al robot.
      /// </summary>
      public Motor Motor { get; set; }

      /// <summary>
      /// Conjunto de sensores del robot.
      /// </summary>
      public RobotSensors Sensors { get; set; }

      /// <summary>
      /// Determina en que direccion mira el robot.
      /// </summary>
      public Direction Direction { get; set; }

      /// <summary>
      /// Inicializa un robot.
      /// </summary>
      /// <param name="name">Nombre del robot a crear.</param>
      /// <param name="weight">Peso del robot.</param>
      /// <param name="volume">Tamaño del robot.</param>
      /// <param name="power">Potencia del robot.</param>
      /// <param name="capacity">Capacidad del robot.</param>
      /// <param name="tempToMelt">Temperatura a la que el robot deja de funcionar.</param>
      /// <param name="image">Imagenes que representan al robot al mirar en cada direccion.</param>
      public Robot(string name, int weight, int volume, int power, int capacity, int tempToMelt, params Bitmap[] image)
            : base(name, image[2], weight, volume, tempToMelt, false,false, Color.Gray)
      {
         for (int i = 0; i < image.Length; i++)
         {
            image[i].MakeTransparent(image[i].GetPixel(0,0));
         }

         LookingUp = new Bitmap(image[0]);
         LookingRight =new Bitmap(image[1]);
         LookingDown = new Bitmap(image[2]);
         LookingLeft = new Bitmap(image[3]);

         Power = power;
         Capacity = capacity;
         Direction = Direction.South;
      }

      /// <summary>
      /// Gira el robot a una direccion determinada.
      /// </summary>
      /// <param name="to">La "direccion determinada".</param>
      public void Turn(Direction to)
      {
         Direction = to;
         OnMove();
      }

      /// <summary>
      /// "Posiciona" al robot en un mapa (inicializa sus sensores, etc.).
      /// </summary>
      /// <param name="map">El mapa donde se va a colocar el robot.</param>
      /// <param name="where">Donde exactamente se va a ubicar.</param>
      public void PlaceInMap(Map map, Point where)
      {
         if (map.HasRobot){
            map[where.X, where.Y].Item = this;
            if (map[where.X, where.Y].Item != this || (map.RobotLocation.X == where.X && map.RobotLocation.Y == where.Y))
               return;
            else{
               map[map.RobotLocation.X, map.RobotLocation.Y].Item = null;
               map.RobotLocation = new Point(where.X,where.Y);
            }
         }
         else{
            map[where.X, where.Y].Item = this;
            map.RobotLocation = new Point(where.X, where.Y);
         }

         this.Motor = new Motor(map,this);
         this.Sensors = new Sensors.RobotSensors(map);
      }

      /// <summary>
      /// Devuelve una representacion en string de las propiedades principales del robot.
      /// </summary>
      public override string ToString()
      {
         string result = "";

         result += string.Format("Name: {0}\n Power: {1}\n Capacity:{2}", Name, Power, Capacity);

         return result;
      }
   }
}