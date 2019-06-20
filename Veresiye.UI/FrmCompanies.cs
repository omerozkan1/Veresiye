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
    public partial class FrmCompanies : Form
    {
        private readonly ICompanyService companyService;
        private readonly FrmCompanyAdd frmCompanyAdd;
        public FrmCompanies(ICompanyService companyService, FrmCompanyAdd frmCompanyAdd)
        {
            this.companyService = companyService;
            this.frmCompanyAdd = frmCompanyAdd;
            InitializeComponent();
            this.frmCompanyAdd.MdiParent = this.MdiParent;
        }

        private void FrmCompanies_Load(object sender, EventArgs e)
        {
            LoadCompanies();
        }
        public void LoadCompanies()
        {
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = companyService.GetAll();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            frmCompanyAdd.Show();
        }
    }
}
