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
            etiquetaMonto = new Label();
            etiquetaPorcentaje = new Label();
            valorPropina = new Label();
            valorTotal = new Label();
            etiquetaPropina = new Label();
            etiquetaTotal = new Label();
            BotonCalcular = new Button();
            BotonLimpiar = new Button();
            campoMonto = new NumericUpDown();
            campoPorcentaje = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)campoMonto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)campoPorcentaje).BeginInit();
            SuspendLayout();
            // 
            // etiquetaMonto
            // 
            etiquetaMonto.AutoSize = true;
            etiquetaMonto.Location = new Point(22, 24);
            etiquetaMonto.Name = "etiquetaMonto";
            etiquetaMonto.Size = new Size(111, 15);
            etiquetaMonto.TabIndex = 2;
            etiquetaMonto.Text = "Monto de la cuenta:";
            // 
            // etiquetaPorcentaje
            // 
            etiquetaPorcentaje.AutoSize = true;
            etiquetaPorcentaje.Location = new Point(22, 60);
            etiquetaPorcentaje.Name = "etiquetaPorcentaje";
            etiquetaPorcentaje.Size = new Size(169, 15);
            etiquetaPorcentaje.TabIndex = 3;
            etiquetaPorcentaje.Text = "Porcentaje de propina (%):";
            // 
            // valorPropina
            // 
            valorPropina.AutoSize = true;
            valorPropina.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            valorPropina.ForeColor = Color.DodgerBlue;
            valorPropina.Location = new Point(265, 96);
            valorPropina.Name = "valorPropina";
            valorPropina.Size = new Size(48, 15);
            valorPropina.TabIndex = 4;
            valorPropina.Text = "$ 0,00";
            valorPropina.TextAlign = ContentAlignment.TopRight;
            // 
            // valorTotal
            // 
            valorTotal.AutoSize = true;
            valorTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            valorTotal.ForeColor = Color.Black;
            valorTotal.Location = new Point(265, 132);
            valorTotal.Name = "valorTotal";
            valorTotal.Size = new Size(61, 20);
            valorTotal.TabIndex = 5;
            valorTotal.Text = "$ 0,00";
            valorTotal.TextAlign = ContentAlignment.TopRight;
            // 
            // etiquetaPropina
            // 
            etiquetaPropina.AutoSize = true;
            etiquetaPropina.Font = new Font("Segoe UI", 9F);
            etiquetaPropina.Location = new Point(22, 96);
            etiquetaPropina.Name = "etiquetaPropina";
            etiquetaPropina.Size = new Size(113, 15);
            etiquetaPropina.TabIndex = 6;
            etiquetaPropina.Text = "Importe de la propina:";
            // 
            // etiquetaTotal
            // 
            etiquetaTotal.AutoSize = true;
            etiquetaTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            etiquetaTotal.Location = new Point(22, 133);
            etiquetaTotal.Name = "etiquetaTotal";
            etiquetaTotal.Size = new Size(90, 19);
            etiquetaTotal.TabIndex = 7;
            etiquetaTotal.Text = "Total a pagar:";
            // 
            // BotonCalcular
            // 
            BotonCalcular.BackColor = Color.CornflowerBlue;
            BotonCalcular.FlatStyle = FlatStyle.Flat;
            BotonCalcular.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BotonCalcular.ForeColor = Color.White;
            BotonCalcular.Location = new Point(22, 167);
            BotonCalcular.Name = "BotonCalcular";
            BotonCalcular.Size = new Size(100, 32);
            BotonCalcular.TabIndex = 8;
            BotonCalcular.Text = "Calcular";
            BotonCalcular.UseVisualStyleBackColor = false;
            BotonCalcular.Click += BotonCalcular_Click;
            // 
            // BotonLimpiar
            // 
            BotonLimpiar.BackColor = Color.LightGray;
            BotonLimpiar.FlatStyle = FlatStyle.Flat;
            BotonLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            BotonLimpiar.Location = new Point(228, 167);
            BotonLimpiar.Name = "BotonLimpiar";
            BotonLimpiar.Size = new Size(100, 32);
            BotonLimpiar.TabIndex = 9;
            BotonLimpiar.Text = "Limpiar";
            BotonLimpiar.UseVisualStyleBackColor = false;
            BotonLimpiar.Click += BotonLimpiar_Click;
            // 
            // campoMonto
            // 
            campoMonto.DecimalPlaces = 2;
            campoMonto.Location = new Point(228, 24);
            campoMonto.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            campoMonto.Name = "campoMonto";
            campoMonto.Size = new Size(100, 23);
            campoMonto.TabIndex = 0;
            campoMonto.TextAlign = HorizontalAlignment.Right;
            campoMonto.ThousandsSeparator = true;
            // 
            // campoPorcentaje
            // 
            campoPorcentaje.Location = new Point(228, 60);
            campoPorcentaje.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            campoPorcentaje.Name = "campoPorcentaje";
            campoPorcentaje.Size = new Size(100, 23);
            campoPorcentaje.TabIndex = 11;
            campoPorcentaje.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // FormularioPropina
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(350, 220);
            Controls.Add(campoPorcentaje);
            Controls.Add(campoMonto);
            Controls.Add(BotonLimpiar);
            Controls.Add(BotonCalcular);
            Controls.Add(etiquetaTotal);
            Controls.Add(valorTotal);
            Controls.Add(etiquetaPropina);
            Controls.Add(valorPropina);
            Controls.Add(etiquetaPorcentaje);
            Controls.Add(etiquetaMonto);
            Font = new Font("Segoe UI", 9F);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormularioPropina";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculadora de propina";
            ((System.ComponentModel.ISupportInitialize)campoMonto).EndInit();
            ((System.ComponentModel.ISupportInitialize)campoPorcentaje).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label etiquetaMonto;
        private Label etiquetaPorcentaje;
        private Label valorPropina;
        private Label valorTotal;
        private Label etiquetaPropina;
        private Label etiquetaTotal;
        private Button BotonCalcular;
        private Button BotonLimpiar;
        private NumericUpDown campoMonto;
        private NumericUpDown campoPorcentaje;
    }
}