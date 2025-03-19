namespace Sentinel.Alertas.Acoes
{
    partial class ModalAcao
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
            btnSalvar = new Button();
            label1 = new Label();
            txtLaudo = new TextBox();
            SuspendLayout();
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(121, 258);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(127, 26);
            btnSalvar.TabIndex = 0;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 1;
            label1.Text = "Laudo Técnico";
            // 
            // txtLaudo
            // 
            txtLaudo.Location = new Point(12, 39);
            txtLaudo.Multiline = true;
            txtLaudo.Name = "txtLaudo";
            txtLaudo.Size = new Size(392, 197);
            txtLaudo.TabIndex = 2;
            // 
            // ModalAcao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(424, 299);
            Controls.Add(txtLaudo);
            Controls.Add(label1);
            Controls.Add(btnSalvar);
            Name = "ModalAcao";
            Text = "ModalAcao";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalvar;
        private Label label1;
        private TextBox txtLaudo;
    }
}