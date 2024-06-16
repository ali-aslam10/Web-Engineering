using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Assignment01
{
    class Voter
    {
        private string voterName;
        private string cnic;
        private string selectedPartyName;
        public Voter(string VoterName,string Cnic,string SelectedPartyName)   //names of paprameter slightly change to prevent conflicts
        {
            voterName = VoterName;
            cnic = Cnic;
            selectedPartyName = SelectedPartyName;
        }
        public string VoterName 
        {
            get { return voterName; } 
            set { voterName = value; }
        }
        public string Cnic 
        {
            get { return cnic; } 
            set { cnic = value; } 
        }
        public string SelectedPartyName 
        { 
            get { return selectedPartyName; }
            set { selectedPartyName = value; }
        }
        public bool hasVoted(string cnic)
        {
        
            SqlConnection connection = new SqlConnection(ConnectionString.connectionstr);
            try
            {
                connection.Open();
                
                string query = "select * from Voters where CNIC='" + cnic + "'";
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (!dr.HasRows)  //voter not exist 
                {
                    dr.Close();
                    return true;  //just to make senese that no to cast vote for that voter
                }
                dr.Read();
                if (dr["VoterName"].ToString() != voterName.ToUpper())
                    return true;
                if (string.IsNullOrEmpty(dr["SelectedPartyName"].ToString())) //if not cast Vote
                {
                    dr.Close();
                    return false;
                }
                else
                {
                    dr.Close();
                    return true;
                }

            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine("Error: " + ex.Message);
                System.Environment.Exit(0);
                return true;
            }
            finally
            {
                // Ensure the connection is closed
                connection.Close();
            }
            
        }
    }
}
