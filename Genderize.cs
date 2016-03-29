using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Genderize
{
    public enum Gender
    {
        Male,
        Female
    }
    public class GenderizeResponse
    {
        public string name { get; set; }
        public Gender gender { get; set; }
        public double probability { get; set; }
        public int count { get; set; }

        public override string ToString() { return string.Format("{0} {1} {2} {3}", name, gender, probability, count); }

    }

    public static class Genderizer
    {
      
        private static readonly string API_PREFORMATTED = "https://api.genderize.io/?name={0}";

        public static GenderizeResponse Genderize(string name)
        {
            var requestURL = String.Format(API_PREFORMATTED, name);

            WebClient wc = new WebClient();
            var webResponse = wc.DownloadString(requestURL);
            var result = JsonConvert.DeserializeObject<GenderizeResponse>(webResponse);

            return result;
        }

        public static Gender GetGender(string name)
        {
            var requestURL = String.Format(API_PREFORMATTED, name);

            WebClient wc = new WebClient();
            var webResponse = wc.DownloadString(requestURL);
            var result = JsonConvert.DeserializeObject<GenderizeResponse>(webResponse);

            return result.gender;
        }
    }
}
