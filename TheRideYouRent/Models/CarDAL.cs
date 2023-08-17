using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TheRideYouRent.Models;

namespace TheRideYouRent.Models
{
    public class CarDAL
    {
        string connectionStringDEV = "Data Source=localhost;Initial Catalog=ST10291606POE;Integrated Security=True";
        //string connectionStringPROD = "Server=tcp:domingodb.database.windows.net,1433;Initial Catalog=DomingoDB;Persist Security Info=False;User ID=Tristan;Password=natsirT1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //Get All Cars
        public IEnumerable<CarModel> GetAllCars()
        {
            List<CarModel> cList = new List<CarModel>();

            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("GetAllCars", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    CarModel car = new CarModel();
                    car.carNo = dr["carNo"].ToString();
                    car.carMake = dr["carMake"].ToString();
                    car.carModel = dr["carModel"].ToString();
                    car.carBodyType = dr["carBodyType"].ToString();
                    car.kilometresTravelled = Convert.ToInt32(dr["kilometresTravelled"].ToString());
                    car.serviceKilometres = Convert.ToInt32(dr["serviceKilometres"].ToString());
                    car.available = dr["available"].ToString();

                    cList.Add(car);
                }
                con.Close();
            }

            return cList;
        }

        //Get Car By CarID
        public CarModel GetCarByCarID(string carNo)
        {
            CarModel car = new CarModel();
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("GetCar", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@carNo", carNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    car.carNo = dr["carNo"].ToString();
                    car.carMake = dr["carMake"].ToString();
                    car.carModel = dr["carModel"].ToString();
                    car.carBodyType = dr["carBodyType"].ToString();
                    car.kilometresTravelled = Convert.ToInt32(dr["kilometresTravelled"].ToString());
                    car.serviceKilometres = Convert.ToInt32(dr["serviceKilometres"].ToString());
                    car.available = dr["available"].ToString();

                }
                con.Close();
            }
            return car;
        }

        //Create car

        public void CreateCar(CarModel car)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("CreateCar", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@carNo", car.carNo);
                cmd.Parameters.AddWithValue("@carMake", car.carMake);
                cmd.Parameters.AddWithValue("@carModel", car.carModel);
                cmd.Parameters.AddWithValue("@carBodyType", car.carBodyType);
                cmd.Parameters.AddWithValue("@kilometresTravelled", car.kilometresTravelled);
                cmd.Parameters.AddWithValue("@serviceKilometres", car.serviceKilometres);
                cmd.Parameters.AddWithValue("@available", car.available);

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

        //Update Car
        public void UpdateCar(CarModel car)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("UpdateCar", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@carNo", car.carNo);
                cmd.Parameters.AddWithValue("@carMake", car.carMake);
                cmd.Parameters.AddWithValue("@carModel", car.carModel);
                cmd.Parameters.AddWithValue("@carBodyType", car.carBodyType);
                cmd.Parameters.AddWithValue("@kilometresTravelled", car.kilometresTravelled);
                cmd.Parameters.AddWithValue("@serviceKilometres", car.serviceKilometres);
                cmd.Parameters.AddWithValue("@available", car.available);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

            }
        }

        //Delete Car
        public void Delete(string carNo)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("DeleteCar", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@carNo", carNo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}

