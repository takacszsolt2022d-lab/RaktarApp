using System;
using System.Collections.Generic;
using System.Text;

namespace RaktarApp
{
    internal class TartosTermek:Termek
    {
        public int GaranciaEvek {  get; set; }
        public TartosTermek(string Cikkszam,int alapar,int garanciaEvek) : base(Cikkszam, alapar)
        {
            GaranciaEvek = garanciaEvek;
        }

        public override int ErtekSzamitas(int darabszam)
        {
            return (base.ErtekSzamitas (darabszam)+GaranciaEvek*500*darabszam);
        }

        public override string ToString()
        {
            return base.ToString() + $"| Garancia: {GaranciaEvek} év";
        }
    }
}
