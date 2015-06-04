using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics; //Cung cấp truy cập đến các quá trình địa phương và từ xa và cho phép bạn bắt đầu và ngừng quá trình hệ thống địa phương.

namespace Task_Manager
{
    public partial class Taskmanager : Form
    {
        public Taskmanager()
        {
            InitializeComponent();
        }
        Process[] process;   // Khởi tạo mảng null process

        //Lấy các process đang xử lý trong máy đưa vào list box

        private void GetProcess()
        {
            process = Process.GetProcesses();
            if (int.Parse(lblNumberProcess.Text) != process.Length)
            {
                listProcess.Items.Clear();         //Xoá sạch listbox 
                for (int i = 0; i < process.Length; i++)
                {
                    listProcess.Items.Add(process[i].ProcessName);
                }
                lblNumberProcess.Text = process.Length.ToString();  // Đếm số process
            }
        }

        private void KillProcess(int index)     //Tạo 1 biến int index: chỉ mục
        {
            process[index].Kill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetProcess();
            timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KillProcess(listProcess.SelectedIndex);  // Kill Process trong index được chọn trong listbox
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetProcess();
        }
        //Tự động cập nhật số Process trong 1s



        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KillProcess(listProcess.SelectedIndex);
        }
        //Thêm chức năng mới có nút chọn phải Kill

    }
}
