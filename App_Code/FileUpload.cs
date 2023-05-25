using System;
using System.IO;
using System.ServiceModel.Web;
using System.Net;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FileUpload" in code, svc and config file together.
public class FileUpload : IFileUpload
{

    public static byte[] ReadFully(Stream input)
    {
        try
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public ValidResponseFormat ProcessImage(string IMAGE_NAME, Stream IMAGE)
    {
        if (HeaderValidates())
        {
            try
            {
                byte[] data = ReadFully(IMAGE);

                using (MemoryStream ms = new MemoryStream(data))
                {
                    using (System.Drawing.Image image = System.Drawing.Image.FromStream(ms))
                    {
                        //image.Save(@"F:\DoNotDeleteHostedApplications\MTMQA\InspectionImages\" + IMAGE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
 			image.Save(@"C:\inetpub\wwwroot\DONOTDELETEALLBizSite\MTMBiz\InspectionImages\" + IMAGE_NAME, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                }
                return new ValidResponseFormat { Success = true, ErrorMessage = "No Error" };
            }
            catch (Exception ex)
            {
                return GlobalUtility<ValidResponseFormat>.Throw_Global_Exception_DataLess(ex.Message);
            }
        }
        else
        {
            return GlobalUtility<ValidResponseFormat>.Throw_Unauthorized_Exception_DataLess();
        }
    }

    private bool HeaderValidates()
    {
        try
        {
            IncomingWebRequestContext request = WebOperationContext.Current.IncomingRequest;
            WebHeaderCollection headers = request.Headers;
            if (headers["EXOTRAC-DEVICEID"] != null)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}
