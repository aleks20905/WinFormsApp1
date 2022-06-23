using System;
using System.Data;
using FormUI;
using Npgsql;

namespace WinFormsApp1 {
    public partial class Dashboard : Form {

        private string id = "";
        private int  intRow = 0;


        public Dashboard() {
            InitializeComponent();
            restMe();
        }

        private void Dashboard_Load(object sender, EventArgs e) {
            LoadData("");

        }
        private void restMe() {//reset everyting
            this.id = string.Empty;
            FirstNameBox.Text = " ";
            phoneNumberBox.Text = " "; 
            typeOfServicesBox.Text = " ";
            hoursBox.Text = "";
            minutsBox.Text = "";


            listBox.Clear();
            if (listBox.CanSelect) {
                listBox.Select();
            }
        } 

        private void LoadData(string keyword) {

            DataAccess.sql = "SELECT userid, firstname, phonenumber, typeofservices, datetime FROM \"Users\"" +
                "WHERE CONCAT(CAST(userid as varchar), '',firstname, '', phonenumber, '', typeofservices, '', datetime) LIKE @keyword::varchar ORDER BY userid ASC "; //SELECT
            


            string strKeyword = string.Format("%{0}%", keyword);

            DataAccess.cmd = new NpgsqlCommand(DataAccess.sql, DataAccess.con);
            DataAccess.cmd.Parameters.Clear();
            DataAccess.cmd.Parameters.AddWithValue("keyword", strKeyword);

            DataTable dt = DataAccess.performCRUD(DataAccess.cmd);

            if (dt.Rows.Count > 0) {
                intRow = Convert.ToInt32(dt.Rows.Count.ToString());
            }
            else {
                intRow = 0;

            }

            toolStripStatusLabel1.Text = "Numbers of row(s):" + intRow.ToString();

            DataGridView dg1 = dataGridView1; // ############### data GRID #######################
            dg1.MultiSelect = false;
            dg1.AutoGenerateColumns = true;
            dg1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dg1.DataSource = dt;

            dg1.Columns[0].HeaderText = "ID";
            dg1.Columns[1].HeaderText = "firstName";
            dg1.Columns[2].HeaderText = "phoneNumber";
            dg1.Columns[3].HeaderText = "typeOfServices";
            dg1.Columns[4].HeaderText = "dateTime";

            dg1.Columns[0].Width = 45;
            dg1.Columns[1].Width = 100;
            dg1.Columns[2].Width = 140;
            dg1.Columns[3].Width = 250;
            dg1.Columns[4].Width = 250;// ############### data GRID ############################





        }  


        private void execute(string mySQL, string param) {

            DataAccess.cmd = new NpgsqlCommand(mySQL, DataAccess.con);
            AddParam(param);
            DataAccess.performCRUD(DataAccess.cmd);


        }

        private void AddParam(string str) {

            DataAccess.cmd.Parameters.Clear();
            DataAccess.cmd.Parameters.AddWithValue("firstName", FirstNameBox.Text.Trim());
            DataAccess.cmd.Parameters.AddWithValue("phoneNumberBox", phoneNumberBox.Text.Trim());
            DataAccess.cmd.Parameters.AddWithValue("typeOfServices", typeOfServicesBox.Text.Trim());
            DataAccess.cmd.Parameters.AddWithValue("dateTime", setTime());
            
            if (str == "Update" || str == "Delete" && !string.IsNullOrEmpty(this.id)) {
                DataAccess.cmd.Parameters.AddWithValue("id", this.id);
            }

        }  

        private void button1_Click(object sender, EventArgs e) {

            if (string.IsNullOrEmpty(FirstNameBox.Text.Trim())|| string.IsNullOrEmpty(phoneNumberBox.Text.Trim())|| string.IsNullOrEmpty(typeOfServicesBox.Text.Trim())) {
                MessageBox.Show("plese input FName, LName & typeOfServices");
                return;
            }
            DataAccess.sql = "INSERT INTO \"Users\" (firstname, phonenumber, typeofservices, datetime) VALUES(@firstName, @phoneNumberBox, @typeOfServices, @dateTime) ";


            execute(DataAccess.sql,"Insert");

            MessageBox.Show("Record has been saved ");

            LoadData("");

            restMe();

        }  


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex != -1) {
                DataGridView dg1 = dataGridView1;

                this.id = Convert.ToString(dg1.CurrentRow.Cells[0].Value);
                updateButton.Text = "Update (" + this.id + ")";
                deleteButton.Text = "Delete (" + this.id + ")";

                FirstNameBox.Text = Convert.ToString(dg1.CurrentRow.Cells[1].Value);
                phoneNumberBox.Text = Convert.ToString(dg1.CurrentRow.Cells[2].Value);
                typeOfServicesBox.Text = Convert.ToString(dg1.CurrentRow.Cells[3].Value);
                dateTimePicker.Text = Convert.ToString(dg1.CurrentRow.Cells[4].Value);

            }

        }  

        private void updateButton_Click(object sender, EventArgs e) {
            if (dataGridView1.Rows.Count == 0) return;

            if (string.IsNullOrEmpty(this.id)) {
                MessageBox.Show("Please select an item from the list. : ","update data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (string.IsNullOrEmpty(FirstNameBox.Text.Trim()) || string.IsNullOrEmpty(phoneNumberBox.Text.Trim()) || string.IsNullOrEmpty(typeOfServicesBox.Text.Trim()) || string.IsNullOrEmpty(dateTimePicker.Text.Trim())) {
                MessageBox.Show("plese input FName, LName & typeOfServices");
                return;
            }
            //dateTimePicker.Value = new DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month, dateTimePicker.Value.Day, 12, 0, 0); //  time setting
            
           
            
            DataAccess.sql = "UPDATE \"Users\" SET firstName = @firstName, phonenumber = @phoneNumberBox, typeofservices = @typeOfServices, datetime = @dateTime WHERE userid = @id::integer";

            MessageBox.Show("fak: " + setTime().ToString() + "    " + DataAccess.sql); // debug
            execute(DataAccess.sql, "Update");

            MessageBox.Show("Tte record has been updated : ", "update data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            LoadData("");

            restMe();


        }  

        private void deleteButton_Click(object sender, EventArgs e) {

            if (dataGridView1.Rows.Count == 0) return;

            if (string.IsNullOrEmpty(this.id)) {
                MessageBox.Show("Please select an item from the list. : ", "update data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (string.IsNullOrEmpty(FirstNameBox.Text.Trim()) || string.IsNullOrEmpty(phoneNumberBox.Text.Trim()) || string.IsNullOrEmpty(typeOfServicesBox.Text.Trim()) || string.IsNullOrEmpty(dateTimePicker.Text.Trim())) {
                MessageBox.Show("plese select the record");
                return;
            }

            if (MessageBox.Show("Do you want to permanently delete the selected record","Detete data ",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)==DialogResult.Yes) {

                DataAccess.sql = "DELETE FROM \"Users\" WHERE userid = @id::integer";

                //MessageBox.Show("fak: " + this.id +"    " + DataAccess.sql); // debug
                execute(DataAccess.sql, "Delete");

                MessageBox.Show("The record has been deleted : ", "delete data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                LoadData("");

                restMe();

            }




        }
        private DateTime setTime() {

            if (string.IsNullOrEmpty(hoursBox.Text.Trim()) && string.IsNullOrEmpty(minutsBox.Text.Trim()))
                return new DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month, dateTimePicker.Value.Day, 12, 0, 0);

            if (string.IsNullOrEmpty(minutsBox.Text.Trim()))
                return new DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month, dateTimePicker.Value.Day, Convert.ToInt32(hoursBox.Text.Trim()), 0, 0);

            

            return new DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month, dateTimePicker.Value.Day, Convert.ToInt32(hoursBox.Text.Trim()) , Convert.ToInt32(minutsBox.Text.Trim()), 0);
        }

        private void searchButton_Click(object sender, EventArgs e) {

            if (string.IsNullOrEmpty(listBox.Text.Trim())) {

                LoadData("");

            }
            else {

                LoadData(listBox.Text.Trim());
                
                

            }

            restMe();
        }

        private void searchByDateButton_Click(object sender, EventArgs e) {

            LoadData(dateTimePicker.Value.Year.ToString() + "-" + validString(dateTimePicker.Value.Month.ToString()) + "-" + validString(dateTimePicker.Value.Day.ToString()) );
           // MessageBox.Show(dateTimePicker.Value.Year.ToString() + "-" + validString(dateTimePicker.Value.Month.ToString()) + "-" + validString(dateTimePicker.Value.Day.ToString())); // debug

            restMe();

        }
        private string validString(string str) {
            
            if (str.Length<2)  return "0"+str;
            
            return str;
        }
    }
}