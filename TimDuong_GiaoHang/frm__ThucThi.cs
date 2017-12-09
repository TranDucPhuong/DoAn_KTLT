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
    public partial class frm__ThucThi : Form
    {
        //Hello
        public List<ThanhPho> list_TP;//list lưu các các thành phố được khởi tạo
        public List<ChuTrinh> lst_Chutrinh;//list chu trình giao hàng
        PictureBox[] pic_tp;
        Graphics g;//đối tượng graphics đễ vẽ Arrow

        public frm__ThucThi()
        {
            InitializeComponent();
        }
        void khoitao()
        {
            pic_tp = new PictureBox[] { pic_1, pic_2, pic_3, pic_4, pic_5, pic_6, pic_7, pic_8, pic_9, pic_10 };//khởi tạo mảng lưu các picture box
            for (int i = 0; i < list_TP.Count; i++)
            {
                pic_tp[i].Location = new Point(list_TP[i].X, list_TP[i].Y);
                pic_tp[i].Visible = true;
            }
        }
        public void Draw(Point a, Point b, Pen p)//vẽ đường đi dựa theo tọa độ
        {
            g = CreateGraphics();
            //Pen p = new Pen(Brushes.Black, 4);
            p.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            //if (a.X > b.X)
            //{
            //    Point start = new Point(b.X + 25, b.Y + 63);
            //    Point stop = new Point(a.X + 25, a.Y);
            //    g.DrawLine(p, start, stop);
            //}
            //else
            //{
                
            //}

            if (a.Y > b.Y)
            {
                Point start = new Point(b.X + 25, b.Y + 32);
                Point stop = new Point(a.X, a.Y + 63);
                g.DrawLine(p, start, stop);
            }
            else
                if (a.Y < b.Y)
                {
                    Point start = new Point(b.X + 25, b.Y);
                    Point stop = new Point(a.X + 25, a.Y + 66);
                    g.DrawLine(p, start, stop);
                }
                else
                {
                    Point start = new Point(b.X, b.Y + 30);
                    Point stop = new Point(a.X + 25, a.Y + 30);
                    g.DrawLine(p, start, stop);
                }

        }
        private void frm__ThucThi_Load(object sender, EventArgs e)
        {
            khoitao();
        }

        int chutrinh = 0;//giá trị lưu sô chu trình
        private void timer1_Tick(object sender, EventArgs e)
        {
            List<Brush> br = new List<Brush>() 
            { Brushes.Red, 
              Brushes.Orange, 
              Brushes.Yellow, 
              Brushes.Yellow, 
              Brushes.Green, 
              Brushes.Blue,
              Brushes.Indigo,
              Brushes.Violet,
              Brushes.RosyBrown,
              Brushes.HotPink,
              Brushes.Lavender
            };
            Pen p = new Pen(br[chutrinh], 7);
            if (chutrinh == lst_Chutrinh.Count)//điều kiện dừng timer
            {
                timer1.Stop();
                MessageBox.Show("Hoàn Thành", "Thông Báo");
                return;
            }
            Point x = new Point(lst_Chutrinh[chutrinh].Start.X, lst_Chutrinh[chutrinh].Start.Y);//khởi tọa tọa độ của thành phố start
            Point y = new Point(lst_Chutrinh[chutrinh].Stop.X, lst_Chutrinh[chutrinh].Stop.Y);//khởi tạo tọa độ của thành phố stop
            Draw(x, y, p);//vẽ đường đi dựa theo hai tọa độ 
            chutrinh++;
        }
    }


}
