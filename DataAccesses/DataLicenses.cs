using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Windows.Controls.Primitives;
using System.Data.SqlClient;
using System.ComponentModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data;

namespace DataAccesses
{
    public class clsDataLicenses
    {

        static public int GetActiveLicenseIDByPersonID(int PersonID, int LicenseClassID)
        {
            int LicenseID = -1;

            SqlConnection connection = new SqlConnection(clsDataSetting.ConnectionString);

            string query = @"SELECT        Licenses.LicenseID
                            FROM Licenses INNER JOIN
                                                     Drivers ON Licenses.DriverID = Drivers.DriverID
                            WHERE  
                             
                             Licenses.LicenseClass = @LicenseClassID
                              AND Drivers.PersonID = @PersonID
                              And IsActive=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int AppID))
                {
                    LicenseID = AppID;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return LicenseID;
            }
            finally
            {
                connection.Close();
            }

            return LicenseID;
        }

        public static bool FindLicenseByLicenseId(int LicenseID, ref int ApplicationID, ref int DriverID, ref int LicenseClass, ref DateTime IssueDate,
          ref DateTime ExpirationDate, ref string Notes, ref Decimal PaidFees, ref bool IsActive, ref int IssueReason, ref int CreatedByUserID)              
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataSetting.ConnectionString);

            string query = "SELECT * FROM Licenses WHERE LicenseID = @LicenseID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    LicenseClass = (int)reader["LicenseClass"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];

                    if (reader["Notes"] != DBNull.Value)
                    {
                        Notes = (string)reader["Notes"];
                    }
                    else
                    {
                        Notes = "";

                    }
                    IsActive = (bool)reader["IsActive"];
                    PaidFees = (Decimal)reader["PaidFees"];
                    IssueReason = (byte)reader["IssueReason"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                   

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();


            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllLicenses()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSetting.ConnectionString);

            string query = "SELECT * FROM Licenses";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }        
        
        public static DataTable GetAllLocalLicensesForADriver(int DriverId)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSetting.ConnectionString);

            string query = @"SELECT     
                           Licenses.LicenseID,
                           ApplicationID,
		                   LicenseClasses.ClassName, Licenses.IssueDate, 
		                   Licenses.ExpirationDate, Licenses.IsActive
                           FROM Licenses INNER JOIN
                                LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID
                            where DriverID=@DriverID
                            Order By IsActive Desc, ExpirationDate Desc";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DriverId", DriverId);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }    
        
        public static DataTable GetAllInternationalLicensesForADriver(int PersonID)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataSetting.ConnectionString);

            string query = "SELECT FROM   Drivers INNER JOIN People ON Drivers.PersonID = People.PersonID INNER JOIN  Licenses ON Drivers.DriverID = Licenses.DriverID where Drivers.PersonID = @PersonID ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }
        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };
 

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass, DateTime IssueDate, DateTime ExpirationDate, 
            string Notes, Decimal PaidFees, bool IsActive,int IssueReason, int CreatedByUserID)
{
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataSetting.ConnectionString);

            string query = @"INSERT INTO [dbo].[Licenses]([ApplicationID],[DriverID],[LicenseClass],[IssueDate],[ExpirationDate],[Notes],[PaidFees],[IsActive],[IssueReason],[CreatedByUserID])
     VALUES
           (@ApplicationID,@DriverID,@LicenseClass ,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID);  SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);   


            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
 
            if (Notes != "" && Notes != null)
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", System.DBNull.Value);




            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return PersonID;
        }


    }


}
