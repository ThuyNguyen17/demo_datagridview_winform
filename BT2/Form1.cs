using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BT2
{
    public partial class Form1 : Form
    {
        private List<NhanVien> DSNhanVien; 
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DSNhanVien = new List<NhanVien>();
            DSNhanVien.Add(new NhanVien(1, "Nguyen Van A", 18000));
            DSNhanVien.Add(new NhanVien(2, "Nguyen Van B", 19444));
            DSNhanVien.Add(new NhanVien(3, "Nguyen Van C", 20555));
            DSNhanVien.Add(new NhanVien(4, "Nguyen Van D", 216666));
            DataListNV.DataSource = DSNhanVien;
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(DSNhanVien, null); 
            form2.ShowDialog();

            UpdateDataGridView();

            // Để dòng có màu xanh 
            if (DSNhanVien.Count > 0)
            {
                currentRowIndex = DSNhanVien.Count - 1;
                DataListNV.Rows[currentRowIndex].Selected = true;
                DataListNV.CurrentCell = DataListNV.Rows[currentRowIndex].Cells[0];
            }
            //int vt = Students.Count;
            //DataListStudent.CurrentCell = DataListStudent.Rows[vt - 1].Cells[0];

        }


        private void DataListStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentRowIndex = e.RowIndex;
            }
        }
        private void UpdateDataGridView()
        {
            DataListNV.DataSource = null;
            DataListNV.DataSource = new BindingList<NhanVien>(DSNhanVien);
        }
        private int currentRowIndex = -1;

        private void btUpdate_Click(object sender, EventArgs e)
        {
            if (currentRowIndex >= 0 && currentRowIndex < DSNhanVien.Count)
            {
                // Lấy nhân viên được chọn
                NhanVien selectedNhanVien = DSNhanVien[currentRowIndex];

                // Mở Form2 để chỉnh sửa
                Form2 form2 = new Form2(DSNhanVien, selectedNhanVien);
                form2.ShowDialog();

                // Cập nhật lại DataGridView
                UpdateDataGridView();

                // màu
                DataListNV.Rows[currentRowIndex].Selected = true;
                DataListNV.CurrentCell = DataListNV.Rows[currentRowIndex].Cells[0];
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để sửa.");
            }
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if (currentRowIndex >= 0 && currentRowIndex < DSNhanVien.Count)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    DSNhanVien.RemoveAt(currentRowIndex);
                    UpdateDataGridView();

                    // Chọn dòng sau khi xóa
                    if (DSNhanVien.Count > 0)
                    {
                        currentRowIndex = Math.Min(currentRowIndex, DSNhanVien.Count - 1);
                        DataListNV.Rows[currentRowIndex].Selected = true;
                        DataListNV.CurrentCell = DataListNV.Rows[currentRowIndex].Cells[0];
                    }
                    else
                    {
                        currentRowIndex = -1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }
            
            // CellcontentClick: Chỉ nội dung trong ô
            // CellClick: Toàn bộ ô (nền và nội dung)
        

        private void btExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
