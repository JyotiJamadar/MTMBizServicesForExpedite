using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

/// <summary>
/// Summary description for CTPATQuestionsRequest
/// </summary>
public class CTPATQuestionsRequest
{
    [DataMember]

    public string CTPATType { get; set; }

    [DataMember]
    public string Questions { get; set; }
}