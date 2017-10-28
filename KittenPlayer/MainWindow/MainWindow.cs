﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

namespace KittenPlayer
{

    /// <summary>
    /// Main window of the program.
    /// </summary>

    public partial class MainWindow : Form
    {
        //static public TabControl MainTabs2.Instance = new TabControl();
        //public MainTabs MainTab = new MainTabs();

        public static MusicPage ActivePage => Instance.MainTab.MainTab.Controls[Instance.MainTab.MainTab.SelectedIndex] as MusicPage;
        public static MusicTab ActiveTab => ActivePage?.musicTab;


        public static MainWindow Instance => Application.OpenForms[0] as MainWindow;

        MusicPlayer musicPlayer = MusicPlayer.Instance;
        ActionsControl actionsControl = ActionsControl.GetInstance();
        public Options options = new Options();
        

        public MainWindow()
        {
            InitializeComponent();
            InitializeTrackbarTimer();
        }

        public static void SavePlaylists()
        {
            LocalData.Instance.SavePlaylists(MainTabs.Instance);
        }
        
        private void MainWindow_Click(object sender, EventArgs e)
        {
            this.Focus();
        }

        private void MainWindow_DoubleClick(object sender, EventArgs e)
        {
            MainWindow.Instance.MainTab.AddNewTabAndRename();
        }

        private void ContextTab_Opening(object sender, CancelEventArgs e)
        {

        }

        RenameBox renameBox = null;
        
        /// <summary>
        /// On renaming action TextBox appears in exact place of original playlist name.
        /// </summary>

        public void RenameTab()
        {
            
            renameBox = new RenameBox(MainTabs.Instance);

        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameTab();
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        public void addNewPlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainWindow.Instance.MainTab.AddNewTabAndRename();
        }

        private void deletePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TabNum = MainTab.MainTab.SelectedIndex;
            MainTab.Controls.RemoveAt(MainTab.MainTab.SelectedIndex);
        }




        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actionsControl.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            actionsControl.Redo();
        }
        
        public String GetSelectedTrackPath()
        {
            int TabIndex = MainTab.MainTab.SelectedIndex;
            MusicPage musicPage = MainTab.Controls[TabIndex] as MusicPage;
            String Path = musicPage.GetSelectedTrackPath();
            return Path;
        }

        private void youTubeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusicPage currentPage = MainTab.MainTab.SelectedTab as MusicPage;
            currentPage.DeleteSelectedTracks();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MusicPage currentPage = MainTab.MainTab.SelectedTab as MusicPage;
            if (currentPage.musicTab.PlaylistView.Focused)
            {
                currentPage.SelectAll();
            }
            else if (MainWindow.Instance.searchBarPage.searchBar.Focused)
            {
                MainWindow.Instance.searchBarPage.searchBar.SelectAll();
            }
        }

        private void addYoutubePlaylistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddPlaylistForm form = new AddPlaylistForm();
            form.ShowDialog();
            List<Track> Tracks = form.Tracks;
            MusicPage currentPage = MainTab.MainTab.SelectedTab as MusicPage;
            currentPage.musicTab.AddTrack(Tracks);
            MainWindow.SavePlaylists();

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            options.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PlaylistProperties_Opening(object sender, CancelEventArgs e)
        {

        }
        
        Form About = new AboutForm();

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About.Show();
            About.Focus();
        }

        private void addYoutubeTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addYoutubeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void savePlaylistsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SavePlaylists();
        }

        private void searchPage1_Load(object sender, EventArgs e)
        {

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void SearchPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void MainWindow_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void LayoutPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                AddPlaylistStrip.Show(LayoutPanel.PointToScreen(e.Location));
            }
        }

        private void downloadAndPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void downloadAgainToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void downloadOnlyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void DownloadAndPlay()
        {

        }

        public void DownloadAgain()
        {

        }

        public void DownloadOnly()
        {

        }

        private void ResultsPage_Load(object sender, EventArgs e)
        {

        }

        private void LayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
