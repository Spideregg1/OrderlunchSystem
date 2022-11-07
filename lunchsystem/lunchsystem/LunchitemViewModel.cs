using System.Drawing;

namespace lunchsystem
{
    internal class LunchitemViewModel
    {
        public int lunch_id { get; set; }
        public string lunch { get; set; }
        public int price { get; set; }

        public byte[] photo { get; set; }
    }
}
