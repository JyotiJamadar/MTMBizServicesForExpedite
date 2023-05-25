using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DispatchPushObject
/// </summary>

public class DispatchPushObject
{
    public string to { get; set; }
    public DispatchOuterLayer data { get; set; }
}

public class DispatchOuterLayer
{
    public string FacilityCode { get; set;}
    public string key { get; set; }
    public string RequestedTo { get; set; }
    public string DispatchData { get; set;}
}
