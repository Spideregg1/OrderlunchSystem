using System;

namespace lunchsystem
{
    internal class LunchViewModel : C2NF_訂單細表
    {
        public int detail_id { get; set; }
        public Nullable<int> lunch_id { get; set; }
        public string employee_name { get; set; }
        public string lunch { get; set; }
    }
}
