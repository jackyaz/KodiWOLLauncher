using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Kodi_WoL_Launcher.WOL;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;
using Kodi_WoL_Launcher.Kodi;
using Kodi_WoL_Launcher.Displays;

namespace Kodi_WoL_Launcher
{
    public partial class frmMain : Form
    {
        WOL_Listener _wollisten;
        Kodi_App _kodi;

        #region Constructor

        public frmMain()
        {
            InitializeComponent();
            _wollisten = new WOL_Listener();
            WOL_Events.OnPacketReceived += new WOL_Events.WOLEventHandler(WOL_Events_OnPacketReceived);

            _kodi = new Kodi_App();

            MainMenu _mainmenu = new MainMenu();
            _mainmenu.MenuItems.Add("File");
            _mainmenu.MenuItems[0].MenuItems.Add("Launch Manually", new EventHandler(MenuItemClicked));
            _mainmenu.MenuItems[0].MenuItems.Add("Quit", new EventHandler(MenuItemClicked));
            this.Menu = _mainmenu;

            ContextMenu _notifyiconmenu = new ContextMenu();
            MenuItem _showmenuitem = new MenuItem("Show", new EventHandler(MenuItemClicked));
            MenuItem _quitmenuitem = new MenuItem("Quit", new EventHandler(MenuItemClicked));
            _notifyiconmenu.MenuItems.AddRange(new MenuItem[] { _showmenuitem, _quitmenuitem });
            notifyKodiAutomator.ContextMenu = _notifyiconmenu;
        }

        #endregion

        #region Form Events

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtWOLPort.Text = Properties.Settings.Default.WOLPort.ToString();
            txtWOLPort.SelectionStart = txtWOLPort.Text.Length;

            txtBrowseKodi.Text = Properties.Settings.Default.KodiPath;

            if (txtBrowseKodi.Text.Length > 0 && File.Exists(txtBrowseKodi.Text))
            {
                openDlgKodi.InitialDirectory = Directory.GetParent(txtBrowseKodi.Text).ToString();
            }
            else
            {
                openDlgKodi.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            }

            cmbDisplayType.SelectedIndex = Properties.Settings.Default.DisplayMode;

            if (Properties.Settings.Default.RunOnStartup)
            {
                chkRunOnStartup.Checked = true;
            }
            else
            {
                chkRunOnStartup.Checked = false;
            }

            btnStartSave.Text = "Save";

            this.ActiveControl = lblWOLPort;
            _wollisten.StartListener(Properties.Settings.Default.WOLPort);

            HideForm(false);
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;

                if (Convert.ToInt32(txtWOLPort.Text) != Properties.Settings.Default.WOLPort)
                {
                    DialogResult dr = MessageBox.Show("Do you want to save any changes made?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        HideForm(true);
                    }
                    else if (dr == System.Windows.Forms.DialogResult.No)
                    {
                        HideForm(false);
                    }
                }
                else
                {
                    HideForm(false);
                }
            }
        }

        #endregion

        #region Form Methods

        private void ShowForm()
        {
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void HideForm(bool savechanges)
        {
            if (savechanges)
            {
                btnStartSave.PerformClick();
            }

            this.Hide();
            this.ShowInTaskbar = false;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.WOLPort = Convert.ToInt32(txtWOLPort.Text);
            Properties.Settings.Default.KodiPath = txtBrowseKodi.Text;
            Properties.Settings.Default.DisplayMode = cmbDisplayType.SelectedIndex;
            Properties.Settings.Default.RunOnStartup = chkRunOnStartup.Checked;
            Properties.Settings.Default.Save();
        }

        #endregion

        #region WOL Event Handling

        private void WOL_Events_OnPacketReceived(object sender, WOLEventArgs e)
        {
            if (e.Status == PacketStatus.Received)
            {
                _kodi.ConfigureKodi((DisplayMode)Properties.Settings.Default.DisplayMode, Properties.Settings.Default.KodiPath);
                _kodi.DeConfigureKodi();
                _wollisten.StartListener(Properties.Settings.Default.WOLPort);
            }
            else if (e.Status == PacketStatus.Error)
            {
                _wollisten.StartListener(Properties.Settings.Default.WOLPort);
            }
        }

        #endregion

        #region Control Events

        #region Listener buttons

        private void btnStartSave_Click(object sender, EventArgs e)
        {
            if (btnStop.Enabled)
            {
                SaveSettings();
                _wollisten.RestartListener(PacketStatus.Stop, Properties.Settings.Default.WOLPort);
            }
            else
            {
                btnStartSave.Text = "Save";
                btnStop.Enabled = true;
                _wollisten.StartListener(Properties.Settings.Default.WOLPort);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _wollisten.StopListener(PacketStatus.Stop);

            btnStartSave.Text = "Start";
            btnStop.Enabled = false;
        }

        #endregion

        #region File Browser Button

        private void btnBrowseKodi_Click(object sender, EventArgs e)
        {
            DialogResult dr = openDlgKodi.ShowDialog();

            if (dr == DialogResult.OK)
            {
                string selectedfile = openDlgKodi.FileName;
                txtBrowseKodi.Text = selectedfile;
            }
        }

        #endregion

        #region Startup Checkbox

        private void chkRunOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey regstartup = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (chkRunOnStartup.Checked)
            {
                regstartup.SetValue("Kodi WoL Launcher", "\"" + Application.ExecutablePath.ToString() + "\"");
            }
            else
            {
                regstartup.DeleteValue("Kodi WoL Launcher");
            }
        }

        #endregion

        #region Menu Actions

        private void MenuItemClicked(object sender, EventArgs e)
        {
            MenuItem _menuitem = (MenuItem)sender;

            switch (_menuitem.Text)
            {
                case "Show":
                    ShowForm();
                    break;
                case "Launch Manually":
                    _wollisten.StopListener(PacketStatus.Stop);
                    _kodi.ConfigureKodi((DisplayMode)Properties.Settings.Default.DisplayMode, Properties.Settings.Default.KodiPath);
                    _kodi.DeConfigureKodi();
                    _wollisten.StartListener(Properties.Settings.Default.WOLPort);
                    break;
                case "Quit":
                    DialogResult dr = MessageBox.Show("Do you really want to exit?", "Exit Application?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        SaveSettings();
                        _wollisten.StopListener(PacketStatus.ApplicationExit);
                        Application.Exit();
                    }
                    break;
            }
        }

        #endregion

        #region Notification Icon actions

        private void notifyKodiAutomator_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                ShowForm();
            }
        }

        #endregion

        #endregion
    }
}
