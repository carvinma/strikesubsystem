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
    public partial class Manage_p : Form
    {
        private OleDbConnection _userConn = new OleDbConnection("Data Source=" + "D:\\UserInfo.mdb;Jet OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0"); //数据库连接
        OleDbConnection strikeConnectionString = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\strike.accdb");
        OleDbDataAdapter adp;
        DataSet ds = new DataSet();
        public Manage_p()
        {
            InitializeComponent();
            Manage_p_BG.Image = Image.FromFile("Images\\Manage_P.jpg");
            adp = new OleDbDataAdapter("select UserName as 姓名,Sex as 性别,Height as 身高,Weight as 体重,Birthday as 生日,Contacts as 联系方式,Remark as 备注"+
            " from UserInfo order by UserID desc", _userConn);
            adp.Fill(ds);
            DataList.DataSource = ds.Tables[0];
            DataList.Rows[0].Selected = true;
            //this.show();
           
        }

        private void Manage_p_Load(object sender, EventArgs e)
        {
           
        }

        private void Button_search_Click(object sender, EventArgs e)
        {
            string sn = Search_name.Text;
            string sql_search = "select UserName as 姓名,Sex as 性别,Height as 身高,Weight as 体重,Birthday as 生日,Contacts as 联系方式,Remark as 备注" +
            " from UserInfo where UserName='" + sn + "'";
            _userConn.Open();
            OleDbDataAdapter dap = new OleDbDataAdapter(sql_search, _userConn);
            DataSet ds2 = new DataSet();
            dap.Fill(ds2);
            _userConn.Close();
            if (ds2.Tables[0].Rows.Count > 0)
            {
                DataList.DataSource = ds2.Tables[0];
            }
            else
                MessageBox.Show("没有找到用户: " + sn + "  对不起");
            ds2.Dispose();
            

        }

        private void Button_submit_Click(object sender, EventArgs e)
        {
            Regex IsNum = new Regex(@"^[0-9]+(.[0-9]{1,3})?$");
            if (UHeight.Text == "")
            {
                errorProvider1.SetError(UHeight, "请输入身高!");
                UHeight.Focus();
            }
            else if (!IsNum.IsMatch(UHeight.Text))
            {
                errorProvider1.SetError(UHeight, "身高必须为数字!");
                UHeight.Focus();
            }
            else if (UWeight.Text == "")
            {
                errorProvider2.SetError(UWeight, "请输入体重!");
                UWeight.Focus();
            }
            else if (!IsNum.IsMatch(UWeight.Text))
            {
                errorProvider2.SetError(UWeight, "体重必须为数字!");
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

                _userConn.Open();
               // OleDbDataAdapter UpAdp = new OleDbDataAdapter("Update UserInfo set Sex = '" + usersex.Trim() + "',Height = " + UHeight.Text.Trim() + ",Weight = " + UWeight.Text.Trim() + ",Birthday = '" + Birthday.Text.Trim() + "',Contacts = '" + Contacts.Text.Trim() + "',Remark = '" + Remark.Text.Trim() + "' where UserName = '" + DataList[0, DataList.CurrentCell.RowIndex].Value + "'",_userConn);
               //
                OleDbCommand cmd = new OleDbCommand("Update UserInfo set Sex = '" + usersex.Trim() + "',Height = " + UHeight.Text.Trim() + ",Weight = " + UWeight.Text.Trim() + ",Birthday = '" + Birthday.Text.Trim() + "',Contacts = '" + Contacts.Text.Trim() + "',Remark = '" + Remark.Text.Trim() + "' where UserName = '" + DataList[0, DataList.CurrentCell.RowIndex].Value + "'", _userConn);
                //adp.UpdateCommand = cmd;
                //OleDbCommandBuilder updateDB = new OleDbCommandBuilder(adp);
                //adp.Update(ds.Tables[0]);
                int res = cmd.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("修改成功");
                }
                _userConn.Close();
                #region 更新显示
                adp = new OleDbDataAdapter("select UserName as 姓名,Sex as 性别,Height as 身高,Weight as 体重,Birthday as 生日,Contacts as 联系方式,Remark as 备注" +
            " from UserInfo order by UserID desc", _userConn);
                ds.Clear();
                adp.Fill(ds.Tables[0]);
                DataList.DataSource = ds.Tables[0];
                #endregion
            }

        }

        private void Button_delete_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("确认删除用户：" + this.UserName.Text + "？", "确认删除？", MessageBoxButtons.OKCancel))
            {
                string UserName = this.UserName.Text;
                try
                {
                    _userConn.Open();
                    string sql = "Delete * from UserInfo where UserName = '" + UserName + "'";
                    OleDbCommand cmd = new OleDbCommand(sql, _userConn);
                    if (cmd.ExecuteNonQuery() > 0)
                    {

                        if (ds.Tables[0].Rows.Count== 0)
                        {
                            Main_Fram tForm = (Main_Fram)this.MdiParent;  //更改父窗口中用户数判断值
                            tForm.set_data_exist(false);
                            if (MessageBox.Show("全部用户都已删除，请添加新用户！", "添加新用户？", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                New_p form_n = new New_p();
                                form_n.MdiParent = this.MdiParent;
                                form_n.Dock = DockStyle.Fill;
                                form_n.Show();
                            }
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("删除成功");
                            #region 更新显示
                            adp = new OleDbDataAdapter("select UserName as 姓名,Sex as 性别,Height as 身高,Weight as 体重,Birthday as 生日,Contacts as 联系方式,Remark as 备注" +
                        " from UserInfo order by UserID desc", _userConn);
                            ds.Clear();
                            adp.Fill(ds.Tables[0]);
                            DataList.DataSource = ds.Tables[0];
                            #endregion
                        }  
                    }
                    _userConn.Close();
                    strikeConnectionString.Open();
                    string delUser = "Delete * from Score where UserName='" + UserName + "'";
                    OleDbCommand cmd2 = new OleDbCommand(delUser, strikeConnectionString);
                    cmd2.ExecuteNonQuery();
                    strikeConnectionString.Close();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Button_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void show()     //在右侧显示列表中选中的内容
        {
            this.UserName.Text = DataList[0, DataList.CurrentCell.RowIndex].Value.ToString();   //姓名
            if (DataList[1, DataList.CurrentCell.RowIndex].Value.ToString() == "男")            //性别
            {
                UserSex1.Select();
            }
            else
            {
                UserSex2.Select();
            }
            this.UHeight.Text = DataList[2, DataList.CurrentCell.RowIndex].Value.ToString();     //身高
            this.UWeight.Text = Convert.ToSingle(DataList[3, DataList.CurrentCell.RowIndex].Value).ToString("0.00");     //体重
            this.Birthday.Text = DataList[4, DataList.CurrentCell.RowIndex].Value.ToString();    //生日
            this.Contacts.Text = DataList[5, DataList.CurrentCell.RowIndex].Value.ToString();   //联系方式
            this.Remark.Text = DataList[6, DataList.CurrentCell.RowIndex].Value.ToString();     //备注
        }

        private void DataList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.show();    //调用show函数，显示选中的内容
        }

        private void UHeight_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }

        private void UWeight_TextChanged(object sender, EventArgs e)
        {
            errorProvider2.Clear();
        }
    }
}
