using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using System.Configuration;
using System.Xml.Serialization;
using System.Threading;
using Microsoft.Win32;

namespace Dipml
{
    public partial class MainWindow : Form
    {
        UserCredential credential;
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        private BindingSource bSource = new BindingSource();
        private DataSet ds = new DataSet();
        private DataTable table = new DataTable();
        string idSelectedRow = "0";


        public MainWindow()
        {
            InitializeComponent();
        }
        MySqlConnection conn;
        private void Form1_Load(object sender, EventArgs e)
        {
            DB.Connection connection = new DB.Connection();
            conn = new MySqlConnection(connection.connStr);

            //GetListClients();

            //dataGridView1.Columns[0].Visible = true;
            //dataGridView1.Columns[1].Visible = true;
            //dataGridView1.Columns[3].Visible = true;
            //dataGridView1.Columns[4].Visible = true;

            //dataGridView1.Columns[0].FillWeight = 15;
            //dataGridView1.Columns[1].FillWeight = 40;
            //dataGridView1.Columns[2].FillWeight = 15;
            //dataGridView1.Columns[3].FillWeight = 15;
            //dataGridView1.Columns[4].FillWeight = 15;


            //dataGridView1.Columns[0].ReadOnly = true;
            //dataGridView1.Columns[1].ReadOnly = true;
            //dataGridView1.Columns[2].ReadOnly = true;
            //dataGridView1.Columns[3].ReadOnly = true;
            //dataGridView1.Columns[4].ReadOnly = true;


            //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //dataGridView1.RowHeadersVisible = false;
            //dataGridView1.ColumnHeadersVisible = true;
        }
        public void GetListClients()
        {
            string commandStr = "SELECT id_doc as 'id', name_doc AS 'Название документа', document_code AS 'Код'," +
                                "document_category AS 'Категория', creation_date AS 'Дата создания' FROM T_documents";
            conn.Open();
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            MyDA.Fill(table);
            bSource.DataSource = table;
            dataGridView1.DataSource = bSource;
            conn.Close();
            int count_rows = dataGridView1.RowCount - 1;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
                RefreshList();
        }
        public void RefreshList()
        {
            table.Clear();
            GetListClients();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Right))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.CurrentCell.Selected = true;
                GetSelectedIDString();
            }
        }
        public void GetSelectedIDString()
        {
            string selectedRow;
            selectedRow = dataGridView1.SelectedCells[0].RowIndex.ToString();
            idSelectedRow = dataGridView1.Rows[Convert.ToInt32(selectedRow)].Cells[0].Value.ToString();
        }
        void DataUpdate()
        {
            conn.Open();
            int rowsCount = dataGridView1.RowCount - 1;
            for (int i = 0; i < rowsCount; i++)
            {
                string cmd = $"update documents set Name_doc = '{dataGridView1[1, i].Value.ToString()}', Otdel = '{dataGridView1[2, i].Value.ToString()}'where ID = '{Convert.ToInt32(dataGridView1[0, i].Value.ToString())}'";
                MySqlCommand command = new MySqlCommand(cmd, conn);
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            DataUpdate();
        }

        private void toolStripLabel2_Click_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           Choice choice = new Choice();
           choice.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
