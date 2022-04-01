using CantinaBill.ConexãoDB;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace CantinaBill.Formulários.Pessoas
{
    public partial class lstPessoas : MetroFramework.Forms.MetroForm
    {
        public lstPessoas()
        {
            InitializeComponent();
            ExibeDados();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            fchPessoa fichaPessoa = new fchPessoa(this);
            fichaPessoa.idpessoa = "0";
            fichaPessoa.ShowDialog();        
            ExibeDados();
        }

        void ExibeDados()
        {
            dgvPessoas.AutoGenerateColumns = false;
            using (CantinaBillEntities db = new CantinaBillEntities())
            {
                dgvPessoas.DataSource = db.Pessoa.ToList<Pessoa>();
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string idpessoa = dgvPessoas.CurrentRow.Cells["idPessoa"].Value.ToString();
            using (CantinaBillEntities db = new CantinaBillEntities())
            {
               
                var RegistroPessoa = (from pessoa in db.Pessoa
                                      where idpessoa == pessoa.idPessoa.ToString()
                                      select pessoa).First();

                db.Pessoa.Remove(RegistroPessoa);
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            fchPessoa FichaPessoa = new fchPessoa(this);
            string idpessoa = dgvPessoas.CurrentRow.Cells["idPessoa"].Value.ToString();            

            using (CantinaBillEntities db = new CantinaBillEntities()) {
                var RegistroPessoa = (from pessoa in db.Pessoa
                                      where idpessoa == pessoa.idPessoa.ToString()
                                      select pessoa).First();

                FichaPessoa.idpessoa    = idpessoa;
                FichaPessoa.nome        = RegistroPessoa.Nome;
                FichaPessoa.rua         = RegistroPessoa.Rua;
                FichaPessoa.bairro      = RegistroPessoa.Bairro;
                FichaPessoa.numero      = RegistroPessoa.Numero.ToString();
                FichaPessoa.cidade      = RegistroPessoa.Cidade;
                FichaPessoa.telefone    = RegistroPessoa.Telefone;

                FichaPessoa.UpdatePessoa();
                FichaPessoa.ShowDialog();
                ExibeDados();
            }
        }
    }
}
