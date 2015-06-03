using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DriverBehaviorPatternDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Your dedicated token for the authentification (visible in your profile on the device manager panel "Authentication")
            string token = "TOKEN";

            // 
            string[] targetedAssets = new string[] { "IMEI" };
            
            // This is the ID of the App on the Device Manager for the Driver Behavior
            // This id can be found with the api describe here : http://manager.cloudconnect.io/api_doc/v2/versions/module_index.html
            int IdApp = 122;

            // EXAMPLE RAW JSON FOR DRIVER BEHAVIOR PATTERN
            //{  
            //   "version":"20140610",
            //   "patterns":{  
            //      "pattern":[  
            //         {  
            //            "-name":"Deceleration",
            //            "-id":"10",
            //            "-activation":"3",
            //            "thresholdKind":"1",
            //            "axisThresholding":"1",
            //            "thresholdingValue":"-300",
            //            "doFilterTime":"1",
            //            "filterTimeMin":"1600",
            //            "filterTimeMax":"10000"
            //         },
            //         {  
            //            "-name":"Acceleration",
            //            "-id":"11",
            //            "-activation":"3",
            //            "thresholdKind":"1",
            //            "axisThresholding":"1",
            //            "thresholdingValue":"300",
            //            "doFilterTime":"1",
            //            "filterTimeMin":"1600",
            //            "filterTimeMax":"10000"
            //         },
            //         {  
            //            "-name":"Turn Left",
            //            "-id":"12",
            //            "-activation":"3",
            //            "thresholdKind":"1",
            //            "axisThresholding":"2",
            //            "thresholdingValue":"-300",
            //            "doFilterTime":"1",
            //            "filterTimeMin":"1600",
            //            "filterTimeMax":"10000"
            //         },
            //         {  
            //            "-name":"Turn Right",
            //            "-id":"13",
            //            "-activation":"3",
            //            "thresholdKind":"1",
            //            "axisThresholding":"2",
            //            "thresholdingValue":"300",
            //            "doFilterTime":"1",
            //            "filterTimeMin":"1600",
            //            "filterTimeMax":"10000"
            //         }
            //      ]
            //   }
            //}

            DriverBehaviorPatternsDefinition patternsDefinition = new DriverBehaviorPatternsDefinition()
            {
                Version = "20140610",
                Patterns = new DriverBehaviorPatterns()
                {
                    Pattern = new DriverBehaviorDefinition[] 
                    { 
                        new DriverBehaviorDefinition()
                        {
                            Name = "Deceleration",
                            Id = "10",
                            Activation = "3",
                            ThresholdKind = "1",
                            AxisThresholding = "1",
                            ThresholdingValue = "-300",
                            DoFilterTime = "1",
                            FilterTimeMin = "1600",
                            FilterTimeMax = "10000"
                        },
                        new DriverBehaviorDefinition()
                        {
                            Name = "Acceleration",
                            Id = "11",
                            Activation = "3",
                            ThresholdKind = "1",
                            AxisThresholding = "1",
                            ThresholdingValue = "300",
                            DoFilterTime = "1",
                            FilterTimeMin = "1600",
                            FilterTimeMax = "10000"
                        },
                        new DriverBehaviorDefinition()
                        {
                            Name = "Turn Left",
                            Id = "12",
                            Activation = "3",
                            ThresholdKind = "1",
                            AxisThresholding = "2",
                            ThresholdingValue = "-300",
                            DoFilterTime = "1",
                            FilterTimeMin = "1600",
                            FilterTimeMax = "10000"
                        },
                        new DriverBehaviorDefinition()
                        {
                            Name = "Turn Right",
                            Id = "13",
                            Activation = "3",
                            ThresholdKind = "1",
                            AxisThresholding = "2",
                            ThresholdingValue = "300",
                            DoFilterTime = "1",
                            FilterTimeMin = "1600",
                            FilterTimeMax = "10000"
                        }
                    }
                }
            };

            // To not make mistake we build a Class based on the raw json. We instanciate this class and convert in Json with newtonJson.net.
            // In this case you will not have error in the json format because we have 2 json, one for your driver pattern message and another 
            // for the final message puts on the Api. If you do that manualy you must backslash all " in the message.
            Message message = new Message()
            {
                targeted_assets = targetedAssets,
                // this is a particular case for Driver Behavior module, we append a command on the json. (OVW to insert a new pattern - please change "version" to follow correctly your update) 
                messages = new string[] { "OVW " + JsonConvert.SerializeObject(patternsDefinition) }
            };

            string parameters = JsonConvert.SerializeObject(message);
            string result = string.Empty;

            HttpWebRequest httpWebRequest = HttpWebRequest.Create(String.Format("http://manager.cloudconnect.io/api/v2/modules/versions/{0}/messages", IdApp)) as HttpWebRequest;
            httpWebRequest.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(token + ":X"));

            httpWebRequest.Accept = "application/json";
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.CookieContainer = new CookieContainer();

            httpWebRequest.Method = "POST";

            using (StreamWriter sw = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                sw.Write(parameters);
            }

            HttpWebResponse httpResponse = httpWebRequest.GetResponse() as HttpWebResponse;

            using (StreamReader sr = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = sr.ReadToEnd();
                sr.Close();
            }

            Console.WriteLine(result);
            Console.WriteLine("");
            Console.WriteLine("PRESS ANY KEY TO CLOSE THE PROGRAM");
            Console.ReadLine();
        }
    }
}
