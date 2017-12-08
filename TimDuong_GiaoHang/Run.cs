using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HaNoi_Tower;

namespace TimDuong_GiaoHang
{
    public partial class Run : Form
    {
        public Run()
        {
            InitializeComponent();
        }

        private void but_thapHN_Click(object sender, EventArgs e)
        {
            HaNoi_Tower_Main hn = new HaNoi_Tower_Main();
            hn.ShowDialog();
        }

        private void but_timdg_Click(object sender, EventArgs e)
        {
            TimDuong_GiaoHang td = new TimDuong_GiaoHang();
            td.ShowDialog();
        }
    }
}
