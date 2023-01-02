namespace AppointmentsService
{
    partial class CreateAppointment
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblSpec = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblRating = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.lblExp = new System.Windows.Forms.Label();
            this.lblPatientCount = new System.Windows.Forms.Label();
            this.txtRating = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton13 = new System.Windows.Forms.RadioButton();
            this.radioButton14 = new System.Windows.Forms.RadioButton();
            this.radioButton15 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblName.Location = new System.Drawing.Point(12, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(85, 29);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSpec
            // 
            this.lblSpec.AutoSize = true;
            this.lblSpec.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSpec.Location = new System.Drawing.Point(13, 46);
            this.lblSpec.Name = "lblSpec";
            this.lblSpec.Size = new System.Drawing.Size(53, 20);
            this.lblSpec.TabIndex = 0;
            this.lblSpec.Text = "label1";
            this.lblSpec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "Інформація";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(13, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "Досвід";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 40);
            this.label5.TabIndex = 1;
            this.label5.Text = "Кількість\r\nпацієнтів";
            // 
            // lblRating
            // 
            this.lblRating.AutoSize = true;
            this.lblRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRating.Location = new System.Drawing.Point(13, 326);
            this.lblRating.Name = "lblRating";
            this.lblRating.Size = new System.Drawing.Size(78, 20);
            this.lblRating.TabIndex = 1;
            this.lblRating.Text = "Рейтинг";
            // 
            // txtInfo
            // 
            this.txtInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtInfo.Location = new System.Drawing.Point(17, 113);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(235, 106);
            this.txtInfo.TabIndex = 2;
            this.txtInfo.Text = "Тестова інформація про лікаря";
            this.txtInfo.Enter += new System.EventHandler(this.txtMyTextbox_Enter);
            // 
            // lblExp
            // 
            this.lblExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblExp.Location = new System.Drawing.Point(114, 222);
            this.lblExp.Name = "lblExp";
            this.lblExp.Size = new System.Drawing.Size(74, 41);
            this.lblExp.TabIndex = 1;
            this.lblExp.Text = "18";
            this.lblExp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPatientCount
            // 
            this.lblPatientCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPatientCount.Location = new System.Drawing.Point(114, 263);
            this.lblPatientCount.Name = "lblPatientCount";
            this.lblPatientCount.Size = new System.Drawing.Size(74, 42);
            this.lblPatientCount.TabIndex = 1;
            this.lblPatientCount.Text = "163";
            this.lblPatientCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRating
            // 
            this.txtRating.BackColor = System.Drawing.Color.Red;
            this.txtRating.Font = new System.Drawing.Font("Arial Rounded MT Bold", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRating.Location = new System.Drawing.Point(120, 313);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(132, 39);
            this.txtRating.TabIndex = 3;
            this.txtRating.Text = "4.7";
            this.txtRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRating.TextChanged += new System.EventHandler(this.txtRating_TextChanged);
            this.txtRating.Enter += new System.EventHandler(this.txtMyTextbox_Enter);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(25, 38);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 20);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "11:00";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(25, 64);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(59, 20);
            this.radioButton4.TabIndex = 4;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "12:00";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(25, 90);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(59, 20);
            this.radioButton7.TabIndex = 4;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "13:00";
            this.radioButton7.UseVisualStyleBackColor = true;
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(25, 116);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(59, 20);
            this.radioButton8.TabIndex = 4;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "14:00";
            this.radioButton8.UseVisualStyleBackColor = true;
            // 
            // radioButton13
            // 
            this.radioButton13.AutoSize = true;
            this.radioButton13.Location = new System.Drawing.Point(25, 168);
            this.radioButton13.Name = "radioButton13";
            this.radioButton13.Size = new System.Drawing.Size(59, 20);
            this.radioButton13.TabIndex = 4;
            this.radioButton13.TabStop = true;
            this.radioButton13.Text = "16:00";
            this.radioButton13.UseVisualStyleBackColor = true;
            // 
            // radioButton14
            // 
            this.radioButton14.AutoSize = true;
            this.radioButton14.Location = new System.Drawing.Point(25, 142);
            this.radioButton14.Name = "radioButton14";
            this.radioButton14.Size = new System.Drawing.Size(59, 20);
            this.radioButton14.TabIndex = 4;
            this.radioButton14.TabStop = true;
            this.radioButton14.Text = "15:00";
            this.radioButton14.UseVisualStyleBackColor = true;
            // 
            // radioButton15
            // 
            this.radioButton15.AutoSize = true;
            this.radioButton15.Location = new System.Drawing.Point(25, 194);
            this.radioButton15.Name = "radioButton15";
            this.radioButton15.Size = new System.Drawing.Size(59, 20);
            this.radioButton15.TabIndex = 4;
            this.radioButton15.TabStop = true;
            this.radioButton15.Text = "17:00";
            this.radioButton15.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(104, 38);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 20);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "11:30";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(104, 90);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(59, 20);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "13:30";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(104, 64);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(59, 20);
            this.radioButton5.TabIndex = 4;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "12:30";
            this.radioButton5.UseVisualStyleBackColor = true;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(104, 168);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(59, 20);
            this.radioButton6.TabIndex = 4;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "16:30";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(104, 142);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(59, 20);
            this.radioButton9.TabIndex = 4;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "15:30";
            this.radioButton9.UseVisualStyleBackColor = true;
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(104, 116);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(59, 20);
            this.radioButton10.TabIndex = 4;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "14:30";
            this.radioButton10.UseVisualStyleBackColor = true;
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.Location = new System.Drawing.Point(104, 194);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(59, 20);
            this.radioButton11.TabIndex = 4;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "17:30";
            this.radioButton11.UseVisualStyleBackColor = true;
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.radioButton6);
            this.groupBox.Controls.Add(this.radioButton11);
            this.groupBox.Controls.Add(this.radioButton1);
            this.groupBox.Controls.Add(this.radioButton15);
            this.groupBox.Controls.Add(this.radioButton2);
            this.groupBox.Controls.Add(this.radioButton10);
            this.groupBox.Controls.Add(this.radioButton7);
            this.groupBox.Controls.Add(this.radioButton8);
            this.groupBox.Controls.Add(this.radioButton3);
            this.groupBox.Controls.Add(this.radioButton9);
            this.groupBox.Controls.Add(this.radioButton4);
            this.groupBox.Controls.Add(this.radioButton14);
            this.groupBox.Controls.Add(this.radioButton5);
            this.groupBox.Controls.Add(this.radioButton13);
            this.groupBox.Location = new System.Drawing.Point(311, 72);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(245, 233);
            this.groupBox.TabIndex = 5;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Обрати вільний час";
            // 
            // CreateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 372);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.txtRating);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lblRating);
            this.Controls.Add(this.lblPatientCount);
            this.Controls.Add(this.lblExp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSpec);
            this.Controls.Add(this.lblName);
            this.Name = "CreateAppointment";
            this.Text = "CreateAppointment";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClosedAction);
            this.Load += new System.EventHandler(this.CreateAppointment_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSpec;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblRating;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label lblExp;
        private System.Windows.Forms.Label lblPatientCount;
        private System.Windows.Forms.TextBox txtRating;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton13;
        private System.Windows.Forms.RadioButton radioButton14;
        private System.Windows.Forms.RadioButton radioButton15;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.GroupBox groupBox;
    }
}