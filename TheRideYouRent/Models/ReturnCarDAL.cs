using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TheRideYouRent.Models;

namespace TheRideYouRent.Models
{
    public class ReturnCarDAL
    {
        string connectionStringDEV = "Data Source=localhost;Initial Catalog=ST10291606POE;Integrated Security=True";
        //string connectionStringPROD = "Server=tcp:domingodb.database.windows.net,1433;Initial Catalog=DomingoDB;Persist Security Info=False;User ID=Tristan;Password=natsirT1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //Get All ReturnCars
        public IEnumerable<ReturnCarModel> GetAllReturnCars()
        {
            List<ReturnCarModel> cList = new List<ReturnCarModel>();

            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("GetAllReturnCars", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ReturnCarModel returnCar = new ReturnCarModel();
                    returnCar.returnCarID = Convert.ToInt32(dr["returnCarID"].ToString());
                    returnCar.returnDate = dr["returnDate"].ToString();
                    returnCar.elapsedDate = Convert.ToInt32(dr["elapsedDate"].ToString());
                    returnCar.carNo = dr["CarNo"].ToString();
                    returnCar.driverID = Convert.ToInt32(dr["driverID"].ToString());
                    returnCar.inspectorNo = dr["inspectorNo"].ToString();
                    returnCar.fineID = Convert.ToInt32(dr["fineID"].ToString());
                    returnCar.fineAmount = Convert.ToInt32(dr["fineAmount"].ToString());



                    cList.Add(returnCar);
                }
                con.Close();
            }

            return cList;
        }

        //Get ReturnCar By ReturnCarID
        public ReturnCarModel GetReturnCar(int? returnCarID)
        {
            ReturnCarModel returnCar = new ReturnCarModel();
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("GetReturnCar", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@returnCarID", returnCarID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    returnCar.returnCarID = Convert.ToInt32(dr["returnCarID"].ToString());
                    returnCar.returnDate = dr["returnDate"].ToString();
                    returnCar.elapsedDate = Convert.ToInt32(dr["elapsedDate"].ToString());
                    returnCar.carNo = dr["CarNo"].ToString();
                    returnCar.driverID = Convert.ToInt32(dr["driverID"].ToString());
                    returnCar.inspectorNo = dr["inspectorNo"].ToString();
                    returnCar.fineID = Convert.ToInt32(dr["fineID"].ToString());
                    

                }
                con.Close();
            }
            return returnCar;
        }

        //Create ReturnCar
        public void CreateReturnCar(ReturnCarModel returnCar)
        {
            //Calculate and add the fine amount to the model
            returnCar.fineAmount = returnCar.elapsedDate * 500;

            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("CreateReturnCar", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@returnDate", returnCar.returnDate);
                cmd.Parameters.AddWithValue("@elapsedDate", returnCar.elapsedDate);
                cmd.Parameters.AddWithValue("@carNo", returnCar.carNo);
                cmd.Parameters.AddWithValue("@driverID", returnCar.driverID);
                cmd.Parameters.AddWithValue("@inspectorNo", returnCar.inspectorNo);
                cmd.Parameters.AddWithValue("@fineID", returnCar.fineID);
                cmd.Parameters.AddWithValue("@fineAmount", returnCar.fineAmount);

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

        //Update ReturnCar
        public void UpdateReturnCar(ReturnCarModel returnCar)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("UpdateReturnCar", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@returnCarID", returnCar.returnCarID);
                cmd.Parameters.AddWithValue("@returnDate", returnCar.returnDate);
                cmd.Parameters.AddWithValue("@elapsedDate", returnCar.elapsedDate);
                cmd.Parameters.AddWithValue("@carNo", returnCar.carNo);
                cmd.Parameters.AddWithValue("@driverID", returnCar.driverID);
                cmd.Parameters.AddWithValue("@inspectorNo", returnCar.inspectorNo);
                cmd.Parameters.AddWithValue("@fineID", returnCar.fineID);
                cmd.Parameters.AddWithValue("@fineAmount", returnCar.fineAmount);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Delete ReturnCar
        public void Delete(int? returnCarID)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("DeleteReturnCar", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@returnCarID", returnCarID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
