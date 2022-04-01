using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CantinaBill.Formulários.Lista_Auxiliar;
using CantinaBill.Class;

namespace CantinaBill.Formulários.Vender
{
    public partial class frmVenda : MetroFramework.Forms.MetroForm
    {
        
        public string idpessoa, nome, telefone, rua, bairro, cidade, numero,
                      idproduto, nome_produto, preco_venda;
        List<ItemVenda> ListaItem = new List<ItemVenda>();

        public frmVenda()
        {
            InitializeComponent();
        }


        private void btnAddItem_Click(object sender, EventArgs e)
        {

            ItemVenda iten_venda = new ItemVenda( txtNomeProduto.Text,  decimal.Parse(txtPrecoVenda.Text),
            decimal.Parse(txtTotalItem.Text), int.Parse(txtQuantidade.Text));

            ListaItem.Add(iten_venda);
            
           //ListaItem.Add(new ItemVenda() { NomeItem = txtNomeProduto.Text, PVenda = decimal.Parse(txtPrecoVenda.Text),
           //TotalItem = decimal.Parse(txtTotalItem.Text), Quantidade = int.Parse(txtQuantidade.Text) });

           dgvItens.DataSource = ListaItem;
            
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

        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            if(txtQuantidade.Text != "")
                txtTotalItem.Text = (decimal.Parse(txtQuantidade.Text) * decimal.Parse(txtPrecoVenda.Text)).ToString();
            else
                txtTotalItem.Text = "0";
        }




    }
}
