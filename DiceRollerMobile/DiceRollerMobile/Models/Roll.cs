using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceRollerMobile.Models
{
    public class Roll
    {
        public DateTime TimeStamp { get; set; }
        public List<Dice> Dices { get; set; }

        public Roll(List<Dice> dices)
        {
            TimeStamp = DateTime.Now;
            var random = new Random();
            foreach (var dice in dices)
            {
                dice.Val = random.Next(dice.MinVal, dice.MaxVal+1);
                dice.Parent = this;
            }
            Dices = dices;
        }

        public override string ToString()
        {
            string roll = TimeStamp.ToString();
            foreach (var dice in Dices)
            {
                roll += $", {dice.Val}";
            }
            return roll;
        }
    }
}
