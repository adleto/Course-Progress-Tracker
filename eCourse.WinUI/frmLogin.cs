using eCourse.Models.Helpers;
using eCourse.WinUI.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eCourse.WinUI
{
    public partial class frmLogin : MaterialSkin.Controls.MaterialForm
    {
        ApiService _service = new ApiService("Auth");
        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                ApiService.Username = txtUsername.Text;
                ApiService.Password = txtPassword.Text;
                Program.Roles = await _service.Get<List<string>>(null);

                this.Close();
                DialogResult = DialogResult.OK;
            }
            catch(ApiException ex)
            {
                if(ex.HttpStatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    MessageBox.Show("Invalid username or password.");
                }
                else
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
