using CantinaBill.ConexãoDB;
using System;
using System.Data.Entity;
using System.Windows.Forms;

namespace CantinaBill.Formulários.Pessoas
{
    public partial class fchPessoa : MetroFramework.Forms.MetroForm
    {
        private readonly lstPessoas _parent;
        Pessoa pessoa = new Pessoa();
        public string idpessoa, nome, telefone, rua, bairro, cidade, numero;

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public fchPessoa(lstPessoas parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdatePessoa()
        {
            btnSalvar.Text = "Atualizar";
            lblIdPessoa.Visible = txtIdPessoa.Visible = true;

            txtIdPessoa.Text    = idpessoa;
            txtNome.Text        = nome;
            txtTelefone.Text    = telefone;
            txtRua.Text         = rua;
            txtBairro.Text      = bairro;
            txtNumero.Text      = numero;
            txtCidade.Text      = cidade;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
          txtIdPessoa.Text = idpessoa;
          pessoa.idPessoa = int.Parse(txtIdPessoa.Text);

          if (pessoa.idPessoa == 0)
            {
                pessoa.Nome          = txtNome.Text;
                pessoa.Telefone      = txtTelefone.Text;
                pessoa.Rua           = txtRua.Text;
                pessoa.Bairro        = txtBairro.Text;
                pessoa.Numero        = int.Parse(txtNumero.Text);
                pessoa.Cidade        = txtCidade.Text;

                using (CantinaBillEntities db = new CantinaBillEntities())
                {
                    db.Pessoa.Add(pessoa);

                    try
                    {
                        if (db.SaveChanges() == 1)
                            MessageBox.Show("Pessoa inserida com sucesso!");

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao inserir uma nova pessoa");
                    }

                    this.Close();
                }
            } 
            else
            {
                pessoa.Nome         = txtNome.Text.Trim();
                pessoa.Telefone     = txtTelefone.Text.Trim();
                pessoa.Rua          = txtRua.Text;
                pessoa.Bairro       = txtBairro.Text.Trim();
                pessoa.Numero       = int.Parse(txtNumero.Text);
                pessoa.Cidade       = txtCidade.Text.Trim();

                using (CantinaBillEntities db = new CantinaBillEntities())
                {                    
                    db.Entry(pessoa).State = EntityState.Modified;

                    try
                    {
                        if (db.SaveChanges() == 1)
                            MessageBox.Show("Registro editado com sucesso");

                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Erro ao editar registro ");
                    }

                    this.Close();
                }

            }

        }

    }
}
