using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using HtmlAgilityPack;

namespace TicketStatus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmTicketStatus());
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            Console.WriteLine("MyHandler caught : " + e.Message);
            MessageBox.Show("Error : " + e.ToString());
        }

    }
    public class SetUrl
    {
        private string _URL = "";
        private string _EventName = "";
        private string _EventTime = "";
        private string _EventStatus = "";
        private string _EventLastStatus = "";
        private string _EventOnSale = "";
        private string _EventOther = "";
        private Boolean _UseProxy;
        private Boolean _IsError;
        private WebProxy _URLProxy;
        private Boolean _IsBusy;

        public string URL { get { return _URL; } set { _URL = value; }}
        public Boolean UseProxy { get { return _UseProxy; } set { _UseProxy = value; } }
        public Boolean IsError { get { return _IsError; } set { _IsError = value; } }
        public Boolean IsBusy { get { return _IsBusy; } set { _IsBusy = value; } }
        public string EventName { get { return _EventName; } set { _EventName = value; } }
        public string EventTime { get { return _EventTime; } set { _EventTime = value; } }
        public string EventStatus { get { return _EventStatus; } set { _EventStatus = value; } }
        public string EventLastStatus { get { return _EventLastStatus; } set { _EventLastStatus = value; } }
        public string EventOnSale { get { return _EventOnSale; } set { _EventOnSale = value; } }
        public string EventOther { get { return _EventOther; } set { _EventOther = value; } }
        public WebProxy URLProxy { get { return _URLProxy; } set { _URLProxy = value; } }

        public SetUrl(string cURL, Boolean lUseProxy)
        {
            _URL = cURL;
            _IsBusy = true;
            try
            {
                WebClient wc = new WebClient();
                if (lUseProxy)
                {
                    URLProxy = Proxy.GetProxy();
                    wc.Proxy = URLProxy;
                }
                UseProxy = URLProxy == null || URLProxy.Address.ToString().Trim() == "" ? false : true;

                var page = wc.DownloadString(cURL);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(page);
                try
                {
                    _EventName = doc.DocumentNode.SelectSingleNode("//h1[@class='headliner']").InnerText.Replace("/n", "").Trim();
                    _EventTime = doc.DocumentNode.SelectSingleNode("//div[@class='showtime']").InnerText.Replace("/n", "").Trim();
                }
                catch
                {
                    try
                    {
                        _EventName = doc.DocumentNode.SelectSingleNode("//h1[@class='page-title']").InnerText.Replace("/n", "").Trim(); ;
                        _EventTime = "";
                    }
                    catch
                    {
                        _EventName = "Invalid URL";
                        _EventTime = "";
                    }
                }

                try
                {
                    _EventStatus = doc.DocumentNode.SelectSingleNode("//a[@class='primary-cta btn-new btn-size-small blue btn-color-blue white btn-text-color-white cta_follow']").InnerText.Replace("/n", "").Trim();
                }
                catch
                {
                    try
                    {
                        _EventStatus = doc.DocumentNode.SelectSingleNode("//a[@class='primary-cta btn-new btn-size-small orange btn-color-orange white btn-text-color-white ']").InnerText.Replace("/n", "").Trim();
                    }
                    catch
                    {
                        _EventStatus = "Expired";
                    }
                }

                try
                {
                    if (_EventStatus.ToLower() == "select tickets")
                    {
                        string cCheckURL = "";
                        try
                        {
                            cCheckURL = doc.DocumentNode.SelectSingleNode("//a[@class='primary-cta btn-new btn-size-small blue btn-color-blue white btn-text-color-white cta_follow']").GetAttributeValue("href", "").ToString().Replace("https://tickets.axs.com/eventShopperV3.html?", "https://mobile.eventshopper.com/mobilewroom/?");
                        }
                        catch
                        {
                            cCheckURL = doc.DocumentNode.SelectSingleNode("//a[@class='primary-cta btn-new btn-size-small orange btn-color-orange white btn-text-color-white ']").GetAttributeValue("href", "").ToString().Replace("https://tickets.axs.com/eventShopperV3.html?", "https://mobile.eventshopper.com/mobilewroom/?");
                        }
                       
                        //string str = wc.UploadString("https://mobile.eventshopper.com/mobileshopper/ajax/availWSS.json", "8d89a50d-40dd-42c8-9743-5ed68413fbba");
                        //string str1 = wc.UploadString("https://mobile.eventshopper.com/mobileshopper/ajax/availWSS.json", "0d727ba1-5771-41f7-8395-d9deedabe086");

                                                
                        wc.DownloadStringCompleted += (sender, e) =>
                        {
                            page = e.Result;
                        };
                        wc.DownloadString(cCheckURL);
                        //page = wc.DownloadString(cCheckURL);
                        doc.LoadHtml(page);
                        

                        if (page.ToLower().Contains("select quantity"))
                        {
                            _EventStatus = "select tickets";
                        }
                        else
                        {
                            _EventStatus = "Sold out";
                        }

                        //string cStatus = "";
                        //try
                        //{
                        //    cStatus = doc.DocumentNode.SelectSingleNode("//*[@id='qtyLabel']").InnerText.Replace("/n", "").Trim();

                        //}
                        //catch { }

                        
                        //if (cStatus.ToLower().Contains("select quantity"))
                        //{
                        //    _EventStatus = "select tickets";
                        //}
                        //else
                        //{
                        //    _EventStatus = "Sold out";
                        //}
                    }
                }
                catch
                {                 }
                
                for (int i = 0; i < 4; i++)
                {
                    try
                    {
                        string strPath = "//*[@id='admission-box']/div/div[" + Convert.ToString(i).Trim() + "]/b[text()='Onsale: ']";
                        _EventOnSale = doc.DocumentNode.SelectSingleNode(strPath.ToString()).NextSibling.InnerHtml.Replace("/n", "").Trim();
                        if (_EventOnSale.Trim() != "")
                        {
                            break;
                        }
                    }
                    catch
                    {
                        _EventOnSale = "";
                    }
                }

                for (int i = 0; i < 10; i++)
                {
                    try
                    {
                        string strPath = "//*[@id='admission-box']/div/div[" + Convert.ToString(i).Trim() + "]/b";
                        _EventOther = _EventOther + System.Environment.NewLine + doc.DocumentNode.SelectSingleNode(strPath.ToString()).NextSibling.InnerHtml.Replace("/n", "").Trim();
                    }
                    catch
                    {
                    }
                }
                _EventLastStatus = _EventStatus;
            }
            catch (Exception Err)
            {
                _IsError = true;
                _EventName = Err.Message.ToString();
                _EventStatus = "Error";
                _EventLastStatus = "Error";
            }
            _IsBusy = false;
        }

        public void CheckStatus(string cURL)
        {
            if (_EventStatus != "Expired" && _EventStatus != "Error")
            {
                _IsBusy = true;
                WebClient wc = new WebClient();
                wc.Proxy = _UseProxy ? _URLProxy : null;
                var page = wc.DownloadString(cURL);
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(page);
                string _NewEventStatus = "";
                try
                {
                    _NewEventStatus = doc.DocumentNode.SelectSingleNode("//a[@class='primary-cta btn-new btn-size-small blue btn-color-blue white btn-text-color-white cta_follow']").InnerText.Replace("/n", "").Trim();
                }
                catch
                {
                    _NewEventStatus = doc.DocumentNode.SelectSingleNode("//a[@class='primary-cta btn-new btn-size-small orange btn-color-orange white btn-text-color-white ']").InnerText.Replace("/n", "").Trim();
                }

                try
                {
                    if (_NewEventStatus.ToLower() == "select tickets")
                    {
                        string cCheckURL = "";
                        cCheckURL = doc.DocumentNode.SelectSingleNode("//*[@id='event-details-content']/div/div[2]/section[1]/div/div[2]/div[2]/div[2]/a").GetAttributeValue("href", "").ToString().Replace("https://tickets.axs.com/eventShopperV3.html?", "https://mobile.eventshopper.com/mobilewroom/?");

                        Uri myUri = new Uri(cCheckURL);
                        string wr = HttpUtility.ParseQueryString(myUri.Query).Get("wr");

                        //RISKY CODE

                        string response = wc.DownloadString(cCheckURL);

                        

                        //Get lot id from above response. Lot id is defined as a variable

                        //using lotid and wr... call below post request
                        //https://tickets.axs.com/xmlrpc/?methodName=getPhase&lotId=<lotid>&wr=<wr>
                        //COntentytpe: application/x-www-form-urlencoded; charset=UTF-8
                        //requestbody
//                        <?xml version="1.0"?>
//<methodCall>
//<methodName>getPhase</methodName>
//<params>
//<param><value><string>07a73b4d-6e15-4926-8f53-abe29a7834ea</string></value></param><param><value><string>NoLotId</string></value></param></params>
//</methodCall>



                        //you will get hash and ts in xml response. you have to use this lot, hash and ts to get the two cookies

                        //the url will be add below things to cCheckURL&lot=<lotid>&hash=<hash>&ts=<ts>

                        //after you hit above url, you will get cookies  srv_id and mobileshopper.session.id
                        //use these in below post to get seta availability

                        
                        string mobileUrl = "https://mobile.eventshopper.com/mobileshopper/ajax/availWSS.json";

                        wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/44.0.2403.155 Safari/537.36");
                        wc.Headers.Add("Content-Type", "text/plain;charset=UTF-8");
                        wc.Headers.Add("Cookie", "srv_id=d50788c37340c8208f74578ddea8f51d; mobileshopper.session.id=a45fa92e59c744dd992f124df46ac1b1");

                        string jsonResponse = wc.UploadString(mobileUrl, string.Format("[\"{0}\"]", wr));

                        //END RISKY CODE. Here you will get the response which will tell whether seats are available or not and what seats are available


                        if (page.ToLower().Contains("select quantity"))
                        {
                            _EventStatus = "select tickets";
                        }
                        else
                        {
                            _EventStatus = "Sold out";
                        } 

                        //page = wc.DownloadString(cCheckURL);
                        //if (page.ToLower().Contains("select quantity"))
                        //{
                        //    _EventStatus = "select tickets";
                        //}
                        //else
                        //{
                        //    _EventStatus = "Sold out";
                        //}
                    }
                    else
                    {
                        _EventStatus = _NewEventStatus;
                    }
                } catch 
                {
                    _EventStatus = _NewEventStatus;
                }

                if (_EventStatus != _EventLastStatus)
                {
                    _EventLastStatus = _EventStatus;
                    //this.AlertEvenet();
                }
                _IsBusy = false;
            }
      }

        public void AlertEvenet()
        {
            MessageBox.Show("Event Name : "+ _EventName.ToString());
        }
    }

   public class Proxy
    {
        public static WebProxy GetProxy()
        {
            string lcHost = "";
            int lnPort = 0;
            string lcPath = Path.GetDirectoryName(Application.ExecutablePath);
            if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\Proxy.txt"))
            {
                string[] lines = System.IO.File.ReadAllLines("Proxy.txt");
                if (lines.Count() != 0)
                {
                    Random rnd = new Random();
                    int nLine = rnd.Next(0, lines.Count());
                    List<String> listStrLineElements;
                    listStrLineElements = lines[nLine].Split(',').ToList();
                    lcHost = listStrLineElements[0].Trim();
                    lnPort = int.Parse(listStrLineElements[1].Trim());
                 }
            }
            return lcHost.ToString() == "" || lnPort == 0 ? null : new WebProxy(lcHost, lnPort);
        }
    }
 
   

}
