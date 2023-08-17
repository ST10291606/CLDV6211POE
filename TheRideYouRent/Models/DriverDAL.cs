using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TheRideYouRent.Models;

namespace TheRideYouRent.Models
{
    public class DriverDAL
    {
        string connectionStringDEV = "Data Source=localhost;Initial Catalog=ST10291606POE;Integrated Security=True";
        //string connectionStringPROD = "Server=tcp:domingodb.database.windows.net,1433;Initial Catalog=DomingoDB;Persist Security Info=False;User ID=Tristan;Password=natsirT1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //Get All Drivers
        public IEnumerable<DriverModel> GetAllDrivers()
        {
            List<DriverModel> dList = new List<DriverModel>();

            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("GetAllDrivers", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DriverModel driver = new DriverModel();
                    driver.driverID = Convert.ToInt32(dr["driverID"].ToString());
                    driver.name = dr["name"].ToString();
                    driver.surname = dr["surname"].ToString();
                    driver.email = dr["email"].ToString();
                    driver.mobileNo = dr["mobileNo"].ToString();
                    driver.address = dr["address"].ToString();

                    dList.Add(driver);
                }
                con.Close();
            }

            return dList;
        }

        //Get Driver By DriverID
        public DriverModel GetDriverByDriverID(int? driverID)
        {
            DriverModel driver = new DriverModel();
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("GetDriver", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@driverID", driverID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    driver.driverID = Convert.ToInt32(dr["driverID"].ToString());
                    driver.name = dr["name"].ToString();
                    driver.surname = dr["surname"].ToString();
                    driver.email = dr["email"].ToString();
                    driver.mobileNo = dr["mobileNo"].ToString();
                    driver.address = dr["address"].ToString();
                }
                con.Close();
            }
            return driver;
        }

        //Create driver

        public void CreateDriver(DriverModel driver)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("CreateDriver", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", driver.name);
                cmd.Parameters.AddWithValue("@surname", driver.surname);
                cmd.Parameters.AddWithValue("@email", driver.email);
                cmd.Parameters.AddWithValue("@mobileNo", driver.mobileNo);
                cmd.Parameters.AddWithValue("@address", driver.address);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                }
                con.Close();

            }
        }

        //Update Driver
        public void UpdateDriver(DriverModel drv)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("UpdateDriver", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@driverID", drv.driverID);
                cmd.Parameters.AddWithValue("@name", drv.name);
                cmd.Parameters.AddWithValue("@surname", drv.surname);
                cmd.Parameters.AddWithValue("@email", drv.email);
                cmd.Parameters.AddWithValue("@mobileNo", drv.mobileNo);
                cmd.Parameters.AddWithValue("@address", drv.address);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //Delete Driver
        public void Delete(int? driverID)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("DeleteDriver", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@driverID", driverID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
