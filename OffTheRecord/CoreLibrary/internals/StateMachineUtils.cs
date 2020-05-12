using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft;
using Newtonsoft.Json;

namespace OffTheRecord.CoreLibrary.internals
{
    public class StateMachineUtils
    {   
        public static StateMachineDefinition Parse(string jsonFile) {
            return JsonConvert.DeserializeObject<StateMachineDefinition>(File.ReadAllText(jsonFile));
        }
    }
}
