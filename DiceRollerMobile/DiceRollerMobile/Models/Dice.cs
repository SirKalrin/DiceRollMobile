using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DiceRollerMobile.Models
{
    public class Dice
    {
        public int? Val { get; set; }
        public int MinVal { get; set; } = 1;
        public int MaxVal { get; set; } = 6;
        public int Sides { get; set; } = 6;
        public Roll Parent { get; set; }
    }
}
