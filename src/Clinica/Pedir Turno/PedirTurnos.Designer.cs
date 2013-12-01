namespace Clinica.Pedir_Turno
{
    partial class PedirTurno
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.selecAfil = new System.Windows.Forms.Button();
            this.textBoxAfiliado = new System.Windows.Forms.TextBox();
            this.gropbox2 = new System.Windows.Forms.GroupBox();
            this.buttonSelecProf = new System.Windows.Forms.Button();
            this.textBoxProf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxEspecialidad = new System.Windows.Forms.ComboBox();
            this.groupBoxTurnos = new System.Windows.Forms.GroupBox();
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.comboBoxTurnos = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.gropbox2.SuspendLayout();
            this.groupBoxTurnos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.selecAfil);
            this.groupBox1.Controls.Add(this.textBoxAfiliado);
            this.groupBox1.Location = new System.Drawing.Point(19, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(412, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Afiliado";
            // 
            // selecAfil
            // 
            this.selecAfil.Location = new System.Drawing.Point(311, 26);
            this.selecAfil.Name = "selecAfil";
            this.selecAfil.Size = new System.Drawing.Size(75, 23);
            this.selecAfil.TabIndex = 1;
            this.selecAfil.Text = "Seleccionar";
            this.selecAfil.UseVisualStyleBackColor = true;
            this.selecAfil.Click += new System.EventHandler(this.selecAfil_Click);
            // 
            // textBoxAfiliado
            // 
            this.textBoxAfiliado.Location = new System.Drawing.Point(17, 29);
            this.textBoxAfiliado.Name = "textBoxAfiliado";
            this.textBoxAfiliado.Size = new System.Drawing.Size(221, 20);
            this.textBoxAfiliado.TabIndex = 0;
            // 
            // gropbox2
            // 
            this.gropbox2.Controls.Add(this.buttonSelecProf);
            this.gropbox2.Controls.Add(this.textBoxProf);
            this.gropbox2.Controls.Add(this.label2);
            this.gropbox2.Controls.Add(this.label1);
            this.gropbox2.Controls.Add(this.comboBoxEspecialidad);
            this.gropbox2.Location = new System.Drawing.Point(19, 110);
            this.gropbox2.Name = "gropbox2";
            this.gropbox2.Size = new System.Drawing.Size(412, 100);
            this.gropbox2.TabIndex = 1;
            this.gropbox2.TabStop = false;
            this.gropbox2.Text = "Profesional";
            // 
            // buttonSelecProf
            // 
            this.buttonSelecProf.Location = new System.Drawing.Point(311, 58);
            this.buttonSelecProf.Name = "buttonSelecProf";
            this.buttonSelecProf.Size = new System.Drawing.Size(75, 23);
            this.buttonSelecProf.TabIndex = 2;
            this.buttonSelecProf.Text = "Seleccionar";
            this.buttonSelecProf.UseVisualStyleBackColor = true;
            this.buttonSelecProf.Click += new System.EventHandler(this.buttonSelecProf_Click);
            // 
            // textBoxProf
            // 
            this.textBoxProf.Location = new System.Drawing.Point(103, 60);
            this.textBoxProf.Name = "textBoxProf";
            this.textBoxProf.Size = new System.Drawing.Size(191, 20);
            this.textBoxProf.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Profesional:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Especialidad:";
            // 
            // comboBoxEspecialidad
            // 
            this.comboBoxEspecialidad.FormattingEnabled = true;
            this.comboBoxEspecialidad.Location = new System.Drawing.Point(103, 27);
            this.comboBoxEspecialidad.Name = "comboBoxEspecialidad";
            this.comboBoxEspecialidad.Size = new System.Drawing.Size(191, 21);
            this.comboBoxEspecialidad.TabIndex = 0;
            // 
            // groupBoxTurnos
            // 
            this.groupBoxTurnos.Controls.Add(this.buttonConfirmar);
            this.groupBoxTurnos.Controls.Add(this.comboBoxTurnos);
            this.groupBoxTurnos.Location = new System.Drawing.Point(19, 217);
            this.groupBoxTurnos.Name = "groupBoxTurnos";
            this.groupBoxTurnos.Size = new System.Drawing.Size(412, 116);
            this.groupBoxTurnos.TabIndex = 2;
            this.groupBoxTurnos.TabStop = false;
            this.groupBoxTurnos.Text = "Turnos Disponibles";
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Location = new System.Drawing.Point(305, 76);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(101, 23);
            this.buttonConfirmar.TabIndex = 3;
            this.buttonConfirmar.Text = "Confirmar";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // comboBoxTurnos
            // 
            this.comboBoxTurnos.FormattingEnabled = true;
            this.comboBoxTurnos.Location = new System.Drawing.Point(17, 28);
            this.comboBoxTurnos.Name = "comboBoxTurnos";
            this.comboBoxTurnos.Size = new System.Drawing.Size(352, 21);
            this.comboBoxTurnos.TabIndex = 4;
            // 
            // PedirTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 346);
            this.Controls.Add(this.groupBoxTurnos);
            this.Controls.Add(this.gropbox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PedirTurno";
            this.Text = "Turno";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gropbox2.ResumeLayout(false);
            this.gropbox2.PerformLayout();
            this.groupBoxTurnos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button selecAfil;
        private System.Windows.Forms.TextBox textBoxAfiliado;
        private System.Windows.Forms.GroupBox gropbox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxEspecialidad;
        private System.Windows.Forms.GroupBox groupBoxTurnos;
        private System.Windows.Forms.Button buttonSelecProf;
        private System.Windows.Forms.TextBox textBoxProf;
        private System.Windows.Forms.ComboBox comboBoxTurnos;
        private System.Windows.Forms.Button buttonConfirmar;
    }
}