namespace Clinica.Cancelar_Atencion
{
    partial class Cancelar
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxMotivoAfil = new System.Windows.Forms.TextBox();
            this.buttonCancelPac = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTunoAfil = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMotivoProf = new System.Windows.Forms.TextBox();
            this.buttonCancelProf = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeHasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDesde = new System.Windows.Forms.DateTimePicker();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(521, 376);
            this.splitContainer1.SplitterDistance = 178;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxMotivoAfil);
            this.groupBox1.Controls.Add(this.buttonCancelPac);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxTunoAfil);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 170);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cancelacion Paciente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Motivo:";
            // 
            // textBoxMotivoAfil
            // 
            this.textBoxMotivoAfil.Location = new System.Drawing.Point(115, 69);
            this.textBoxMotivoAfil.Name = "textBoxMotivoAfil";
            this.textBoxMotivoAfil.Size = new System.Drawing.Size(326, 20);
            this.textBoxMotivoAfil.TabIndex = 7;
            // 
            // buttonCancelPac
            // 
            this.buttonCancelPac.Location = new System.Drawing.Point(285, 107);
            this.buttonCancelPac.Name = "buttonCancelPac";
            this.buttonCancelPac.Size = new System.Drawing.Size(206, 23);
            this.buttonCancelPac.TabIndex = 1;
            this.buttonCancelPac.Text = "Cancelar Turno Seleccionado";
            this.buttonCancelPac.UseVisualStyleBackColor = true;
            this.buttonCancelPac.Click += new System.EventHandler(this.buttonCancelPac_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Turnos asignados:";
            // 
            // comboBoxTunoAfil
            // 
            this.comboBoxTunoAfil.FormattingEnabled = true;
            this.comboBoxTunoAfil.Location = new System.Drawing.Point(115, 42);
            this.comboBoxTunoAfil.Name = "comboBoxTunoAfil";
            this.comboBoxTunoAfil.Size = new System.Drawing.Size(326, 21);
            this.comboBoxTunoAfil.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBoxMotivoProf);
            this.groupBox2.Controls.Add(this.buttonCancelProf);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dateTimeHasta);
            this.groupBox2.Controls.Add(this.dateTimeDesde);
            this.groupBox2.Location = new System.Drawing.Point(4, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 175);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cancelacion de Turnos Profesional";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Motivo:";
            // 
            // textBoxMotivoProf
            // 
            this.textBoxMotivoProf.Location = new System.Drawing.Point(114, 99);
            this.textBoxMotivoProf.Name = "textBoxMotivoProf";
            this.textBoxMotivoProf.Size = new System.Drawing.Size(326, 20);
            this.textBoxMotivoProf.TabIndex = 5;
            // 
            // buttonCancelProf
            // 
            this.buttonCancelProf.Location = new System.Drawing.Point(284, 146);
            this.buttonCancelProf.Name = "buttonCancelProf";
            this.buttonCancelProf.Size = new System.Drawing.Size(206, 23);
            this.buttonCancelProf.TabIndex = 4;
            this.buttonCancelProf.Text = "Cancelar Turnos Seleccionados";
            this.buttonCancelProf.UseVisualStyleBackColor = true;
            this.buttonCancelProf.Click += new System.EventHandler(this.buttonCancelProf_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Turnos fecha hasta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Turnos fecha desde:";
            // 
            // dateTimeHasta
            // 
            this.dateTimeHasta.Location = new System.Drawing.Point(114, 72);
            this.dateTimeHasta.Name = "dateTimeHasta";
            this.dateTimeHasta.Size = new System.Drawing.Size(219, 20);
            this.dateTimeHasta.TabIndex = 1;
            // 
            // dateTimeDesde
            // 
            this.dateTimeDesde.Location = new System.Drawing.Point(114, 39);
            this.dateTimeDesde.Name = "dateTimeDesde";
            this.dateTimeDesde.Size = new System.Drawing.Size(219, 20);
            this.dateTimeDesde.TabIndex = 0;
            // 
            // Cancelar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 388);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Cancelar";
            this.Text = "Cancelar";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTunoAfil;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeHasta;
        private System.Windows.Forms.DateTimePicker dateTimeDesde;
        private System.Windows.Forms.Button buttonCancelPac;
        private System.Windows.Forms.Button buttonCancelProf;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxMotivoAfil;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxMotivoProf;

    }
}