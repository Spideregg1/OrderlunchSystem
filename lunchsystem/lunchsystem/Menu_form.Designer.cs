namespace lunchsystem
{
    partial class Menu_form
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
            this.dataGridView_menu = new System.Windows.Forms.DataGridView();
            this.btn_add_lunch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pick_lunch_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pick = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lunch_list = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_menu)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_menu
            // 
            this.dataGridView_menu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_menu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pick_lunch_id,
            this.pick,
            this.lunch_list,
            this.price});
            this.dataGridView_menu.Location = new System.Drawing.Point(180, 126);
            this.dataGridView_menu.Name = "dataGridView_menu";
            this.dataGridView_menu.RowTemplate.Height = 24;
            this.dataGridView_menu.Size = new System.Drawing.Size(443, 140);
            this.dataGridView_menu.TabIndex = 98;
            this.dataGridView_menu.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.datagridview_change_color);
            // 
            // btn_add_lunch
            // 
            this.btn_add_lunch.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_add_lunch.Location = new System.Drawing.Point(284, 324);
            this.btn_add_lunch.Name = "btn_add_lunch";
            this.btn_add_lunch.Size = new System.Drawing.Size(109, 34);
            this.btn_add_lunch.TabIndex = 105;
            this.btn_add_lunch.Text = "新增餐點";
            this.btn_add_lunch.UseVisualStyleBackColor = true;
            this.btn_add_lunch.Click += new System.EventHandler(this.btn_add_lunch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(279, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 27);
            this.label1.TabIndex = 106;
            this.label1.Text = "菜色選擇";
            // 
            // pick_lunch_id
            // 
            this.pick_lunch_id.DataPropertyName = "lunch_id";
            this.pick_lunch_id.HeaderText = "";
            this.pick_lunch_id.Name = "pick_lunch_id";
            // 
            // pick
            // 
            this.pick.DataPropertyName = "\"\"";
            this.pick.HeaderText = "選取";
            this.pick.Name = "pick";
            this.pick.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.pick.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // lunch_list
            // 
            this.lunch_list.DataPropertyName = "lunch";
            this.lunch_list.HeaderText = "餐點列表";
            this.lunch_list.Name = "lunch_list";
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "價格";
            this.price.Name = "price";
            // 
            // Menu_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_add_lunch);
            this.Controls.Add(this.dataGridView_menu);
            this.Name = "Menu_form";
            this.Text = "菜色選擇清單";
            this.Load += new System.EventHandler(this.Menu_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_menu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_menu;
        private System.Windows.Forms.Button btn_add_lunch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pick_lunch_id;
        private System.Windows.Forms.DataGridViewCheckBoxColumn pick;
        private System.Windows.Forms.DataGridViewTextBoxColumn lunch_list;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
    }
}