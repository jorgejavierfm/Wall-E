using System;
using System.Drawing;

namespace Walle.Scenario{
   /// <summary>
   /// Delegado que representa la signatura de una interaccion terreno-objeto.
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>
   public delegate void InteractionEventHandler(object sender, InteractionEventArgs e);

   /// <summary>
   /// Encapsula el funcionamiento de un objeto.
   /// </summary>
   [Serializable]
   public class Item : ICloneable
   {
      // Propiedades de los objetos.
      public string Name { get; set; }
      public virtual Bitmap Image { get; set; }
      public int Weight { get; set; }
      public int Volume { get; set; }
      public int TempToMelt { get; set; }
      public bool CanFillHoles { get; set; }
      public Color Color { get; set; }
      public bool Floats { get; set; }


      public Item(string name, Image bmp, int weight, int volume, int tempToMelt, bool fillsHoles, bool floats, Color color)
      {
         Name = name;
         Image = new Bitmap(bmp);
         if (Image != null){
            Image.MakeTransparent(Image.GetPixel(0, 0));   
         }
         Floats = floats;
         Weight = weight;
         Volume = volume;
         TempToMelt = tempToMelt;
         CanFillHoles = fillsHoles;
         Color = color;
      }

      public object Clone()
      {
         return MemberwiseClone();
      }

      public override string ToString()
      {
         string result = "";

         result += string.Format("Item name: {0}\n Floats: {1}\n Weight: {2}\n Volume: {3}\n Can fill holes: {4}\n Color: {5}\n Melts at: {6}", Name, Floats, Weight, Volume, CanFillHoles, Color.Name,TempToMelt);

         return result;
      }
   }
}