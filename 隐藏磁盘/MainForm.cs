using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace 隐藏磁盘
{
    public partial class MainForm : Form
    {
        enum DisposeFun {Hide,Forbid};
        List<string> list_Letter = new List<string>();
        RegistryKey Key;
        DisposeFun runDis = DisposeFun.Hide;
        string fixedPath = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer";
        string removablePath = @"SYSTEM\CurrentControlSet\Services\USBSTOR";
        public MainForm()
        {
            InitializeComponent();
            
            Thread t_setwined = new Thread(SetWindowsEdition);
            t_setwined.IsBackground = true;
            t_setwined.Start();
            Thread t_initform = new Thread(InitForm);
            t_initform.IsBackground = true;
            t_initform.Start();
            //InitForm();
        }
        #region 添加多选框
        List<CheckBox> cbs = new List<CheckBox>();
        Point lastCB = new Point(5, 15);
        int space = 20;
        delegate void d_AddCheckBox(string cbname, GroupBox gb);
        private void AddCheckBox(string cbname, GroupBox gb)
        {
            if (this.InvokeRequired == true)
            {
                d_AddCheckBox dacb = new d_AddCheckBox(AddCheckBox);
                this.Invoke(dacb,cbname, gb);
            }
            else
            {
                CheckBox cb = new CheckBox();
                cb.AutoSize = true;
                cb.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                cb.Name = "cb_" + cbname; ;
                cb.Size = new System.Drawing.Size(43, 20);
                cb.TabIndex = 25;
                cb.Text = cbname;
                cb.UseVisualStyleBackColor = true;
                cb.Parent = gb;
                if (lastCB.X + space + cb.Width >= gb.Width)
                {
                    lastCB.X = 5;
                    lastCB.Y += 30;
                    gb.Height += 30;
                }
                cb.Location = new System.Drawing.Point(lastCB.X + space, lastCB.Y);
                cbs.Add(cb);
                lastCB.X = cb.Location.X + cb.Width;
            }
        }
        #endregion
        
        private void 磁盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            隐藏磁盘ToolStripMenuItem.BackColor = Color.Transparent;
            禁用磁盘ToolStripMenuItem.BackColor = Color.Transparent;
            ToolStripItem tsi = (ToolStripItem)sender;
            string menutext = tsi.Text;
            btn_achieve.Text = menutext;
            tsi.BackColor = Color.Coral;
            switch (menutext)
            {
                case "隐藏磁盘":
                    runDis = DisposeFun.Hide;
                    InitHide();
                    break;
                case "禁用磁盘":
                    runDis = DisposeFun.Forbid;
                    InitForbid();
                    break;
            };
        }
        private void 禁用U盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = (ToolStripItem)sender;
            switch(tsi.Text)
            {
                case "启用U盘":
                    tsi.Text = "禁用U盘";
                    SetUSBSTOR(3);
                    break;
                case "禁用U盘":
                    tsi.Text = "启用U盘";
                    SetUSBSTOR(4);
                    break;
            }
        }
        delegate void d_SetWinEd();
        private void SetWindowsEdition()
        {
            if (this.InvokeRequired == true) 
            {
                d_SetWinEd dsw=new d_SetWinEd(SetWindowsEdition);
                this.Invoke(dsw);
            }
            else
            {
                lab_windowEdition.Text = WindowsEdition.GetEdition();
                cb_reStartExplore.Visible = false;
                if (lab_windowEdition.Text == "Windows 7")
                    cb_reStartExplore.Visible = true;
            }
        }
        private void InitForm()
        {
            gb_exist.Controls.Clear();
            gb_noExist.Controls.Clear();
            gb_noExist.Height = 50;
            gb_exist.Height = 50;
            cbs.Clear();
            lastCB = new Point(5, 15);
            list_Letter.Clear();
            for (int i = 0; i < 26; i++)
            {
                list_Letter.Add(((char)('A' + i)).ToString());
            }
            foreach (DriveInfo di in DriveInfo.GetDrives())
            {
                AddCheckBox(di.Name.Substring(0, 1), gb_exist);
                list_Letter.Remove(di.Name.Substring(0, 1));
            }
            lastCB = new Point(5, 15);
            gb_noExist.Location = new Point(0, gb_exist.Location.Y + gb_exist.Height);
            foreach (string letter in list_Letter)
                AddCheckBox(letter, gb_noExist);
            this.Height = gb_noExist.Location.Y + gb_noExist.Height + 80;
            隐藏磁盘ToolStripMenuItem.BackColor = Color.Transparent;
            禁用磁盘ToolStripMenuItem.BackColor = Color.Transparent;
            if (runDis == DisposeFun.Hide)
            {
                InitHide();
                btn_achieve.Text = "隐藏磁盘";
                隐藏磁盘ToolStripMenuItem.BackColor = Color.Coral;
            }
            else if (runDis == DisposeFun.Forbid)
            {
                InitForbid();
                btn_achieve.Text = "禁用磁盘";
                禁用磁盘ToolStripMenuItem.BackColor = Color.Coral;
            }
            InitRemovable();
        }
        private void InitRemovable()
        {
            Key = Registry.LocalMachine;
            RegistryKey msglm = Key.OpenSubKey(removablePath);
            try
            {
                int rps = (int)msglm.GetValue("Start");
                if (rps == 4)
                    禁用U盘ToolStripMenuItem.Text = "启用U盘";
                else
                    禁用U盘ToolStripMenuItem.Text = "禁用U盘";
            }
            catch (Exception ex)
            {
                禁用U盘ToolStripMenuItem.Text = "禁用U盘";
            }
        }
        private void InitHide()
        {
            Key = Registry.CurrentUser;
            RegistryKey msgcu = Key.OpenSubKey(fixedPath);
            try
            {
                Byte[] by = (Byte[])msgcu.GetValue("NoDrives");
                foreach (CheckBox cb in cbs)
                {
                    cb.Checked = Exist(Char.Parse(cb.Text), by);
                }
            }
            catch (Exception ex)
            {
                foreach (CheckBox cb in cbs)
                {
                    cb.Checked = false;
                }
            }
            Key.Close();
        }
        private void InitForbid()
        {
            Key = Registry.LocalMachine;
            RegistryKey msglm = Key.OpenSubKey(fixedPath);
            try
            {
                int nvod = (int)msglm.GetValue("NoViewOnDrive");
                foreach (CheckBox cb in cbs)
                {
                    cb.Checked = Exist(Char.Parse(cb.Text), nvod);
                }
            }
            catch (Exception ex)
            {
                foreach (CheckBox cb in cbs)
                {
                    cb.Checked = false;
                }
            }
            Key.Close();
        }
        private void btn_achieve_Click(object sender, EventArgs e)
        {
            Button btn=(Button)sender;
            if (btn.Text == "隐藏磁盘")
                AchieveHide();
            else if (btn.Text == "禁用磁盘")
                AchieveForbid();
            if (cb_reStartExplore.Checked)
            {
                Process[] pro = Process.GetProcessesByName ("explorer");
                pro[0].Kill();
            }
            //ChangeReg();
            SHChangeNotify(SHCNE_DRIVEADD, SHCNF_IDLIST | SHCNF_PATH, "H:/", IntPtr.Zero);
            MessageBox.Show(btn.Text+"成功!");
        }

        int[] cimi = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768, 65536, 131072, 262144, 524288, 1048576, 2097152, 4194304, 8388608, 16777216, 33554432, 67108864, 134217728 };
        private bool Exist(char ch, Byte[] by)
        {
            ch = Char.ToUpper(ch);
            int temp = ch - 'A';
            int wei = temp / 8;
            int yushu = temp % 8;
            if ((cimi[yushu] & by[wei]) > 0)
                return true;
            else
                return false;
        }
        private bool Exist(char ch, int novdnum)
        {
            ch = Char.ToUpper(ch);
            int temp = ch - 'A';
            if ((cimi[temp] & novdnum) > 0)
                return true;
            else
                return false;
        }
        private void AchieveHide()
        {
            int []into = new int[4];
            foreach (CheckBox cb in cbs)
            {
                if (cb.Checked)
                {
                    char ch = Char.Parse(cb.Text);
                    int temp = ch - 'A';
                    int wei = temp / 8;
                    int yushu = temp % 8;
                    into[wei] = into[wei] | cimi[yushu];
                }
            }
            Key = Registry.CurrentUser;
            RegistryKey myreg = Key.OpenSubKey(fixedPath, true); //该项必须已存在
            if (myreg == null)
            {
                myreg = Key.CreateSubKey(fixedPath);
            }
            try
            {
                myreg.SetValue("NoDrives", into, RegistryValueKind.Binary);
            }
            catch (Exception ex)
            {
                Byte[] by = new Byte[4];
                for (int i = 0; i < 4; i++)
                    by[i] = Byte.Parse(into[i].ToString());
                myreg.SetValue("NoDrives", by, RegistryValueKind.Binary);
            }
            Key.Close();
            
        }
        private void AchieveForbid()
        {
            int nvodnum = 0;
            foreach (CheckBox cb in cbs)
            {
                if (cb.Checked)
                {
                    nvodnum += cimi[Char.Parse(cb.Text)-'A'];
                }
            }
            Key = Registry.LocalMachine;
            RegistryKey myreg = Key.OpenSubKey(fixedPath, true); //该项必须已存在
            myreg.SetValue("NoViewOnDrive", nvodnum);
            Key.Close();
        }
        private void SetUSBSTOR(int value)
        {
            Key = Registry.LocalMachine;
            RegistryKey myreg = Key.OpenSubKey(removablePath, true); //该项必须已存在
            myreg.SetValue("Start", value, RegistryValueKind.DWord);
            Key.Close();
        }

        private void llab_selectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel ll = (LinkLabel)sender;
            if (ll.Text == "全不选")
            {
                foreach (CheckBox cb in cbs)
                {
                    cb.Checked = false;
                }
            }
            else if (ll.Text == "全选")
            {
                foreach (CheckBox cb in cbs)
                {
                    cb.Checked = true;
                }
            }
            else if (ll.Text == "刷新")
            {
                InitForm();
            }
        }

        #region 接受处理窗体消息
        private const int WM_DEVICECHANGE = 0x219;
        private const int DBT_DEVICEARRIVAL = 0x8000;
        private const int DBT_CONFIGCHANGECANCELED = 0x0019;
        private const int DBT_CONFIGCHANGED = 0x0018;
        private const int DBT_CUSTOMEVENT = 0x8006;
        private const int DBT_DEVICEQUERYREMOVE = 0x8001;
        private const int DBT_DEVICEQUERYREMOVEFAILED = 0x8002;
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004;
        private const int DBT_DEVICEREMOVEPENDING = 0x8003;
        private const int DBT_DEVICETYPESPECIFIC = 0x8005;
        private const int DBT_DEVNODES_CHANGED = 0x0007;
        private const int DBT_QUERYCHANGECONFIG = 0x0017;
        private const int DBT_USERDEFINED = 0xFFFF;
        protected override void WndProc(ref Message m)
        {
            try
            {
                if (m.Msg == WM_DEVICECHANGE)
                {
                    switch (m.WParam.ToInt32())
                    {
                        case WM_DEVICECHANGE:
                            break;
                        case DBT_DEVICEARRIVAL://U盘插入
                            InitForm();
                            break;
                        case DBT_CONFIGCHANGECANCELED:
                            break;
                        case DBT_CONFIGCHANGED:
                            break;
                        case DBT_CUSTOMEVENT:
                            break;
                        case DBT_DEVICEQUERYREMOVE:
                            break;
                        case DBT_DEVICEQUERYREMOVEFAILED:
                            break;
                        case DBT_DEVICEREMOVECOMPLETE: //U盘卸载
                            InitForm();
                            break;
                        case DBT_DEVICEREMOVEPENDING:
                            break;
                        case DBT_DEVICETYPESPECIFIC:
                            break;
                        case DBT_DEVNODES_CHANGED:
                            break;
                        case DBT_QUERYCHANGECONFIG:
                            break;
                        case DBT_USERDEFINED:
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            base.WndProc(ref m);
        }
        #endregion

        #region wEventId
        private const Int64 SHCNE_RENAMEITEM = 0x1;
        private const Int64 SHCNE_CREATE = 0x2;
        private const Int64 SHCNE_DELETE = 0x4;
        private const Int64 SHCNE_MKDIR = 0x8;
        private const Int64 SHCNE_RMDIR = 0x10;
        private const Int64 SHCNE_MEDIAINSERTED = 0x20;
        private const Int64 SHCNE_MEDIAREMOVED = 0x40;
        private const Int64 SHCNE_DRIVEREMOVED = 0x80;
        private const Int64 SHCNE_DRIVEADD = 0x100;
        private const Int64 SHCNE_NETSHARE = 0x200;
        private const Int64 SHCNE_NETUNSHARE = 0x400;
        private const Int64 SHCNE_ATTRIBUTES = 0x800;
        private const Int64 SHCNE_UPDATEDIR = 0x1000;
        private const Int64 SHCNE_UPDATEITEM = 0x2000;
        private const Int64 SHCNE_SERVERDISCONNECT = 0x4000;
        private const Int64 SHCNE_UPDATEIMAGE = 0x8000;
        private const Int64 SHCNE_DRIVEADDGUI = 0x10000;
        private const Int64 SHCNE_RENAMEFOLDER = 0x20000;
        private const Int64 SHCNE_FREESPACE = 0x40000;
        private const Int64 SHCNE_ASSOCCHANGED = 0x8000000;
        private const Int64 SHCNE_DISKEVENTS = 0x2381F;
        private const Int64 SHCNE_GLOBALEVENTS = 0xC0581E0;
        private const Int64 SHCNE_ALLEVENTS = 0x7FFFFFFF;
        private const Int64 SHCNE_INTERRUPT = 0x80000000;
        #endregion
        private const Int64 SHCNF_IDLIST = 0;               //  LPITEMIDLIST
        private const Int64 SHCNF_PATHA = 0x1;               // path name
        private const Int64 SHCNF_PRINTERA = 0x2;            // printer friendly name
        private const Int64 SHCNF_DWORD = 0x3;               // DWORD
        private const Int64 SHCNF_PATHW = 0x5;               // path name
        private const Int64 SHCNF_PRINTERW = 0x6;            // printer friendly name
        private const Int64 SHCNF_TYPE = 0xFF;
        private const Int64 SHCNF_FLUSH = 0x1000;
        private const Int64 SHCNF_FLUSHNOWAIT = 0x2000;
        private const Int64 SHCNF_PATH = SHCNF_PATHW;
        private const Int64 SHCNF_PRINTER = SHCNF_PRINTERW;
        private const Int64 WM_SHNOTIFY = 0x401;


        [DllImport("shell32.dll")]
        public static extern void SHChangeNotify (Int64 wEventId, Int64 uFlags, string dwItem1, IntPtr dwItem2);

        //SHChangeNotify(HChangeNotifyEventID.SHCNE_ASSOCCHANGED,HChangeNotifyFlags.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);

        #region 应用注册表修改
        const int WM_SETTINGCHANGE = 0x001A;
        const int HWND_BROADCAST = 0xffff;
        IntPtr result1;
        public enum SendMessageTimeoutFlags : uint
        {
            SMTO_NORMAL = 0x0000,
            SMTO_BLOCK = 0x0001,
            SMTO_ABORTIFHUNG = 0x0002,
            SMTO_NOTIMEOUTIFNOTHUNG = 0x0008
        }

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(
        IntPtr windowHandle,
        uint Msg,
        IntPtr wParam,
        IntPtr lParam,
        SendMessageTimeoutFlags flags,
        uint timeout,
        out IntPtr result
        );

        public void ChangeReg()
        {
            //通知所有打开的程序注册表以修改 
            SendMessageTimeout(new IntPtr(HWND_BROADCAST), WM_SETTINGCHANGE, IntPtr.Zero, IntPtr.Zero,

            SendMessageTimeoutFlags.SMTO_NORMAL, 1000, out result1);
        }
        #endregion 
    }
}
