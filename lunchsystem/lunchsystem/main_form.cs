using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lunchsystem
{
    public partial class main_form : Form
    {
        // TODO 20221017：程式內滿滿的　new MylunchEntities1，統一一個使用 done!
        MylunchEntities1 db = new MylunchEntities1();//lunch db

        C2NF_訂單細表 form_head = new C2NF_訂單細表();//表頭
        C3NF_午餐 form_body = new C3NF_午餐();//表身



        public main_form()
        {
            InitializeComponent();
        }

        public string id_value;

        private string Id_value
        {
            set
            {
                id_value = value;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";

            //comboBox1.Items.Add(new ComboBoxItem("1", "姓名"));
            //comboBox1.Items.Add(new ComboBoxItem("2", "午餐"));
            //comboBox1.Items.Add(new ComboBoxItem("3", "日期"));


            //將hardcore轉從資料庫抓取檔案

            var lunch_list = from lunch_item in db.C3NF_午餐種類 select lunch_item;

            var employee_list = from employee_name in db.C2NF_員工清單 select employee_name;

            comboBox_lunch.DataSource = lunch_list.ToList();
            comboBox_lunch.DisplayMember = "lunch";
            comboBox_lunch.ValueMember = "lunch_id";

            comboBox_name.DataSource = employee_list.ToArray();
            comboBox_name.DisplayMember = "employee_name";
            comboBox_name.ValueMember = "employee_id";




            //comboBox_lunch.Items.Add(new ComboBoxItem("1", "便當"));
            //comboBox_lunch.Items.Add(new ComboBoxItem("2", "素食"));
            //comboBox_lunch.Items.Add(new ComboBoxItem("3", "炒飯"));
            Clear();
            LoadData();
        }


        public void LoadData()//load data
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;

            // Linq to Entity 或 Linq to SQL
            // Lambda Express
            //var source = db.C2NF_訂單細表.Join(db.C2NF_員工清單,
            //    o => o.employee_id,
            //    e => e.employee_id).
            //    Join(db.C3NF_午餐,
            //    a => a.master_id,
            //    b => b.master_id).
            //    Join(db.C3NF_午餐種類,
            //    c => c.lunch_id,
            //    d => d.lunch_id,
            //    (c, d) => new LunchViewModel()
            //    {
            //        //employee_id = employee_id,
            //        //employee_name = 
            //        lunch_id = c.lunch_id,
            //        lunch = d.lunch,
            //        //date = date
            //    }).ToList();

            // Linq 
            // Provider
            var query = from fh in db.C2NF_訂單細表
                        join ei in db.C2NF_員工清單 on fh.employee_id equals ei.employee_id
                        join fb in db.C3NF_午餐 on fh.master_id equals fb.master_id
                        join li in db.C3NF_午餐種類 on fb.lunch_id equals li.lunch_id

                        select new LunchViewModel
                        {
                            master_id = fh.master_id,
                            employee_id = fh.employee_id,
                            employee_name = ei.employee_name,
                            detail_id = fb.detail_id,
                            lunch_id = fb.lunch_id,
                            lunch = li.lunch,
                            date = fh.date
                        };

            var source = query.ToList();
            dataGridView1.DataSource = source;

            string TSQL =
                    @"Select
	                date,
	                [1] as rice,
	                [2] as food,
	                [3] as vegan
	                from 
	                (Select date,lunch_id from [dbo].[2NF_訂單細表] as H
	                join [dbo].[3NF_午餐] as B on H.master_id = B.master_id
	                ) as main_table
                pivot (count(lunch_id) for lunch_id in ([1],[2],[3])) as T_pivot";

            var source2 = db.Database.SqlQuery<FoodNumberViewModel>(TSQL);
            dataGridView2.DataSource = source2.ToList();

            string TSQL2forAmount =
                @"Select
                L.lunch as food,
                count(B.lunch_id) as total_count ,
                sum(L.price) as total_amount 
                from [dbo].[2NF_訂單細表] as H 
                Join [dbo].[3NF_午餐] as B on H.master_id = B.master_id 
                and date between '2022-10-01' and '2022-10-31' 
                Join [dbo].[3NF_午餐種類] as L on B.lunch_id = L.lunch_id  
                group by lunch , price ";

            var source3 = db.Database.SqlQuery<AmountViewModel>(TSQL2forAmount);
            dataGridView3.DataSource = source3.ToList();




        }

        #region CRUD部分
        private void btn_insert_Click(object sender, EventArgs e) //新增
        {
            Menu_form menu_Form = new Menu_form();

            menu_Form.Owner = this;

            string str_lunchid = id_value;

            int[] index_lunch = str_lunchid.Select(n => n - '0').ToArray();

            form_head.date = dateTimePicker1.Value;
            form_head.employee_id = comboBox_name.SelectedIndex + 1;
            db.C2NF_訂單細表.Add(form_head);

            for (int i = 0; i < index_lunch.Length; i++)
            {


                // EF 對應 masterid
                form_body.master_id = form_head.master_id;
                form_body.lunch_id = index_lunch[i];

                //form_body.lunch_id = comboBox_lunch.SelectedIndex + 1;
                // TODO 20221024 檔頭重覆增加

                db.C3NF_午餐.Add(form_body);

                db.SaveChanges();
            }

            //db.C2NF_訂單細表.Add(form_head);
            // db.C3NF_午餐.Add(form_body);

            //db.SaveChanges();
            Clear();
            LoadData();
            MessageBox.Show("新增成功！");

        }

        ////private void btnread_Click(object sender, EventArgs e) //查詢
        //{

        //    string value = ComboBoxUtil.GetItem(comboBox1).Value;

        //    int Employee_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[datagrid_employee_id.Index].Value);


        //    //txt_lunch = valueoflunch();

        //    ///if (value == "1")
        //    //{
        //        //dataGridView1.DataSource = db.C2NF_員工清單.Where(x => x.employee_id == Employee_ID).ToList();
        //    //}
        //    //else if (value == "2")
        //    //{
        //    //    dataGridView1.DataSource = db.lunchtables.Where(x => x.lunch.Contains(txt_lunch)).ToList();
        //    //}
        //    //else if (value == "3")
        //    //{

        //    //    dataGridView1.DataSource = db.lunchtables.Where(x => x.date == lunchtable.date).ToList();
        //    //}
        //}

        void Clear()//清空text的資料值
        {

        }

        private void btn_update_Click(object sender, EventArgs e)//更新
        {

            form_head.date = dateTimePicker1.Value;
            form_head.employee_id = comboBox_name.SelectedIndex + 1;
            form_body.master_id = form_head.master_id;
            form_body.lunch_id = comboBox_lunch.SelectedIndex + 1;

            db.Entry(form_head).State = EntityState.Modified;
            db.Entry(form_body).State = EntityState.Modified;
            db.SaveChanges();
            Clear();
            LoadData();
            MessageBox.Show("更新成功！");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {

            db.C2NF_訂單細表.Remove(form_head);
            db.C3NF_午餐.Remove(form_body);

            db.SaveChanges();
            LoadData();
            Clear();
            MessageBox.Show("刪除成功");
        }


        private void dataGridView1_DoubleClick(object sender, EventArgs e)//點擊二下想改的地方
        {

            // TODO 20221017：請使用 Early Return，讓程式碼更方便閱讀
            if (dataGridView1.CurrentRow.Index == -1)
                return;

            // TODO 20221017：避免 HardCode，Cells 內的 "master_id"、"lunch_id" 請改寫 done!

            int Master_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[datagrid_master_id.Index].Value);

            int Detail_ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[datagrid_detail_id.Index].Value);



            form_head = db.C2NF_訂單細表.Where(x => x.master_id == Master_ID).FirstOrDefault();



            form_body = db.C3NF_午餐.Where(x => x.detail_id == Detail_ID).FirstOrDefault();


            comboBox_name.Text = form_head.C2NF_員工清單.employee_name;

            comboBox_lunch.Text = form_body.C3NF_午餐種類.lunch;
            // TODO 20221017：請說明 [C2NF_訂單細表.Date 欄位] 是允許 null，訂購日期是設計可以不填嗎？ done!
            dateTimePicker1.Value = (DateTime)form_head.date;

            //txt_date.Text = lunchtable.date;
        }
        #endregion



        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // TODO 20221017：datetimepicker 控件有 value 屬性可以直接抓到 datetime，
            //  不知道為什麼要透過 _lunchtime field 來暫存 datetimepicker.Text，
            //  實際應用還要透過 Convert.ToDateTime(_lunchtime); 來轉換，
            //  另外要這樣幹，也要透過一個 method 來統一存取才是 done!

            txt_showdate.Text += dateTimePicker1?.Value.toTWDate();
            // DateTime.TWDate()
            // 擴充方法 Extension method
        }

        private void button1_Click(object sender, EventArgs e)// test function
        {
            //string str_lunchid = index_lunchid.Text;
            //int[] index_lunch = str_lunchid.Select(n => n - '0').ToArray();
            //for (int i = 0; i < index_lunch.Length; i++)
            //{
            //    MessageBox.Show(index_lunch[i].ToString());
            //}
            Menu_form menu_Form = new Menu_form();
            menu_Form.Owner = this;

            string str_lunchid = id_value;
            MessageBox.Show(str_lunchid);

        }

        #region 同視窗 datagridview
        //private void btn_add_lunch_Click(object sender, EventArgs e)
        //{

        //    int lunch_id = 0;
        //    string lunch_name = "";
        //    string msg = "";
        //    string msg_id = "";

        //    int row = dataGridView_lunchlist.RowCount - 1;



        //    for (int i = 0; i <= row; i++)
        //    {
        //        if (Convert.ToBoolean(dataGridView_lunchlist.Rows[i].Cells[pick.Index].Value) == true)
        //        {

        //            lunch_id = (int)dataGridView_lunchlist.Rows[i].Cells[pick_lunch_id.Index].Value;

        //            lunch_name = dataGridView_lunchlist.Rows[i].Cells[lunch_list.Index].Value.ToString();
        //            msg += lunch_name;
        //            msg_id += lunch_id.ToString();
        //        }


        //    }

        //    txt_lunch.Text = msg;
        //    index_lunchid.Text = msg_id;





        //}
        #endregion

        private void btn_lunch_Click(object sender, EventArgs e)
        {

            Menu_form menu_Form = new Menu_form();
            // TODO 20221024 Form.Show() 和 FormShowDialog() 差異 差異在於Form.show() 可以無限打開另一個Form；Form.ShowDialog() 只能一次 關掉後才能存取
            menu_Form.Show(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // var demo = new ComboBoxItem("", "") { Value = "", Text = "" };

            // var demo = new ComboBoxItem() { Value = "", Text = "" };
            // var demo2 = new ComboBoxItem("" , "") { Value = "", Text = "" };
            // 唯一
            // var demo3 = new ComboBoxItem("" , "");

            //demo2.Value = "";
            //var getValue = demo2.Value;

            // var demo2 = new ConstructorDemo();
        }

        public void changeDataGridViewColor(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= -1)
            {
                DataGridViewCell dgvc = dataGridView1.Rows[e.RowIndex].Cells[date.Index];
                DateTime colorchanged_date = Convert.ToDateTime(dgvc.Value);


                int yy = colorchanged_date.Year;
                DateTime start = new DateTime(yy, 10, 20);
                if (colorchanged_date < start)
                {
                    dgvc.Style.BackColor = Color.Magenta;
                }
                else
                {
                    dgvc.Style.BackColor = Color.Orange;
                }

                string vegan = (dgvc.Value).ToString();

                if (vegan.Trim() == "素食")
                {
                    dgvc.Style.BackColor = Color.Green;
                }

            }


        }


    }
}
