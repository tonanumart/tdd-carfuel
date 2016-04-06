using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Model
{
    public class FillUp
    {

        public FillUp() { }

        public FillUp(int odoMeter, int lites)
        {
            OdoMeter = odoMeter;
            Lites = lites;
        }

        public int Id { get; set; }

        public decimal Lites { get; set; }
        public int OdoMeter { get; set; }
        public decimal? RateKmLite
        {
            get
            {
                if (NextFillUp == null)
                    return null;

                var diffOdometerValue = NextFillUp.OdoMeter - this.OdoMeter;
                return diffOdometerValue / NextFillUp.Lites;

            }
        }
        public FillUp NextFillUp { get; set; }
    }
}
