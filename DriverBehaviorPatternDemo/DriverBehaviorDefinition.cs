using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverBehaviorPatternDemo
{
    //"-name":"Turn Right",
    //"-id":"13",
    //"-activation":"3",
    //"thresholdKind":"1",
    //"axisThresholding":"2",
    //"thresholdingValue":"300",
    //"doFilterTime":"1",
    //"filterTimeMin":"1600",
    //"filterTimeMax":"10000"
    public class DriverBehaviorDefinition
    {
        [JsonProperty("-name")]
        public string Name { get; set; }

        [JsonProperty("-id")]
        public string Id { get; set; }

        [JsonProperty("-activation")]
        public string Activation { get; set; }

        [JsonProperty("thresholdKind")]
        public string ThresholdKind { get; set; }

        [JsonProperty("axisThresholding")]
        public string AxisThresholding { get; set; }

        [JsonProperty("thresholdingValue")]
        public string ThresholdingValue { get; set; }

        [JsonProperty("doFilterTime")]
        public string DoFilterTime { get; set; }

        [JsonProperty("filterTimeMin")]
        public string FilterTimeMin { get; set; }

        [JsonProperty("filterTimeMax")]
        public string FilterTimeMax { get; set; }
    }

}
