namespace Propinas.Visual
{
    partial class FormularioPropina
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
            label1 = new Label();
            label2 = new Label();
            valorPropina = new TextBox();
            valorTotal = new TextBox();
            label3 = new Label();
            label4 = new Label();
            BotonCalcular = new Button();
            BotonLimpiar = new Button();
            campoMonto = new NumericUpDown();
            campoPorcentaje = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)campoMonto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)campoPorcentaje).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 80);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 2;
            label1.Text = "Monto";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 109);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 3;
            label2.Text = "Porcentaje";
            // 
            // valorPropina
            // 
            valorPropina.Location = new Point(175, 155);
            valorPropina.Name = "valorPropina";
            valorPropina.Size = new Size(100, 23);
            valorPropina.TabIndex = 4;
            // 
            // valorTotal
            // 
            valorTotal.Location = new Point(174, 193);
            valorTotal.Name = "valorTotal";
            valorTotal.Size = new Size(100, 23);
            valorTotal.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(110, 159);
            label3.Name = "label3";
            label3.Size = new Size(48, 15);
            label3.TabIndex = 6;
            label3.Text = "Propina";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(117, 193);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 7;
            label4.Text = "Total";
            // 
            // BotonCalcular
            // 
            BotonCalcular.Location = new Point(308, 255);
            BotonCalcular.Name = "BotonCalcular";
            BotonCalcular.Size = new Size(75, 23);
            BotonCalcular.TabIndex = 8;
            BotonCalcular.Text = "Calcular";
            BotonCalcular.UseVisualStyleBackColor = true;
            BotonCalcular.Click += BotonCalcular_Click;
            // 
            // BotonLimpiar
            // 
            BotonLimpiar.Location = new Point(400, 255);
            BotonLimpiar.Name = "BotonLimpiar";
            BotonLimpiar.Size = new Size(75, 23);
            BotonLimpiar.TabIndex = 9;
            BotonLimpiar.Text = "Limpiar";
            BotonLimpiar.UseVisualStyleBackColor = true;
            BotonLimpiar.Click += BotonLimpiar_Click;
            // 
            // campoMonto
            // 
            campoMonto.Location = new Point(189, 77);
            campoMonto.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            campoMonto.Name = "campoMonto";
            campoMonto.Size = new Size(120, 23);
            campoMonto.TabIndex = 10;
            // 
            // campoPorcentaje
            // 
            campoPorcentaje.Location = new Point(192, 108);
            campoPorcentaje.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            campoPorcentaje.Name = "campoPorcentaje";
            campoPorcentaje.Size = new Size(120, 23);
            campoPorcentaje.TabIndex = 11;
            // 
            // FormularioPropina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 366);
            Controls.Add(campoPorcentaje);
            Controls.Add(campoMonto);
            Controls.Add(BotonLimpiar);
            Controls.Add(BotonCalcular);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(valorTotal);
            Controls.Add(valorPropina);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormularioPropina";
            Text = "FormularioPropina";
            ((System.ComponentModel.ISupportInitialize)campoMonto).EndInit();
            ((System.ComponentModel.ISupportInitialize)campoPorcentaje).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private TextBox valorPropina;
        private TextBox valorTotal;
        private Label label3;
        private Label label4;
        private Button BotonCalcular;
        private Button BotonLimpiar;
        private NumericUpDown campoMonto;
        private NumericUpDown campoPorcentaje;
    }
}