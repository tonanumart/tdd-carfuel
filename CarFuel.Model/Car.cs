using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFuel.Model
{
    public class Car
    {
        public Car()
        {
            FillUps = new HashSet<FillUp>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual ICollection<FillUp> FillUps { get; set; }
        public Guid OwnerId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public FillUp AddFillUp(int odoMeter, int lites)
        {
            var fillUp = new FillUp(odoMeter, lites);

            var lastFillUp = this.FillUps.SingleOrDefault(item => item.NextFillUp == null);
            //var lastFillUp = this.FillUps.LastOrDefault();
            if (lastFillUp != null)
            {
                lastFillUp.NextFillUp = fillUp;
            }
            this.FillUps.Add(fillUp);
            return fillUp;
        }

        public decimal? AvgRateFillUp
        {
            get
            {
                if (FillUps.Count > 1)
                {
                    var firstFill = this.FillUps.FirstOrDefault();
                    var lastFill = this.FillUps.LastOrDefault();
                    decimal OdoDiff = lastFill.OdoMeter - firstFill.OdoMeter;
                    var totalLites = this.FillUps.Sum(item => item.Lites) - firstFill.Lites;
                    return Math.Round(OdoDiff / totalLites, 2, MidpointRounding.AwayFromZero);
                }
                return null;
            }
        }

    }
}
