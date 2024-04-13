using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5_wpff.Model
{
    internal class RPCmodel
    {
        public enum Choice
        {
            Rock,
            Paper,
            Scissors,
            None

        }

        public Choice PlayerChoice { get; set; }
        public Choice ComputerChoice { get; set; }
    }
}
