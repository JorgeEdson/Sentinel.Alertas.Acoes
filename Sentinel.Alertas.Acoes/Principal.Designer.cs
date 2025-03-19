namespace Sentinel.Alertas.Acoes
{
    partial class Principal
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
            dgvCriticos = new DataGridView();
            dgvAlertas = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCriticos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAlertas).BeginInit();
            SuspendLayout();
            // 
            // dgvCriticos
            // 
            dgvCriticos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCriticos.Location = new Point(167, 61);
            dgvCriticos.Name = "dgvCriticos";
            dgvCriticos.Size = new Size(1203, 288);
            dgvCriticos.TabIndex = 0;
            dgvCriticos.CellClick += dgvCriticos_CellClick;
            // 
            // dgvAlertas
            // 
            dgvAlertas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlertas.Location = new Point(167, 398);
            dgvAlertas.Name = "dgvAlertas";
            dgvAlertas.Size = new Size(1203, 288);
            dgvAlertas.TabIndex = 1;
            dgvAlertas.CellClick += dgvAlertas_CellClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(167, 31);
            label1.Name = "label1";
            label1.Size = new Size(160, 15);
            label1.TabIndex = 2;
            label1.Text = "PAINEL DE FALHAS CRITICAS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(167, 371);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 3;
            label2.Text = "PAINEL DE ALERTAS";
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1597, 826);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvAlertas);
            Controls.Add(dgvCriticos);
            Name = "Principal";
            Text = "Principal";
            ((System.ComponentModel.ISupportInitialize)dgvCriticos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAlertas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCriticos;
        private DataGridView dgvAlertas;
        private Label label1;
        private Label label2;
    }
}