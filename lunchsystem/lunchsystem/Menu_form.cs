using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace lunchsystem
{

    public partial class Menu_form : Form
    {
        MylunchEntities1 db = new MylunchEntities1();//lunch db
        // TODO 20220224 請說明回傳值選擇，為什麼是串接字串回傳？
        public string _lunch_name = null;
        public string _index_lunch_id = null;

        public const int low_price = 0;
        public const int high_price = 50;

        public Menu_form()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            dataGridView_menu.AutoGenerateColumns = false;


            dataGridView_menu.AutoResizeColumns();

            dataGridView_menu.DataSource = db.C3NF_午餐種類.ToList();

        }


        private void Menu_form_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btn_add_lunch_Click(object sender, EventArgs e) // 新增餐點按鈕
        {
            int lunch_id = 0;
            string lunch_name = "";
            string msg = "";
            string msg_id = "";

            int row = dataGridView_menu.RowCount - 1;



            for (int i = 0; i <= row; i++)
            {
                if (Convert.ToBoolean(dataGridView_menu.Rows[i].Cells[pick.Index].Value) == true)
                {

                    lunch_id = (int)dataGridView_menu.Rows[i].Cells[pick_lunch_id.Index].Value;

                    lunch_name = dataGridView_menu.Rows[i].Cells[lunch_list.Index].Value.ToString();
                    msg += lunch_name;
                    msg_id += lunch_id.ToString();
                }


            }

            _lunch_name = msg;
            _index_lunch_id = msg_id;

            main_form main_Form = (main_form)this.Owner;
            main_Form.id_value = _index_lunch_id;

            this.Close();




        }

        private void datagridview_change_color(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                int color_changed_price = Convert.ToInt32(dataGridView_menu.Rows[e.RowIndex].Cells[price.Index].Value);


                DataGridViewCell dgvc = dataGridView_menu.Rows[e.RowIndex].Cells[price.Index];
                // TODO 20221024 Google Magic Number done!

                if (color_changed_price <= high_price && color_changed_price >= low_price)
                {
                    // TODO 20221024 dataGridView_menu.Rows[e.RowIndex].Cells[price.Index].Style.BackColor 重覆 done!
                    dgvc.Style.BackColor = Color.Blue;
                }
                else
                {
                    dgvc.Style.BackColor = Color.Red;
                }
            }
        }

    }
}
