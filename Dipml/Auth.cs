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

namespace Dipml
{
    public partial class Auth : Form
    {
        MySqlConnection conn;
        MainWindow mainWindow = new MainWindow();
        MySqlDataAdapter daAD = new MySqlDataAdapter();
        DataTable dT = new DataTable();
        public Auth()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        bool ConnCheck()
        {
            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения " + ex.Message);
                return false;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DB.Connection connection = new DB.Connection();
            conn = new MySqlConnection(connection.connStr);
            Login.MaxLength = 64;
            Password.PasswordChar = '*';
            Password.MaxLength = 64;
        }
        bool Authorization()
        {
            bool result;
            string login = Login.Text;
            string password = Password.Text;
            MySqlCommand cmd = new MySqlCommand("select ID_user, role_user from T_users where user_login = @uL and user_password = @uP", conn);
            cmd.Parameters.Add("@uL", MySqlDbType.VarChar).Value = login;
            cmd.Parameters.Add("@uP", MySqlDbType.VarChar).Value = sha256(Password.Text);
            conn.Open();
            daAD.SelectCommand = cmd;
            daAD.Fill(dT);
            conn.Close();
            if (dT.Rows.Count > 0)
            {
                MySqlCommand com = new MySqlCommand($"select role_user from T_user where login = '{login}'", conn);
                conn.Open();
                ACData.data = Convert.ToInt32(com.ExecuteScalar());
                conn.Close();
                result = true;
            }
            else
                result = false;
            return result;
        }
        static string sha256(string value)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(value));
            foreach (byte bt in crypto)
            {
                hash.Append(bt.ToString("x2"));
            }
            return hash.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {

            //bool result = Authorization();
            //if (result == true)
            //{
            //    this.Hide();
            //    mainWindow.Show();
            //}
            //else
            //    MessageBox.Show("неверно");

            mainWindow.Show();
        }
        private void Password_TextChanged(object sender, EventArgs e)
        {

        }
        private void Auth_Load(object sender, EventArgs e)
        {
            DB.Connection connection = new DB.Connection();
            conn = new MySqlConnection(connection.connStr);
            Login.MaxLength = 64;
            Password.PasswordChar = '*';
            Password.MaxLength = 64;
        }
    }
}
