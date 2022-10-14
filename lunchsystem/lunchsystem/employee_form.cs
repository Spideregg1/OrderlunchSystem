using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace lunchsystem
{
    public partial class employee_form : Form
    {
        MylunchEntities1 db = new MylunchEntities1();//lunch db
        C2NF_員工清單 employee_list = new C2NF_員工清單();//employee

        

        public employee_form()
        {
            InitializeComponent();
        }
        private void employee_form_Load(object sender, EventArgs e)
        {
            Clear();
            LoadData();
        }

        public void LoadData()//load data
        {
            dataGridView1.AutoGenerateColumns = false;
            using (MylunchEntities1 db = new MylunchEntities1())
            {
                dataGridView1.DataSource = db.C2NF_員工清單.ToList();
            }
        }

        void Clear()//清空text的資料值
        {
            txt_employee_name.Text = "";

            employee_list.employee_id = 0;


        }
        #region CRUD部分
        private void btn_insert_Click(object sender, EventArgs e)//新增
        {

            //防呆

            if (string.IsNullOrEmpty(txt_employee_name.Text))
            {
                MessageBox.Show("請填入姓名");
            }
            else
            {
                employee_list.employee_name = txt_employee_name.Text.Trim();
                if (employee_list.employee_id == 0)
                {
                    db.C2NF_員工清單.Add(employee_list);
                }
                db.SaveChanges();
                Clear();
                LoadData();
                MessageBox.Show("新增成功");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)//點擊二下想改的地方
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                employee_list.employee_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["employee_id"].Value);
                employee_list = db.C2NF_員工清單.Where(x => x.employee_id == employee_list.employee_id).FirstOrDefault();
                txt_employee_name.Text = employee_list.employee_name;
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)//更新
        {

            employee_list.employee_name = txt_employee_name.Text;
            if (employee_list.employee_id != 0)
            {
                db.Entry(employee_list).State = EntityState.Modified;
            }
            db.SaveChanges();
            Clear();
            LoadData();
            MessageBox.Show("更新成功");
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            var entry = db.Entry(employee_list);
            if (entry.State == EntityState.Detached)
            {
                db.C2NF_員工清單.Attach(employee_list);
            }
            db.C2NF_員工清單.Remove(employee_list);
            db.SaveChanges();
            LoadData();
            Clear();
            MessageBox.Show("刪除成功");
        }
        #endregion

       
    }
}
