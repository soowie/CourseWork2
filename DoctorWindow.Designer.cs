namespace AppointmentsService
{
    partial class DoctorWindow
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
            this.btnPrintPlan = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.labelPatientInfo = new System.Windows.Forms.Label();
            this.dgvAppointment = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointment)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrintPlan
            // 
            this.btnPrintPlan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPrintPlan.BackColor = System.Drawing.Color.Cornsilk;
            this.btnPrintPlan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintPlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrintPlan.Location = new System.Drawing.Point(129, 22);
            this.btnPrintPlan.Name = "btnPrintPlan";
            this.btnPrintPlan.Size = new System.Drawing.Size(227, 35);
            this.btnPrintPlan.TabIndex = 8;
            this.btnPrintPlan.Text = "Друкувати записи";
            this.btnPrintPlan.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            this.btnLogout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogout.BackColor = System.Drawing.Color.Cornsilk;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnLogout.Location = new System.Drawing.Point(22, 22);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(101, 35);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Вийти";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // labelPatientInfo
            // 
            this.labelPatientInfo.AutoSize = true;
            this.labelPatientInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPatientInfo.Location = new System.Drawing.Point(373, 22);
            this.labelPatientInfo.Name = "labelPatientInfo";
            this.labelPatientInfo.Size = new System.Drawing.Size(327, 58);
            this.labelPatientInfo.TabIndex = 7;
            this.labelPatientInfo.Text = "Прізвище, Ім\'я, По-батькові\r\nРоків";
            // 
            // dgvAppointment
            // 
            this.dgvAppointment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAppointment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointment.Location = new System.Drawing.Point(22, 167);
            this.dgvAppointment.Name = "dgvAppointment";
            this.dgvAppointment.ReadOnly = true;
            this.dgvAppointment.RowHeadersWidth = 51;
            this.dgvAppointment.RowTemplate.Height = 24;
            this.dgvAppointment.Size = new System.Drawing.Size(1126, 362);
            this.dgvAppointment.TabIndex = 11;
            this.dgvAppointment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAppointment_CellFormatting);
            // 
            // DoctorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1170, 551);
            this.Controls.Add(this.dgvAppointment);
            this.Controls.Add(this.btnPrintPlan);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.labelPatientInfo);
            this.Name = "DoctorWindow";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "DoctorWindow";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClosedAction);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrintPlan;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Label labelPatientInfo;
        private System.Windows.Forms.DataGridView dgvAppointment;
    }
}