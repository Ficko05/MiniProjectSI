using RestTest.Models;
using System.Data.SqlClient;
using System.Web.Http;
using System.Web.Mvc;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace RestTest.Controllers
{
    public class ProfileController : ApiController
    {
        // GET: api/Profile
        public IHttpActionResult Get()
        {
            List<Profile> profiles = new List<Profile>();

            string connetionString;
            SqlConnection conn;
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(connetionString);
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Profiles", conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                // while there is another record present
                while (reader.Read())
                {
                    profiles.Add(new Profile(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString()));
                }
            }
            conn.Close();

            return Json(profiles);
        }

        // GET: api/Profile/5
        public IHttpActionResult Get(int id)
        {
            Profile profile = null;

            string connetionString;
            SqlConnection conn;
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(connetionString);
            conn.Open();

            SqlCommand command = new SqlCommand("SELECT * FROM Profiles WHERE Id="  + id, conn);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                // while there is another record present
                while (reader.Read())
                {
                    profile = new Profile(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString());
                }
            }
            conn.Close();

            return Json(profile);
        }


        // POST: api/Profile
        public IHttpActionResult Post([FromBody]Profile jsonBody)
        {
            Profile newProfile  = jsonBody;

            string connetionString;
            SqlConnection conn;
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(connetionString);
            conn.Open();

            string query = "INSERT INTO Profiles (Name,Phone,Country) VALUES (@name,@phone, @country)";

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@name", newProfile.Name);
                command.Parameters.AddWithValue("@phone", newProfile.Phone);
                command.Parameters.AddWithValue("@country", newProfile.Country);

                int result = command.ExecuteNonQuery();
            }
            conn.Close();

            return Json(new JsonResponseMessage(200, "Profile added"));
        }

        // PUT: api/Profile/5
        public IHttpActionResult Put(int id, [FromBody]Profile jsonBody)
        {
            Profile newProfile = jsonBody;

            string connetionString;
            SqlConnection conn;
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(connetionString);
            conn.Open();

            string query = "UPDATE Profiles SET Name = @name, Phone = @phone, Country = @country WHERE Id =" + id;

            using (SqlCommand command = new SqlCommand(query, conn))
            {
                command.Parameters.AddWithValue("@name", newProfile.Name);
                command.Parameters.AddWithValue("@phone", newProfile.Phone);
                command.Parameters.AddWithValue("@country", newProfile.Country);

                int result = command.ExecuteNonQuery();
            }
            conn.Close();

            return Json(new JsonResponseMessage(200, "Profile updated"));
        }

        // DELETE: api/Profile/5
        public IHttpActionResult Delete(int id)
        {
            string connetionString;
            SqlConnection conn;
            connetionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(connetionString);
            conn.Open();
            string query = "Delete FROM Profiles WHERE Id =" + id;

            SqlCommand command = new SqlCommand(query, conn);

            int result = command.ExecuteNonQuery();
            
            conn.Close();

            return Json(new JsonResponseMessage(200, "Profile deleted"));
        }
    }
}
