using System;
using CantinaBill.ConexãoDB;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CantinaBill.Formulários.Vender;

namespace CantinaBill.Formulários.Lista_Auxiliar
{
    public partial class frmListaProduto : MetroFramework.Forms.MetroForm
    {
        frmVenda _formVenda = new frmVenda();
        public frmListaProduto(frmVenda parent)
        {
            InitializeComponent();
            ExibirProdutos();
            _formVenda = parent;
        }

        void ExibirProdutos()
        {
            dgvProdutos.AutoGenerateColumns = false;
            using (CantinaBillEntities db = new CantinaBillEntities())
            {
                var ListarProdutos = (from produtos in db.Produto
                                      select produtos).ToList();
                dgvProdutos.DataSource = ListarProdutos;
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            string idProduto = dgvProdutos.CurrentRow.Cells["idProduto"].Value.ToString();

            using (CantinaBillEntities db = new CantinaBillEntities())
            {
                var RegistroProduto = (from produto in db.Produto
                                      where idProduto == produto.idProduto.ToString()
                                      select produto).First();

                _formVenda.idproduto = idProduto;
                _formVenda.nome_produto = RegistroProduto.Nome_Produto;
                _formVenda.preco_venda = RegistroProduto.Preco_Venda.ToString();
            }
            this.Close();
        }
    }
}
