using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace lunchsystem
{
    public partial class Form1 : Form
    {
        MylunchEntities1 db = new MylunchEntities1();//lunch db
        lunchtable lunchtable = new lunchtable();//lunch

        public Form1()
        {
            InitializeComponent();
        }
        private string _lunchtime = "";


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'mylunchDataSet1.lunchtable' 資料表。您可以視需要進行移動或移除。
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";

            //更改成民國



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
            using (MylunchEntities1 db = new MylunchEntities1())
            {
                dataGridView1.DataSource = db.lunchtables.ToList();
            }
        }

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

                lunchtable.name = txt_name.Text.Trim();
                lunchtable.lunch = txt_lunch.Trim();
                lunchtable.date = Convert.ToDateTime(_lunchtime);
                using (MylunchEntities1 db = new MylunchEntities1())
                {
                    if (lunchtable.id == 0)
                    {
                        db.lunchtables.Add(lunchtable);

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
        }

        private void btn_update_Click(object sender, EventArgs e)//更新
        {
            string txt_lunch = null;
            txt_lunch = valueoflunch();
            lunchtable.name = txt_name.Text.Trim();
            lunchtable.lunch = txt_lunch.Trim();
            lunchtable.date = Convert.ToDateTime(_lunchtime);
            //lunchtable.date = txt_date.Text.Trim();
            using (MylunchEntities1 db = new MylunchEntities1())
            {
                if (lunchtable.id != 0)
                {
                    db.Entry(lunchtable).State = EntityState.Modified;
                }
                db.SaveChanges();
            }
            Clear();
            LoadData();
            MessageBox.Show("更新成功！");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            using (MylunchEntities1 db = new MylunchEntities1())
            {
                var entry = db.Entry(lunchtable);
                if (entry.State == EntityState.Detached)
                {
                    db.lunchtables.Attach(lunchtable);
                }
                db.lunchtables.Remove(lunchtable);
                db.SaveChanges();
                LoadData();
                Clear();
                MessageBox.Show("刪除成功");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)//點擊二下想改的地方
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                lunchtable.id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["id"].Value);
                using (MylunchEntities1 db = new MylunchEntities1())
                {
                    lunchtable = db.lunchtables.Where(x => x.id == lunchtable.id).FirstOrDefault();
                    txt_name.Text = lunchtable.name;

                    //txt_date.Text = lunchtable.date;
                }
            }
        }

        private string valueoflunch()//將午餐選單判斷是寫成Function
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
