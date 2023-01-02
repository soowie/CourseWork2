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
            this.txtRating.Size = new System.Drawing.Size(68, 39);
            this.txtRating.TabIndex = 3;
            this.txtRating.Text = "4.7";
            this.txtRating.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRating.TextChanged += new System.EventHandler(this.txtRating_TextChanged);
            this.txtRating.Enter += new System.EventHandler(this.txtMyTextbox_Enter);
            // 
            // CreateAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 372);
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
    }
}