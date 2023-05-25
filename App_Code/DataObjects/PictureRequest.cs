using System.Runtime.Serialization;

/// <summary>
/// Summary description for PictureRequest
/// </summary>
[DataContract]
public class PictureRequest
{
    [DataMember]
    public string Location { get; set; }
    [DataMember]
    public string PictureRequestID { get; set; }
    [DataMember]
    public string LocationCode { get; set; }
    [DataMember]
    public string TrailerID { get; set; }
    [DataMember]
    public string ActionType { get; set; }
    [DataMember]
    public string Placard { get; set; }
    [DataMember]
    public string UserCode { get; set; }
    [DataMember]
    public string PicturePath { get; set; }
    [DataMember]
    public string ReferenceKey { get; set; }
    [DataMember]
    public string ScanTime { get; set; }
    [DataMember]
    public string TimeStamp { get; set; }
    [DataMember]
    public string ActionDetails { get; set; }
    [DataMember]
    public string PictureCount { get; set; }
}