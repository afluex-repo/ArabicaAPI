using System;
using System.Configuration;
using System.IO;
using System.Net;

namespace ArabicaAPI
{
    static public class BLSMS
    {
        public static string SendSMSNew(string Mobile_Number, string Message)
        {
          

            //string strUrl = "http://smsw.co.in/API/WebSMS/Http/v1.0a/index.php?username=moonlite&password=d82fa5-de877&sender=MOONLT&to=" + Mobile_Number + "&message=" + Message + "& reqid = 1 & format ={ json}&route_id = 39 & callback =#&unique=0&sendondate='" + DateTime.Now.ToString() + " '";

            string strUrl = "http://smsw.co.in/API/WebSMS/Http/v1.0a/index.php?username=fuhaarparadise&password=r1hXod-x1H6&sender=PRDISE&to=" + Mobile_Number + "&message=" + Message + "& reqid = 1 & format ={ json}&route_id = 39 & callback =#&unique=0&sendondate='" + DateTime.Now.ToString() + " '";
    

            WebRequest request = HttpWebRequest.Create(strUrl);
            // Get the response back  
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream s = (Stream)response.GetResponseStream();
            StreamReader readStream = new StreamReader(s);
            string dataString = readStream.ReadToEnd();
            response.Close();
            s.Close();
            readStream.Close();
            return dataString;
        }
        
    }
}
