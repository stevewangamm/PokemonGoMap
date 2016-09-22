using System.Collections.Generic;
using System.Drawing;

namespace Pgmasst.Main.Pginfos
{
    public class Sprite
    {
        public string Name;
        public string NameCn;
        public int Id;

        public Image BigIcon;
        public Image SmallIcon;

        public double Lat;
        public double Lng;
        public int DeSpawn;

        public Sprite()
        {
        }
    }
}