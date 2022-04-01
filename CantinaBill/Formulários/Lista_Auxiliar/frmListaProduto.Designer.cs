
namespace CantinaBill.Formulários.Lista_Auxiliar
{
    partial class frmListaProduto
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
            this.dgvProdutos = new System.Windows.Forms.DataGridView();
            this.idProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome_Produto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Preco_Venda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new MetroFramework.Controls.MetroButton();
            this.btnSelecionar = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProdutos
            // 
            this.dgvProdutos.AllowUserToAddRows = false;
            this.dgvProdutos.AllowUserToDeleteRows = false;
            this.dgvProdutos.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvProdutos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProdutos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProduto,
            this.Nome_Produto,
            this.Preco_Venda});
            this.dgvProdutos.Location = new System.Drawing.Point(23, 63);
            this.dgvProdutos.Name = "dgvProdutos";
            this.dgvProdutos.ReadOnly = true;
            this.dgvProdutos.Size = new System.Drawing.Size(639, 364);
            this.dgvProdutos.TabIndex = 7;
            // 
            // idProduto
            // 
            this.idProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idProduto.DataPropertyName = "idProduto";
            this.idProduto.HeaderText = "idProduto";
            this.idProduto.Name = "idProduto";
            this.idProduto.ReadOnly = true;
            // 
            // Nome_Produto
            // 
            this.Nome_Produto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nome_Produto.DataPropertyName = "Nome_Produto";
            this.Nome_Produto.HeaderText = "Nome Produto";
            this.Nome_Produto.Name = "Nome_Produto";
            this.Nome_Produto.ReadOnly = true;
            // 
            // Preco_Venda
            // 
            this.Preco_Venda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Preco_Venda.DataPropertyName = "Preco_Venda";
            this.Preco_Venda.HeaderText = "Valor de Venda";
            this.Preco_Venda.Name = "Preco_Venda";
            this.Preco_Venda.ReadOnly = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(576, 435);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 34);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseSelectable = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(483, 435);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(85, 34);
            this.btnSelecionar.TabIndex = 8;
            this.btnSelecionar.Text = "Selecionar";
            this.btnSelecionar.UseSelectable = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // frmListaProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 492);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSelecionar);
            this.Controls.Add(this.dgvProdutos);
            this.Name = "frmListaProduto";
            this.Text = "Lista de Produtos";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProdutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvProdutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome_Produto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Preco_Venda;
        private MetroFramework.Controls.MetroButton btnCancelar;
        private MetroFramework.Controls.MetroButton btnSelecionar;
    }
}