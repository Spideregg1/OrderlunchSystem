using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace lunchsystem
{
    public partial class lunchitem : Form
    {
        MylunchEntities1 db = new MylunchEntities1();//lunch db
        C3NF_午餐種類 lunchitemtable = new C3NF_午餐種類();
        public lunchitem()
        {
            InitializeComponent();
        }

        private void lunchitem_Load(object sender, EventArgs e)
        {
            Clear();
            LoadData();
        }
        public void LoadData()//load data
        {
            dataGridView1.AutoGenerateColumns = false;
            using (MylunchEntities1 db = new MylunchEntities1())
            {
                dataGridView1.DataSource = db.C3NF_午餐種類.ToList();
            }
            
        }

        void Clear()//清空text的資料值
        {
            txt_lunch_name.Text = "";

            lunchitemtable.lunch_id = 0;


        }
        #region CRUD部分



        

        private void btn_insert_Click(object sender, EventArgs e)
        {
            //防呆

            if (string.IsNullOrEmpty(txt_lunch_name.Text))
            {
                MessageBox.Show("請填入種類");
            }
            else
            {
                lunchitemtable.lunch = txt_lunch_name.Text.Trim();
                if (lunchitemtable.lunch_id == 0)
                {
                    db.C3NF_午餐種類.Add(lunchitemtable);
                }
                db.SaveChanges();
                Clear();
                LoadData();
                MessageBox.Show("新增成功");
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            var entry = db.Entry(lunchitemtable);
            if (entry.State == EntityState.Detached)
            {
                db.C3NF_午餐種類.Attach(lunchitemtable);

                db.C3NF_午餐種類.Remove(lunchitemtable);
                db.SaveChanges();
                LoadData();
                Clear();
            }
            MessageBox.Show("刪除成功");
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)//點擊二下想改的地方
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                lunchitemtable.lunch_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["lunch_id"].Value);
                lunchitemtable= db.C3NF_午餐種類.Where(x => x.lunch_id == lunchitemtable.lunch_id).FirstOrDefault();
                txt_lunch_name.Text = lunchitemtable.lunch;
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            lunchitemtable.lunch = txt_lunch_name.Text;
            if (lunchitemtable.lunch_id != 0)
            {
                db.Entry(lunchitemtable).State = EntityState.Modified;
            }
            db.SaveChanges();
            Clear();
            LoadData();
            MessageBox.Show("更新成功");
        }

        #endregion


    }
}
