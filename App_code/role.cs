using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using System.Web;


namespace LoginForm
{
    public static class buffer
    {
        //public static string role="" ;
        public static string error="";
        public static List<object[]> students, subjects;
        public static ReportDocument doc;
        public static bool report,isMark;
        public static DataTable table;
        public static string docTitle;
        public static Dictionary<string,int> units=new Dictionary<string,int>();
        

        public static List<object[]> getSet(string query)
        {
            List<object[]> set = new List<object[]>();
            string _path_to_db = HttpContext.Current.Server.MapPath(@"~/resultdb.accdb");
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+_path_to_db);
            try
            {
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                OleDbDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                { 
                 object[] record=new object[rdr.FieldCount];
                 rdr.GetValues(record);
                 set.Add(record);
                }

            }
            catch (Exception ex)
            { 
            
            }
            con.Close();
            return set;
        
        }
        public static bool insertRecord(string query)
        {
            bool success = false;
            string _path_to_db = HttpContext.Current.Server.MapPath(@"~/resultdb.accdb");
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+_path_to_db);
            try
            {
                con.Open();
                OleDbCommand cmd = con.CreateCommand();
                cmd.CommandText = query;
                int affected = cmd.ExecuteNonQuery();
                success = true;

            }
            catch (Exception ex)
            {

            }
            con.Close();
            return success;
        
        }
        public static DataTable getTable(string qry)
        {
            DataTable table = new DataTable();
            string _path_to_db = HttpContext.Current.Server.MapPath(@"~/resultdb.accdb");
            table.TableName = "COMSET";
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+_path_to_db);
            try
            {
                con.Open();
                OleDbDataAdapter dptr = new OleDbDataAdapter(qry, con);
                dptr.Fill(table);

            }
            catch (Exception ex)
            {

            }
            con.Close();
            
            return table;
        }
        public static double getGPA(DataTable table,int cunits,int exam,int test,int assign)
        {
            double gpa = 0; double total_units=0;
            foreach (DataRow row in table.Rows)
            {
                total_units += Convert.ToDouble(row[cunits]);
                gpa += getPoints(Convert.ToDouble(row[cunits]), Convert.ToDouble(row[exam]) + Convert.ToDouble(row[test]) + Convert.ToDouble(row[assign]));
            }
            return gpa/total_units;
        
        }
        public static double getPoints(double c_units, double score)
        {
            if (score >= 70) return 5 * c_units;
            else
                if (score >= 60 && score < 70) return 4 * c_units;
                else if (score >= 50 && score < 60) return 3 * c_units;
                else if (score >= 45 && score < 50) return 2 * c_units;
                else if (score >= 40 && score < 45) return 2 * c_units;
                else return 0;
        
        }
    
    }
}
