using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Umbraco.Core.IO;
using Umbraco.Web.WebApi;

namespace EditorCourse.Controllers
{
    public class TwitterController : UmbracoAuthorizedApiController
    {
        private JArray tweets;
        public TwitterController()
        {
            //get some fake tweets
            var json = System.IO.File.ReadAllText(IOHelper.MapPath("/app_data/tweets.json"));
            tweets = JArray.Parse(json);
        }


        [HttpGet]
        public IEnumerable<JToken> Search(string term)
        {
            return tweets.Where(x => x.Value<string>("message").Contains(term));
        }
    }
}
