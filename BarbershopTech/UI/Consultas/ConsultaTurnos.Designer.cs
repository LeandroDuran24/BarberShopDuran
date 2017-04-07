namespace BarbershopTech.Consultas
{
    partial class ConsultaTurnos
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaTurnos));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hastadateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.desdedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BuscartextBox = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Filtrar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(297, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 55;
            this.label4.Text = "Hasta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 54;
            this.label3.Text = "Desde";
            // 
            // hastadateTimePicker
            // 
            this.hastadateTimePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hastadateTimePicker.CustomFormat = "yyy/MM/dd";
            this.hastadateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hastadateTimePicker.Location = new System.Drawing.Point(370, 52);
            this.hastadateTimePicker.Name = "hastadateTimePicker";
            this.hastadateTimePicker.Size = new System.Drawing.Size(153, 20);
            this.hastadateTimePicker.TabIndex = 53;
            // 
            // desdedateTimePicker
            // 
            this.desdedateTimePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.desdedateTimePicker.CustomFormat = "yyy/MM/dd";
            this.desdedateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.desdedateTimePicker.Location = new System.Drawing.Point(128, 50);
            this.desdedateTimePicker.Name = "desdedateTimePicker";
            this.desdedateTimePicker.Size = new System.Drawing.Size(153, 20);
            this.desdedateTimePicker.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "Busqueda";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 16);
            this.label1.TabIndex = 50;
            this.label1.Text = "Seleccione";
            // 
            // BuscartextBox
            // 
            this.BuscartextBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BuscartextBox.Location = new System.Drawing.Point(369, 25);
            this.BuscartextBox.Name = "BuscartextBox";
            this.BuscartextBox.Size = new System.Drawing.Size(154, 20);
            this.BuscartextBox.TabIndex = 49;
            this.BuscartextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BuscartextBox_KeyPress);
            // 
            // comboBox1
            // 
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(128, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(153, 21);
            this.comboBox1.TabIndex = 48;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            // 
            // Filtrar
            // 
            this.Filtrar.BackColor = System.Drawing.Color.Transparent;
            this.Filtrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Filtrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Filtrar.Image = ((System.Drawing.Image)(resources.GetObject("Filtrar.Image")));
            this.Filtrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Filtrar.Location = new System.Drawing.Point(529, 32);
            this.Filtrar.Name = "Filtrar";
            this.Filtrar.Size = new System.Drawing.Size(84, 31);
            this.Filtrar.TabIndex = 47;
            this.Filtrar.Text = "Filtrar";
            this.Filtrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Filtrar.UseVisualStyleBackColor = false;
            this.Filtrar.Click += new System.EventHandler(this.Filtrar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 83);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(691, 197);
            this.dataGridView1.TabIndex = 46;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // buttonImprimir
            // 
            this.buttonImprimir.BackColor = System.Drawing.Color.Transparent;
            this.buttonImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimir.Image = ((System.Drawing.Image)(resources.GetObject("buttonImprimir.Image")));
            this.buttonImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonImprimir.Location = new System.Drawing.Point(619, 32);
            this.buttonImprimir.Name = "buttonImprimir";
            this.buttonImprimir.Size = new System.Drawing.Size(84, 31);
            this.buttonImprimir.TabIndex = 56;
            this.buttonImprimir.Text = "Imprimir";
            this.buttonImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonImprimir.UseVisualStyleBackColor = false;
            this.buttonImprimir.Click += new System.EventHandler(this.buttonImprimir_Click);
            // 
            // ConsultaTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BarbershopTech.Properties.Resources.consulta2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(726, 339);
            this.Controls.Add(this.buttonImprimir);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hastadateTimePicker);
            this.Controls.Add(this.desdedateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BuscartextBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.Filtrar);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsultaTurnos";
            this.Text = "Turnos";
            this.Load += new System.EventHandler(this.ConsultaTurnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker hastadateTimePicker;
        private System.Windows.Forms.DateTimePicker desdedateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BuscartextBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button Filtrar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button buttonImprimir;
    }
}