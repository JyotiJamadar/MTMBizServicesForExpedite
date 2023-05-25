using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for modFunction
/// </summary>
public class DBTransactionHandler
{
    public void OpenConnection(ref SqlConnection sqlcon)
    {
        if (sqlcon.State == ConnectionState.Closed)
        {
            sqlcon.ConnectionString = ConfigurationManager.ConnectionStrings["ServiceConnection"].ToString();
            sqlcon.Open();
        }
    }
    public string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["ServiceConnection"].ToString();
    }
    public void CloseConnection(ref SqlConnection sqlcon)
    {
        if (sqlcon.State == ConnectionState.Open)
        {
            sqlcon.Close();
        }
    }
    public void GetScalarResponse(ref SqlCommand sqlcmd, ref SqlConnection sqlcon)
    {
        OpenConnection(ref sqlcon);
        sqlcmd.ExecuteScalar();
    }

    public SqlDataReader GetResultSet(ref SqlCommand sqlcmd, ref SqlConnection sqlcon)
    {
        OpenConnection(ref sqlcon);
        sqlcmd.CommandType = CommandType.StoredProcedure;
        return sqlcmd.ExecuteReader();

    }

}