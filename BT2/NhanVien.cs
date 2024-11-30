using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT2
{
    public class NhanVien
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int LuongCB  { get; set; }
        public NhanVien(int id, string name, int luongcb)
        {
            ID = id;
            Name = name;
            LuongCB = luongcb;
        }

        public NhanVien()
        {
        }
    }
}
