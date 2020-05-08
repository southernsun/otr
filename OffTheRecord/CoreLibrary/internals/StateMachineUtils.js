using System;
using System.Collections.Generic;
using System.Text;

using Newtonsoft;


namespace OffTheRecord.CoreLibrary.internals
{
    public class StateMachineUtils
    {   
        public StateMachineDefinition Parse(string jsonFile) {
            return JsonConvert.DeserializeObject<StateMachineDefintion>(File.ReadAllText(jsonFile));
        }
    }
}
