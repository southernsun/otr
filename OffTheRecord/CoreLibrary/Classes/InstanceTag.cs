using System;
using System.Collections.Generic;
using System.Text;

namespace OffTheRecord.CoreLibrary.Classes
{
    public class InstanceTag 
    {
        ////private uint instanceTag; // 4 byte unsigned int to hold instance tag.

        //// Notes for future reference: https://stackoverflow.com/questions/17080112/generate-random-uint

        public static bool IsValid(uint instanceTag)
        {
            // hex = 100 is 256 in decimal;
            if (instanceTag > 0 && instanceTag < 256)
            {
                return false;
            }

            return true;
        }
    }
}
