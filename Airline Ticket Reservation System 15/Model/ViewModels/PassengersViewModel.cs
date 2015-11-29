using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public class PassengersViewModel
    {
        public int Adults { get; set; }
        public int Childrens { get; set; }
        public int Seniors { get; set; }
        public int InfantsInSeat { get; set; }
        public int InfantsInLap { get; set; }
    }
}
