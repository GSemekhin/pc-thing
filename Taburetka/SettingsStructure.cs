using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taburetka
{
    class SettingsStructure
    {
        [DefaultValue(50)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int Volume { get; set; }
        [DefaultValue(0)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int Opacity { get; set; }
        [DefaultValue(100)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int Latency { get; set; }
        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool OnlyHighlighted { get; set; }
        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool HideToTray { get; set; }
        [DefaultValue(true)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public bool LaunchMinimizied { get; set; }
        [DefaultValue(400)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int FormHeight { get; set; }
        [DefaultValue(650)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int FormWidth { get; set; }
        [DefaultValue(200)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int FormLocationX { get; set; }
        [DefaultValue(200)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int FormLocationY { get; set; }
        [DefaultValue(1)]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public int Theme { get; set; }
    }
}
