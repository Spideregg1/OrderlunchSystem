using System;
using System.Linq;
using System.Windows.Forms;

namespace lunchsystem
{
    public partial class Menu_form : Form
    {
        MylunchEntities1 db = new MylunchEntities1();//lunch db
        public string _lunch_name = null;
        public string _index_lunch_id = null;
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
        
    }
}
