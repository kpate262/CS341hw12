//
// HW #12
// 
// SQL, C# and ADO.NET program to retrieve crimes counts from 
// ChicagoCrimes database in Azure.
// 
// <<Kisan Patel>>
// 

using System;
using System.Data.SqlClient;
using System.Data;

namespace workspace
{
  class Program
  {
    
    //
    // Main:
    //
    static void Main(string[] args)
    {
      string connectionInfo = String.Format(@"
            Server=tcp:jhummel2.database.windows.net,1433;Initial Catalog=ChicagoCrimes;
            Persist Security Info=False;User ID=student;Password=cs341!uic;
            MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;
            Connection Timeout=30;
            ");
      
      string input, name;
      bool isIntegerInput;
      int areaOrYear;
        
      System.Console.Write("Enter area, year, or primary description> ");
      input = System.Console.ReadLine();
      
      isIntegerInput = System.Int32.TryParse(input, out areaOrYear);
      SqlConnection db = null;
      
      
        
      try{
          db = new SqlConnection(connectionInfo);
          db.Open();
      }
      catch (Exception ex){
          System.Console.WriteLine("Error: {0}", ex.Message);
      }
      
      finally{
          
          string sql = null;
          if(isIntegerInput == false){
              sql = string.Format(@"
                        SELECT COUNT(PrimaryDesc) FROM Crimes INNER JOIN Codes ON Crimes.IUCR = Codes.IUCR 
                        WHERE PrimaryDesc='{0}' GROUP BY PrimaryDesc;
                        ", input);
          }
          else if(isIntegerInput == true){
              if(areaOrYear >= 2001){
                  sql = string.Format(@"
                        SELECT COUNT(Year) FROM Crimes WHERE Year={0} GROUP BY Year;
                        ", input);
              }
              else {
                  sql = string.Format(@"
                        SELECT COUNT(Area) FROM Crimes WHERE Area={0} GROUP BY Area;
                        ", input);
              }
                  
          }
          
          SqlCommand cmd = new SqlCommand();
          cmd.Connection = db;
          cmd.CommandText = sql;

          object result = cmd.ExecuteScalar();


          if(db != null && db.State != ConnectionState.Closed)
              db.Close();

          if(result == null)
              name = "0";
          else if (result == System.DBNull.Value)
              name = "Found row, but no value in the DB: " + input;
          else
              name = System.Convert.ToString(result);

          System.Console.WriteLine("{0}", name);
      }
    }//Main
    
  }//class
}//namespace
