namespace AppointmentsService
{
    partial class AdminDoctorChangePanel
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDoctorFio = new System.Windows.Forms.TextBox();
            this.txtDoctorInfo = new System.Windows.Forms.TextBox();
            this.txtDoctorEmail = new System.Windows.Forms.TextBox();
            this.txtDoctorPhone = new System.Windows.Forms.TextBox();
            this.txtDoctorLogin = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txtDoctorPass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGoDepartment = new System.Windows.Forms.Button();
            this.сmbSpecialization = new System.Windows.Forms.ComboBox();
            this.cmbDepartment = new System.Windows.Forms.ComboBox();
            this.txtDoctorCabinet = new System.Windows.Forms.NumericUpDown();
            this.txtDoctorExperience = new System.Windows.Forms.NumericUpDown();
            this.doctor_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DoctorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specialization = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.experience = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patients_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cabinet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rating = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DepartmentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.account_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoctorCabinet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoctorExperience)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(32, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ПІБ";
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToDeleteRows = false;
            this.dgvCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCustomer.BackgroundColor = System.Drawing.Color.White;
            this.dgvCustomer.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.doctor_id,
            this.DoctorName,
            this.specialization,
            this.Info,
            this.email,
            this.Phone,
            this.experience,
            this.patients_count,
            this.Cabinet,
            this.rating,
            this.DepartmentID,
            this.account_id});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.PaleGreen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomer.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomer.Location = new System.Drawing.Point(404, 12);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.ReadOnly = true;
            this.dgvCustomer.RowHeadersWidth = 51;
            this.dgvCustomer.RowTemplate.Height = 32;
            this.dgvCustomer.Size = new System.Drawing.Size(457, 441);
            this.dgvCustomer.TabIndex = 2;
            this.dgvCustomer.DoubleClick += new System.EventHandler(this.dgvCustomer_DoubleClick);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Palace Script MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(22, 396);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 57);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(32, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Інформація";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(32, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Електронна пошта";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(32, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Номер телефону";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Palace Script MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(145, 396);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(117, 57);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Palace Script MT", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(268, 396);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(117, 57);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(32, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Номер кабінету";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(32, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Логін";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(32, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Пароль";
            // 
            // txtDoctorFio
            // 
            this.txtDoctorFio.Location = new System.Drawing.Point(213, 58);
            this.txtDoctorFio.Name = "txtDoctorFio";
            this.txtDoctorFio.Size = new System.Drawing.Size(172, 22);
            this.txtDoctorFio.TabIndex = 4;
            // 
            // txtDoctorInfo
            // 
            this.txtDoctorInfo.Location = new System.Drawing.Point(213, 86);
            this.txtDoctorInfo.Multiline = true;
            this.txtDoctorInfo.Name = "txtDoctorInfo";
            this.txtDoctorInfo.Size = new System.Drawing.Size(172, 42);
            this.txtDoctorInfo.TabIndex = 4;
            // 
            // txtDoctorEmail
            // 
            this.txtDoctorEmail.Location = new System.Drawing.Point(213, 134);
            this.txtDoctorEmail.Name = "txtDoctorEmail";
            this.txtDoctorEmail.Size = new System.Drawing.Size(172, 22);
            this.txtDoctorEmail.TabIndex = 4;
            // 
            // txtDoctorPhone
            // 
            this.txtDoctorPhone.Location = new System.Drawing.Point(213, 162);
            this.txtDoctorPhone.Name = "txtDoctorPhone";
            this.txtDoctorPhone.Size = new System.Drawing.Size(172, 22);
            this.txtDoctorPhone.TabIndex = 4;
            // 
            // txtDoctorLogin
            // 
            this.txtDoctorLogin.Location = new System.Drawing.Point(213, 324);
            this.txtDoctorLogin.Name = "txtDoctorLogin";
            this.txtDoctorLogin.Size = new System.Drawing.Size(172, 22);
            this.txtDoctorLogin.TabIndex = 4;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(213, 351);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(172, 22);
            this.textBox6.TabIndex = 4;
            // 
            // txtDoctorPass
            // 
            this.txtDoctorPass.Location = new System.Drawing.Point(213, 351);
            this.txtDoctorPass.Name = "txtDoctorPass";
            this.txtDoctorPass.Size = new System.Drawing.Size(172, 22);
            this.txtDoctorPass.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(32, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Відділення";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(32, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "Спецільність";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(32, 274);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Досвід";
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.Cornsilk;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(22, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Вийти";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnGoDepartment
            // 
            this.btnGoDepartment.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnGoDepartment.BackColor = System.Drawing.Color.Cornsilk;
            this.btnGoDepartment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnGoDepartment.Location = new System.Drawing.Point(156, 12);
            this.btnGoDepartment.Name = "btnGoDepartment";
            this.btnGoDepartment.Size = new System.Drawing.Size(229, 35);
            this.btnGoDepartment.TabIndex = 5;
            this.btnGoDepartment.Text = "Редагувати відділи";
            this.btnGoDepartment.UseVisualStyleBackColor = false;
            this.btnGoDepartment.Click += new System.EventHandler(this.btnGoDepartment_Click);
            // 
            // сmbSpecialization
            // 
            this.сmbSpecialization.FormattingEnabled = true;
            this.сmbSpecialization.Items.AddRange(new object[] {
            "Акушер - гінеколог",
            "Алерголог - імунолог",
            "Андролог",
            "Анестезіолог - реаніматолог",
            "Ароматерапевт",
            "Бактеріолог",
            "Венеролог",
            "Вертебролог",
            "Гастроентеролог",
            "Гематолог",
            "Геріатр (Геронтолог)",
            "Гірудотерапевт",
            "Гомеопат",
            "Дерматолог",
            "Дієтолог",
            "Ембріолог",
            "Ендокринолог",
            "Ендоскопіст",
            "Епідеміолог",
            "Еферентолог",
            "Інфекціоніст",
            "Кардіолог",
            "Кардіохірург",
            "Кінезітерапевт",
            "Комбустіолог",
            "Косметолог",
            "Лікар функціональної діагностики (Функціональний діагност)",
            "Лікар швидкої допомоги",
            "Мамолог (Онколог-мамолог)",
            "Мануальний терапевт (Мануальщик/Остеопат)",
            "Медична сестра (Медсестра)",
            "Міколог",
            "Нарколог",
            "Невропатолог (Невролог)",
            "Нейрохірург",
            "Неонатолог",
            "Нефролог",
            "Нутриціолог",
            "Онколог (Хірург-онколог)",
            "Ортопед",
            "Оториноларинголог (отоларинголог, ЛОР)",
            "Офтальмолог (Окуліст)",
            "Патологоанатом",
            "Педіатр",
            "Подолог",
            "Провізор",
            "Проктолог",
            "Психіатр",
            "Психотерапевт",
            "Пульмонолог",
            "Радіолог",
            "Реабілітолог",
            "Ревматолог",
            "Рентгенолог",
            "Рефлексотерапевт",
            "Сексолог (Сексопатолог)",
            "Сімейний лікар",
            "Спортивний лікар",
            "Стоматолог",
            "Терапевт",
            "Токсиколог",
            "Травматолог",
            "Трансплантолог",
            "Уролог",
            "Фармацевт",
            "Фахівець з клітинних технологій",
            "Фоніатр",
            "Фтизіатр",
            "Хірург"});
            this.сmbSpecialization.Location = new System.Drawing.Point(213, 246);
            this.сmbSpecialization.Name = "сmbSpecialization";
            this.сmbSpecialization.Size = new System.Drawing.Size(172, 24);
            this.сmbSpecialization.TabIndex = 6;
            this.сmbSpecialization.Text = "Медпрацівник";
            // 
            // cmbDepartment
            // 
            this.cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartment.FormattingEnabled = true;
            this.cmbDepartment.Location = new System.Drawing.Point(213, 216);
            this.cmbDepartment.Name = "cmbDepartment";
            this.cmbDepartment.Size = new System.Drawing.Size(172, 24);
            this.cmbDepartment.TabIndex = 7;
            // 
            // txtDoctorCabinet
            // 
            this.txtDoctorCabinet.Location = new System.Drawing.Point(213, 188);
            this.txtDoctorCabinet.Name = "txtDoctorCabinet";
            this.txtDoctorCabinet.Size = new System.Drawing.Size(172, 22);
            this.txtDoctorCabinet.TabIndex = 8;
            // 
            // txtDoctorExperience
            // 
            this.txtDoctorExperience.Location = new System.Drawing.Point(213, 274);
            this.txtDoctorExperience.Name = "txtDoctorExperience";
            this.txtDoctorExperience.Size = new System.Drawing.Size(172, 22);
            this.txtDoctorExperience.TabIndex = 8;
            // 
            // doctor_id
            // 
            this.doctor_id.DataPropertyName = "doctor_id";
            this.doctor_id.HeaderText = "ІД";
            this.doctor_id.MinimumWidth = 6;
            this.doctor_id.Name = "doctor_id";
            this.doctor_id.ReadOnly = true;
            this.doctor_id.Visible = false;
            this.doctor_id.Width = 125;
            // 
            // DoctorName
            // 
            this.DoctorName.DataPropertyName = "name";
            this.DoctorName.HeaderText = "ПІБ";
            this.DoctorName.MinimumWidth = 6;
            this.DoctorName.Name = "DoctorName";
            this.DoctorName.ReadOnly = true;
            this.DoctorName.Width = 125;
            // 
            // specialization
            // 
            this.specialization.DataPropertyName = "specialization";
            this.specialization.HeaderText = "Спеціальність";
            this.specialization.MinimumWidth = 6;
            this.specialization.Name = "specialization";
            this.specialization.ReadOnly = true;
            this.specialization.Width = 125;
            // 
            // Info
            // 
            this.Info.DataPropertyName = "information";
            this.Info.HeaderText = "Інформація";
            this.Info.MinimumWidth = 6;
            this.Info.Name = "Info";
            this.Info.ReadOnly = true;
            this.Info.Width = 125;
            // 
            // email
            // 
            this.email.DataPropertyName = "email";
            this.email.HeaderText = "Електронна Пошта";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.ReadOnly = true;
            this.email.Width = 125;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "phone_number";
            this.Phone.HeaderText = "Номер телефону";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Width = 125;
            // 
            // experience
            // 
            this.experience.DataPropertyName = "experience";
            this.experience.HeaderText = "Років досвіду";
            this.experience.MinimumWidth = 6;
            this.experience.Name = "experience";
            this.experience.ReadOnly = true;
            this.experience.Width = 125;
            // 
            // patients_count
            // 
            this.patients_count.DataPropertyName = "patients_count";
            this.patients_count.HeaderText = "Кількість пацієнтів";
            this.patients_count.MinimumWidth = 6;
            this.patients_count.Name = "patients_count";
            this.patients_count.ReadOnly = true;
            this.patients_count.Width = 125;
            // 
            // Cabinet
            // 
            this.Cabinet.DataPropertyName = "cabinet_number";
            this.Cabinet.HeaderText = "Номер кабінету";
            this.Cabinet.MinimumWidth = 6;
            this.Cabinet.Name = "Cabinet";
            this.Cabinet.ReadOnly = true;
            this.Cabinet.Width = 125;
            // 
            // rating
            // 
            this.rating.DataPropertyName = "rating";
            this.rating.HeaderText = "Рейтинг";
            this.rating.MinimumWidth = 6;
            this.rating.Name = "rating";
            this.rating.ReadOnly = true;
            this.rating.Width = 125;
            // 
            // DepartmentID
            // 
            this.DepartmentID.DataPropertyName = "department_id";
            this.DepartmentID.HeaderText = "Номер відділу";
            this.DepartmentID.MinimumWidth = 6;
            this.DepartmentID.Name = "DepartmentID";
            this.DepartmentID.ReadOnly = true;
            this.DepartmentID.Width = 125;
            // 
            // account_id
            // 
            this.account_id.DataPropertyName = "account_id";
            this.account_id.HeaderText = "Номер аккаунту";
            this.account_id.MinimumWidth = 6;
            this.account_id.Name = "account_id";
            this.account_id.ReadOnly = true;
            this.account_id.Width = 125;
            // 
            // AdminDoctorChangePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(873, 465);
            this.Controls.Add(this.txtDoctorExperience);
            this.Controls.Add(this.txtDoctorCabinet);
            this.Controls.Add(this.cmbDepartment);
            this.Controls.Add(this.сmbSpecialization);
            this.Controls.Add(this.btnGoDepartment);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDoctorPass);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.txtDoctorLogin);
            this.Controls.Add(this.txtDoctorPhone);
            this.Controls.Add(this.txtDoctorEmail);
            this.Controls.Add(this.txtDoctorInfo);
            this.Controls.Add(this.txtDoctorFio);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Name = "AdminDoctorChangePanel";
            this.Text = "Таблиця лікарів";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminDoctorChangePanel_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoctorCabinet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDoctorExperience)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDoctorFio;
        private System.Windows.Forms.TextBox txtDoctorInfo;
        private System.Windows.Forms.TextBox txtDoctorEmail;
        private System.Windows.Forms.TextBox txtDoctorPhone;
        private System.Windows.Forms.TextBox txtDoctorLogin;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox txtDoctorPass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGoDepartment;
        private System.Windows.Forms.ComboBox сmbSpecialization;
        private System.Windows.Forms.ComboBox cmbDepartment;
        private System.Windows.Forms.NumericUpDown txtDoctorCabinet;
        private System.Windows.Forms.NumericUpDown txtDoctorExperience;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctor_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DoctorName;
        private System.Windows.Forms.DataGridViewTextBoxColumn specialization;
        private System.Windows.Forms.DataGridViewTextBoxColumn Info;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn experience;
        private System.Windows.Forms.DataGridViewTextBoxColumn patients_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cabinet;
        private System.Windows.Forms.DataGridViewTextBoxColumn rating;
        private System.Windows.Forms.DataGridViewTextBoxColumn DepartmentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn account_id;
    }
}

