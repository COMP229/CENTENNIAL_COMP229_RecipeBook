using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for UnitMeasure
/// </summary>
public class UnitMeasure
{
    public int id;
    public String name;

    public UnitMeasure()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static List<UnitMeasure> getUnitMeasures()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;
        List<UnitMeasure> unitMeasures = new List<UnitMeasure>();

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("SelectUnitMeasures", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                UnitMeasure unitMeasure = new UnitMeasure();
                unitMeasure.id = (int)rdr["idUnitMeasure"];
                unitMeasure.name = (String)rdr["name"];
                unitMeasures.Add(unitMeasure);
            }

            return unitMeasures;
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
            if (rdr != null)
            {
                rdr.Close();
            }
        }
    }

    public void getUnitMeasure()
    {
        SqlConnection conn = null;
        SqlDataReader rdr = null;

        try
        {
            // create and open a connection object
            conn = DBTools.createConnection();

            // the stored procedure
            SqlCommand cmd = new SqlCommand("SelectUnitMeasure", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@idUnitMeasure", id));

            rdr = cmd.ExecuteReader();

            if (rdr.Read())
            {
                name = (String)rdr["name"];
            }
        }
        finally
        {
            if (conn != null)
            {
                conn.Close();
            }
            if (rdr != null)
            {
                rdr.Close();
            }
        }
    }
}