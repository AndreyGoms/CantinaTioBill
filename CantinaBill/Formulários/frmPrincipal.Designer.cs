
namespace CantinaBill
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPessoas = new MetroFramework.Controls.MetroTile();
            this.btnProdutos = new MetroFramework.Controls.MetroTile();
            this.btnVender = new MetroFramework.Controls.MetroTile();
            this.btnListaVendas = new MetroFramework.Controls.MetroTile();
            this.SuspendLayout();
            // 
            // btnPessoas
            // 
            this.btnPessoas.ActiveControl = null;
            this.btnPessoas.Location = new System.Drawing.Point(236, 103);
            this.btnPessoas.Name = "btnPessoas";
            this.btnPessoas.Size = new System.Drawing.Size(131, 81);
            this.btnPessoas.TabIndex = 1;
            this.btnPessoas.Text = "Pessoas";
            this.btnPessoas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPessoas.UseSelectable = true;
            this.btnPessoas.Click += new System.EventHandler(this.btnPessoas_Click);
            // 
            // btnProdutos
            // 
            this.btnProdutos.ActiveControl = null;
            this.btnProdutos.Location = new System.Drawing.Point(236, 190);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(191, 81);
            this.btnProdutos.TabIndex = 2;
            this.btnProdutos.Text = "Produtos";
            this.btnProdutos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProdutos.UseSelectable = true;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // btnVender
            // 
            this.btnVender.ActiveControl = null;
            this.btnVender.Location = new System.Drawing.Point(373, 103);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(195, 81);
            this.btnVender.TabIndex = 4;
            this.btnVender.Text = "Vender";
            this.btnVender.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVender.UseSelectable = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnListaVendas
            // 
            this.btnListaVendas.ActiveControl = null;
            this.btnListaVendas.Location = new System.Drawing.Point(433, 190);
            this.btnListaVendas.Name = "btnListaVendas";
            this.btnListaVendas.Size = new System.Drawing.Size(135, 81);
            this.btnListaVendas.TabIndex = 5;
            this.btnListaVendas.Text = "Lista de vendas";
            this.btnListaVendas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnListaVendas.UseSelectable = true;
            this.btnListaVendas.Click += new System.EventHandler(this.btnListaVendas_Click);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnListaVendas);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.btnProdutos);
            this.Controls.Add(this.btnPessoas);
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.Resizable = false;
            this.Text = "Cantina do Tio Bill";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTile btnPessoas;
        private MetroFramework.Controls.MetroTile btnProdutos;
        private MetroFramework.Controls.MetroTile btnVender;
        private MetroFramework.Controls.MetroTile btnListaVendas;
    }
}

