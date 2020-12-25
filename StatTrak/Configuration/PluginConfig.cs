using StatTrak.Data;
using System.Collections.Generic;
using IPA.Config.Stores.Attributes;
using IPA.Config.Stores.Converters;

namespace StatTrak.Configuration
{
    public class PluginConfig
    {
        public static PluginConfig Instance { get; set; }

        [UseConverter(typeof(ListConverter<StatTrakData>))]
        public virtual List<StatTrakData> data { get; set; } = new List<StatTrakData>();
    }
}