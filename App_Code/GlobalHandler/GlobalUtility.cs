/// <summary>
/// Summary description for GlobalUtility
/// </summary>
public static class GlobalUtility<T>
{
    public static GeneralResponse<T> Throw_Unauthorized_Exception()
    {
        return new GeneralResponse<T>
        {
            Success = false,
            ErrorCode = 401,
            ErrorMessage = "Unauthorized Access."
        };

    }
    public static ValidResponseFormat Throw_Unauthorized_Exception_DataLess()
    {
        return new ValidResponseFormat
        {
            Success = false,
            ErrorCode = 401,
            ErrorMessage = "Unauthorized Access."
        };
    }
    public static GeneralResponse<T> Throw_Global_Exception(string exceptionMessage, int ErrorCode = 700)
    {
        return new GeneralResponse<T>
        {
            Success = false,
            ErrorCode = ErrorCode,
            ErrorMessage = exceptionMessage
        };
    }
    public static ValidResponseFormat Throw_Global_Exception_DataLess(string exceptionMessage, int ErrorCode = 700)
    {
        return new ValidResponseFormat
        {
            Success = false,
            ErrorCode = ErrorCode,
            ErrorMessage = exceptionMessage
        };
    }

 
}