namespace LR_1_
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbGramatica = new System.Windows.Forms.ListBox();
            this.tvAFD = new System.Windows.Forms.TreeView();
            this.dgvTabla = new System.Windows.Forms.DataGridView();
            this.dgvTAcciones = new System.Windows.Forms.DataGridView();
            this.columnsPilaAS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnCadEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.lRes = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbCadena = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTAcciones)).BeginInit();
            this.SuspendLayout();
            // 
            // lbGramatica
            // 
            this.lbGramatica.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbGramatica.FormattingEnabled = true;
            this.lbGramatica.Location = new System.Drawing.Point(12, 31);
            this.lbGramatica.Name = "lbGramatica";
            this.lbGramatica.Size = new System.Drawing.Size(201, 576);
            this.lbGramatica.TabIndex = 0;
            // 
            // tvAFD
            // 
            this.tvAFD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tvAFD.Location = new System.Drawing.Point(219, 31);
            this.tvAFD.Name = "tvAFD";
            this.tvAFD.Size = new System.Drawing.Size(231, 577);
            this.tvAFD.TabIndex = 2;
            // 
            // dgvTabla
            // 
            this.dgvTabla.AllowUserToAddRows = false;
            this.dgvTabla.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTabla.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTabla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTabla.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTabla.Location = new System.Drawing.Point(456, 31);
            this.dgvTabla.Name = "dgvTabla";
            this.dgvTabla.ReadOnly = true;
            this.dgvTabla.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvTabla.Size = new System.Drawing.Size(551, 233);
            this.dgvTabla.TabIndex = 3;
            // 
            // dgvTAcciones
            // 
            this.dgvTAcciones.AllowUserToAddRows = false;
            this.dgvTAcciones.AllowUserToDeleteRows = false;
            this.dgvTAcciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTAcciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTAcciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnsPilaAS,
            this.columnCadEntrada,
            this.ColumnAccion});
            this.dgvTAcciones.Location = new System.Drawing.Point(456, 270);
            this.dgvTAcciones.Name = "dgvTAcciones";
            this.dgvTAcciones.ReadOnly = true;
            this.dgvTAcciones.Size = new System.Drawing.Size(547, 213);
            this.dgvTAcciones.TabIndex = 4;
            // 
            // columnsPilaAS
            // 
            this.columnsPilaAS.HeaderText = "PilaAS";
            this.columnsPilaAS.Name = "columnsPilaAS";
            this.columnsPilaAS.ReadOnly = true;
            // 
            // columnCadEntrada
            // 
            this.columnCadEntrada.HeaderText = "Cadena de Entrada";
            this.columnCadEntrada.Name = "columnCadEntrada";
            this.columnCadEntrada.ReadOnly = true;
            // 
            // ColumnAccion
            // 
            this.ColumnAccion.HeaderText = "Accion";
            this.ColumnAccion.Name = "ColumnAccion";
            this.ColumnAccion.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(456, 520);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cadena";
            // 
            // lRes
            // 
            this.lRes.AutoSize = true;
            this.lRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRes.Location = new System.Drawing.Point(938, 534);
            this.lRes.Name = "lRes";
            this.lRes.Size = new System.Drawing.Size(0, 20);
            this.lRes.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Gramática";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbCadena
            // 
            this.tbCadena.AcceptsTab = true;
            this.tbCadena.Location = new System.Drawing.Point(527, 489);
            this.tbCadena.Name = "tbCadena";
            this.tbCadena.Size = new System.Drawing.Size(405, 119);
            this.tbCadena.TabIndex = 9;
            this.tbCadena.Text = "";
            this.tbCadena.TextChanged += new System.EventHandler(this.tbCadena_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(483, 540);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "a";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label3.Location = new System.Drawing.Point(459, 560);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Validar:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 617);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCadena);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lRes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvTAcciones);
            this.Controls.Add(this.dgvTabla);
            this.Controls.Add(this.tvAFD);
            this.Controls.Add(this.lbGramatica);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTAcciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbGramatica;
        private System.Windows.Forms.TreeView tvAFD;
        private System.Windows.Forms.DataGridView dgvTabla;
        private System.Windows.Forms.DataGridView dgvTAcciones;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lRes;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnsPilaAS;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnCadEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox tbCadena;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}

