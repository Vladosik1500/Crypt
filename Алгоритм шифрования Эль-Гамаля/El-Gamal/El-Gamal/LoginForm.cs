using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace El_Gamal
{
    public partial class LoginForm : MetroFramework.Forms.MetroForm
    {
        SQLiteConnection conn = SQLite2.GetDBConnection();
        public LoginForm()
        {
            InitializeComponent();
        }
        private void metroButton1_Click(object sender, EventArgs e)
        {
            Admin f = new Admin();
            User s = new User();
            if (Admin_Check.Checked == true)
            {
                String pass = password.Text;
                DataTable table = new DataTable();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                SQLiteCommand command = new SQLiteCommand($"Select * From admin Where password = {pass}", conn);
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    this.Visible = false;
                    f.Show();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Неверный пароль.", "Уведомление");
                }
            }
            if(Admin_Check.Checked == false)
            {
                DialogResult result1 = MetroFramework.MetroMessageBox.Show(this, "Вы авторизованы, как пользователь", "Уведомление");
                if (result1 == DialogResult.OK)
                {
                    this.Visible = false;
                }
                s.Show();
            }
            
        }

        private void Admin_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Admin_Check.Checked)
            {
                pass_label.Visible = true;
                password.Visible = true;
            }
            else
            {
                pass_label.Visible = false;
                password.Visible = false;
            }
        }
    }
}
