namespace EUSignTestCS
{
    partial class EUSettings
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Файлове сховище", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Proxy-сервер", 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("TSP-сервер", 2);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("OCSP-сервер", 3);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("LDAP-сервер", 4);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("CMP-сервер", 5);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EUSettings));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.pictureBoxSplitImageBottom = new System.Windows.Forms.PictureBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.listViewTabs = new System.Windows.Forms.ListView();
            this.imageListSettings = new System.Windows.Forms.ImageList(this.components);
            this.serverTabCMP = new EUSignTestCS.ServerTab();
            this.serverTabLDAP = new EUSignTestCS.ServerTab();
            this.serverTabOCSP = new EUSignTestCS.ServerTab();
            this.serverTabTSP = new EUSignTestCS.ServerTab();
            this.serverTabProxy = new EUSignTestCS.ServerTab();
            this.fileStorageTab = new EUSignTestCS.FileStorageTab();
            this.panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBottom.Controls.Add(this.pictureBoxSplitImageBottom);
            this.panelBottom.Controls.Add(this.buttonSave);
            this.panelBottom.Controls.Add(this.buttonCancel);
            this.panelBottom.Controls.Add(this.buttonOK);
            this.panelBottom.Location = new System.Drawing.Point(0, 317);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(614, 55);
            this.panelBottom.TabIndex = 4;
            // 
            // pictureBoxSplitImageBottom
            // 
            this.pictureBoxSplitImageBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSplitImageBottom.Image = global::EUSignTestCS.Properties.Resources.RPK_SplitImage;
            this.pictureBoxSplitImageBottom.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxSplitImageBottom.Name = "pictureBoxSplitImageBottom";
            this.pictureBoxSplitImageBottom.Size = new System.Drawing.Size(614, 1);
            this.pictureBoxSplitImageBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSplitImageBottom.TabIndex = 8;
            this.pictureBoxSplitImageBottom.TabStop = false;
            // 
            // buttonSave
            // 
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(521, 15);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(79, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Застосувати";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(440, 15);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Відміна";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(359, 15);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "ОК";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer.IsSplitterFixed = true;
            this.splitContainer.Location = new System.Drawing.Point(12, 12);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listViewTabs);
            this.splitContainer.Panel1MinSize = 30;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.serverTabLDAP);
            this.splitContainer.Panel2.Controls.Add(this.serverTabOCSP);
            this.splitContainer.Panel2.Controls.Add(this.serverTabTSP);
            this.splitContainer.Panel2.Controls.Add(this.serverTabProxy);
            this.splitContainer.Panel2.Controls.Add(this.fileStorageTab);
            this.splitContainer.Panel2.Controls.Add(this.serverTabCMP);
            this.splitContainer.Size = new System.Drawing.Size(589, 299);
            this.splitContainer.SplitterDistance = 153;
            this.splitContainer.TabIndex = 5;
            // 
            // listViewTabs
            // 
            this.listViewTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewTabs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewTabs.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6});
            this.listViewTabs.Location = new System.Drawing.Point(3, 3);
            this.listViewTabs.Name = "listViewTabs";
            this.listViewTabs.Size = new System.Drawing.Size(145, 291);
            this.listViewTabs.SmallImageList = this.imageListSettings;
            this.listViewTabs.TabIndex = 1;
            this.listViewTabs.UseCompatibleStateImageBehavior = false;
            this.listViewTabs.View = System.Windows.Forms.View.List;
            this.listViewTabs.SelectedIndexChanged += new System.EventHandler(this.listViewTabs_SelectedIndexChanged);
            // 
            // imageListSettings
            // 
            this.imageListSettings.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListSettings.ImageStream")));
            this.imageListSettings.TransparentColor = System.Drawing.Color.White;
            this.imageListSettings.Images.SetKeyName(0, "DiskFloppy.bmp");
            this.imageListSettings.Images.SetKeyName(1, "ServerEarthLink.bmp");
            this.imageListSettings.Images.SetKeyName(2, "ServerClock.bmp");
            this.imageListSettings.Images.SetKeyName(3, "ServerCertificate.bmp");
            this.imageListSettings.Images.SetKeyName(4, "ServerBook.bmp");
            this.imageListSettings.Images.SetKeyName(5, "ServerArrows.bmp");
            // 
            // serverTabCMP
            // 
            this.serverTabCMP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverTabCMP.BackColor = System.Drawing.SystemColors.Window;
            this.serverTabCMP.Changed = false;
            this.serverTabCMP.Location = new System.Drawing.Point(0, 0);
            this.serverTabCMP.Name = "serverTabCMP";
            this.serverTabCMP.Size = new System.Drawing.Size(425, 278);
            this.serverTabCMP.TabIndex = 5;
            this.serverTabCMP.Visible = false;
            // 
            // serverTabLDAP
            // 
            this.serverTabLDAP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverTabLDAP.BackColor = System.Drawing.SystemColors.Window;
            this.serverTabLDAP.Changed = false;
            this.serverTabLDAP.Location = new System.Drawing.Point(0, 0);
            this.serverTabLDAP.Name = "serverTabLDAP";
            this.serverTabLDAP.Size = new System.Drawing.Size(425, 278);
            this.serverTabLDAP.TabIndex = 4;
            this.serverTabLDAP.Visible = false;
            // 
            // serverTabOCSP
            // 
            this.serverTabOCSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverTabOCSP.BackColor = System.Drawing.SystemColors.Window;
            this.serverTabOCSP.Changed = false;
            this.serverTabOCSP.Location = new System.Drawing.Point(0, 0);
            this.serverTabOCSP.Name = "serverTabOCSP";
            this.serverTabOCSP.Size = new System.Drawing.Size(425, 278);
            this.serverTabOCSP.TabIndex = 3;
            this.serverTabOCSP.Visible = false;
            // 
            // serverTabTSP
            // 
            this.serverTabTSP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverTabTSP.BackColor = System.Drawing.SystemColors.Window;
            this.serverTabTSP.Changed = false;
            this.serverTabTSP.Location = new System.Drawing.Point(0, 0);
            this.serverTabTSP.Name = "serverTabTSP";
            this.serverTabTSP.Size = new System.Drawing.Size(425, 278);
            this.serverTabTSP.TabIndex = 2;
            this.serverTabTSP.Visible = false;
            // 
            // serverTabProxy
            // 
            this.serverTabProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverTabProxy.BackColor = System.Drawing.SystemColors.Window;
            this.serverTabProxy.Changed = false;
            this.serverTabProxy.Location = new System.Drawing.Point(0, 0);
            this.serverTabProxy.Name = "serverTabProxy";
            this.serverTabProxy.Size = new System.Drawing.Size(425, 278);
            this.serverTabProxy.TabIndex = 1;
            this.serverTabProxy.Visible = false;
            // 
            // fileStorageTab
            // 
            this.fileStorageTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileStorageTab.BackColor = System.Drawing.SystemColors.Window;
            this.fileStorageTab.Changed = false;
            this.fileStorageTab.Location = new System.Drawing.Point(4, 3);
            this.fileStorageTab.Name = "fileStorageTab";
            this.fileStorageTab.Size = new System.Drawing.Size(423, 278);
            this.fileStorageTab.TabIndex = 0;
            this.fileStorageTab.Visible = false;
            // 
            // EUSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(612, 373);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EUSettings";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметри роботи";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EUSettings_FormClosing);
            this.Load += new System.EventHandler(this.EUSettings_Load);
            this.panelBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSplitImageBottom)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ImageList imageListSettings;
        private FileStorageTab fileStorageTab;
        private System.Windows.Forms.ListView listViewTabs;
        private ServerTab serverTabProxy;
        private ServerTab serverTabCMP;
        private ServerTab serverTabLDAP;
        private ServerTab serverTabOCSP;
        private ServerTab serverTabTSP;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.PictureBox pictureBoxSplitImageBottom;
    }
}