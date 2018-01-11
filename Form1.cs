using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string GetSQLString()
        {
            string sSQL = "SELECT ROW_ID,NAME,CELL_NUM,STATIONARY_NUM,BIRTH_DATE FROM FIO_PhoneBook WHERE NAME<>'' ";
            if (FIO.Text != "") sSQL += " AND NAME LIKE '%" + FIO.Text + "%'";
            if (MobileNum.Text != "") sSQL += " AND CELL_NUM LIKE '%" + MobileNum.Text + "%'";
            if (HomeNum.Text != "") sSQL += " AND STATIONARY_NUM LIKE '%" + HomeNum.Text + "%'";
            if (BDate.Text != "") sSQL += " AND BIRTH_DATE LIKE '%" + BDate.Text + "%'";

            sSQL += " ORDER BY NAME";
            return sSQL;
        }
        private void SelectDataFromDB()
        {
            String sSQL = GetSQLString();
            String sConnectionString = "Database=TestDB;Data Source=localhost;User Id=root;Password=qwerty789";
            MySqlLib.MySqlData.MySqlExecuteData.MyResultData result = new MySqlLib.MySqlData.MySqlExecuteData.MyResultData();
            result = MySqlLib.MySqlData.MySqlExecuteData.SqlReturnDataset(sSQL, sConnectionString);
            if (result.HasError == false)
            {
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = result.ResultData.DefaultView;
            }
            else
            {
                MessageBox.Show(result.ErrorText);
            }
        }
        private string GetInsertSQL()
        {
            string sSQL = "INSERT INTO FIO_PhoneBook (NAME,CELL_NUM,STATIONARY_NUM,BIRTH_DATE) VALUES (";
            sSQL += "'" + FIO.Text + "',";
            sSQL += "'" + MobileNum.Text + "',";
            sSQL += "'" + HomeNum.Text + "',";
            sSQL += "'" + BDate.Text + "')";
            return sSQL;
        }
        private string GetDeleteSQL()
        {
            string sSQL = "DELETE FROM FIO_PhoneBook WHERE NAME<>'' ";
            if (FIO.Text != "") sSQL += " AND NAME LIKE '%" + FIO.Text + "%'";
            if (MobileNum.Text != "") sSQL += " AND CELL_NUM LIKE '%" + MobileNum.Text + "%'";
            if (HomeNum.Text != "") sSQL += " AND STATIONARY_NUM LIKE '%" + HomeNum.Text + "%'";
            if (BDate.Text != "") sSQL += " AND BIRTH_DATE LIKE '%" + BDate.Text + "%'";
            return sSQL;
        }

        private void button2_Click(object sender, EventArgs e) ///Write
        {
            string sSQL = "";
            String sConnectionString = "Database=TestDB;Data Source=localhost;User Id=root;Password=qwerty789";
            sSQL = GetInsertSQL();
            MySqlLib.MySqlData.MySqlExecute.SqlNoneQuery(sSQL, sConnectionString);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
              
        private void button1_Click(object sender, EventArgs e) ///Find
        {
            SelectDataFromDB();        
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                String sConnectionString = "Database=TestDB;Data Source=localhost;User Id=root;Password=qwerty789";
                MySqlLib.MySqlData.MySqlExecute.SqlNoneQuery("DELETE FROM FIO_PhoneBook WHERE ROW_ID=" + dataGridView1.CurrentCell.Value.ToString(), sConnectionString);
                SelectDataFromDB();
            }
        }
        private void FIO_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
