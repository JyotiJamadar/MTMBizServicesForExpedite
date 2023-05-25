using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using System.Security.Cryptography;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for WebPushData
/// </summary>
public class SendWebPush
{
    SqlConnection sqlcon = new SqlConnection();
    DBTransactionHandler db = new DBTransactionHandler();

    public void SendPushForWebIssue(string Issue, string Description)
    {
        try
        {
            Dictionary<string, string> RequestData = new Dictionary<string, string>();
            RequestData.Add("Issue", Issue);
            RequestData.Add("Description", Description);
            RequestData.Add("WebIssue", "1");
            RequestData.Add("TrailerFixed", "");
            RequestData.Add("TrailerDamaged", "");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonn = jss.Serialize(RequestData);
            WebPushObject wp = new WebPushObject();
            WebPushData data = new WebPushData();
            CloudPush cp = new CloudPush();
            db.OpenConnection(ref sqlcon);

            using (sqlcon)
            {
                string SQLQuery = "GetWebPushHelpToken";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        wp.to = reader["Token"].ToString();
                        data.title = "Issue Notification";
                        data.body = jsonn;
                        wp.data = data;
                        cp.SendWebNotification(wp);
                    }
                    reader.Close();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SendPushForRepair(string Issue, string TrailerID)
    {
        try
        {
            Dictionary<string, string> RequestData = new Dictionary<string, string>();
            RequestData.Add("Issue", Issue);
            RequestData.Add("TrailerID", TrailerID);
            RequestData.Add("WebIssue", "");
            RequestData.Add("TrailerFixed", "1");
            RequestData.Add("TrailerDamaged", "");
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonn = jss.Serialize(RequestData);
            WebPushObject wp = new WebPushObject();
            WebPushData data = new WebPushData();
            CloudPush cp = new CloudPush();
            db.OpenConnection(ref sqlcon);
            using (sqlcon)
            {
                string SQLQuery = "GetWebPushHelpToken";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        wp.to = reader["Token"].ToString();
                        data.title = "Trailer Repaired";
                        data.body = jsonn;
                        wp.data = data;
                        cp.SendWebNotification(wp);
                    }
                    reader.Close();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void SendPushForTrailerDamage(string Issue, string Area, string TrailerID , string Title)
    {
        try
        {
            Dictionary<string, string> RequestData = new Dictionary<string, string>();
            RequestData.Add("Issue", Issue);
            RequestData.Add("TrailerID", TrailerID);
            RequestData.Add("WebIssue", "");
            RequestData.Add("TrailerFixed", "");
            RequestData.Add("TrailerDamaged", "1");
            RequestData.Add("Area", Area);
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonn = jss.Serialize(RequestData);
            WebPushObject wp = new WebPushObject();
            WebPushData data = new WebPushData();
            CloudPush cp = new CloudPush();
            db.OpenConnection(ref sqlcon);
            using (sqlcon)
            {
                string SQLQuery = "GetWebPushHelpToken";
                db.OpenConnection(ref sqlcon);
                using (SqlCommand sqlcmd = new SqlCommand(SQLQuery, sqlcon))
                {
                    SqlDataReader reader = sqlcmd.ExecuteReader();
                    while (reader.Read())
                    {
                        wp.to = reader["Token"].ToString();
                        data.title = Title;
                        data.body = jsonn;
                        wp.data = data;
                        cp.SendWebNotification(wp);
                    }
                    reader.Close();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
public class WebPushObject
{
    public string to { get; set; }
    public WebPushData data { get; set; }
}
public class WebPushData
{
    public string title { get; set; }
    public string body { get; set; }
}
