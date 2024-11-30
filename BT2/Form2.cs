using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT2
{
    public partial class Form2 : Form
    {

        private List<NhanVien> Students; // Danh sách nhân viên
        private NhanVien currentNhanVien; // Nhân viên hiện tại (để sửa hoặc thêm)

        // Constructor nhận danh sách nhân viên và nhân viên hiện tại
        public Form2(List<NhanVien> nhanvien, NhanVien nhanVien)
        {
            InitializeComponent();
            Students = nhanvien;

            if (nhanVien != null)
            {
                // Nếu sửa, điền dữ liệu vào các TextBox
                currentNhanVien = nhanVien;
                txtID.Text = nhanVien.ID.ToString();
                txtName.Text = nhanVien.Name;
                txtLuong.Text = nhanVien.LuongCB.ToString(); // Cập nhật giá trị vào txtLuong
            }
            else
            {
                // Nếu thêm mới, tạo một đối tượng mới
                currentNhanVien = new NhanVien();
            }
        }

        private void btDongY_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường có trống không
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtLuong.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại nếu có trường trống
            }

            // Kiểm tra xem txtLuong có phải là số hợp lệ không
            int luong;
            if (!int.TryParse(txtLuong.Text, out luong))
            {
                MessageBox.Show("Lương phải là một số hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng lại nếu lương không hợp lệ
            }

            // Cập nhật thông tin của nhân viên
            currentNhanVien.ID = int.Parse(txtID.Text);
            currentNhanVien.Name = txtName.Text;
            currentNhanVien.LuongCB = luong; // Cập nhật lương từ txtLuong

            // Kiểm tra xem nhân viên đã tồn tại trong danh sách chưa, so sánh theo ID
            if (!Students.Any(nv => nv.ID == currentNhanVien.ID))
            {
                Students.Add(currentNhanVien); // Nếu chưa tồn tại, thêm vào danh sách
            }

            // Đóng form sau khi lưu
            this.Close();
        }

        private void btBoQua_Click(object sender, EventArgs e)
        {
            // Đóng form mà không lưu thông tin
            this.Close();
        }
    }
}
