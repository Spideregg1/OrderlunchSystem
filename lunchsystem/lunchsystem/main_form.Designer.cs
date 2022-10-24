namespace lunchsystem
{
    partial class main_form
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnupdate = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnread = new System.Windows.Forms.Button();
            this.btn_insert = new System.Windows.Forms.Button();
            this.lunch = new System.Windows.Forms.Label();
            this.txtname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lunchtableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mylunchDataSet = new lunchsystem.MylunchDataSet();
            this.lunchtableTableAdapter = new lunchsystem.MylunchDataSetTableAdapters.lunchtableTableAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.datagrid_master_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datagrid_detail_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datagrid_employee_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employee_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datagrid_lunch_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mylunch = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mylunchDataSet1 = new lunchsystem.MylunchDataSet1();
            this.lunchtableBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lunchtableTableAdapter1 = new lunchsystem.MylunchDataSet1TableAdapters.lunchtableTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_lunch = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txt_showdate = new System.Windows.Forms.TextBox();
            this.index_employeeid = new System.Windows.Forms.TextBox();
            this.index_lunchid = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_name = new System.Windows.Forms.ComboBox();
            this.btn_lunch = new System.Windows.Forms.Button();
            this.txt_lunch = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lunchtableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mylunchDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mylunchDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lunchtableBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnupdate
            // 
            this.btnupdate.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnupdate.Location = new System.Drawing.Point(217, 254);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(76, 34);
            this.btnupdate.TabIndex = 89;
            this.btnupdate.Text = "更新";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btndelete
            // 
            this.btndelete.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btndelete.Location = new System.Drawing.Point(135, 254);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(76, 34);
            this.btndelete.TabIndex = 88;
            this.btndelete.Text = "刪除";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnread
            // 
            this.btnread.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnread.Location = new System.Drawing.Point(487, 112);
            this.btnread.Name = "btnread";
            this.btnread.Size = new System.Drawing.Size(76, 34);
            this.btnread.TabIndex = 87;
            this.btnread.Text = "查詢";
            this.btnread.UseVisualStyleBackColor = true;
            // 
            // btn_insert
            // 
            this.btn_insert.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_insert.Location = new System.Drawing.Point(42, 254);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(76, 34);
            this.btn_insert.TabIndex = 86;
            this.btn_insert.Text = "新增";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // lunch
            // 
            this.lunch.AutoSize = true;
            this.lunch.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lunch.Location = new System.Drawing.Point(37, 157);
            this.lunch.Name = "lunch";
            this.lunch.Size = new System.Drawing.Size(61, 30);
            this.lunch.TabIndex = 83;
            this.lunch.Text = "餐點";
            // 
            // txtname
            // 
            this.txtname.AutoSize = true;
            this.txtname.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtname.Location = new System.Drawing.Point(37, 113);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(61, 30);
            this.txtname.TabIndex = 82;
            this.txtname.Text = "姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Cyan;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 20F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(153, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 35);
            this.label1.TabIndex = 81;
            this.label1.Text = "訂便當系統";
            // 
            // lunchtableBindingSource
            // 
            this.lunchtableBindingSource.DataMember = "lunchtable";
            this.lunchtableBindingSource.DataSource = this.mylunchDataSet;
            // 
            // mylunchDataSet
            // 
            this.mylunchDataSet.DataSetName = "MylunchDataSet";
            this.mylunchDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lunchtableTableAdapter
            // 
            this.lunchtableTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.datagrid_master_id,
            this.datagrid_detail_id,
            this.datagrid_employee_id,
            this.employee_name,
            this.datagrid_lunch_id,
            this.mylunch,
            this.date});
            this.dataGridView1.Location = new System.Drawing.Point(42, 322);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(543, 150);
            this.dataGridView1.TabIndex = 90;
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.changeDataGridViewColor);
            this.dataGridView1.DoubleClick += new System.EventHandler(this.dataGridView1_DoubleClick);
            // 
            // datagrid_master_id
            // 
            this.datagrid_master_id.DataPropertyName = "master_id";
            this.datagrid_master_id.HeaderText = "master_id";
            this.datagrid_master_id.Name = "datagrid_master_id";
            this.datagrid_master_id.ReadOnly = true;
            this.datagrid_master_id.Visible = false;
            // 
            // datagrid_detail_id
            // 
            this.datagrid_detail_id.DataPropertyName = "detail_id";
            this.datagrid_detail_id.HeaderText = "detail_id";
            this.datagrid_detail_id.Name = "datagrid_detail_id";
            this.datagrid_detail_id.ReadOnly = true;
            this.datagrid_detail_id.Visible = false;
            // 
            // datagrid_employee_id
            // 
            this.datagrid_employee_id.DataPropertyName = "employee_id";
            this.datagrid_employee_id.HeaderText = "員工編號";
            this.datagrid_employee_id.Name = "datagrid_employee_id";
            this.datagrid_employee_id.ReadOnly = true;
            // 
            // employee_name
            // 
            this.employee_name.DataPropertyName = "employee_name";
            this.employee_name.HeaderText = "員工姓名";
            this.employee_name.Name = "employee_name";
            this.employee_name.ReadOnly = true;
            // 
            // datagrid_lunch_id
            // 
            this.datagrid_lunch_id.DataPropertyName = "lunch_id";
            this.datagrid_lunch_id.HeaderText = "餐點編號";
            this.datagrid_lunch_id.Name = "datagrid_lunch_id";
            this.datagrid_lunch_id.ReadOnly = true;
            // 
            // mylunch
            // 
            this.mylunch.DataPropertyName = "lunch";
            this.mylunch.HeaderText = "餐點";
            this.mylunch.Name = "mylunch";
            this.mylunch.ReadOnly = true;
            // 
            // date
            // 
            this.date.DataPropertyName = "date";
            this.date.HeaderText = "日期";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // mylunchDataSet1
            // 
            this.mylunchDataSet1.DataSetName = "MylunchDataSet1";
            this.mylunchDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lunchtableBindingSource1
            // 
            this.lunchtableBindingSource1.DataMember = "lunchtable";
            this.lunchtableBindingSource1.DataSource = this.mylunchDataSet1;
            // 
            // lunchtableTableAdapter1
            // 
            this.lunchtableTableAdapter1.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(464, 77);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 91;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(37, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 30);
            this.label2.TabIndex = 92;
            this.label2.Text = "日期";
            // 
            // comboBox_lunch
            // 
            this.comboBox_lunch.FormattingEnabled = true;
            this.comboBox_lunch.Location = new System.Drawing.Point(124, 164);
            this.comboBox_lunch.Name = "comboBox_lunch";
            this.comboBox_lunch.Size = new System.Drawing.Size(121, 20);
            this.comboBox_lunch.TabIndex = 94;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(113, 206);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 95;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // txt_showdate
            // 
            this.txt_showdate.Font = new System.Drawing.Font("新細明體", 9F);
            this.txt_showdate.Location = new System.Drawing.Point(320, 206);
            this.txt_showdate.Name = "txt_showdate";
            this.txt_showdate.Size = new System.Drawing.Size(100, 22);
            this.txt_showdate.TabIndex = 96;
            // 
            // index_employeeid
            // 
            this.index_employeeid.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.index_employeeid.ForeColor = System.Drawing.Color.IndianRed;
            this.index_employeeid.Location = new System.Drawing.Point(264, 113);
            this.index_employeeid.Name = "index_employeeid";
            this.index_employeeid.Size = new System.Drawing.Size(100, 25);
            this.index_employeeid.TabIndex = 98;
            this.index_employeeid.Text = "employee_id";
            this.index_employeeid.Visible = false;
            // 
            // index_lunchid
            // 
            this.index_lunchid.Font = new System.Drawing.Font("新細明體", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.index_lunchid.ForeColor = System.Drawing.Color.IndianRed;
            this.index_lunchid.Location = new System.Drawing.Point(264, 159);
            this.index_lunchid.Name = "index_lunchid";
            this.index_lunchid.Size = new System.Drawing.Size(66, 25);
            this.index_lunchid.TabIndex = 99;
            this.index_lunchid.Text = "lunch_id";
            this.index_lunchid.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(934, 464);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 100;
            this.button1.Text = "test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_name
            // 
            this.comboBox_name.FormattingEnabled = true;
            this.comboBox_name.Location = new System.Drawing.Point(124, 118);
            this.comboBox_name.Name = "comboBox_name";
            this.comboBox_name.Size = new System.Drawing.Size(121, 20);
            this.comboBox_name.TabIndex = 101;
            // 
            // btn_lunch
            // 
            this.btn_lunch.Location = new System.Drawing.Point(345, 159);
            this.btn_lunch.Name = "btn_lunch";
            this.btn_lunch.Size = new System.Drawing.Size(75, 23);
            this.btn_lunch.TabIndex = 102;
            this.btn_lunch.Text = "選擇餐點";
            this.btn_lunch.UseVisualStyleBackColor = true;
            this.btn_lunch.Click += new System.EventHandler(this.btn_lunch_Click);
            // 
            // txt_lunch
            // 
            this.txt_lunch.Location = new System.Drawing.Point(440, 159);
            this.txt_lunch.Name = "txt_lunch";
            this.txt_lunch.Size = new System.Drawing.Size(103, 22);
            this.txt_lunch.TabIndex = 103;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(715, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 104;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 499);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt_lunch);
            this.Controls.Add(this.btn_lunch);
            this.Controls.Add(this.comboBox_name);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.index_lunchid);
            this.Controls.Add(this.index_employeeid);
            this.Controls.Add(this.txt_showdate);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboBox_lunch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnupdate);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnread);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.lunch);
            this.Controls.Add(this.txtname);
            this.Controls.Add(this.label1);
            this.Name = "main_form";
            this.Text = "訂便當系統";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lunchtableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mylunchDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mylunchDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lunchtableBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnupdate;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnread;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Label lunch;
        private System.Windows.Forms.Label txtname;
        private System.Windows.Forms.Label label1;
        private MylunchDataSet mylunchDataSet;
        private System.Windows.Forms.BindingSource lunchtableBindingSource;
        private MylunchDataSetTableAdapters.lunchtableTableAdapter lunchtableTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView1;
        private MylunchDataSet1 mylunchDataSet1;
        private System.Windows.Forms.BindingSource lunchtableBindingSource1;
        private MylunchDataSet1TableAdapters.lunchtableTableAdapter lunchtableTableAdapter1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_lunch;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txt_showdate;
        private System.Windows.Forms.TextBox index_employeeid;
        private System.Windows.Forms.TextBox index_lunchid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn datagrid_master_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn datagrid_detail_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn datagrid_employee_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn employee_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn datagrid_lunch_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn mylunch;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.Button btn_lunch;
        private System.Windows.Forms.TextBox txt_lunch;
        private System.Windows.Forms.Button button2;
    }
}

