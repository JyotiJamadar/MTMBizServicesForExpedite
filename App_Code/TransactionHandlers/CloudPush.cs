using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using System.Configuration;

using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Text;
/// <summary>
/// Summary description for CloudPush
/// </summary>
public class CloudPush
{

    public  AndroidFCMPushNotificationStatus SendGCM(string DispatchData, string key, string FacilityCode, string RequestedTo)
    {
        AndroidFCMPushNotificationStatus result = new AndroidFCMPushNotificationStatus();
        string serverApiKey = null;
        string senderId = null;

        try
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
            result.Successful = false;
            result.Error = null;
            serverApiKey = "AAAATdPcOXs:APA91bEhWcFx4nDbpC5tr3FKq8h7rYmdBQH30odvQ-hhILEMH-WHpA8asd_OPZp6br1gZSgIX9qwIIKkFFSWPAy16-t9vvxsgZj7Yo9Aevq5bnNH-Lm5pNl8TXEpGAy7W1ErmiGv-2PN";
             
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", serverApiKey));
            tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
	    
	    DispatchPushObject dispatchObject = new DispatchPushObject();
	    dispatchObject.to="/topics/MTM_QA-driver-dispatch";
	    

	    DispatchOuterLayer dispatchOuterLayer=new DispatchOuterLayer();
	    dispatchOuterLayer.FacilityCode=FacilityCode;
	    dispatchOuterLayer.key=key;
	    dispatchOuterLayer.RequestedTo=RequestedTo;
	    dispatchOuterLayer.DispatchData=DispatchData;
	    
	    dispatchObject.data=dispatchOuterLayer;
	    
	    
	    JavaScriptSerializer jss = new JavaScriptSerializer();
	    string postData=jss.Serialize(dispatchObject);
            
            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;

            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);

                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            result.Response = sResponseFromServer;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            result.Successful = false;
            result.Response = null;
            result.Error = ex;
        }

        return result;
    }

    public AndroidFCMPushNotificationStatus SendWebNotification(WebPushObject wp)
    {
        AndroidFCMPushNotificationStatus result = new AndroidFCMPushNotificationStatus();
        string serverApiKey = null;
        string senderId = null;
        try
        {
            result.Successful = false;
            result.Error = null;
            serverApiKey = "AAAA6lpUNM4:APA91bFAKkCS9DftXaRSp4Dqtazey_rGe60ytO8jSk8Jo0ejpbSRb0k3qSeumR1f6dc-HAfZmSIcG0hDKETTEHFQRflIyTaN3QtDadLIg7x8SbjSNR8-ET5ZiO16_y4m-zi6lW67jOiu";
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/json";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", serverApiKey));
            tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string postData = jss.Serialize(wp);

            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;

            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);

                using (WebResponse tResponse = tRequest.GetResponse())
                {

                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            result.Response = sResponseFromServer;
                            //result.Response=postData;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            result.Successful = false;
            result.Response = null;
            result.Error = ex;
        }

        return result;
    }

    

}
public  class AndroidFCMPushNotificationStatus
{
    public bool Successful
    {
        get { return m_Successful; }
        set { m_Successful = value; }
    }

    private bool m_Successful;
    public string Response
    {
        get { return m_Response; }
        set { m_Response = value; }
    }
    private string m_Response;
    public Exception Error
    {
        get { return m_Error; }
        set { m_Error = value; }
    }
    private Exception m_Error;
}

