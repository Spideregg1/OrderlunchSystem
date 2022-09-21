using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace lunchsystem
{
    public partial class Form1 : Form
    {
        MylunchEntities db = new MylunchEntities();//lunch db
        lunchtable lunchtable = new lunchtable();//lunch
        
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'mylunchDataSet1.lunchtable' 資料表。您可以視需要進行移動或移除。
            this.lunchtableTableAdapter1.Fill(this.mylunchDataSet1.lunchtable);
            comboBox1.Items.Add(new ComboBoxItem("1", "姓名"));
            comboBox1.Items.Add(new ComboBoxItem("2", "午餐"));
            Clear();
            LoadData();
        }

        public void LoadData()//load data
        {
            dataGridView1.AutoGenerateColumns = false;
            using (MylunchEntities db = new MylunchEntities())
            {
                dataGridView1.DataSource = db.lunchtables.ToList();
            }
        }

        private void btn_insert_Click(object sender, EventArgs e) //新增
        {
            if (String.IsNullOrEmpty(txt_name.Text) || (String.IsNullOrEmpty(txt_lunch.Text)))//防止空的
            {
                MessageBox.Show("請填入資料");
            }
            else
            {
                lunchtable.name = txt_name.Text.Trim();
                lunchtable.lunch = txt_lunch.Text.Trim();
                using (MylunchEntities db = new MylunchEntities())
                {
                    if (lunchtable.id == 0)
                    {
                        db.lunchtables.Add(lunchtable);
                    }
                    /*else
                    {
                        db.Entry(lunchtable).State = EntityState.Modified;
                    }*/
                    db.SaveChanges();
                }
                Clear();
                LoadData();
                MessageBox.Show("新增成功！");
            }
        }

        private void btnread_Click(object sender, EventArgs e) //查詢
        {
            string value= ComboBoxUtil.GetItem(comboBox1).Value;
            if (value == "1")
            {
                dataGridView1.DataSource = db.lunchtables.Where(x => x.name.Contains(txt_name.Text)).ToList();
            }
            else if (value=="2")
            {
                dataGridView1.DataSource = db.lunchtables.Where(x => x.lunch.Contains(txt_lunch.Text)).ToList();
            }
        }

        void Clear()//清空txt的資料值
        {
            txt_name.Text = txt_lunch.Text = "";
            lunchtable.id = 0;
        }

        private void btn_update_Click(object sender , EventArgs e)//更新
        {
            lunchtable.name = txt_name.Text.Trim();
            lunchtable.lunch = txt_lunch.Text.Trim();
            using (MylunchEntities db = new MylunchEntities())
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
            using (MylunchEntities db = new MylunchEntities())
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
                using (MylunchEntities db = new MylunchEntities())
                {
                    lunchtable = db.lunchtables.Where(x => x.id == lunchtable.id).FirstOrDefault();
                    txt_name.Text = lunchtable.name;
                    txt_lunch.Text = lunchtable.lunch;
                }
            }
        }

       
    }
}
