using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Services;
using HtmlAgilityPack;

namespace HavaDurumuService.Controllers
{
    public class HomeController : ApiController
    {
        // GET: api/Home
        public List<string> Get()
        {
            Uri url = new Uri("http://www.hurriyet.com.tr/hava-durumu/istanbul");
            WebClient client = new WebClient();
            string html = client.DownloadString(url);

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);

            HtmlNodeCollection divler = htmlDoc.DocumentNode.SelectNodes("//div[@class='four-box']/div[@class='dbd']");

            List<string> liste = new List<string>();

            foreach(var item in divler)
            {
                byte[] bytes = Encoding.Default.GetBytes(item.InnerText);
                string itemText = Encoding.UTF8.GetString(bytes);
                liste.Add(itemText);
            }

            return liste;
                
        }

        // GET: api/Home/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Home
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Home/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Home/5
        public void Delete(int id)
        {
        }

    }
}
