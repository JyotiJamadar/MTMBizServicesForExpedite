using System.Runtime.Serialization;

/// <summary>
/// Summary description for DispatchStatusResponse
/// </summary>
[DataContract]
public class DispatchStatusResponse
{
    [DataMember]
    public string DispatchStatus { get; set; }

}