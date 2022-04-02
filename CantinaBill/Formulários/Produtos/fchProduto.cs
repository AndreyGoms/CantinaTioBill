using System;
using System.Windows.Forms;
using CantinaBill.ConexãoDB;
using System.Data.Entity;

namespace CantinaBill.Formulários.Produtos
{
    public partial class fchProduto : MetroFramework.Forms.MetroForm
    {
        private readonly lstProdutos _parent;
        Produto produto = new Produto();
        public string idproduto, nome_produto, preco_venda;

        public fchProduto(lstProdutos parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateProduto()
        {
            btnSalvar.Text = "Atualizar";
            lblIdProduto.Visible = txtIdProduto.Visible = true;

            txtIdProduto.Text       = idproduto;
            txtNome.Text            = nome_produto;
            txtPrecoVenda.Text      = preco_venda; 
        }

        public void ValidaCampo(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtPrecoVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidaCampo(sender, e);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            txtIdProduto.Text = idproduto;
            produto.idProduto = int.Parse(txtIdProduto.Text);

            if (produto.idProduto == 0)
            {
                produto.Nome_Produto = txtNome.Text;
                produto.Preco_Venda = decimal.Parse(txtPrecoVenda.Text);
                
                using (CantinaBillEntities db = new CantinaBillEntities())
                {
                    db.Produto.Add(produto);

                    try
                    {
                        if (db.SaveChanges() == 1)
                            MessageBox.Show("Produto inserido com sucesso!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao inserir um novo Produto");
                    }

                    this.Close();
                }
            } 
            else
            {
                produto.Nome_Produto    = txtNome.Text;
                produto.Preco_Venda     = decimal.Parse(txtPrecoVenda.Text);

                using (CantinaBillEntities db = new CantinaBillEntities())
                {
                    db.Entry(produto).State = EntityState.Modified;

                    try
                    {
                        if (db.SaveChanges() == 1)
                            MessageBox.Show("Produto inserido com sucesso!");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao inserir um novo Produto");
                    }

                    this.Close();
                }
            }        
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
