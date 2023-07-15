using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Gamal
{
    public partial class Save : MetroFramework.Forms.MetroForm
    {
        public Save()
        {
            InitializeComponent();
        }

        private void pinkod_MouseMove(object sender, MouseEventArgs e)
        {
            tool1.SetToolTip(pinkod, "Введите пин-код для входа в приложение!!!");
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            if (pinkod.Text == "fate123")
            {
                MetroFramework.MetroMessageBox.Show(this, "Вы вошли в приложение", "Уведомление");
                this.Visible = false;
                login.Show();
            }
            else
                MetroFramework.MetroMessageBox.Show(this, "Пин-код не верный, введите снова!!!", "Уведомление");
        }
    }
}
