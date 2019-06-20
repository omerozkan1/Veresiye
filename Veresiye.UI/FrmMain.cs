﻿using System;
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
    public partial class FrmMain : Form
    {
        private readonly IUserService userService;
        private readonly FrmRegister frmRegister;
        private readonly FrmCompanies frmCompanies;
        private readonly FrmLogin frmLogin;
        private readonly FrmCompanyAdd frmCompanyAdd;
        public FrmMain(IUserService userService, FrmRegister frmRegister, FrmCompanies frmCompanies,FrmLogin frmLogin,FrmCompanyAdd companyAdd)
        {
          this.userService = userService;
          this.frmRegister = frmRegister;
          this.frmCompanies = frmCompanies;
          this.frmLogin = frmLogin;

          InitializeComponent();
          this.frmRegister.MdiParent = this;
          this.frmCompanies.MdiParent = this;
          this.frmLogin.MdiParent = this;
          this.frmLogin.MasterForm = this;
          this.frmRegister.FormClosed += FrmRegister_FormClosed;  
        }
        public void ShowFrmCompanies()
        {
          frmCompanies.Show();

        }
        private void FrmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            var userCount = userService.GetAll().Count();

            if (userCount == 0)
            {
                frmRegister.Show();
            }
            else
            {
                frmLogin.Show();

            }


        }
    }
}
