using CantinaBill.Formulários.Lista_Auxiliar;
using CantinaBill.Formulários.Listar_Vendas;
using CantinaBill.Formulários.Pessoas;
using CantinaBill.Formulários.Produtos;
using CantinaBill.Formulários.Vender;
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

        private void btnVender_Click(object sender, EventArgs e)
        {
            frmVenda TelaVenda = new frmVenda();
            TelaVenda.Show();
        }

        private void btnListaVendas_Click(object sender, EventArgs e)
        {
            frmListarVendas ListaVendas = new frmListarVendas();
            ListaVendas.Show();
        }
    }
}
