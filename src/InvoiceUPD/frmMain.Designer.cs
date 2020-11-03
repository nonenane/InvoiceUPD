namespace InvoiceUPD
{
    partial class frmMain
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.cmbShop = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbUL = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTTN = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btSelectProvider = new System.Windows.Forms.Button();
            this.cmbDeps = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbNamePost = new System.Windows.Forms.TextBox();
            this.cSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cDeps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTTH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cPostInn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSumZak = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSumSell = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lUL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btUpdate = new System.Windows.Forms.Button();
            this.btClearPost = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btSettings = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Период";
            // 
            // dtpStart
            // 
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(66, 13);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(93, 20);
            this.dtpStart.TabIndex = 2;
            this.dtpStart.CloseUp += new System.EventHandler(this.dtpStart_CloseUp);
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            this.dtpStart.Leave += new System.EventHandler(this.dtpStart_Leave);
            // 
            // cmbShop
            // 
            this.cmbShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShop.FormattingEnabled = true;
            this.cmbShop.Location = new System.Drawing.Point(367, 13);
            this.cmbShop.Name = "cmbShop";
            this.cmbShop.Size = new System.Drawing.Size(177, 21);
            this.cmbShop.TabIndex = 3;
            this.cmbShop.SelectionChangeCommitted += new System.EventHandler(this.cmbShop_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "по";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(190, 13);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(93, 20);
            this.dtpEnd.TabIndex = 2;
            this.dtpEnd.CloseUp += new System.EventHandler(this.dtpStart_CloseUp);
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            this.dtpEnd.Leave += new System.EventHandler(this.dtpStart_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Магазин";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Тип накладной";
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(98, 40);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(177, 21);
            this.cmbType.TabIndex = 3;
            this.cmbType.SelectionChangeCommitted += new System.EventHandler(this.cmbType_SelectionChangeCommitted);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "ЮЛ";
            // 
            // cmbUL
            // 
            this.cmbUL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUL.FormattingEnabled = true;
            this.cmbUL.Location = new System.Drawing.Point(98, 67);
            this.cmbUL.Name = "cmbUL";
            this.cmbUL.Size = new System.Drawing.Size(177, 21);
            this.cmbUL.TabIndex = 3;
            this.cmbUL.SelectionChangeCommitted += new System.EventHandler(this.cmbType_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Поставщик";
            // 
            // tbTTN
            // 
            this.tbTTN.Location = new System.Drawing.Point(12, 132);
            this.tbTTN.Name = "tbTTN";
            this.tbTTN.Size = new System.Drawing.Size(100, 20);
            this.tbTTN.TabIndex = 4;
            this.tbTTN.TextChanged += new System.EventHandler(this.tbTTN_TextChanged);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToResizeRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cSelect,
            this.cDeps,
            this.cTTH,
            this.cDate,
            this.cPostInn,
            this.cName,
            this.cSumZak,
            this.cSumSell,
            this.cType,
            this.lUL});
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvData.DefaultCellStyle = dataGridViewCellStyle24;
            this.dgvData.Location = new System.Drawing.Point(12, 158);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvData.RowHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1106, 372);
            this.dgvData.TabIndex = 5;
            this.dgvData.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dgvData_ColumnWidthChanged);
            // 
            // btSelectProvider
            // 
            this.btSelectProvider.Location = new System.Drawing.Point(286, 92);
            this.btSelectProvider.Name = "btSelectProvider";
            this.btSelectProvider.Size = new System.Drawing.Size(32, 23);
            this.btSelectProvider.TabIndex = 6;
            this.btSelectProvider.Text = "...";
            this.btSelectProvider.UseVisualStyleBackColor = true;
            this.btSelectProvider.Click += new System.EventHandler(this.btSelectProvider_Click);
            // 
            // cmbDeps
            // 
            this.cmbDeps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeps.FormattingEnabled = true;
            this.cmbDeps.Location = new System.Drawing.Point(367, 40);
            this.cmbDeps.Name = "cmbDeps";
            this.cmbDeps.Size = new System.Drawing.Size(177, 21);
            this.cmbDeps.TabIndex = 3;
            this.cmbDeps.SelectionChangeCommitted += new System.EventHandler(this.cmbDeps_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(310, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Отдел";
            // 
            // tbNamePost
            // 
            this.tbNamePost.Location = new System.Drawing.Point(98, 94);
            this.tbNamePost.Name = "tbNamePost";
            this.tbNamePost.ReadOnly = true;
            this.tbNamePost.Size = new System.Drawing.Size(177, 20);
            this.tbNamePost.TabIndex = 7;
            // 
            // cSelect
            // 
            this.cSelect.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cSelect.DataPropertyName = "isSelect";
            this.cSelect.HeaderText = "V";
            this.cSelect.MinimumWidth = 45;
            this.cSelect.Name = "cSelect";
            this.cSelect.Width = 45;
            // 
            // cDeps
            // 
            this.cDeps.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cDeps.DataPropertyName = "nameDep";
            this.cDeps.HeaderText = "Отдел";
            this.cDeps.MinimumWidth = 80;
            this.cDeps.Name = "cDeps";
            this.cDeps.ReadOnly = true;
            this.cDeps.Width = 80;
            // 
            // cTTH
            // 
            this.cTTH.DataPropertyName = "ttn";
            this.cTTH.HeaderText = "ТТН";
            this.cTTH.Name = "cTTH";
            this.cTTH.ReadOnly = true;
            // 
            // cDate
            // 
            this.cDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cDate.DataPropertyName = "dprihod";
            this.cDate.HeaderText = "Дата";
            this.cDate.MinimumWidth = 80;
            this.cDate.Name = "cDate";
            this.cDate.ReadOnly = true;
            this.cDate.Width = 80;
            // 
            // cPostInn
            // 
            this.cPostInn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.cPostInn.DataPropertyName = "inn";
            this.cPostInn.HeaderText = "ИНН";
            this.cPostInn.MinimumWidth = 110;
            this.cPostInn.Name = "cPostInn";
            this.cPostInn.ReadOnly = true;
            this.cPostInn.Width = 110;
            // 
            // cName
            // 
            this.cName.DataPropertyName = "namePost";
            this.cName.HeaderText = "Наименование";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            // 
            // cSumZak
            // 
            this.cSumZak.DataPropertyName = "sumBuy";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N2";
            this.cSumZak.DefaultCellStyle = dataGridViewCellStyle22;
            this.cSumZak.HeaderText = "Сумма зак.";
            this.cSumZak.Name = "cSumZak";
            this.cSumZak.ReadOnly = true;
            // 
            // cSumSell
            // 
            this.cSumSell.DataPropertyName = "sumRealiz";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "N2";
            this.cSumSell.DefaultCellStyle = dataGridViewCellStyle23;
            this.cSumSell.HeaderText = "Сумма прод.";
            this.cSumSell.Name = "cSumSell";
            this.cSumSell.ReadOnly = true;
            // 
            // cType
            // 
            this.cType.DataPropertyName = "nameOperand";
            this.cType.HeaderText = "Тип";
            this.cType.Name = "cType";
            this.cType.ReadOnly = true;
            // 
            // lUL
            // 
            this.lUL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.lUL.DataPropertyName = "Abbriviation";
            this.lUL.HeaderText = "ЮЛ";
            this.lUL.MinimumWidth = 60;
            this.lUL.Name = "lUL";
            this.lUL.ReadOnly = true;
            this.lUL.Width = 60;
            // 
            // btUpdate
            // 
            this.btUpdate.Image = global::InvoiceUPD.Properties.Resources.reload_8055;
            this.btUpdate.Location = new System.Drawing.Point(571, 25);
            this.btUpdate.Name = "btUpdate";
            this.btUpdate.Size = new System.Drawing.Size(32, 32);
            this.btUpdate.TabIndex = 8;
            this.btUpdate.UseVisualStyleBackColor = true;
            this.btUpdate.Click += new System.EventHandler(this.btUpdate_Click);
            // 
            // btClearPost
            // 
            this.btClearPost.Image = global::InvoiceUPD.Properties.Resources.remove_ticket1_;
            this.btClearPost.Location = new System.Drawing.Point(324, 92);
            this.btClearPost.Name = "btClearPost";
            this.btClearPost.Size = new System.Drawing.Size(32, 23);
            this.btClearPost.TabIndex = 6;
            this.btClearPost.UseVisualStyleBackColor = true;
            this.btClearPost.Click += new System.EventHandler(this.btClearPost_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Image = global::InvoiceUPD.Properties.Resources.gtk_print_report;
            this.btPrint.Location = new System.Drawing.Point(1048, 536);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(32, 32);
            this.btPrint.TabIndex = 0;
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btSettings
            // 
            this.btSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSettings.Image = global::InvoiceUPD.Properties.Resources.p3;
            this.btSettings.Location = new System.Drawing.Point(1086, 25);
            this.btSettings.Name = "btSettings";
            this.btSettings.Size = new System.Drawing.Size(32, 32);
            this.btSettings.TabIndex = 0;
            this.btSettings.UseVisualStyleBackColor = true;
            this.btSettings.Click += new System.EventHandler(this.btSettings_Click);
            // 
            // btExit
            // 
            this.btExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExit.Image = global::InvoiceUPD.Properties.Resources.door_out;
            this.btExit.Location = new System.Drawing.Point(1086, 536);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(32, 32);
            this.btExit.TabIndex = 0;
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 571);
            this.Controls.Add(this.btUpdate);
            this.Controls.Add(this.tbNamePost);
            this.Controls.Add(this.btClearPost);
            this.Controls.Add(this.btSelectProvider);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.tbTTN);
            this.Controls.Add(this.cmbUL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbDeps);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbShop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btSettings);
            this.Controls.Add(this.btExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выгрузка УПД ведение накладных";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.ComboBox cmbShop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbUL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbTTN;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btSelectProvider;
        private System.Windows.Forms.ComboBox cmbDeps;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btClearPost;
        private System.Windows.Forms.TextBox tbNamePost;
        private System.Windows.Forms.DataGridViewCheckBoxColumn cSelect;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDeps;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTTH;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPostInn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSumZak;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSumSell;
        private System.Windows.Forms.DataGridViewTextBoxColumn cType;
        private System.Windows.Forms.DataGridViewTextBoxColumn lUL;
        private System.Windows.Forms.Button btSettings;
        private System.Windows.Forms.Button btUpdate;
    }
}

