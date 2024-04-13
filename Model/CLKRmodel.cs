using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba5_wpff.Model
{
    internal class CLKRmodel
    {

        public int Clicks { get; set; }
        public int Seconds { get; set; }

        public int ClicksPerMinute => Clicks * 60 / Seconds;

    }
}
