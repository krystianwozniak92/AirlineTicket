using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModels
{
    public enum PassengerType
    {
        Adult,
        Child,
        InfantInSeat,
        InfantInLap,
        Senior
    };

    public class PassengersViewModel
    {
        public PassengerType PassengerType { get; set; }
        public int Count { get; set; }
    }
}
