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
    public partial class TimDuong_GiaoHang : Form
    {
        public TimDuong_GiaoHang()
        {
            InitializeComponent();
        }
        //==============================================================================================================
        ToaDo[] cbb_toado;//Mang lưu các đối tượng combobox tọa độ
        int SoTP = 0;//giá trị lưu số thành phố
        List<ThanhPho> lst_Thanhpho;//list lưu các các thành phố được khởi tạo
        List<ChuTrinh> lst_Chutrinh;//list chu trình giao hàng
        List<ChuTrinh> lst_Canh;//list các tuyến đường
        //List<PictureBox> lThanhPho = new List<PictureBox>();//list lưu  các thành phố được khởi tạo
        TimDuongGiaoHang timduong;//đối tượng tìm đường giao hàng
        Graphics g;//đối tượng graphics đễ vẽ Arrow
        //==============================================================================================================
        void load()//Hàm khởi tạo các giá trị ban đầu
        {
            cbb_toado = new ToaDo[]//khởi tạo mảng lưu các combobox tọa độ
            {
                new ToaDo(cbb_X1,cbb_Y1),
                new ToaDo(cbb_X2,cbb_Y2),
                new ToaDo(cbb_X3,cbb_Y3),
                new ToaDo(cbb_X4,cbb_Y4),
                new ToaDo(cbb_X5,cbb_Y5),
                new ToaDo(cbb_X6,cbb_Y6),
                new ToaDo(cbb_X7,cbb_Y7),
                new ToaDo(cbb_X8,cbb_Y8),
                new ToaDo(cbb_X9,cbb_Y9),
                new ToaDo(cbb_X10,cbb_Y10)
            };
            but_nhapsotp.Enabled = false;
            foreach (ToaDo td in cbb_toado)//Cho giá tị Enable của các combobox ban đầu bằng false
            {
                td.X.Enabled = false;
                td.Y.Enabled = false;
            }
            but_khoitao.Enabled = false;
            but_start.Enabled = false;
            cbb_sotp.Enabled = true;
        }
        //==============================================================================================================
        void Nhap_cbb_XY()//nhập dữ liệu cho các combobox
        {
            List<string> x = new List<string>() {"0,5","1","1,5","2","2,5","3","3,5","4","4,5","5","5,5","6","6,5","7","7,5","8","8,5","9"};
            List<string> y = new List<string>() { "0,5", "1", "1,5", "2", "2,5", "3", "3,5", "4", "4,5", "5", "5,5","6" };
            for (int j = 0; j < x.Count; j++)//nhập cho các cbb_X
            {
                for (int i = 0; i < SoTP; i++)
                {
                    cbb_toado[i].X.Items.Add(x[j]);
                }
            }

            for (int j = 0; j < y.Count; j++)//nhập cho các cbb_Y
            {
                for (int i = 0; i < SoTP; i++)
                {
                    cbb_toado[i].Y.Items.Add(y[j]);
                }
            }
        }
        //==============================================================================================================
        private void TimDuong_GiaoHang_Load(object sender, EventArgs e)//sự kiện load
        {
           
            load();
        }
        //==============================================================================================================
        void Draw_Line()//vẽ đường thẳng
        {
            Point x = new Point(30, 30);
            Point y = new Point(30, 600);
            Point z = new Point(900, 30);
            g = CreateGraphics();
            Pen p = new Pen(Brushes.Black, 5);
            g.DrawLine(p,x,y);
            g.DrawLine(p, x, z);
        }
        //==============================================================================================================
        private void but_nhapsotp_Click(object sender, EventArgs e)//sự kiện click của button nhập sô thành phố
        {
            lst_Thanhpho = new List<ThanhPho>();//khởi tạo đối tượng
            lst_Chutrinh = new List<ChuTrinh>();//khởi tạo đối tượng
            lst_Canh = new List<ChuTrinh>();//khởi tạo đối tượng
            SoTP = int.Parse(cbb_sotp.Text);//Lấy Số thành Phố
            for (int i = 0; i < SoTP; i++)//khởi tạo lại giá trị Enable của các combobox thuộc các thành phố được khởi tạo theo số tp
            {
                //lThanhPho.Add(pic_tp[i]);
                cbb_toado[i].X.Enabled = true;
                cbb_toado[i].Y.Enabled = true;
            }
            Nhap_cbb_XY();//nhập dữ liệu cho các combobox
            Nhap_cbb_start();//Nhập dữ liệu cho combobox lưu giá trị tên thành phố bắt đầu đi
            but_nhapsotp.Enabled = false;
            cbb_sotp.Enabled = false;

            cbb_start.SelectedIndex = 0;
            cbb_speed.SelectedIndex = 0;
           // Draw_Line();
        }
        //==============================================================================================================
        private void cbb_sotp_SelectedIndexChanged(object sender, EventArgs e)//sự kiện tay đỗi giá trị index được chọn của cbb_sotp
        {
            SoTP = int.Parse(cbb_sotp.Text);
            but_nhapsotp.Enabled = true;
        }
        //==============================================================================================================
        void Nhap_cbb_start()//Nhập dữ liệu cho combobox lưu giá trị tên thành phố bắt đầu đi
        {
            List<string> name = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H", "I", "K" };
            for (int i = 0; i < SoTP; i++)
            {
                cbb_start.Items.Add(name[i]);
            }
        }
        //==============================================================================================================
        Char Tentp(int i)
        {
            switch (i)
            { 
                case 0:
                    return 'A';
                case 1:
                    return 'B';
                case 2:
                    return 'C';
                case 3:
                    return 'D';
                case 4:
                    return 'E';
                case 5:
                    return 'F';
                case 6:
                    return 'G';
                case 7:
                    return 'H';
                case 8:
                    return 'I';
                case 9:
                    return 'K';
            }
            return '_';
        }
        //==============================================================================================================
        private void but_khoitao_Click(object sender, EventArgs e)//sự kiện click của button Khởi tạo thành phố
        {
            for (int i = 0; i < SoTP; i++)//tạo số thành phố dựa theo cbb_sotp
            {
                int x = (int)(float.Parse(cbb_toado[i].X.Text)*100);//lấy giá trị tọa độ x
                int y = (int)(float.Parse(cbb_toado[i].Y.Text) * 100);//lấy giá trị tọa độ x
                //giá trị tọa độ cứ 1 đơn vị trong commbobox bằng 100 đơn vị tọa độ
                ThanhPho tp = new ThanhPho();//khởi tạo một đối tượng thành phố
                tp.Name = Tentp(i).ToString() ;//gán tên Thành Phố vừa khởi tạo bằng tag của picturebox
                tp.X = x;//gán giá trị tọa dộ x của tp bằng giá trị cbb_x
                tp.Y = y;//gán giá trị tọa dộ y của tp bằng giá trị cbb_y
                lst_Thanhpho.Add(tp);///thêm thành phố vừa khởi tạo vào list lưu các thành phố
            }
            timduong = new TimDuongGiaoHang(lst_Thanhpho, cbb_start.Text);//khởi tạo đối tượng TimDuongGiaoHang
            timduong.timCanh();//chạy hàm tìm cạnh đễ lấy danh sách các cạnh
            lst_Canh = timduong.LCanh;//gán danh sách cạch của from bằng danh sách cạnh vừa tim được của lớp TimDuongGiaoHang
            timduong.timchutinh();//chạy hàm tìm chu trình đễ lấy danh sách các chu trình đường đi
            lst_Chutrinh = timduong.LChuTrinh;//gán danh sách chu trình của from bằng danh sách chu trình vừa tim được của lớp TimDuongGiaoHang
            but_khoitao.Enabled = false;
            but_start.Enabled = true;
            
        }
        //==============================================================================================================
        bool kiemtra_cbb_ToaDo()//khiểm tra các combobox được khởi tạo có rỗng hay không
        {
            for (int i = 0; i < SoTP; i++)
            {
                if (cbb_toado[i].X.Text.Length == 0 || cbb_toado[i].Y.Text.Length == 0)
                    return false;
            }
            return true;
        }
        //==============================================================================================================
        private void SelectedIndexChanged(object sender, EventArgs e)//sự kiện thay đỗi index giá trị được chọn của các cbb_X và cbb_Y
        {
            but_khoitao.Enabled = kiemtra_cbb_ToaDo();//gán giá trị Enable của button khởi tạo các thành phố bằng giá trị trả về của hàm kiểm tra các cbb_X, cbb_Y
        }
        //==============================================================================================================
        private void but_start_Click(object sender, EventArgs e)
        {
            but_start.Enabled = false;
            timer.Interval = int.Parse(cbb_speed.Text) * 1000;
            frm__ThucThi th = new frm__ThucThi();
            th.list_TP = lst_Thanhpho;
            th.lst_Chutrinh = lst_Chutrinh;
            th.timer1.Interval = int.Parse(cbb_speed.Text) * 1000;
            th.timer1.Start();
            timer.Start();//cho timer chạy
            th.Show();
        }
        //==============================================================================================================

        int chutrinh = 0;//giá trị lưu sô chu trình
        private void timer_Tick(object sender, EventArgs e)//sựu kiện tick của timer
        {
            if (chutrinh == lst_Chutrinh.Count)//điều kiện dừng timer
            {
                timer.Stop();
                return;
            }
            float khoangcach = lst_Chutrinh[chutrinh].Khoangcach;//lấy giá trị khoảng cách của chu trình
            double tongkhoangcach = float.Parse(txt_quangduong.Text);//lấy giá trị tổng khoảng cách
            txt_quangduong.Text = string.Format("{0:0.000}", (tongkhoangcach + khoangcach));//gán lại giá trị cho tổng khoảng cách
            string s = lst_Chutrinh[chutrinh].Start.Name + "--->" + lst_Chutrinh[chutrinh].Stop.Name;
            string kc = khoangcach.ToString();
            lst_chutrinh.Items.Add(s);
            lst_chutrinh.Items[chutrinh].SubItems.Add(kc);
            chutrinh++;//tăng gái trị chu sô trình lên
        }
        //==============================================================================================================
        private void but_reset_Click(object sender, EventArgs e)
        {
            foreach (Control b in grp_info.Controls)
            {
                if (b is ComboBox)
                {
                    if (b != cbb_speed && b != cbb_sotp)
                    {
                        ((ComboBox)b).Items.Clear();
                    }
                }
            }
            lst_chutrinh.Items.Clear();
            txt_quangduong.Text="0";
            but_nhapsotp.Enabled = false;
            foreach (ToaDo td in cbb_toado)//Cho giá tị Enable của các combobox ban đầu bằng false
            {
                td.X.Enabled = false;
                td.Y.Enabled = false;
            }
            but_khoitao.Enabled = false;
            but_start.Enabled = false;
            cbb_sotp.Enabled = true;
            chutrinh = 0;
        }
        //==============================================================================================================
        private void but_canh_Click(object sender, EventArgs e)
        {
            frm_Canh c = new frm_Canh();
            c.lst = lst_Canh;
            c.Show();
        }
        //==============================================================================================================
        
    }
    public class ToaDo //class lưu combobox các giá trị tọa độ của 1 thành phố
    {
        ComboBox x, y;

        public ComboBox Y
        {
            get { return y; }
            set { y = value; }
        }

        public ComboBox X
        {
            get { return x; }
            set { x = value; }
        }
        public ToaDo(ComboBox a, ComboBox b)
        {
            x = a;
            y = b;
        }
    }
    //==============================================================================================================
    public class ThanhPho//class lưu các thông tin của một thành phố
    {
        String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
        int x, y, bac;

        public int Bac
        {
            get { return bac; }
            set { bac = value; }
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public ThanhPho()
        {
            name = null;
            x = 443;
            y = 269;
            bac = 0;
        }
    }
    //==============================================================================================================
    public class ChuTrinh
    {
        ThanhPho start;

        internal ThanhPho Start
        {
            get { return start; }
            set { start = value; }
        }
        ThanhPho stop;

        internal ThanhPho Stop
        {
            get { return stop; }
            set { stop = value; }
        }
        float khoangcach;

        public float Khoangcach
        {
            get 
            {
                double x = Math.Pow((stop.X - start.X),2);
                double y = Math.Pow((stop.Y - start.Y), 2);
                return (float)Math.Sqrt(x+y); 
            }
            set { khoangcach = value; }
        }

        public ChuTrinh()
        {
            start = new ThanhPho();
            stop = new ThanhPho();
        }
    }//class lưu thông tin của 1 chu trình
    //==============================================================================================================
    public class TimDuongGiaoHang//class sử lý các thao tác tìm chu trình và tìm cạnh
    {
        List<ThanhPho> lThanhPho;
        List<ChuTrinh> lChuTrinh;
        List<ChuTrinh> lCanh;
        string start;

        public string Start
        {
            get { return start; }
            set { start = value; }
        }

        internal List<ThanhPho> LThanhPho
        {
            get { return lThanhPho; }
            set { lThanhPho = value; }
        }
        

        internal List<ChuTrinh> LChuTrinh
        {
            get { return lChuTrinh; }
            set { lChuTrinh = value; }
        }
        

        internal List<ChuTrinh> LCanh
        {
            get { return lCanh; }
            set { lCanh = value; }
        }
        public TimDuongGiaoHang(List<ThanhPho> list_ThanhPho,string tp_start)//hàm khởi tạo dựa trên danh sách thành phố và tên thành phố bắt đầu
        {
            lThanhPho = list_ThanhPho;
            lChuTrinh = new List<ChuTrinh>();
            lCanh = new List<ChuTrinh>();
            Start = tp_start;
        }

        public void timCanh()//tìm tất cả các cạnh
        { 
            int n= lThanhPho.Count();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    ChuTrinh ct = new ChuTrinh();
                    ct.Start = lThanhPho[i];
                    ct.Stop = lThanhPho[j];
                    lCanh.Add(ct);
                }
            }
            sapxep();//sắp xếp các cạnh theo khoảng cách tăng dần
        }
        bool kiemTra_Bac(ChuTrinh canh)//kiểm tra bậ của một cạnh
        {
            if (canh.Start.Bac + 1 <= 2 && canh.Stop.Bac + 1 <= 2)
                return true;
            return false;
        }

        bool kiemTra_TrungCanh(ChuTrinh canh, List<ChuTrinh> lcanh)//kiểm tra cạnh có thuộc chu trình chưa
        {
            if (LCanh.Count == 1)
                return true;
	        for(int i=0;i<lChuTrinh.Count;i++)
	        {
                if (lChuTrinh[i].Start.Name == canh.Start.Name && lChuTrinh[i].Stop.Name == canh.Stop.Name)
			        return false;
	        }
	        return true;
        }
        public void timchutinh()//tìm chu trinh
        {
            string st = start;
            int sotp=lThanhPho.Count;
            for (int i = 0; i < lCanh.Count; i++)
            {
                try
                {
                    ChuTrinh e = lCanh[i];
                    string hientai = e.Start.Name + "/" + e.Stop.Name;
                    ChuTrinh c = lChuTrinh[lChuTrinh.Count-1];
                    string trongchutrinh = c.Start.Name + "/" + c.Stop.Name;
                    
                }
                catch { };
                if (lChuTrinh.Count == sotp)
                    break;
                //===========================================
                if (kiemTra_TrungCanh(LCanh[i],LCanh))
                {
                    if (lChuTrinh.Count == 0)//khi sô chu trình bằng 0 thì cạnh đưa vào đầu tiên phải có tồn tại một thành phố trùng tên với thành phố bắt đầu và có quảng đường bé nhất
                    {
                        if (lCanh[i].Start.Name == start)
                        {
                            if (kiemTra_Bac(lCanh[i]))
                            {
                                lCanh[i].Start.Bac++;
                                lCanh[i].Stop.Bac++;
                                lChuTrinh.Add(lCanh[i]);
                                start = lCanh[i].Stop.Name;
                                i = -1;
                            }
                        }
                        //===========================================
                        else if (lCanh[i].Stop.Name == start)
                        {
                            if (kiemTra_Bac(LCanh[i]))
                            {
                                lCanh[i].Start.Bac++;
                                lCanh[i].Stop.Bac++;
                                ChuTrinh ct = new ChuTrinh();
                                ct.Start = LCanh[i].Stop;
                                ct.Stop = LCanh[i].Start;
                                lChuTrinh.Add(ct);
                                start = LCanh[i].Start.Name;
                                i = -1;
                            }
                        }
                        //===========================================
                    }
                    //===========================================
                    else if (lChuTrinh.Count == sotp - 1)//khi sô chu trình bằng số thành phố -1 thì cạnh đưa vào phải có tồn tại một thành phố trùng tên với thành phố bắt đầu và có quảng đường bé nhất
                    {
                        if (LCanh[i].Start.Name == start && LCanh[i].Stop.Name == st)
                        {
                            if (kiemTra_Bac(LCanh[i]))
                            {
                                LCanh[i].Start.Bac++;
                                LCanh[i].Stop.Bac++;
                                LChuTrinh.Add(LCanh[i]);
                                start = LCanh[i].Stop.Name;
                                i = -1;
                            }
                        }
                        else if (LCanh[i].Stop.Name == start && LCanh[i].Start.Name == st)
                        {
                            if (kiemTra_Bac(LCanh[i]))
                            {
                                LCanh[i].Start.Bac++;
                                LCanh[i].Stop.Bac++;
                                ChuTrinh ct = new ChuTrinh();
                                ct.Start = LCanh[i].Stop;
                                ct.Stop = LCanh[i].Start;
                                LChuTrinh.Add(ct);
                                start = LCanh[i].Start.Name;
                                i = -1;
                            }
                        }
                    }
                    //===========================================
                    else //khi sô chu trình lớn hơn 0 và bé hơn số thành phố -1 thì cạnh đưa vào phải có tồn tại một thành phố trùng tên với thành phố kết thúc của cạnh trước đó và có quảng đường bé nhất
                    {
                        if (LCanh[i].Start.Name != st && LCanh[i].Stop.Name != st)//cạnh đưa vào không được phép chứa thành phố bắt đầu
                        {
                            if (LCanh[i].Start.Name == start)
                            {
                                if (kiemTra_Bac(LCanh[i]))
                                {
                                    LCanh[i].Start.Bac++;
                                    LCanh[i].Stop.Bac++;
                                    lChuTrinh.Add(LCanh[i]);
                                    start = LCanh[i].Stop.Name;
                                    i = -1;
                                }
                            }
                            else if (LCanh[i].Stop.Name == start)
                            {
                                if (kiemTra_Bac(LCanh[i]))
                                {
                                    LCanh[i].Start.Bac++;
                                    LCanh[i].Stop.Bac++;
                                    ChuTrinh ct = new ChuTrinh();
                                    ct.Start = LCanh[i].Stop;
                                    ct.Stop = LCanh[i].Start;
                                    LChuTrinh.Add(ct);
                                    start = LCanh[i].Start.Name;
                                    i = -1;
                                }
                            }
                        }
                    }
                    //===========================================
                }
            }
        }
        void Swap(ChuTrinh a, ChuTrinh b)
        {
            ChuTrinh c = new ChuTrinh();
            c.Start = a.Start;
            c.Stop = a.Stop;
            a.Start = b.Start;
            a.Stop = b.Stop;
            b.Start = c.Start;
            b.Stop = c.Stop;
        }

        public void sapxep()
        {
            for (int i = 0; i < lCanh.Count-1; i++)
            {
                for (int j = i + 1; j < lCanh.Count; j++)
                {
                    if (lCanh[i].Khoangcach > lCanh[j].Khoangcach)
                        Swap(LCanh[i], LCanh[j]);
                }
            }
        }
    }
    //==============================================================================================================
}
