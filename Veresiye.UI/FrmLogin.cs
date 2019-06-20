using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Veresiye.Service;

namespace Veresiye.UI
{
    public partial class FrmLogin : Form
    {
        private readonly IUserService userService;
        public FrmMain MasterForm { get; set; }
        private readonly FrmCompanies frmCompanies; 
        public FrmLogin(IUserService userService,FrmCompanies frmCompanies)
        {
            this.userService = userService;
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var user = userService.Login(txtUserName.Text, txtPassword.Text);
            if (user != null)
            {
                MasterForm.ShowFrmCompanies();
                this.Close();
            }else
            {
                MessageBox.Show("Geçersiz kullanıcı adı ve parola. Lütfen tekrar deneyin");
            }
        }
    }
}
