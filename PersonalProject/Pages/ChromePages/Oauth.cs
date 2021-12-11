using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;    // NuGet Json.NET
using RestSharp;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace PersonalProject.Pages
{
    public static class Oauth
    {
        public static String GetTokenAdmin()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var client = new RestClient("https://login.microsoftonline.com/common/oauth2/v2.0/authorize");
            var request = new RestRequest();

            request.Method = Method.POST;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            /*
            string body = new JavaScriptSerializer().Serialize(new
            {
                username = "halley.bradt@tabs.toshiba.com",
                password = "Toshiba123"
            });
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            */
            var response = client.Execute(request);
            var content = response.Content;

            return content;
        }

        public static String Content()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
            var client = new RestClient(@"https://outlook.office.com/api/v2.0/me/messages");
            var request = new RestRequest();

            request.Method = Method.GET;
            request.AddHeader("Accept", "application/json");

            var response = client.Execute(request);
            var content = response.Content;
            return content;
        }




    }
}