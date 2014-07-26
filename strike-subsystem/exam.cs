using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace strike_subsystem
{
    public partial class exam : Form

    {
        int readytime = 5,downcouter=59;
        int j = 0,k=0;
        int flag = 0;
        int total = 0;
        byte[] data = new byte[7];
        double ptime=0;
        double ctime = 0;
        double Tinteval=0;
        double pinterval=0;
        double pinterval_min = 0;
        double mean,var;
        int examid=0;
        bool start=false;
        string username;
        double[] T_interval = new double[600];
        int times15, times30, times45, times60;
        const int MaxCount = 150;
        const double MaxDev = 0.1;
        // Thread Add Data delegate
        public delegate void AddDataDelegate();
        public AddDataDelegate addDataDel;

        OleDbConnection exam_conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\strike.accdb");
        private OleDbConnection _userConn = new OleDbConnection("Data Source=" + "D:\\UserInfo.mdb;Jet OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0"); //数据库连接
        delegate void Sdelegate();
        public exam()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            chart1.Visible = false;
            chart2.Visible = false;
            button1.Enabled = false;
            label_onTest.Visible = false;
            pictureBox1.Image=Image.FromFile("images\\DigitNum\\6.jpg");
            pictureBox2.Image = Image.FromFile("images\\DigitNum\\0.jpg");
            //open connection
            exam_conn.Open();
            // Reset number of series in the chart.
            chart3.Series.Clear();

            Dundas.Charting.WinControl.Series newSeries = new Dundas.Charting.WinControl.Series("敲击间隔实时显示");
            newSeries.Type = Dundas.Charting.WinControl.SeriesChartType.Line;
            newSeries.BorderWidth = 1;
            newSeries.Color = Color.FromArgb(224, 64, 10);
            newSeries.ShadowOffset = 1;
            //newSeries.XValueType = Dundas.Charting.WinControl.ChartValueTypes.Time;
            chart3.Series.Add(newSeries);
            chart3.ChartAreas[0].AxisY.IntervalAutoMode = Dundas.Charting.WinControl.IntervalAutoMode.VariableCount;
            chart3.ChartAreas[0].AxisX.Minimum = 1;
            //chart3.ChartAreas[0].AxisY.Minimum = 0.2;
            //chart3.ChartAreas[0].AxisY.Maximum = 0.5;
            //chart1.ChartAreas[0].AxisX.Minimum = 1;
            //chart1.ChartAreas[0].AxisY.Minimum = 0.2;
            //chart1.ChartAreas[0].AxisY.Maximum = 0.5;

            //从UserInfo读取用户姓名
            OleDbDataAdapter adp = new OleDbDataAdapter("select UserId,UserName from UserInfo order by UserID desc", _userConn);
            DataSet ds = new DataSet();
            adp.Fill(ds, "UserInfo");
            username = ds.Tables[0].Rows[0][1].ToString();
            textBox_username.Text=username; //更新显示
            ds.Dispose();                   

            //从score读取测试号
            OleDbDataAdapter Sel_examID = new OleDbDataAdapter("select examID from score order by ID desc", exam_conn);
            DataSet ReadID = new DataSet();
            Sel_examID.Fill(ReadID, "examID");
            if (ReadID == null)
                examid = 1;
            else
                examid = (int)ReadID.Tables[0].Rows[0][0]+1;
            ReadID.Dispose();

            textBox_examID.Text = examid.ToString();
            #region serial port check
            string[] Pnames = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string Pname in Pnames)
            {
                Sp.PortName = Pname;
                try
                {
                    Sp.Open();
                    Sp.Close();
                }
                catch
                {

                }
            }
#endregion
        }
        public void setID(string uname)
        {
            username = uname;
            textBox_username.Text = uname;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //ThreadStart addDataThreadStart = new ThreadStart(AddDataThreadLoop);
            //addDataRunner = new Thread(addDataThreadStart);

            //addDataDel += new AddDataDelegate(AddData);
            //addDataRunner.Start();
        }
        private void AddDataThreadLoop()
        {
            try
            {
                while (true)
                {
                    // Invoke method must be used to interact with the chart
                    // control on the form!
                    chart3.Invoke(addDataDel);

                    // Thread is inactive for 200ms
                    Thread.Sleep(100);
                }
            }
            catch
            {
                // Thread is aborted
            }
        }
        public void AddData()
        {
            // Add new data point to its series.
            chart3.Series[0].Points.AddXY(k, Tinteval);
            chart3.Invalidate();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (readytime>0)
            {
                label_timeleft.Text = Convert.ToString(readytime-1);
                //label1.Text = (string)downcouter;
                readytime--;
            }
            else if (readytime == 0)
            {
                label_onTest.Visible = true;
                readytime = -1;
                if (Sp.IsOpen)
                {
                    Sp.Close();
                }
                Sp.Open();
                byte[] start = { 0xAA };
                this.Sp.Write(start, 0, 1);
                //addDataRunner.Start();
                label_intro.Visible = false;
                label_timeleft.Visible = false;
                label_secText.Visible = false;
            }
            else
            {
                
                pictureBox1.Image = Image.FromFile("images\\DigitNum\\"+downcouter/10+".jpg");
                pictureBox2.Image = Image.FromFile("images\\DigitNum\\" + downcouter % 10 + ".jpg");
                downcouter--;
            }
            if (downcouter == 0)
            {
                button1.Enabled = true;
                timer1.Stop();
                label_onTest.Text = "测试结束";
                pictureBox2.Image = Image.FromFile("images\\DigitNum\\0.jpg");
                //addDataRunner.Abort();
                 Sdelegate dp = new Sdelegate(disp);
                 Invoke(dp, new object[] { });
            }

        }

        private void Sp_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int length = Sp.BytesToRead;
            byte temp;
            byte[] sdata = new byte[9];
            for (int i = 0; i < length; i++)
            {
                //j = (j == 6) ? 0 : j;
                //if (Sp.IsOpen)
                {
                    temp = (byte)Sp.ReadByte();
                    if (temp == 0xff)
                    {
                        start = true;
                        continue;
                    }
                    if (start)
                    {

                        sdata[j++] = temp;
                        if (j == 9)
                        {
                            j = 0;
                            start = false;
                            if( (sdata[0] == 0xaa) && (sdata[1] == 0x55))
                            {
                                    Array.Copy(sdata, 2, data, 0, 7);
                                    Sdelegate Cd = new Sdelegate(Cal);
                                    Invoke(Cd, new object[] { });
                            }
                        }
                    }
                }

            }

        }

        private void Cal()
        {
            //total =255* flag + (int)data[0];
            //if ((int)data[0]== 254)
            //    flag ++;
            total = 255 * data[0] + data[1];
            ctime = (int)data[3] * 10 + (int)data[4] + 0.1*(int)data[5]+0.01*(int)data[6] ;
            Tinteval = ctime - ptime;
            if (total == 1)
            {
                ptime = ctime;
                Tinteval = 0;
                pinterval = 10;
                pinterval_min = 0;
                //chart3.Series[0].Points.AddXY(0, 0);
                //chart3.Invalidate();
            }
            else
            {
                if (Tinteval > 1.4* pinterval)
                {
                    Tinteval =  1.1*pinterval;
                }
                if ((Tinteval < 0.6 * pinterval_min) || (Tinteval < 0))
                {
                    Tinteval = 0.8*pinterval;
                    
                }
                chart3.Series[0].Points.AddXY(total-1, Tinteval);
                chart3.Invalidate();
                pinterval = Tinteval;
                pinterval_min = pinterval;
            }
            if (ctime < 15)
                times15++;
            else if (ctime < 30)
                times30++;
            else if (ctime < 45)
                times45++;
            else
                times60++;
            if (total > 1)
            {
                T_interval[k++] = Tinteval;
            }
            ptime = ctime;
            //string sql = "Insert into score(examID,username,times,inteval)values(" + examid + ",'" + username + "'," + total + "," + Tinteval + ")";
            //OleDbCommand cmd = new OleDbCommand(sql, exam_conn);
            //cmd.ExecuteNonQuery();
            //Sdelegate ps = new Sdelegate(realDraw);
            //Invoke(ps, new object[] { });

            //textBox2.Text += Convert.ToString((int)data[0]) + " " + Convert.ToString((int)data[1]) + " " + Convert.ToString((int)data[2]) + " " + Convert.ToString((int)data[3]) + " " + Convert.ToString((int)data[4]) + " " + Convert.ToString((int)data[5]) + " "+Convert.ToString((int)data[6]) + "\n";
        }
        private void draw_p()
        {
            double[] x = new double[total];
            double[] y = new double[total ];
            double[] z = new double[total];
            for (int i = 0; i < total; i++)
            {
                y[i] = mean;
                z[i] = var;
            }
            Array.Copy(T_interval, x, total-1);
            x[total - 1] = x[total - 2]=x[total-3];
            chart1.Series["transient interval"].Points.DataBindY(x);
            //chart1.Series["mean interval"].Points.DataBindY(y);
            //chart1.Series["interval variance"].Points.DataBindY(z);
            string []xv={"between 0-14s","between 15-29s","between 30-44s","between 45-59s"};
            int []yv={times15,times30,times45,times60};
            chart2.Series["Serial1"].Points.DataBindXY(xv,yv);       
        }
        private void disp()
        {
            chart1.Visible = true;
            //Sp.Close();
            chart2.Visible = true;
            chart3.Visible = false;
            double sum = 0, vari = 0;
            for (int m = 1; m < total; m++)
            {
                sum += T_interval[m];
            }
            mean = sum / total;
            for (int m = 0; m < total; m++)
                vari += Math.Pow(T_interval[m] - mean, 2.0);
            var = vari / total;
            label_times.Text = total.ToString() + "次";
            label_scoreMean.Text = mean.ToString("f2") + "秒";
            label1.Text = (60*(1-var/MaxDev)+40*total/MaxCount).ToString("f2");
            string sql = "Insert into score(examID,username,times,inteval,mean)values(" + examid + ",'" + username + "'," + total + "," + Tinteval + "," + mean + ")";
            OleDbCommand cmd = new OleDbCommand(sql, exam_conn);
            cmd.ExecuteNonQuery();
            Sdelegate sc = new Sdelegate(draw_p);
            Invoke(sc, new object[] { });
            exam_conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            username = textBox_username.Text.Trim();
            button_ready.Enabled = false;
            timer1.Enabled = true;
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Sp.Close();
            this.Close();
        }

     }
}
