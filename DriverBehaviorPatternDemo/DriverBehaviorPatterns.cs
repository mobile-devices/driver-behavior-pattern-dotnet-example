using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverBehaviorPatternDemo
{
    public class DriverBehaviorPatterns
    {
        [JsonProperty("pattern")]
        public DriverBehaviorDefinition[] Pattern { get; set; }
    }
}
