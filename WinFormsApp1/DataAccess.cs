using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Npgsql;

namespace FormUI {
    public class DataAccess {
        public static NpgsqlConnection con = new NpgsqlConnection(Helper.ConnString());
        public static NpgsqlCommand cmd = default(NpgsqlCommand);
        public static string sql = string.Empty;

        public static DataTable performCRUD(NpgsqlCommand com) {
            NpgsqlDataAdapter da = default(NpgsqlDataAdapter);
            DataTable dt = new DataTable();

            try {
                da = new NpgsqlDataAdapter();
                da.SelectCommand = com;
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex) {

                MessageBox.Show( "EROR etc occured : "+ex.Message," fail ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                dt = null;
                
            }
            return dt;
        }



        






    }
}


