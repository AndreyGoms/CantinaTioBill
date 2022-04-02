using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CantinaBill.ConexãoDB;

namespace CantinaBill.Formulários.Listar_Vendas
{
    public partial class frmListarVendas : MetroFramework.Forms.MetroForm
    {
        public frmListarVendas()
        {
            InitializeComponent();
            ExbirVendas();
        }


        void ExbirVendas()
        {
            using (CantinaBillEntities db = new CantinaBillEntities())
            {
                var query =
                    (from venda in db.Venda
                     join pessoa in db.Pessoa on venda.idPessoa equals pessoa.idPessoa
                     select new
                     {
                         venda.idVenda,
                         venda.Status,
                         pessoa.idPessoa,
                         pessoa.Nome,
                         venda.Subtotal,
                         venda.Desconto,
                         venda.Taxa_Entrega,
                         venda.Valor_Total,
                         venda.Data_venda
                     }).ToList();

                dgvVendas.DataSource = query;
            }
        }

        private void btnCancelarVenda_Click(object sender, EventArgs e)
        {
            string idVenda = dgvVendas.CurrentRow.Cells["idVenda"].Value.ToString();

            using (CantinaBillEntities db = new CantinaBillEntities())
            {
                var RegistroVenda = (from Venda in db.Venda
                                      where idVenda == Venda.idVenda.ToString()
                                      select Venda).First();

                RegistroVenda.Status = "C";

                db.Entry(RegistroVenda).State = EntityState.Modified;
                db.SaveChanges();
                ExbirVendas();
            }

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
