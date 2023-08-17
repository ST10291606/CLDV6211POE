using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TheRideYouRent.Models;

namespace TheRideYouRent.Models
{
    public class InspectorDAL
    {
        string connectionStringDEV = "Data Source=localhost;Initial Catalog=ST10291606POE;Integrated Security=True";
        //string connectionStringPROD = "Server=tcp:domingodb.database.windows.net,1433;Initial Catalog=DomingoDB;Persist Security Info=False;User ID=Tristan;Password=natsirT1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //Get All Inspectors
        public IEnumerable<InspectorModel> GetAllInspectors()
        {
            List<InspectorModel> iList = new List<InspectorModel>();

            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("GetAllInspectors", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    InspectorModel inspector = new InspectorModel();
                    inspector.inspectorNo = dr["inspectorNo"].ToString();
                    inspector.name = dr["name"].ToString();
                    inspector.surname = dr["surname"].ToString();
                    inspector.email = dr["email"].ToString();
                    inspector.mobileNo = dr["mobileNo"].ToString();
                    

                    iList.Add(inspector);
                }
                con.Close();
            }

            return iList;
        }

        //Get Inspector By InspectorID
        public InspectorModel GetInspectorByInspectorID(string inspectorNo)
        {
            InspectorModel inspector = new InspectorModel();
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("GetInspector", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@inspectorNo", inspectorNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    inspector.inspectorNo = dr["inspectorNo"].ToString();
                    inspector.name = dr["name"].ToString();
                    inspector.surname = dr["surname"].ToString();
                    inspector.email = dr["email"].ToString();
                    inspector.mobileNo = dr["mobileNo"].ToString();


                }
                con.Close();
            }
            return inspector;
        }

        //Create Inspector
        public void CreateInspector(InspectorModel inspector)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("CreateInspector", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@inspectorNo", inspector.inspectorNo);
                cmd.Parameters.AddWithValue("@name", inspector.name);
                cmd.Parameters.AddWithValue("@surname", inspector.surname);
                cmd.Parameters.AddWithValue("@email", inspector.email);
                cmd.Parameters.AddWithValue("@mobileNo", inspector.mobileNo);

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

        //Update Inspector
        public void UpdateInspector(InspectorModel insp)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("UpdateInspector", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@inspectorNo", insp.inspectorNo);
                cmd.Parameters.AddWithValue("@name", insp.name);
                cmd.Parameters.AddWithValue("@surname", insp.surname);
                cmd.Parameters.AddWithValue("@email", insp.email);
                cmd.Parameters.AddWithValue("@mobileNo", insp.mobileNo);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //Delete Inspector
        public void Delete(string inspectorNo)
        {
            using (SqlConnection con = new SqlConnection(connectionStringDEV))
            {
                SqlCommand cmd = new SqlCommand("DeleteInspector", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@inspectorNo", inspectorNo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
