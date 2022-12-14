using System;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

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
           
            dataGridView1.DataSource = db.C3NF_午餐種類.ToList();
            
            
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
            else if (string.IsNullOrEmpty(txt_price.Text))
            {
                MessageBox.Show("請輸入價格");
            }
            else
            {
                


                lunchitemtable.lunch = txt_lunch_name.Text.Trim();
                lunchitemtable.price = Convert.ToInt32(txt_price.Text.Trim());
                lunchitemtable.photo = ConvertFiltoByte(pictureBox1.ImageLocation);

                
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
            if (dataGridView1.CurrentRow.Index == -1)
            {
                return;
            }
                lunchitemtable.lunch_id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[lunch_id.Index].Value);
                lunchitemtable= db.C3NF_午餐種類.Where(x => x.lunch_id == lunchitemtable.lunch_id).FirstOrDefault();
                txt_lunch_name.Text = lunchitemtable.lunch;
                txt_price.Text = lunchitemtable.price.ToString();
            
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            lunchitemtable.lunch = txt_lunch_name.Text;
            lunchitemtable.price = Convert.ToInt32(txt_price.Text);
            lunchitemtable.photo = ConvertFiltoByte(pictureBox1.ImageLocation);
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

        //上傳圖片
        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog odg = new OpenFileDialog();
            
                odg.Title = "打開圖片";
                odg.Filter = "png files(*.png)|*.png";
                if (odg.ShowDialog() == DialogResult.OK)
                {
                    Image image = Image.FromFile(odg.FileName);
                    pictureBox1.ImageLocation = odg.FileName;
                }
        }
        
        private byte[] ConvertFiltoByte(string sPath)
        {
            byte[] data = null;
            FileInfo fInfo=new FileInfo(sPath);
            long numBytes = fInfo.Length;
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fStream);
            data = br.ReadBytes((int)numBytes);
            return data;
        }
    }
}
