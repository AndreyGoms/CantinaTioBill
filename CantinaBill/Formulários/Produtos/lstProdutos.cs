using CantinaBill.ConexãoDB;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CantinaBill.Formulários.Produtos
{
    public partial class lstProdutos : MetroFramework.Forms.MetroForm
    {
        public lstProdutos()
        {
            InitializeComponent();
            ExibeDados();
        }

        public void ExibeDados()
        {
            dgvProdutos.AutoGenerateColumns = false;
            using (CantinaBillEntities db = new CantinaBillEntities())
            {
                dgvProdutos.DataSource = db.Produto.ToList<Produto>();
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            fchProduto FichaProduto = new fchProduto(this);
            FichaProduto.idproduto = "0";
            FichaProduto.ShowDialog();
            ExibeDados();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            fchProduto FichaProduto = new fchProduto(this);
            string idproduto = dgvProdutos.CurrentRow.Cells["idProduto"].Value.ToString();

            using (CantinaBillEntities db = new CantinaBillEntities())
            {
                var RegistroProduto = (from produto in db.Produto
                                       where idproduto == produto.idProduto.ToString()
                                       select produto).First();

                FichaProduto.idproduto          = idproduto;
                FichaProduto.nome_produto       = RegistroProduto.Nome_Produto;
                FichaProduto.preco_venda        = RegistroProduto.Preco_Venda.ToString();

                FichaProduto.UpdateProduto();
                FichaProduto.ShowDialog();
                ExibeDados();
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string idproduto = dgvProdutos.CurrentRow.Cells["idProduto"].Value.ToString();
            using (CantinaBillEntities db = new CantinaBillEntities())
            {

                var RegistroProduto = (from produto in db.Produto
                                       where idproduto == produto.idProduto.ToString()
                                       select produto).First();

                db.Produto.Remove(RegistroProduto);
                try
                {
                    if (db.SaveChanges() == 1)
                        MessageBox.Show("Registro deletado com sucesso");
                    ExibeDados();
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro ao deletar registro");
                }
            }
        }
    }
}
