using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ContosoUniversity.Models
{
    public class Weather
    {
        [DisplayName("温度")]
        public string Temperature { get; set; }
        [DisplayName("城市")]
        public string City { get; set; }
        //[DisplayName("天气")]
        //public string WeatherInfo { get; set; }
        [DisplayName("湿度")]
        public string Humidity { get; set; }
        public string Wind { get; set; }
        public string Dressing_advice { get; set; }

    }
}