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

        public int Iv;

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}, NameCn: {2}, Lat: {3}, Lng: {4}, Despawn: {5}, Iv: {6}",
                this.Id,
                this.Name,
                this.NameCn,
                this.Lat,
                this.Lng,
                this.DeSpawn,
                this.Iv);
        }
    }
}