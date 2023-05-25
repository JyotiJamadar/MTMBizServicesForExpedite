using System.ServiceModel;
using System.IO;
using System.ServiceModel.Web;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFileUpload" in both code and config file together.
[ServiceContract]
public interface IFileUpload
{

    [OperationContract]
    [WebInvoke(UriTemplate = "/Image/{IMAGE_NAME}", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
    ValidResponseFormat ProcessImage(string IMAGE_NAME, Stream IMAGE);
}
