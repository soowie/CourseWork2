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
            this.radioPlanned = new System.Windows.Forms.RadioButton();
            this.radioDone = new System.Windows.Forms.RadioButton();
            this.checkRating = new System.Windows.Forms.CheckBox();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.dgvAppointment.Location = new System.Drawing.Point(22, 203);
            this.dgvAppointment.Name = "dgvAppointment";
            this.dgvAppointment.ReadOnly = true;
            this.dgvAppointment.RowHeadersWidth = 51;
            this.dgvAppointment.RowTemplate.Height = 24;
            this.dgvAppointment.Size = new System.Drawing.Size(1126, 326);
            this.dgvAppointment.TabIndex = 11;
            this.dgvAppointment.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvAppointment_CellFormatting);
            // 
            // radioPlanned
            // 
            this.radioPlanned.AutoSize = true;
            this.radioPlanned.Location = new System.Drawing.Point(22, 144);
            this.radioPlanned.Name = "radioPlanned";
            this.radioPlanned.Size = new System.Drawing.Size(148, 20);
            this.radioPlanned.TabIndex = 12;
            this.radioPlanned.Text = "Лише заплановані";
            this.radioPlanned.UseVisualStyleBackColor = true;
            this.radioPlanned.CheckedChanged += new System.EventHandler(this.radioPlanned_CheckedChanged);
            // 
            // radioDone
            // 
            this.radioDone.AutoSize = true;
            this.radioDone.Location = new System.Drawing.Point(22, 170);
            this.radioDone.Name = "radioDone";
            this.radioDone.Size = new System.Drawing.Size(122, 20);
            this.radioDone.TabIndex = 12;
            this.radioDone.TabStop = true;
            this.radioDone.Text = "Лише прийняті";
            this.radioDone.UseVisualStyleBackColor = true;
            this.radioDone.CheckedChanged += new System.EventHandler(this.radioDone_CheckedChanged);
            // 
            // checkRating
            // 
            this.checkRating.AutoSize = true;
            this.checkRating.Location = new System.Drawing.Point(22, 92);
            this.checkRating.Name = "checkRating";
            this.checkRating.Size = new System.Drawing.Size(111, 20);
            this.checkRating.TabIndex = 13;
            this.checkRating.Text = "З рейтингом";
            this.checkRating.UseVisualStyleBackColor = true;
            this.checkRating.CheckedChanged += new System.EventHandler(this.checkRating_CheckedChanged);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Checked = true;
            this.radioAll.Location = new System.Drawing.Point(22, 118);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(97, 20);
            this.radioAll.TabIndex = 12;
            this.radioAll.TabStop = true;
            this.radioAll.Text = "Усі записи";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radioAll_CheckedChanged);
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(282, 170);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(178, 22);
            this.searchBox.TabIndex = 14;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Пошук пацієнта за ім\'ям";
            // 
            // DoctorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1170, 551);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.checkRating);
            this.Controls.Add(this.radioDone);
            this.Controls.Add(this.radioAll);
            this.Controls.Add(this.radioPlanned);
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
        private System.Windows.Forms.RadioButton radioPlanned;
        private System.Windows.Forms.RadioButton radioDone;
        private System.Windows.Forms.CheckBox checkRating;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Label label1;
    }
}