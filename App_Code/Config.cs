using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Config
/// </summary>
public class Config
{

    //public static SqlConnection conn = new SqlConnection(@"Server=MCY-LAPTOP;Database=MCYPost;User ID=sa;Password=123;");
    public static SqlConnection conn = new SqlConnection(@"Server=79.171.17.205;Database=MCYPost;User ID=mcypostuser;Password=mcy2011;");
    //public static SqlConnection conn = new SqlConnection(@"Server=79.171.17.205;Database=MCY_AF;User ID=akademiform;Password=AF2011;");

	public Config()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}