using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimDuong_GiaoHang
{
    public partial class frm_Canh : Form
    {
        public frm_Canh()
        {
            InitializeComponent();
        }

        public List<ChuTrinh> lst;

        public void GetData()
        {
            for (int i = 0; i < lst.Count; i++)
            {

                string s = lst[i].Start.Name + " --> " + lst[i].Stop.Name;
                lst_canh.Items.Add((i + 1).ToString());
                lst_canh.Items[i].SubItems.Add(s);
                lst_canh.Items[i].SubItems.Add(lst[i].Khoangcach.ToString());
            }
        }

        private void frm_Canh_Load(object sender, EventArgs e)
        {
            GetData();
        }
    }
}
