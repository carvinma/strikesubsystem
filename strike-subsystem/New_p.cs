using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace strike_subsystem
{
    public partial class New_p : Form
    {
        private OleDbConnection _userConn = new OleDbConnection("Data Source=" + "D:\\UserInfo.mdb;Jet OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0"); //数据库连接

        public New_p()
        {
            InitializeComponent();
            New_p_BG.Image = Image.FromFile("images\\New_P.jpg");
            Birthday.MaxDate = DateTime.Today;
        }

        private void Button_submit_Click(object sender, EventArgs e)
        {
            Regex IsNum = new Regex(@"^[0-9]+(.[0-9]{1,3})?$");
            if (UserName.Text == "")
            {
                errorProvider1.SetError(UserName, "请输入姓名!");
                UserName.Focus();
            }
            else if (UHeight.Text == "")
            {
                errorProvider2.SetError(UHeight, "请输入身高!");
                UHeight.Focus();
            }
            else if (!IsNum.IsMatch(UHeight.Text))
            {
                errorProvider2.SetError(UHeight, "身高必须为数字!");
                UHeight.Focus();
            }
            else if (UWeight.Text == "")
            {
                errorProvider3.SetError(UWeight, "请输入体重");
                UWeight.Focus();
            }
            else if (!IsNum.IsMatch(UWeight.Text))
            {
                errorProvider3.SetError(UWeight, "体重必须为数字!");
                UWeight.Focus();
            }
            else
            {
                string usersex;
                if (this.UserSex1.Checked)
                {
                    usersex = "男";
                }
                else
                {
                    usersex = "女";
                }
                try
                {
                    _userConn.Open();    //添加新用户
                    string sql = "Insert into UserInfo (UserName,Sex,Height,Weight,Birthday,Contacts,Remark) values ('" + UserName.Text.Trim() + "','" + usersex.Trim() + "'," + UHeight.Text.Trim() + "," + UWeight.Text.Trim() + ",'" + Birthday.Text.Trim() + "','" + Contacts.Text.Trim() + "','" + Remark.Text.Trim() + "')";
                    OleDbCommand cmd = new OleDbCommand(sql, _userConn);
                    cmd.ExecuteNonQuery();
                    _userConn.Close();
                    Main_Fram tForm = (Main_Fram)this.MdiParent;  //更改父窗口中用户数判断值
                    tForm.set_data_exist(true);

                    if (DialogResult.OK == (MessageBox.Show("添加成功，开始检测？", "添加成功", MessageBoxButtons.OKCancel)))
                    {
                        //_userConn.Open();    //查找用户
                        //cmd.CommandText = "select * from UserInfo order by UserId desc";
                        //int Uid = Convert.ToInt32(cmd.ExecuteScalar());
                        //_userConn.Close();

                        exam Form_ex = new exam();
                        Form_ex.MdiParent = this.MdiParent;
                        //Form_ex.Set_UId(Uid, UserName.Text);
                        Form_ex.Show();
                        Form_ex.Dock = DockStyle.Fill;
                        this.Close();
                    }
                    else
                    {
                        this.UserName.Text = "";
                        this.UserSex1.Select();
                        this.UHeight.Text = "";
                        this.UWeight.Text = "";
                        this.Birthday.Value = DateTime.Today;
                        this.Contacts.Text = "";
                        this.Remark.Text = "";
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void UserName_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            button_check.Enabled = true;
        }

        private void UHeight_TextChanged(object sender, EventArgs e)
        {
            errorProvider2.Clear();
        }

        private void UWeight_TextChanged(object sender, EventArgs e)
        {
            errorProvider3.Clear();
        }
        
        private void Button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void New_p_BG_Click(object sender, EventArgs e)
        {

        }

        private void button_check_Click(object sender, EventArgs e)
        {
            _userConn.Open();
            string sql_search = "select UserName from UserInfo where UserName='"+UserName.Text.Trim()+"'";
            OleDbCommand cmd = new OleDbCommand(sql_search, _userConn);
            string Uname = Convert.ToString(cmd.ExecuteScalar());
            if (Uname == "")
                MessageBox.Show("用户:" + UserName.Text + "不存在," + "请完善信息", "用户不存在");
            else
            {
                if (DialogResult.OK == (MessageBox.Show("用户：" + UserName.Text.Trim() + " " + "已存在," + "开始测试?", "开始测试", MessageBoxButtons.OKCancel)))
                {
                    exam form_exam = new exam();
                    form_exam.setID(UserName.Text.Trim());
                    form_exam.MdiParent = this.MdiParent;
                    form_exam.Show();
                    form_exam.Dock = DockStyle.Fill;
                }
            }
            _userConn.Close();
        }
    }
}
