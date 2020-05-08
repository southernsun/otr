using System;
using System.Collections.Generic;
using System.Text;

namespace OffTheRecord.CoreLibrary.internals
{
    public class Transition
    {
        public string from { get; set; }
        public string to { get; set; }

        public string eventName { get; set; }

        public List<string> actions { get; set; }
    }
}
