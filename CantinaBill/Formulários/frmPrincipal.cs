using CantinaBill.Formulários.Pessoas;
using CantinaBill.Formulários.Produtos;
using System;

namespace CantinaBill
{
    public partial class frmPrincipal : MetroFramework.Forms.MetroForm
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnPessoas_Click(object sender, EventArgs e)
        {
            lstPessoas ListaPessoas = new lstPessoas();
            ListaPessoas.Show();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            lstProdutos ListaProdutos = new lstProdutos();
            ListaProdutos.Show();
        }
    }
}
