﻿namespace strike_subsystem
{
    partial class Manage_p
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Button_delete = new System.Windows.Forms.Button();
            this.UserName = new System.Windows.Forms.TextBox();
            this.UHeight = new System.Windows.Forms.TextBox();
            this.Button_search = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Remark = new System.Windows.Forms.TextBox();
            this.UWeight = new System.Windows.Forms.TextBox();
            this.Search_name = new System.Windows.Forms.TextBox();
            this.DataList = new System.Windows.Forms.DataGridView();
            this.Birthday = new System.Windows.Forms.DateTimePicker();
            this.UserSex2 = new System.Windows.Forms.RadioButton();
            this.UserSex1 = new System.Windows.Forms.RadioButton();
            this.Contacts = new System.Windows.Forms.TextBox();
            this.Button_submit = new System.Windows.Forms.Button();
            this.Button_exit = new System.Windows.Forms.Button();
            this.Manage_p_BG = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Manage_p_BG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_delete
            // 
            this.Button_delete.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Button_delete.Location = new System.Drawing.Point(555, 578);
            this.Button_delete.Name = "Button_delete";
            this.Button_delete.Size = new System.Drawing.Size(100, 30);
            this.Button_delete.TabIndex = 11;
            this.Button_delete.Text = "删    除";
            this.Button_delete.UseVisualStyleBackColor = true;
            this.Button_delete.Click += new System.EventHandler(this.Button_delete_Click);
            // 
            // UserName
            // 
            this.UserName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserName.Location = new System.Drawing.Point(540, 208);
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Size = new System.Drawing.Size(150, 21);
            this.UserName.TabIndex = 2;
            this.UserName.TabStop = false;
            // 
            // UHeight
            // 
            this.UHeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UHeight.Location = new System.Drawing.Point(540, 308);
            this.UHeight.Name = "UHeight";
            this.UHeight.Size = new System.Drawing.Size(150, 21);
            this.UHeight.TabIndex = 5;
            this.UHeight.TextChanged += new System.EventHandler(this.UHeight_TextChanged);
            // 
            // Button_search
            // 
            this.Button_search.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Button_search.Location = new System.Drawing.Point(313, 510);
            this.Button_search.Name = "Button_search";
            this.Button_search.Size = new System.Drawing.Size(75, 23);
            this.Button_search.TabIndex = 2;
            this.Button_search.Text = "搜  索";
            this.Button_search.UseVisualStyleBackColor = true;
            this.Button_search.Click += new System.EventHandler(this.Button_search_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.Remark);
            this.panel1.Controls.Add(this.UWeight);
            this.panel1.Controls.Add(this.Button_delete);
            this.panel1.Controls.Add(this.UserName);
            this.panel1.Controls.Add(this.UHeight);
            this.panel1.Controls.Add(this.Button_search);
            this.panel1.Controls.Add(this.Search_name);
            this.panel1.Controls.Add(this.DataList);
            this.panel1.Controls.Add(this.Birthday);
            this.panel1.Controls.Add(this.UserSex2);
            this.panel1.Controls.Add(this.UserSex1);
            this.panel1.Controls.Add(this.Contacts);
            this.panel1.Controls.Add(this.Button_submit);
            this.panel1.Controls.Add(this.Button_exit);
            this.panel1.Controls.Add(this.Manage_p_BG);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 685);
            this.panel1.TabIndex = 0;
            // 
            // Remark
            // 
            this.Remark.Location = new System.Drawing.Point(540, 508);
            this.Remark.Name = "Remark";
            this.Remark.Size = new System.Drawing.Size(240, 21);
            this.Remark.TabIndex = 9;
            // 
            // UWeight
            // 
            this.UWeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UWeight.Location = new System.Drawing.Point(540, 358);
            this.UWeight.Name = "UWeight";
            this.UWeight.Size = new System.Drawing.Size(150, 21);
            this.UWeight.TabIndex = 6;
            this.UWeight.TextChanged += new System.EventHandler(this.UWeight_TextChanged);
            // 
            // Search_name
            // 
            this.Search_name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Search_name.Location = new System.Drawing.Point(185, 512);
            this.Search_name.Name = "Search_name";
            this.Search_name.Size = new System.Drawing.Size(113, 21);
            this.Search_name.TabIndex = 1;
            // 
            // DataList
            // 
            this.DataList.AllowUserToAddRows = false;
            this.DataList.AllowUserToDeleteRows = false;
            this.DataList.AllowUserToResizeRows = false;
            this.DataList.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataList.Location = new System.Drawing.Point(108, 231);
            this.DataList.MultiSelect = false;
            this.DataList.Name = "DataList";
            this.DataList.ReadOnly = true;
            this.DataList.RowHeadersVisible = false;
            this.DataList.RowHeadersWidth = 10;
            this.DataList.RowTemplate.Height = 23;
            this.DataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataList.Size = new System.Drawing.Size(291, 273);
            this.DataList.TabIndex = 0;
            this.DataList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataList_CellClick);
            // 

            // 
            // userInfoDataSet1

            // 
            // Birthday
            // 
            this.Birthday.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Birthday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Birthday.Location = new System.Drawing.Point(540, 408);
            this.Birthday.Name = "Birthday";
            this.Birthday.Size = new System.Drawing.Size(150, 21);
            this.Birthday.TabIndex = 7;
            // 
            // UserSex2
            // 
            this.UserSex2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserSex2.AutoSize = true;
            this.UserSex2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.UserSex2.Location = new System.Drawing.Point(655, 258);
            this.UserSex2.Name = "UserSex2";
            this.UserSex2.Size = new System.Drawing.Size(35, 16);
            this.UserSex2.TabIndex = 4;
            this.UserSex2.Text = "女";
            this.UserSex2.UseVisualStyleBackColor = false;
            // 
            // UserSex1
            // 
            this.UserSex1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserSex1.AutoSize = true;
            this.UserSex1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.UserSex1.Checked = true;
            this.UserSex1.Location = new System.Drawing.Point(540, 258);
            this.UserSex1.Name = "UserSex1";
            this.UserSex1.Size = new System.Drawing.Size(35, 16);
            this.UserSex1.TabIndex = 3;
            this.UserSex1.TabStop = true;
            this.UserSex1.Text = "男";
            this.UserSex1.UseVisualStyleBackColor = false;
            // 
            // Contacts
            // 
            this.Contacts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Contacts.Location = new System.Drawing.Point(540, 458);
            this.Contacts.Name = "Contacts";
            this.Contacts.Size = new System.Drawing.Size(150, 21);
            this.Contacts.TabIndex = 8;
            // 
            // Button_submit
            // 
            this.Button_submit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Button_submit.Location = new System.Drawing.Point(430, 578);
            this.Button_submit.Name = "Button_submit";
            this.Button_submit.Size = new System.Drawing.Size(100, 30);
            this.Button_submit.TabIndex = 10;
            this.Button_submit.Text = "修    改";
            this.Button_submit.UseVisualStyleBackColor = true;
            this.Button_submit.Click += new System.EventHandler(this.Button_submit_Click);
            // 
            // Button_exit
            // 
            this.Button_exit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Button_exit.Location = new System.Drawing.Point(680, 578);
            this.Button_exit.Name = "Button_exit";
            this.Button_exit.Size = new System.Drawing.Size(100, 30);
            this.Button_exit.TabIndex = 12;
            this.Button_exit.Text = "返    回";
            this.Button_exit.UseVisualStyleBackColor = true;
            this.Button_exit.Click += new System.EventHandler(this.Button_exit_Click);
            // 
            // Manage_p_BG
            // 
            this.Manage_p_BG.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Manage_p_BG.Location = new System.Drawing.Point(0, 0);
            this.Manage_p_BG.Name = "Manage_p_BG";
            this.Manage_p_BG.Size = new System.Drawing.Size(900, 685);
            this.Manage_p_BG.TabIndex = 74;
            this.Manage_p_BG.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // 
            // Manage_p
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(900, 685);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Manage_p";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage_p";
            this.Load += new System.EventHandler(this.Manage_p_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Manage_p_BG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_delete;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.TextBox UHeight;
        private System.Windows.Forms.Button Button_search;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Search_name;
        private System.Windows.Forms.DataGridView DataList;
        private System.Windows.Forms.DateTimePicker Birthday;
        private System.Windows.Forms.RadioButton UserSex2;
        private System.Windows.Forms.RadioButton UserSex1;
        private System.Windows.Forms.TextBox Contacts;
        private System.Windows.Forms.Button Button_submit;
        private System.Windows.Forms.Button Button_exit;
        private System.Windows.Forms.PictureBox Manage_p_BG;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.TextBox UWeight;
        private System.Windows.Forms.TextBox Remark;
    }
}