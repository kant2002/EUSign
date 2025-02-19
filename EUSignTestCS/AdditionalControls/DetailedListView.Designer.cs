namespace EUSignTestCS
{
    partial class DetailedListView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelDetailed = new System.Windows.Forms.Panel();
            this.richTextBoxValue = new System.Windows.Forms.RichTextBox();
            this.labelValueTitle = new System.Windows.Forms.Label();
            this.listViewFields = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelDetailed.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTitle.Location = new System.Drawing.Point(0, 1);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(397, 13);
            this.labelTitle.TabIndex = 6;
            this.labelTitle.Text = "Поля:";
            // 
            // panelDetailed
            // 
            this.panelDetailed.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetailed.Controls.Add(this.richTextBoxValue);
            this.panelDetailed.Controls.Add(this.labelValueTitle);
            this.panelDetailed.Location = new System.Drawing.Point(0, 243);
            this.panelDetailed.Name = "panelDetailed";
            this.panelDetailed.Size = new System.Drawing.Size(400, 55);
            this.panelDetailed.TabIndex = 7;
            this.panelDetailed.Visible = false;
            // 
            // richTextBoxValue
            // 
            this.richTextBoxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxValue.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxValue.Location = new System.Drawing.Point(3, 15);
            this.richTextBoxValue.Name = "richTextBoxValue";
            this.richTextBoxValue.ReadOnly = true;
            this.richTextBoxValue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.richTextBoxValue.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxValue.Size = new System.Drawing.Size(391, 35);
            this.richTextBoxValue.TabIndex = 5;
            this.richTextBoxValue.Text = "";
            // 
            // labelValueTitle
            // 
            this.labelValueTitle.AutoSize = true;
            this.labelValueTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelValueTitle.Location = new System.Drawing.Point(1, 0);
            this.labelValueTitle.Name = "labelValueTitle";
            this.labelValueTitle.Size = new System.Drawing.Size(67, 13);
            this.labelValueTitle.TabIndex = 4;
            this.labelValueTitle.Text = "Значення:";
            // 
            // listViewFields
            // 
            this.listViewFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFields.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewFields.FullRowSelect = true;
            this.listViewFields.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewFields.HideSelection = false;
            this.listViewFields.Location = new System.Drawing.Point(3, 18);
            this.listViewFields.MultiSelect = false;
            this.listViewFields.Name = "listViewFields";
            this.listViewFields.Size = new System.Drawing.Size(391, 220);
            this.listViewFields.TabIndex = 5;
            this.listViewFields.UseCompatibleStateImageBehavior = false;
            this.listViewFields.View = System.Windows.Forms.View.Details;
            this.listViewFields.SelectedIndexChanged += new System.EventHandler(this.listViewFields_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Тип поля";
            this.columnHeader1.Width = 192;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Значення";
            this.columnHeader2.Width = 230;
            // 
            // DetailedListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.panelDetailed);
            this.Controls.Add(this.listViewFields);
            this.Name = "DetailedListView";
            this.Size = new System.Drawing.Size(400, 300);
            this.panelDetailed.ResumeLayout(false);
            this.panelDetailed.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelDetailed;
        private System.Windows.Forms.RichTextBox richTextBoxValue;
        private System.Windows.Forms.Label labelValueTitle;
        private System.Windows.Forms.ListView listViewFields;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}
