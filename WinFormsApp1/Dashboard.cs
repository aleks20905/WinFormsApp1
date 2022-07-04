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
            trainIDBox.Text = " "; // to do
            trainNameBox.Text = " "; 
            typeOfTrainBox.Text = " ";
            vagoniBox.Text = " "; 



            listBox.Clear();
            if (listBox.CanSelect) {
                listBox.Select();
            }
        } 

        private void LoadData(string keyword) {

            DataAccess.sql = "SELECT trainid, name, type, vagoni FROM \"train\"" +
                "WHERE CONCAT(CAST(trainid as varchar), '',name, '', type, '', CAST(vagoni as varchar)) LIKE @keyword::varchar ORDER BY trainid ASC "; //SELECT
            


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
            dg1.Columns[1].HeaderText = "trainName";
            dg1.Columns[2].HeaderText = "train type";
            dg1.Columns[3].HeaderText = "vagoni";
           


            dg1.Columns[0].Width = 100;
            dg1.Columns[1].Width = 200;
            dg1.Columns[2].Width = 100;
            dg1.Columns[3].Width = 100;// ############### data GRID ############################





        }  


        private void execute(string mySQL, string param) {

            DataAccess.cmd = new NpgsqlCommand(mySQL, DataAccess.con);
            AddParam(param);
            DataAccess.performCRUD(DataAccess.cmd);


        }

        private void AddParam(string str) {

           

            DataAccess.cmd.Parameters.Clear();
            DataAccess.cmd.Parameters.AddWithValue("id", Convert.ToInt32(trainIDBox.Text.Trim()));
            DataAccess.cmd.Parameters.AddWithValue("name", trainNameBox.Text.Trim());
            DataAccess.cmd.Parameters.AddWithValue("type", typeOfTrainBox.Text.Trim());
            DataAccess.cmd.Parameters.AddWithValue("vagoni", Convert.ToInt32(vagoniBox.Text.Trim()));


            //if (str == "Update" || str == "Delete" && !string.IsNullOrEmpty(this.id)) {
            //    DataAccess.cmd.Parameters.AddWithValue("id", this.id);
            //}

        }  

        private void button1_Click(object sender, EventArgs e) {

            if (string.IsNullOrEmpty(trainIDBox.Text.Trim())|| string.IsNullOrEmpty(trainNameBox.Text.Trim())|| string.IsNullOrEmpty(typeOfTrainBox.Text.Trim()) || string.IsNullOrEmpty(vagoniBox.Text.Trim()) ) {
                MessageBox.Show("plese input FName, LName & typeOfServices");
                return;
            }
            DataAccess.sql = "INSERT INTO \"train\" (trainid, name, type, vagoni) VALUES(@id, @name, @type, @vagoni) ";


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

                trainIDBox.Text = Convert.ToString(dg1.CurrentRow.Cells[0].Value); // id
                trainNameBox.Text = Convert.ToString(dg1.CurrentRow.Cells[1].Value); // name
                typeOfTrainBox.Text = Convert.ToString(dg1.CurrentRow.Cells[2].Value); // type
                vagoniBox.Text = Convert.ToString(dg1.CurrentRow.Cells[3].Value);//vagoni

                
            }

        }  

        private void updateButton_Click(object sender, EventArgs e) {
            if (dataGridView1.Rows.Count == 0) return;

            if (string.IsNullOrEmpty(this.id)) {
                MessageBox.Show("Please select an item from the list. : ","update data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            if (string.IsNullOrEmpty(trainIDBox.Text.Trim()) || string.IsNullOrEmpty(trainNameBox.Text.Trim()) || string.IsNullOrEmpty(typeOfTrainBox.Text.Trim()) || string.IsNullOrEmpty(vagoniBox.Text.Trim())) {
                MessageBox.Show("plese input FName, LName & typeOfServices");
                return;
            }
            //dateTimePicker.Value = new DateTime(dateTimePicker.Value.Year, dateTimePicker.Value.Month, dateTimePicker.Value.Day, 12, 0, 0); //  time setting
            
           
            
            DataAccess.sql = "UPDATE \"train\" SET  name = @name, type = @type, vagoni = @vagoni WHERE trainid = @id::integer"; //  ??

            //MessageBox.Show("fak: " + setTime().ToString() + "    " + DataAccess.sql); // debug
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

            if (string.IsNullOrEmpty(trainIDBox.Text.Trim()) || string.IsNullOrEmpty(trainNameBox.Text.Trim()) || string.IsNullOrEmpty(typeOfTrainBox.Text.Trim()) || string.IsNullOrEmpty(vagoniBox.Text.Trim()) ) {
                MessageBox.Show("plese select the record");
                return;
            }

            if (MessageBox.Show("Do you want to permanently delete the selected record","Detete data ",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1)==DialogResult.Yes) {

                DataAccess.sql = "DELETE FROM \"train\" WHERE trainid = @id::integer";

                //MessageBox.Show("fak: " + this.id +"    " + DataAccess.sql); // debug
                execute(DataAccess.sql, "Delete");

                MessageBox.Show("The record has been deleted : ", "delete data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                LoadData("");

                restMe();

            }




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

       
       
    }
}