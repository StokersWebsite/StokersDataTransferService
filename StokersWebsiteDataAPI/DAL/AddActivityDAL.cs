using System.Data.SqlClient;
using System.Data;
using DTOLayer;
using AbstractionLayer;

namespace DataLayer
{
    //public List<MemberDTO> members = new List<MemberDTO>();
    public class AddActivityDAL : IActivityData
    {
        static public SqlConnection? sc;
        static string ConnectionString = "Server=mssql.fhict.local;Database=Stokers;";

        public AddActivityDAL()
        {
            sc = new SqlConnection();
            sc.ConnectionString = ConnectionString;
        }

        public List<ActivityDTO>? Read()
        {
            //new klant list aanmaken
            List<ActivityDTO> result = new List<ActivityDTO>();

            // Creeër een nieuw SqlConnection Object met de connectionString
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //sql query
                    string sqlQuery = "SELECT * FROM Activity";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        //open de sql connectie 
                        connection.Open();

                        // Voer het SqlCommand uit
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        List<ActivityDTO> Events = new List<ActivityDTO>();

                        foreach (DataRow row in dt.Rows)
                        {
                            Events.Add(new ActivityDTO()
                            {
                                name = (string)row["name"],
                                description = (string)row["description"],
                                date = (DateOnly)row["date"],
                                location = (string)row["location"],
                                MaxMembers = (string)row["maxMembers"],
                            }) ;
                        }
                        return Events;
                    }
                }
            }
            //Vangt de mogelijke fouten op en toont een melding 
            catch (SqlException sqlError)
            {
                //toont een sqlError met de fout
                return null;
            }
        }

        public int AddAcitivtyDAL(ActivityDTO activityDTO)
        { 
            // Upload naar database logica
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //sql query
                    string sqlQuery = "INSERT INTO activities VALUES (@name, @description, @date, @location, @maxMembers) SELECT SCOPE_IDENTITY()";

                    SqlParameter nameParam = new SqlParameter("Name", System.Data.SqlDbType.VarChar) { Value = activityDTO.name };
                    SqlParameter descriptionParam = new SqlParameter("Description", System.Data.SqlDbType.VarChar) { Value = activityDTO.description };
                    SqlParameter dateParam = new SqlParameter("Date", System.Data.SqlDbType.VarChar) { Value = activityDTO.date };
                    SqlParameter locationParam = new SqlParameter("Location", System.Data.SqlDbType.VarChar) { Value = activityDTO.location };
                    SqlParameter maxMembersParam = new SqlParameter("MaxMembers", System.Data.SqlDbType.VarChar) { Value = activityDTO.MaxMembers };


                    using (SqlCommand command = CommandBuilder(sqlQuery, nameParam, descriptionParam, dateParam, locationParam, maxMembersParam))
                    {
                        //open de sql connectie
                        connection.Open();

                        // Voer het SqlCommand uit
                        int rowID = Convert.ToInt32(command.ExecuteScalar());
                        return rowID;
                    }
                   
                }
            }
            //Vangt de mogelijke fouten op en toont een melding 
            catch (SqlException sqlError)
            {
                Console.WriteLine(sqlError.Message);
                return 0;
            }

        }
        protected static SqlCommand CommandBuilder(string baseQuery, params SqlParameter[] parameters)
        {
            SqlCommand sqlCommand = new(baseQuery);
            foreach (SqlParameter sqlParameter in parameters)
            {
                sqlCommand.Parameters.Add(sqlParameter);
            }
            return sqlCommand;
        }
    }
}