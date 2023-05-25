using System.Runtime.Serialization;

/// <summary>
/// Summary description for ResponseFormat
/// </summary>
[DataContract]
public class ValidResponseFormat
{


    [DataMember(Order = 2)]
    public string ErrorMessage { get; set; }
    [DataMember(Order = 1)]
    public bool Success { get; set; }
    [DataMember(Order = 3)]
    public int ErrorCode { get; set; }
}
[DataContract]
public class GeneralResponse<T> : ValidResponseFormat
{
    [DataMember(Order = 4)]
    public T Data { get; set; }
}