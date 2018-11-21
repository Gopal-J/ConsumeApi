using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace ConsumeApi.Models
{

    /// <summary>
    /// Exchange rate result display model
    /// </summary>
    public class ExRateOutPut
    {
        [JsonProperty("minimum")]
        public decimal Minimum { get; set; }

        [JsonProperty("maximum")]
        public decimal Maximum { get; set; }

        [JsonProperty("average")]
        public decimal Average { get; set; }

        [JsonProperty("basecurrency")]
        public string BaseCurrency { get; set; }

        [JsonProperty("targetcurrency")]
        public string TargetCurrency { get; set; }

    }

    /// <summary>
    /// Exchange rate time series data model returned from exchangeratesapi.io
    /// </summary>
    public class ExchangeRate
    {
        [JsonProperty("end_at")]
        public string end_at { get; set; }

        [JsonProperty("start_at")]
        public string start_at { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, Dictionary<string, decimal>> Rate { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }
    }

}
