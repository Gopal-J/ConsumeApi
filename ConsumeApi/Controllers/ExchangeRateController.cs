using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConsumeApi.Models;
using Newtonsoft.Json;
using ConsumeApi.BLL;

namespace ConsumeApi.Controllers
{
    public class ExchangeRateController : Controller
    {
        /// <summary>
        /// Calls the API with predefined input values.
        /// To change the value string values should be amended.
        /// 
        /// The action method to be changed to accept the input values from User
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            string strObject1 = "";

            //Values below to be changed to change the input parameters to the API call
            //The section to be changed to accept the input values from User
            string curBase = "USD";
            string curTarget = "INR";
            string startDt = "2018-09-01";
            string endDt = "2018-09-30";

            ExchangeRate exRmodel = null;
            ExchangeRateBL exRBL = new ExchangeRateBL();
                //Below is to test or develop in the absence of internet or api service.
                //strObject1 = "{\"end_at\":\"2018-11-10\",\"start_at\":\"2018-11-01\",\"rates\":{\"2018-11-08\":{\"INR\":72.4085259104},\"2018-11-01\":{\"INR\":73.4486087949},\"2018-11-05\":{\"INR\":73.0800351803},\"2018-11-02\":{\"INR\":72.4432863274},\"2018-11-09\":{\"INR\":72.5048475234},\"2018-11-06\":{\"INR\":72.9598354918},\"2018-11-07\":{\"INR\":72.499347088}},\"base\":\"USD\"}";

                //Call Api passing necessary parameters 
                strObject1 = exRBL.CallMyApi(startDt, endDt, curBase, curTarget);
                exRmodel = JsonConvert.DeserializeObject<ExchangeRate>(strObject1);

                //This returns the class(with ave value etc.) expected processing the JSON returned by API
                ExRateOutPut exRateResult = exRBL.ParseExRateJson(strObject1, curBase, curTarget);
                exRBL = null;
                return View(exRateResult);
        } 
    }
}