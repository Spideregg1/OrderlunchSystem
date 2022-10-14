using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace lunchsystem
{
    public partial class main_form : Form
    {
        MylunchEntities1 db = new MylunchEntities1();//lunch db
        lunchtable lunchtable = new lunchtable();//lunch
        C2NF_訂單細表 form_head = new C2NF_訂單細表();//表頭
        C3NF_午餐 form_body = new C3NF_午餐();//表身
        C2NF_員工清單 employee_item = new C2NF_員工清單();//員工清單
        C3NF_午餐種類 lunch_item = new C3NF_午餐種類();//午餐種類
        LunchViewModel lunchViewModel = new LunchViewModel();//LunchViewmodel

        public main_form()
        {
            InitializeComponent();
        }
        private string _lunchtime = "";



        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'mylunchDataSet1.lunchtable' 資料表。您可以視需要進行移動或移除。
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";

            comboBox1.Items.Add(new ComboBoxItem("1", "姓名"));
            comboBox1.Items.Add(new ComboBoxItem("2", "午餐"));
            comboBox1.Items.Add(new ComboBoxItem("3", "日期"));

            comboBox_lunch.Items.Add(new ComboBoxItem("1", "便當"));
            comboBox_lunch.Items.Add(new ComboBoxItem("2", "素食"));
            comboBox_lunch.Items.Add(new ComboBoxItem("3", "炒飯"));
            Clear();
            LoadData();
        }


        public void LoadData()//load data
        {
            dataGridView1.AutoGenerateColumns = false;

            // TODO ViewModel
            // TODO Model、Entity => 相似

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
                            lunch_id = fb.lunch_id,
                            lunch = li.lunch,
                            date = fh.date
                        };

            var source = query.ToList();

            //var demo = new List<C2NF_訂單細表>();
            //demo.Add(new C2NF_訂單細表() { employee_id = 1, date = DateTime.Today });
            //demo.Select((s, index) => new LunchViewModel() 
            //{ 

            //});

            //source.Select(s => new LunchViewModel()
            //{
            //    employee_id = s.employee_id,
            //    date = DateAdd7(DateTime.Today),
            //    Employee_Name = "測試"
            //}
            //); ;

            //DateTime DateAdd7(DateTime dt)
            //{
            //    return dt.AddDays(7);
            //}

            dataGridView1.DataSource = source;

            //using (MylunchEntities1 db = new MylunchEntities1())
            //{
            //    foreach (var item in query)
            //    {
            //        dataGridView1.DataSource = item.ToList();
            //    }
            //}
        }

        #region CRUD部分
        private void btn_insert_Click(object sender, EventArgs e) //新增
        {

            string value_lunch = ComboBoxUtil.GetItem(comboBox_lunch).Value;
            string txt_lunch = null;
            if (String.IsNullOrEmpty(txt_name.Text))//防止空的
            {
                MessageBox.Show("請填入資料");
            }
            else
            {
                txt_lunch = valueoflunch();
                lunchViewModel.employee_name = txt_name.Text.Trim();
                lunchViewModel.lunch = txt_lunch.Trim();
                lunchViewModel.date = Convert.ToDateTime(_lunchtime);

                lunchtable.name = txt_name.Text.Trim();
                lunchtable.lunch = txt_lunch.Trim();
                lunchtable.date = Convert.ToDateTime(_lunchtime);
                form_head.date = Convert.ToDateTime(_lunchtime);


                var query = from a in db.C2NF_員工清單 orderby a.employee_id select a; // 搜尋全部員工的清單
                var lunch_query = from b in db.C3NF_午餐種類 orderby b.lunch_id select b;//搜尋全部午餐的種類


                using (MylunchEntities1 db = new MylunchEntities1())
                {
                    if (lunchtable.id == 0)
                    {
                        db.lunchtables.Add(lunchtable);
                    }
                    if (form_head.master_id == 0)
                    {
                        foreach (var item in query)//走訪全部
                        {

                            if (txt_name.Text.Trim() == item.employee_name.Trim())//如果輸入的姓名與員工清單的姓名一樣
                            {
                                form_head.employee_id = item.employee_id;//訂單細表的employee_id就是員工清單的employee_id
                                lunchViewModel.employee_id = item.employee_id;
                            }
                        }
                        foreach (var item in lunch_query)
                        {
                            if (lunchtable.lunch == item.lunch.Trim())//如果輸入的午餐與午餐種類一樣
                            {
                                form_body.lunch_id = item.lunch_id;//id一致
                                lunchViewModel.lunch_id = item.lunch_id;
                            }
                        }


                        db.C3NF_午餐.Add(form_body);
                        db.C2NF_訂單細表.Add(form_head);
                    }


                    db.SaveChanges();
                }
                Clear();
                LoadData();
                MessageBox.Show("新增成功！");
            }
        }

        private void btnread_Click(object sender, EventArgs e) //查詢
        {
            string txt_lunch = null;
            string value = ComboBoxUtil.GetItem(comboBox1).Value;
            lunchtable.date = Convert.ToDateTime(_lunchtime);


            txt_lunch = valueoflunch();

            if (value == "1")
            {
                dataGridView1.DataSource = db.lunchtables.Where(x => x.name.Contains(txt_name.Text)).ToList();
            }
            else if (value == "2")
            {
                dataGridView1.DataSource = db.lunchtables.Where(x => x.lunch.Contains(txt_lunch)).ToList();
            }
            else if (value == "3")
            {

                dataGridView1.DataSource = db.lunchtables.Where(x => x.date == lunchtable.date).ToList();
            }
        }

        void Clear()//清空text的資料值
        {
            txt_name.Text = "";

            lunchtable.id = 0;

            form_head.master_id = 0;

            form_head.employee_id = 0;

            form_body.detail_id = 0;

            form_body.master_id = 0;

        }

        private void btn_update_Click(object sender, EventArgs e)//更新
        {

            string txt_lunch = null;
            txt_lunch = valueoflunch();

            var query = from a in db.C2NF_員工清單 orderby a.employee_id select a; // 搜尋全部員工的清單
            var lunch_query = from b in db.C3NF_午餐種類 orderby b.lunch_id select b;//搜尋全部午餐的種類

            //lunchtable.name = txt_name.Text.Trim();
            //lunchtable.lunch = txt_lunch.Trim();
            //lunchtable.date = Convert.ToDateTime(_lunchtime);

            var entity = new C2NF_員工清單();

            var head = new C2NF_訂單細表();

            var body = new C3NF_午餐();




            entity.employee_name = txt_name.Text;
            head.date = Convert.ToDateTime(_lunchtime);


            var lunch_entity = new C3NF_午餐種類();

            lunch_entity.lunch = txt_lunch.Trim();




            using (MylunchEntities1 db = new MylunchEntities1())
            {
                //if (lunchtable.id != 0)
                //{
                //    db.Entry(lunchtable).State = EntityState.Modified;
                //}

                if (form_head.master_id != 0)
                {
                    foreach (var item in query)//走訪全部
                    {
                        if (entity.employee_name.Trim() == item.employee_name.Trim())//如果輸入的姓名與員工清單的姓名一樣
                        {
                            head.employee_id = item.employee_id;//訂單細表的employee_id就是員工清單的employee_id
                        }

                    }

                    foreach (var item in lunch_query)
                    {
                        if (lunch_entity.lunch.Trim() == item.lunch.Trim())//如果輸入的午餐與午餐種類一樣
                        {
                            lunch_entity.lunch_id = item.lunch_id;//id一致
                        }
                    }
                    body.master_id = form_head.master_id;
                    body.lunch_id = lunch_entity.lunch_id;
                    body.detail_id = form_head.master_id;
                    head.master_id = form_head.master_id;
                    //db.C2NF_訂單細表.AddOrUpdate(head);
                    db.Entry(head).State = EntityState.Modified;
                    db.Entry(body).State = EntityState.Modified;
                    // db.Entry(lunchViewModel).State = EntityState.Modified;
                    // db.Entry(form_body).State = EntityState.Modified;

                }

                db.SaveChanges();
            }

            Clear();
            LoadData();
            MessageBox.Show("更新成功！");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            
            var entry=db.Entry(form_head);
            var entry2 = db.Entry(form_body);

            if (entry.State == EntityState.Detached && entry2.State == EntityState.Detached)
            {
                db.C2NF_訂單細表.Attach(form_head);
                db.C3NF_午餐.Attach(form_body);
                 
            }
            db.C2NF_訂單細表.Remove(form_head);
            db.C3NF_午餐.Remove(form_body);

            db.SaveChanges();
                LoadData();
                Clear();
                MessageBox.Show("刪除成功");
        }
        

        private void dataGridView1_DoubleClick(object sender, EventArgs e)//點擊二下想改的地方
        {

            if (dataGridView1.CurrentRow.Index != -1)
            {
                form_head.master_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["master_id"].Value);
                form_body.lunch_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["lunch_id"].Value);

                using (MylunchEntities1 db = new MylunchEntities1())
                {

                    form_head = db.C2NF_訂單細表.Where(x => x.master_id == form_head.master_id).FirstOrDefault();
                    form_body = db.C3NF_午餐.Where(x => x.lunch_id == form_body.lunch_id).FirstOrDefault();


                    txt_name.Text = form_head.C2NF_員工清單.employee_name;

                    comboBox_lunch.Text = form_body.C3NF_午餐種類.lunch;
                    dateTimePicker1.Value = (DateTime)form_head.date;

                    //txt_date.Text = lunchtable.date;
                }
            }
        }
        #endregion 

        private string valueoflunch()//將午餐選單判斷式寫成Function
        {
            string txt_lunch = null;
            string value_lunch = ComboBoxUtil.GetItem(comboBox_lunch).Value;
            //加入午餐選單判斷式
            if (value_lunch == "1")
            {
                txt_lunch = ComboBoxUtil.GetItem(comboBox_lunch, 0).Text;

            }
            else if (value_lunch == "2")
            {
                txt_lunch = ComboBoxUtil.GetItem(comboBox_lunch, 1).Text;
            }
            else if (value_lunch == "3")
            {
                txt_lunch = ComboBoxUtil.GetItem(comboBox_lunch, 2).Text;
            }
            return txt_lunch;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            _lunchtime = dateTimePicker1.Text;
            txt_showdate.Text = dateTimePicker1?.Value.TWDate();
            // DateTime.TWDate()
            // 擴充方法 Extension method
        }

       
    }
}
