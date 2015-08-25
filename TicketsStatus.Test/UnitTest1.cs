using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicketStatus.Common;
using System.Xml.Linq;
using System.Xml;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TicketsStatus.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Get()
        {
            string url = "https://mobile.eventshopper.com/mobilewroom/?wr=07a73b4d-6e15-4926-8f53-abe29a7834ea&amp;preFill=1&amp;lang=en&amp;locale=en_us&amp;eventid=278555&amp;ec=STC151106&amp;src=AEGAXS1_WMAIN&amp;skin=axs_staples&amp;fbShareURL=m.axs.com%2Fevents%2F278555%2Fnitro-circus-live-tickets%3F%26ref%3Devs_fb";
            string wr = "07a73b4d-6e15-4926-8f53-abe29a7834ea";

            HttpSimulator simulator = new HttpSimulator();
            string respose = simulator.Get(url);

            string lot = simulator.GetData(respose, "var lotId = \"", "\";", System.Text.RegularExpressions.RegexOptions.None);

            string xmlData = string.Format("<?xml version=\"1.0\"?><methodCall><methodName>getPhase</methodName><params><param><value><string>{0}</string></value></param><param><value><string>{1}</string></value></param></params></methodCall>", wr, lot);

            string xmlResponse = simulator.PostFormUrlEncoded(string.Format("https://tickets.axs.com/xmlrpc/?methodName=getPhase&lotId={0}&wr={1}", lot, wr), xmlData);

            string hash = GetXmlNodeValue(xmlResponse.Replace("<?xml version=\"1.0\"?>", string.Empty), "hash");
            string ts = GetXmlNodeValue(xmlResponse.Replace("<?xml version=\"1.0\"?>", string.Empty), "hashts");

            string newUrl = string.Format("{0}&lot={1}&hash={2}&ts={3}", url.Replace("mobilewroom", "mobileshopper"), lot, hash, ts);

            simulator.Get(newUrl);

            string res = simulator.PostPlainText("https://mobile.eventshopper.com/mobileshopper/ajax/availWSS.json", string.Format("[\"{0}\"]", wr));
        }

        [TestMethod]
        public void ParseJson()
        {
            //string json = "{\"eventavail_ss\": {\"STC150825\": [], \"STC150824\": [], \"STC150826\": [], \"STC150821\": [], \"STC150822\": []}, \"eventavail\": {\"STC150825\": [], \"STC150824\": [], \"STC150826\": [], \"STC150821\": [], \"STC150822\": []}}";

            string json = "{\"eventavail_ss\": {\"STC151106\": [[\"101_1_18W\", 1, 1], [\"102_1_20\", 1, 21], [\"103_1_20\", 1, 15], [\"104_5_18W\", 1, 16], [\"105_3_20\", 1, 15], [\"106_1_18W\", 1, 24], [\"107_1_18W\", 1, 24], [\"108_3_18W\", 1, 15], [\"109_1_18W\", 1, 14], [\"110_1_20\", 1, 20], [\"111_1_20\", 1, 1], [\"112_1_18W\", 1, 21], [\"113_1_18W\", 1, 14], [\"117_10_18W\", 3, 2], [\"118_1_20\", 1, 15], [\"119_1_18W\", 1, 20], [\"205_1_12\", 3, 17], [\"206_1_12\", 3, 27], [\"207_1_12\", 3, 26], [\"208_1_12\", 3, 25], [\"209_1_12\", 3, 24], [\"210_1_12\", 3, 17], [\"214_1_12\", 5, 1], [\"215_1_12\", 5, 4], [\"301_1_15\", 3, 25], [\"301_1_15\", 5, 25], [\"302_1_15\", 3, 2], [\"302_1_15\", 5, 24], [\"303_1_5\", 3, 17], [\"303_6_15\", 5, 20], [\"304_1_15\", 5, 25], [\"305_1_12\", 7, 17], [\"306_1_10\", 7, 18], [\"307_1_8\", 7, 18], [\"308_1_7\", 7, 26], [\"309_1_7\", 7, 18], [\"310_1_7\", 7, 18], [\"312_1_8\", 7, 15], [\"313_1_10\", 7, 21], [\"314_1_12\", 7, 18], [\"315_1_12\", 5, 25], [\"316_1_5\", 3, 18], [\"316_6_12\", 5, 22], [\"317_1_12\", 3, 13], [\"317_1_12\", 5, 13], [\"318_1_12\", 3, 19], [\"318_1_12\", 5, 38], [\"319_1_12\", 3, 13], [\"319_1_12\", 5, 13], [\"320_1_5\", 3, 18], [\"320_6_12\", 5, 22], [\"333_1_5\", 3, 17], [\"333_6_15\", 5, 21], [\"334_1_15\", 3, 22], [\"334_1_15\", 5, 25], [\"PR10_1_12\", 2, 15], [\"PR11_1_12\", 2, 14], [\"PR12_1_12\", 2, 18], [\"PR13_1_10\", 2, 20], [\"PR15_1_10\", 2, 18], [\"PR17_1_12\", 4, 1], [\"PR18_1_12\", 4, 6], [\"PR1_1_12\", 6, 1], [\"PR2_1_12\", 2, 14], [\"PR3_1_12\", 2, 18], [\"PR4_1_10\", 2, 16], [\"PR5_1_10\", 2, 6], [\"PR6_1_10\", 2, 20], [\"PR7_1_12\", 2, 18], [\"PR8_1_12\", 2, 14], [\"PR9_1_12\", 2, 15]]}, \"eventavail\": {\"STC151106\": [[1, 24], [2, 20], [3, 27], [4, 6], [5, 38], [6, 1], [7, 26]]}}";

            //dynamic obj = JsonConvert.DeserializeObject(json);

            var foodJsonObj = JObject.Parse(json);

            bool isEmpty = true;

            foreach (var prop in foodJsonObj["eventavail"])
            {
                int length = (prop.First as JArray).Children().Count();

                if (length > 0)
                {
                    isEmpty = false;
                    break;
                }
            }
        }

        private string GetXmlNodeValue(string inputXml, string memberName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(inputXml);

            XmlNodeList members = xmlDoc.SelectNodes("methodResponse/params/param/value/struct/member");

            foreach (XmlNode member in members)
            {
                if (member.SelectSingleNode("name").InnerText == memberName)
                {
                    return member.SelectSingleNode("value/string").InnerText;
                }
            }

            return null;
        }
    }
}
