using System;
using System.Windows.Forms;
using System.Drawing;

namespace WhisperType
{
    public partial class MainWindow
    {
        private NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;

        private AppState _appState;
        public AppState AppState
        {
            get
            {
                return _appState;
            }
            set
            {
                // whenever the property is set, call the UpdateUI() method
                _appState = value;
                UpdateUI();
            }
        }

        public void SetupTrayIcon()
        {
            trayMenu = new ContextMenuStrip();

            var showMainMenuItem = new ToolStripMenuItem("Show Main Window");
            showMainMenuItem.Click += ShowMainForm;
            trayMenu.Items.Add(showMainMenuItem);

            var startRecordingMenuItem = new ToolStripMenuItem("Start Recording");
            startRecordingMenuItem.Click += OnStartRecording;
            trayMenu.Items.Add(startRecordingMenuItem);

            var exitMenuItem = new ToolStripMenuItem("Exit");
            exitMenuItem.Click += OnExit;
            trayMenu.Items.Add(exitMenuItem);

            trayIcon = new NotifyIcon()
            {
                Text = "My Application",
                Icon = new Icon(SystemIcons.Application, 40, 40), // Add your Icon here
                ContextMenuStrip = trayMenu,
                Visible = true
            };

            trayIcon.DoubleClick += ShowMainForm;
        }

        // This method shows the form when the related menu item is clicked or the tray icon is double clicked.
        private void ShowMainForm(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                this.Hide();
            }
            else
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            base.OnFormClosing(e);
        }

        private void OnStartRecording(object sender, EventArgs e)
        {
            AppState = AppState.Recording;
            UpdateUI();
        }

        private void OnExit(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        // Useful .ico converter - https://convertico.com/
        private void UpdateTrayIcon()
        {
            switch (AppState)
            {
                case AppState.Recording:
                    trayIcon.Icon = config.MegaConspiciousTrayIcons ? Properties.Resources.Logo256_RedFull : Properties.Resources.Logo256_Red1; 
                    break;
                case AppState.Transcribing:
                    trayIcon.Icon = config.MegaConspiciousTrayIcons ? Properties.Resources.Logo256_GreenFull : Properties.Resources.Logo256_Green1; 
                    break;
                case AppState.Ready:
                default:
                    trayIcon.Icon = Properties.Resources.Logo256; 
                    break;
            }
        }
    }
}