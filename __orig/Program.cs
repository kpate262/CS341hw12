//
// HW #12
// 
// SQL, C# and ADO.NET program to retrieve crimes counts from 
// ChicagoCrimes database in Azure.
// 
// <<YOUR NAME>>
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
      
      
      System.Console.WriteLine();
      System.Console.WriteLine("TODO!");
      System.Console.WriteLine();
      
      
    }//Main
    
  }//class
}//namespace
