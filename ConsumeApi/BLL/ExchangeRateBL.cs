using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsumeApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace ConsumeApi.BLL
{
    public class ExchangeRateBL
    {

        public ExRateOutPut ParseExRateJson(string strIn, string curbase, string curtarget)
        {
            int count = 0;
            decimal sumRate = 0;
            decimal aveRate = 0;
            dynamic rate1 = null;
            dynamic value1 = null;
            dynamic min1 = 0;
            dynamic max1 = 0;

            dynamic data = JObject.Parse(strIn);
            string str1 = data.start_at.ToString();
            dynamic data1 = data.rates;

            foreach (var kvp in data1)
            {
                rate1 = kvp.Value;
                foreach (var key in rate1)
                {
                    value1 = key.Value;
                    if (count == 0)
                    {
                        min1 = value1;
                        max1 = value1;
                    }

                    sumRate += (decimal)value1;
                    min1 = value1 < min1 ? value1 : min1;
                    max1 = value1 > max1 ? value1 : max1;
                    count++;
                }

            }
            aveRate = sumRate / count;
            ExRateOutPut ExRateOP1 = new ExRateOutPut();
            ExRateOP1.Minimum = min1;
            ExRateOP1.Maximum = max1;
            ExRateOP1.Average = aveRate;
            ExRateOP1.BaseCurrency = curbase;
            ExRateOP1.TargetCurrency = curtarget;

            return ExRateOP1;
        }



        public string CallMyApi(string stDt, string enDt, string curBase, string curTgt)
        {
            string url1 = "https://api.exchangeratesapi.io/";
            string param1 = "history?start_at=" + stDt + "&end_at=" + enDt + "&base=" + curBase + "&symbols=" + curTgt;
            string strObject = "";


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url1);

                //GetAsync to send a GET request   
                var responseTask = client.GetAsync(param1);
                responseTask.Wait();

                //To store result of web api response.   
                var result = responseTask.Result;

                //If success received   
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();

                    readTask.Wait();
                    strObject = readTask.Result;

                }
                else
                {
                    //Error response received   
                    strObject = null;
                    throw new Exception(result.ReasonPhrase);
                }
            }

            return strObject;
        }


    }
}
