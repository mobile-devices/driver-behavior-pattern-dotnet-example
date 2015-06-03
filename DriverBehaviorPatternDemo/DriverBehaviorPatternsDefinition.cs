using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverBehaviorPatternDemo
{
    public class DriverBehaviorPatternsDefinition
    {
        [JsonProperty("version")]
        public string Version { get; set; }
        [JsonProperty("patterns")]
        public DriverBehaviorPatterns Patterns { get; set; }
    }
}
