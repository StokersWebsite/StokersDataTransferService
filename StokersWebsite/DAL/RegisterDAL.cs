using System.Data.SqlClient;
using System.Data;
using DTOLayer;
using AbstractionLayer;

namespace DataLayer
{
    //public List<MemberDTO> members = new List<MemberDTO>();
    public class RegisterDAL : IMembersData
    {
        static public SqlConnection? sc;
        static string ConnectionString = "Data Source=DELL-XPS-15;Initial Catalog=Stokers;Integrated Security=True";

        public RegisterDAL()
        {
            sc = new SqlConnection();
            sc.ConnectionString = ConnectionString;
        }

        public List<MemberDTO>? Read()
        {
            //new klant list aanmaken
            List<MemberDTO> result = new List<MemberDTO>();

            // Creeër een nieuw SqlConnection Object met de connectionString
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //sql query
                    string sqlQuery = "SELECT * FROM members";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        //open de sql connectie 
                        connection.Open();

                        // Voer het SqlCommand uit
                        SqlDataReader reader = command.ExecuteReader();

                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        List<MemberDTO> members = new List<MemberDTO>();

                        foreach (DataRow row in dt.Rows)
                        {
                            members.Add(new MemberDTO()
                            {
                                Firstname = (string)row["FirstName"],
                                Lastname = (string)row["LastName"],
                                PhoneNumber = (string)row["PhoneNumber"],
                                Birthdate = (DateOnly)row["Birthdate"],
                                Adress = (string)row["Adress"],
                                PostalCode = (string)row["PostalCode"],
                            }) ;
                            //test
                        }
                        return members;
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

        public int RegisterMember(MemberDTO memberDTO)
        {


            // Upload naar database logica
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    //sql query
                    string sqlQuery = "INSERT INTO members VALUES (@FirstName, @LastName, @PhoneNumber, @Birthdate, @Adress, @PostalCode) SELECT SCOPE_IDENTITY()";

                    SqlParameter firstNameParam = new SqlParameter("FirstName", System.Data.SqlDbType.VarChar) { Value = memberDTO.Firstname };
                    SqlParameter lastNameParam = new SqlParameter("LastName", System.Data.SqlDbType.VarChar) { Value = memberDTO.Lastname };
                    SqlParameter phoneNumberParam = new SqlParameter("PhoneNumber", System.Data.SqlDbType.VarChar) { Value = memberDTO.PhoneNumber };
                    SqlParameter birthdateParam = new SqlParameter("Birthdate", System.Data.SqlDbType.VarChar) { Value = memberDTO.Birthdate };
                    SqlParameter adressParam = new SqlParameter("Adress", System.Data.SqlDbType.VarChar) { Value = memberDTO.Adress };
                    SqlParameter postalCodeParam = new SqlParameter("PostalCode", System.Data.SqlDbType.VarChar) { Value = memberDTO.PostalCode };


                    using (SqlCommand command = CommandBuilder(sqlQuery, firstNameParam, lastNameParam, phoneNumberParam, birthdateParam, adressParam, postalCodeParam))
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
                //loggen
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