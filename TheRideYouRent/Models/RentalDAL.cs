using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TheRideYouRent.Models
{
    public class RentalDAL
    {
        string connectionStringDEV = "Data Source=localhost;Initial Catalog=ST10291606POE;Integrated Security=True";
        //string connectionStringPROD = "Server=tcp:domingodb.database.windows.net,1433;Initial Catalog=DomingoDB;Persist Security Info=False;User ID=Tristan;Password=natsirT1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //Get All Rentals
        public IEnumerable<RentalModel> GetAllRentals()
        {
            List<RentalModel> rList = new List<RentalModel>();

            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("GetAllRentals", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RentalModel rental = new RentalModel();
                    rental.rentalID = Convert.ToInt32(dr["rentalID"].ToString());
                    rental.rentalFee = Convert.ToInt32(dr["rentalFee"].ToString());
                    rental.startDate = dr["startDate"].ToString();
                    rental.endDate = dr["endDate"].ToString();
                    rental.carNo = dr["carNo"].ToString();
                    rental.driverID = Convert.ToInt32(dr["driverID"].ToString());
                    rental.inspectorNo = dr["inspectorNo"].ToString();

                    rList.Add(rental);
                }
                con.Close();
            }

            return rList;
        }

        //Get Rental By RentalID
        public RentalModel GetRentalByRentalID(int? rentalID)
        {
            RentalModel rental = new RentalModel();
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("GetRental", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@rentalID", rentalID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    rental.rentalID = Convert.ToInt32(dr["rentalID"].ToString());
                    rental.rentalFee = Convert.ToInt32(dr["rentalFee"].ToString());
                    rental.startDate = dr["startDate"].ToString();
                    rental.endDate = dr["endDate"].ToString();
                    rental.carNo = dr["carNo"].ToString();
                    rental.driverID = Convert.ToInt32(dr["driverID"].ToString());
                    rental.inspectorNo = dr["inspectorNo"].ToString();
                }
                con.Close();
            }
            return rental;
        }

        //Create Rental
        public void CreateRental(RentalModel rental)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("CreateRental", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@rentalFee", rental.rentalFee);
                cmd.Parameters.AddWithValue("@startDate", rental.startDate);
                cmd.Parameters.AddWithValue("@endDate", rental.endDate);
                cmd.Parameters.AddWithValue("@carNo", rental.carNo);
                cmd.Parameters.AddWithValue("@driverID", rental.driverID);
                cmd.Parameters.AddWithValue("@inspectorNo", rental.inspectorNo);

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

        //Update Rental
        public void UpdateRental(RentalModel rental)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("UpdateRental", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@rentalID", rental.rentalID);
                cmd.Parameters.AddWithValue("@rentalFee", rental.rentalFee);
                cmd.Parameters.AddWithValue("@startDate", rental.startDate);
                cmd.Parameters.AddWithValue("@endDate", rental.endDate);
                cmd.Parameters.AddWithValue("@carNo", rental.carNo);
                cmd.Parameters.AddWithValue("@diverID", rental.driverID);
                cmd.Parameters.AddWithValue("@inspectorNo", rental.inspectorNo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //Delete Rental
        public void Delete(int? rentalID)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("DeleteRental", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@rentalID", rentalID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
