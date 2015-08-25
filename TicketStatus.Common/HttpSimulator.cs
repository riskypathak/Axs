using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TicketStatus.Common
{
    public class HttpSimulator
    {
        CookieAwareWebClient webclient = new CookieAwareWebClient();

        public string Get(string url)
        {
            webclient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.155 Safari/537.36");
            return webclient.DownloadString(url);
        }

        public string PostPlainText(string url, string data)
        {
            webclient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.155 Safari/537.36");
            webclient.Headers.Add("Content-Type", "text/plain;charset=UTF-8");
            
            return webclient.UploadString(url, data);
        }

        public string PostFormUrlEncoded(string url, string data)
        {
            webclient.Headers.Add("Content-Type", "application/x-www-form-urlencoded; charset=UTF-8");
            webclient.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.155 Safari/537.36");
            return webclient.UploadString(url, data);
        }

        public string GetData(string input, string startString, string endString, RegexOptions regexOptions)
        {

            Regex expression = new Regex(string.Format("{0}.*{1}", startString, endString), regexOptions);
            Match match = expression.Match(input);

            if (match.Success)
            {
                return ExtractValue(match.Value, startString, endString);
            }
            else
            {
                return null;
            }
        }

        private string ExtractValue(string input, string startString, string endString)
        {
            startString = startString.Replace("\\", string.Empty);
            endString = endString.Replace("\\", string.Empty);

            return input.Replace(startString, string.Empty).Replace(endString, string.Empty);
        }
    }
}
