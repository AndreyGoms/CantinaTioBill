using System;
using System.Collections.Generic;
using System.Linq;
using CantinaBill.Formulários.Lista_Auxiliar;
using CantinaBill.Class;
using CantinaBill.ConexãoDB;
using System.Windows.Forms;

namespace CantinaBill.Formulários.Vender
{
    public partial class frmVenda : MetroFramework.Forms.MetroForm
    {
        
        public string idpessoa, nome, telefone, rua, bairro, cidade, numero,
                      idproduto, nome_produto, preco_venda;
        string StatusDesconto = "NaoAplicado";
        decimal ValorSubtotal = 0, QtdeAcumulada = 0;
        int idItem = 1;
        Venda venda = new Venda();
        Item_Venda item_venda = new Item_Venda();
        List<ItemVenda> ListaItem = new List<ItemVenda>();

        public frmVenda()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (txtIdProduto.Text != "")
            {
                if (txtQuantidade.Text != "0")
                {
                    ItemVenda item_venda = new ItemVenda(idItem, int.Parse(txtIdProduto.Text), txtNomeProduto.Text, decimal.Parse(txtPrecoVenda.Text),
                    decimal.Parse(txtTotalItem.Text), decimal.Parse(txtQuantidade.Text));

                    ListaItem.Add(item_venda);
                    idItem++;

                    ValorSubtotal = ValorSubtotal + decimal.Parse(txtTotalItem.Text);
                    lblSubtotal.Text = ValorSubtotal.ToString();

                    QtdeAcumulada = QtdeAcumulada + item_venda.Quantidade;

                    if (((int.Parse(txtQuantidade.Text) == 5) || (ListaItem.Count() == 5) || (QtdeAcumulada >= 5))
                          && StatusDesconto == "NaoAplicado")
                    {
                        txtDesconto.Text = (Math.Round(ValorSubtotal * decimal.Parse("0,0215"), 2)).ToString();
                        StatusDesconto = "Aplicado";
                    }
                    else if (decimal.Parse(txtDesconto.Text) == 0)
                        txtDesconto.Text = "0";

                    dgvItens.DataSource = ListaItem.ToList();
                }
                else
                  MessageBox.Show("Quantidade do produto inválida!");
            } else
                MessageBox.Show("Nenhum Produto Selecionado!");
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            string iditem = dgvItens.CurrentRow.Cells["IdItemVenda"].Value.ToString();

            foreach(ItemVenda item in ListaItem)
            {
                if (item.iditem == int.Parse(iditem))
                {
                    ListaItem.Remove(item);
                    break;
                }                    
            }
            ExibirDados();
        }

        void ExibirDados()
        {
            dgvItens.DataSource = ListaItem.ToList();
        }

        private void btnSelecionaProduto_Click(object sender, EventArgs e)
        {
            frmListaProduto ListaAuxProduto = new frmListaProduto(this);
            ListaAuxProduto.ShowDialog();
            txtIdProduto.Text = idproduto;
            txtNomeProduto.Text = nome_produto;
            txtPrecoVenda.Text = preco_venda;
        }

        private void btnSelecionaPessoa_Click(object sender, EventArgs e)
        {
            frmListaPessoas ListaAuxPessoas = new frmListaPessoas(this);
            ListaAuxPessoas.ShowDialog();
            txtIdPessoa.Text = idpessoa;
            txtNome.Text = nome;
            txtNumero.Text = numero;
            txtRua.Text = rua;
            txtTelefone.Text = telefone;
            txtBairro.Text = bairro;         
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            txtTaxaEntrega.Enabled  = txtPrecoVenda.Enabled = txtTotalItem.Enabled = false;

            lblValorTotal.Text = (ValorSubtotal - decimal.Parse(txtDesconto.Text) + decimal.Parse(txtTaxaEntrega.Text)).ToString();

        }

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            if(txtQuantidade.Text != "")
                txtTotalItem.Text = (decimal.Parse(txtQuantidade.Text) * decimal.Parse(txtPrecoVenda.Text)).ToString();
            else
                txtTotalItem.Text = "0";
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

        private void btnConcluirPedido_Click(object sender, EventArgs e)
        {
            venda.Data_venda = DateTime.Now;
            venda.Desconto = decimal.Parse(txtDesconto.Text);
            venda.idPessoa = int.Parse(txtIdPessoa.Text);
            venda.Taxa_Entrega = decimal.Parse(txtTaxaEntrega.Text);
            venda.Subtotal = ValorSubtotal;
            venda.Valor_Total = decimal.Parse(lblValorTotal.Text);
            venda.Status = "F";

            using (CantinaBillEntities db = new CantinaBillEntities())
            {
                db.Venda.Add(venda);

                try
                  {
                      if (db.SaveChanges() == 1)
                        MessageBox.Show("Venda concluída com sucesso!");

                        item_venda.idVenda = venda.idVenda;

                        foreach (ItemVenda item in ListaItem)
                        {
                           item_venda.idProduto = item.idproduto;
                           item_venda.Quantidade = item.Quantidade;
                           item_venda.Val_Un = item.PVenda;
                           item_venda.Valor_Total = item.TotalItem;

                           db.Item_Venda.Add(item_venda);
                           db.SaveChanges();
                            }
                }
                catch (Exception)
                {
                   MessageBox.Show("Erro concluir a venda!");
                }

                this.Close();                 
            }
        }

        private void btnSalvarPedido_Click(object sender, EventArgs e)
        {
            venda.Data_venda = DateTime.Now;
            venda.Desconto = decimal.Parse(txtDesconto.Text);
            venda.idPessoa = int.Parse(txtIdPessoa.Text);
            venda.Taxa_Entrega = decimal.Parse(txtTaxaEntrega.Text);
            venda.Subtotal = ValorSubtotal;
            venda.Valor_Total = decimal.Parse(lblValorTotal.Text);
            venda.Status = "A";

            using (CantinaBillEntities db = new CantinaBillEntities())
            {
                db.Venda.Add(venda);

                try
                {
                    if (db.SaveChanges() == 1)
                        MessageBox.Show("Pedido armazenado com sucesso!");

                    item_venda.idVenda = venda.idVenda;

                    foreach (ItemVenda item in ListaItem)
                    {
                        item_venda.idProduto = item.idproduto;
                        item_venda.Quantidade = item.Quantidade;
                        item_venda.Val_Un = item.PVenda;
                        item_venda.Valor_Total = item.TotalItem;

                        db.Item_Venda.Add(item_venda);
                        db.SaveChanges();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Erro armazenar o pedido!");
                }

                this.Close();
            }
        }

    }
}
