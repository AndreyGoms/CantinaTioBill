using System;
using System.Data;
using System.Linq;
using CantinaBill.ConexãoDB;
using CantinaBill.Formulários.Vender;

namespace CantinaBill.Formulários.Lista_Auxiliar
{
    public partial class frmListaPessoas : MetroFramework.Forms.MetroForm
    {

        private readonly frmVenda _formVenda = new frmVenda();

        public frmListaPessoas(frmVenda parent)
        {
            InitializeComponent();
            _formVenda = parent;
            ExibirPessoas();          
        }

        void ExibirPessoas()
        {
            dgvPessoas.AutoGenerateColumns = false;
            using (CantinaBillEntities db = new CantinaBillEntities())
            {
                var ListaPessoas = (from pessoa in db.Pessoa
                                   select pessoa).ToList();
                dgvPessoas.DataSource = ListaPessoas;
            }
        }


        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            string idpessoa = dgvPessoas.CurrentRow.Cells["idPessoa"].Value.ToString();

            using (CantinaBillEntities db = new CantinaBillEntities())
            {
                var RegistroPessoa = (from pessoa in db.Pessoa
                                      where idpessoa == pessoa.idPessoa.ToString()
                                      select pessoa).First();

                _formVenda.idpessoa = idpessoa;
                _formVenda.nome = RegistroPessoa.Nome;
                _formVenda.rua = RegistroPessoa.Rua;
                _formVenda.bairro = RegistroPessoa.Bairro;
                _formVenda.numero = RegistroPessoa.Numero.ToString();
                _formVenda.cidade = RegistroPessoa.Cidade;
                _formVenda.telefone = RegistroPessoa.Telefone;
              
            }
            this.Close();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
