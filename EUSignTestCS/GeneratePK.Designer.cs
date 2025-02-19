namespace EUSignTestCS
{
	partial class EUGeneratePK
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
			this.folderBrowserDialogPKFile = new System.Windows.Forms.FolderBrowserDialog();
			this.panelTop = new System.Windows.Forms.Panel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.pkTypeView = new EUSignTestCS.AdditionalControls.PKTypeView();
			this.pkCertReqView = new EUSignTestCS.AdditionalControls.CRsView();
			this.rsaParamsView = new EUSignTestCS.AdditionalControls.PKParamsView();
			this.uaParamsView = new EUSignTestCS.AdditionalControls.PKParamsView();
			this.panelTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelTop
			// 
			this.panelTop.Controls.Add(this.labelTitle);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(498, 35);
			this.panelTop.TabIndex = 3;
			// 
			// labelTitle
			// 
			this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
			this.labelTitle.Location = new System.Drawing.Point(12, 6);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(373, 23);
			this.labelTitle.TabIndex = 2;
			this.labelTitle.Text = "Генерація ключів";
			// 
			// pkTypeView
			// 
			this.pkTypeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pkTypeView.Location = new System.Drawing.Point(10, 36);
			this.pkTypeView.Name = "pkTypeView";
			this.pkTypeView.Size = new System.Drawing.Size(480, 284);
			this.pkTypeView.TabIndex = 4;
			// 
			// pkCertReqView
			// 
			this.pkCertReqView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pkCertReqView.CRPathRSA = "";
			this.pkCertReqView.CRPathUA_DS = "";
			this.pkCertReqView.CRPathUA_KEP = "";
			this.pkCertReqView.Location = new System.Drawing.Point(10, 54);
			this.pkCertReqView.Name = "pkCertReqView";
			this.pkCertReqView.Size = new System.Drawing.Size(480, 266);
			this.pkCertReqView.TabIndex = 7;
			this.pkCertReqView.Visible = false;
			// 
			// rsaParamsView
			// 
			this.rsaParamsView.AlgIndex = -1;
			this.rsaParamsView.AlgTypes = new string[] {
        "RSA"};
			this.rsaParamsView.DSIndex = -1;
			this.rsaParamsView.DSParams = new string[] {
        "мінімальна (1024 біта з SHA-1)",
        "базова (2048 біт з SHA-256)",
        "велика (3072 біта з SHA-256)",
        "максимальна (4096 біт з SHA-256)",
        "з файлу параметрів"};
			this.rsaParamsView.KEPIndex = -1;
			this.rsaParamsView.KEPParams = new string[0];
			this.rsaParamsView.Location = new System.Drawing.Point(10, 36);
			this.rsaParamsView.Name = "rsaParamsView";
			this.rsaParamsView.ParamsPath = "";
			this.rsaParamsView.Size = new System.Drawing.Size(480, 266);
			this.rsaParamsView.TabIndex = 6;
			this.rsaParamsView.UseDSAsKEP = true;
			this.rsaParamsView.UseKEP = false;
			this.rsaParamsView.Visible = false;
			// 
			// uaParamsView
			// 
			this.uaParamsView.AlgIndex = -1;
			this.uaParamsView.AlgTypes = new string[] {
        "ДСТУ 4145-2002 та Диффі-Гелман в гр. точок ЕК"};
			this.uaParamsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.uaParamsView.DSIndex = -1;
			this.uaParamsView.DSParams = new string[] {
        "мінімальна (191 біт)",
        "базова (257 біт)",
        "велика (307 біт)",
        "з файлу параметрів"};
			this.uaParamsView.KEPIndex = -1;
			this.uaParamsView.KEPParams = new string[] {
        "базова (257 біт)",
        "велика (431 біт)",
        "максимальна (571 біт)",
        "з файлу параметрів"};
			this.uaParamsView.Location = new System.Drawing.Point(10, 54);
			this.uaParamsView.Name = "uaParamsView";
			this.uaParamsView.ParamsPath = "";
			this.uaParamsView.Size = new System.Drawing.Size(480, 266);
			this.uaParamsView.TabIndex = 5;
			this.uaParamsView.UseDSAsKEP = true;
			this.uaParamsView.UseKEP = false;
			this.uaParamsView.Visible = false;
			// 
			// EUGeneratePK
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 320);
			this.Controls.Add(this.panelTop);
			this.Controls.Add(this.pkTypeView);
			this.Controls.Add(this.rsaParamsView);
			this.Controls.Add(this.pkCertReqView);
			this.Controls.Add(this.uaParamsView);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EUGeneratePK";
			this.ShowIcon = false;
			this.Text = "Генерація ключів";
			this.Shown += new System.EventHandler(this.EUGeneratePK_Shown);
			this.panelTop.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPKFile;
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Label labelTitle;
		private AdditionalControls.PKTypeView pkTypeView;
		private AdditionalControls.PKParamsView uaParamsView;
		private AdditionalControls.PKParamsView rsaParamsView;
		private AdditionalControls.CRsView pkCertReqView;
	}
}