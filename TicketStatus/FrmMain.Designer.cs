namespace TicketStatus
{
    partial class FrmTicketStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTicketStatus));
            this.lstURL = new System.Windows.Forms.ListBox();
            this.gdvAllEvents = new System.Windows.Forms.DataGridView();
            this.CntMenuGrd1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolOpenEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.toolDeleteEvent = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ChkProxy = new System.Windows.Forms.CheckBox();
            this.btnAddUrl = new System.Windows.Forms.Button();
            this.lblUrl = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.gdvEventsTicketsAvailable = new System.Windows.Forms.DataGridView();
            this.CntMenuGrd2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.tooldeleteUrl = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlLog = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.lblGrid2Title = new System.Windows.Forms.Label();
            this.lblGrid1Title = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.rectangleShape2 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            this.rectangleShape1 = new Microsoft.VisualBasic.PowerPacks.RectangleShape();
            ((System.ComponentModel.ISupportInitialize)(this.gdvAllEvents)).BeginInit();
            this.CntMenuGrd1.SuspendLayout();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvEventsTicketsAvailable)).BeginInit();
            this.CntMenuGrd2.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstURL
            // 
            this.lstURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstURL.BackColor = System.Drawing.Color.Black;
            this.lstURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstURL.CausesValidation = false;
            this.lstURL.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstURL.ForeColor = System.Drawing.Color.White;
            this.lstURL.FormattingEnabled = true;
            this.lstURL.ItemHeight = 18;
            this.lstURL.Location = new System.Drawing.Point(1, 431);
            this.lstURL.Name = "lstURL";
            this.lstURL.Size = new System.Drawing.Size(1140, 252);
            this.lstURL.TabIndex = 4;
            this.lstURL.TabStop = false;
            // 
            // gdvAllEvents
            // 
            this.gdvAllEvents.AllowUserToAddRows = false;
            this.gdvAllEvents.AllowUserToDeleteRows = false;
            this.gdvAllEvents.AllowUserToOrderColumns = true;
            this.gdvAllEvents.AllowUserToResizeColumns = false;
            this.gdvAllEvents.AllowUserToResizeRows = false;
            this.gdvAllEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvAllEvents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvAllEvents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gdvAllEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvAllEvents.Location = new System.Drawing.Point(-1, 27);
            this.gdvAllEvents.MultiSelect = false;
            this.gdvAllEvents.Name = "gdvAllEvents";
            this.gdvAllEvents.ReadOnly = true;
            this.gdvAllEvents.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.gdvAllEvents.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdvAllEvents.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gdvAllEvents.RowTemplate.ContextMenuStrip = this.CntMenuGrd1;
            this.gdvAllEvents.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdvAllEvents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvAllEvents.ShowCellErrors = false;
            this.gdvAllEvents.ShowCellToolTips = false;
            this.gdvAllEvents.ShowEditingIcon = false;
            this.gdvAllEvents.ShowRowErrors = false;
            this.gdvAllEvents.Size = new System.Drawing.Size(567, 372);
            this.gdvAllEvents.TabIndex = 8;
            this.gdvAllEvents.TabStop = false;
            this.gdvAllEvents.UseWaitCursor = true;
            // 
            // CntMenuGrd1
            // 
            this.CntMenuGrd1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOpenEvent,
            this.toolDeleteEvent});
            this.CntMenuGrd1.Name = "DeleteURL";
            this.CntMenuGrd1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.CntMenuGrd1.Size = new System.Drawing.Size(140, 48);
            // 
            // toolOpenEvent
            // 
            this.toolOpenEvent.Image = global::TicketStatus.Properties.Resources.open_in_browser;
            this.toolOpenEvent.Name = "toolOpenEvent";
            this.toolOpenEvent.Size = new System.Drawing.Size(139, 22);
            this.toolOpenEvent.Text = "Open Event";
            this.toolOpenEvent.Click += new System.EventHandler(this.toolOpenEvent_Click);
            // 
            // toolDeleteEvent
            // 
            this.toolDeleteEvent.Image = global::TicketStatus.Properties.Resources.logout;
            this.toolDeleteEvent.Name = "toolDeleteEvent";
            this.toolDeleteEvent.Size = new System.Drawing.Size(139, 22);
            this.toolDeleteEvent.Text = "Delete Event";
            this.toolDeleteEvent.Click += new System.EventHandler(this.toolDeleteEvent_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ChkProxy);
            this.MainPanel.Controls.Add(this.btnAddUrl);
            this.MainPanel.Controls.Add(this.lblUrl);
            this.MainPanel.Controls.Add(this.txtURL);
            this.MainPanel.Location = new System.Drawing.Point(1, -5);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1140, 35);
            this.MainPanel.TabIndex = 12;
            // 
            // ChkProxy
            // 
            this.ChkProxy.AutoSize = true;
            this.ChkProxy.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkProxy.Location = new System.Drawing.Point(1068, 11);
            this.ChkProxy.Name = "ChkProxy";
            this.ChkProxy.Size = new System.Drawing.Size(64, 23);
            this.ChkProxy.TabIndex = 16;
            this.ChkProxy.Text = "Proxy";
            this.ChkProxy.UseVisualStyleBackColor = true;
            // 
            // btnAddUrl
            // 
            this.btnAddUrl.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddUrl.Location = new System.Drawing.Point(981, 9);
            this.btnAddUrl.Name = "btnAddUrl";
            this.btnAddUrl.Size = new System.Drawing.Size(79, 27);
            this.btnAddUrl.TabIndex = 14;
            this.btnAddUrl.Text = "Add URL";
            this.btnAddUrl.UseVisualStyleBackColor = true;
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUrl.Location = new System.Drawing.Point(4, 13);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(44, 19);
            this.lblUrl.TabIndex = 13;
            this.lblUrl.Text = "URL :";
            // 
            // txtURL
            // 
            this.txtURL.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL.Location = new System.Drawing.Point(48, 9);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(926, 26);
            this.txtURL.TabIndex = 12;
            this.txtURL.Leave += new System.EventHandler(this.txtURL_Leave);
            // 
            // gdvEventsTicketsAvailable
            // 
            this.gdvEventsTicketsAvailable.AllowUserToAddRows = false;
            this.gdvEventsTicketsAvailable.AllowUserToDeleteRows = false;
            this.gdvEventsTicketsAvailable.AllowUserToOrderColumns = true;
            this.gdvEventsTicketsAvailable.AllowUserToResizeColumns = false;
            this.gdvEventsTicketsAvailable.AllowUserToResizeRows = false;
            this.gdvEventsTicketsAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvEventsTicketsAvailable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gdvEventsTicketsAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gdvEventsTicketsAvailable.Location = new System.Drawing.Point(567, 27);
            this.gdvEventsTicketsAvailable.MultiSelect = false;
            this.gdvEventsTicketsAvailable.Name = "gdvEventsTicketsAvailable";
            this.gdvEventsTicketsAvailable.ReadOnly = true;
            this.gdvEventsTicketsAvailable.RowHeadersVisible = false;
            this.gdvEventsTicketsAvailable.RowTemplate.ContextMenuStrip = this.CntMenuGrd2;
            this.gdvEventsTicketsAvailable.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gdvEventsTicketsAvailable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvEventsTicketsAvailable.Size = new System.Drawing.Size(568, 372);
            this.gdvEventsTicketsAvailable.TabIndex = 13;
            this.gdvEventsTicketsAvailable.TabStop = false;
            // 
            // CntMenuGrd2
            // 
            this.CntMenuGrd2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openUrl,
            this.tooldeleteUrl});
            this.CntMenuGrd2.Name = "DeleteURL";
            this.CntMenuGrd2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.CntMenuGrd2.Size = new System.Drawing.Size(140, 48);
            // 
            // openUrl
            // 
            this.openUrl.Image = ((System.Drawing.Image)(resources.GetObject("openUrl.Image")));
            this.openUrl.Name = "openUrl";
            this.openUrl.Size = new System.Drawing.Size(139, 22);
            this.openUrl.Text = "Open Event";
            this.openUrl.Click += new System.EventHandler(this.openUrl_Click);
            // 
            // tooldeleteUrl
            // 
            this.tooldeleteUrl.Image = ((System.Drawing.Image)(resources.GetObject("tooldeleteUrl.Image")));
            this.tooldeleteUrl.Name = "tooldeleteUrl";
            this.tooldeleteUrl.Size = new System.Drawing.Size(139, 22);
            this.tooldeleteUrl.Text = "Delete Event";
            this.tooldeleteUrl.Click += new System.EventHandler(this.tooldeleteUrl_Click);
            // 
            // pnlLog
            // 
            this.pnlLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLog.Location = new System.Drawing.Point(1, 431);
            this.pnlLog.Name = "pnlLog";
            this.pnlLog.Size = new System.Drawing.Size(1140, 257);
            this.pnlLog.TabIndex = 14;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.Controls.Add(this.lblGrid2Title);
            this.pnlGrid.Controls.Add(this.lblGrid1Title);
            this.pnlGrid.Controls.Add(this.gdvAllEvents);
            this.pnlGrid.Controls.Add(this.gdvEventsTicketsAvailable);
            this.pnlGrid.Controls.Add(this.shapeContainer1);
            this.pnlGrid.Location = new System.Drawing.Point(2, 30);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1140, 404);
            this.pnlGrid.TabIndex = 15;
            // 
            // lblGrid2Title
            // 
            this.lblGrid2Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrid2Title.AutoSize = true;
            this.lblGrid2Title.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrid2Title.Location = new System.Drawing.Point(799, 5);
            this.lblGrid2Title.Name = "lblGrid2Title";
            this.lblGrid2Title.Size = new System.Drawing.Size(122, 19);
            this.lblGrid2Title.TabIndex = 18;
            this.lblGrid2Title.Text = "Tickets Available";
            // 
            // lblGrid1Title
            // 
            this.lblGrid1Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGrid1Title.AutoSize = true;
            this.lblGrid1Title.Font = new System.Drawing.Font("Comic Sans MS", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGrid1Title.Location = new System.Drawing.Point(244, 5);
            this.lblGrid1Title.Name = "lblGrid1Title";
            this.lblGrid1Title.Size = new System.Drawing.Size(77, 19);
            this.lblGrid1Title.TabIndex = 17;
            this.lblGrid1Title.Text = "Event List";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.rectangleShape2,
            this.rectangleShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(1140, 404);
            this.shapeContainer1.TabIndex = 19;
            this.shapeContainer1.TabStop = false;
            // 
            // rectangleShape2
            // 
            this.rectangleShape2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleShape2.Location = new System.Drawing.Point(2, 2);
            this.rectangleShape2.Name = "rectangleShape2";
            this.rectangleShape2.Size = new System.Drawing.Size(561, 22);
            // 
            // rectangleShape1
            // 
            this.rectangleShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleShape1.Location = new System.Drawing.Point(570, 2);
            this.rectangleShape1.Name = "rectangleShape1";
            this.rectangleShape1.Size = new System.Drawing.Size(561, 22);
            // 
            // FrmTicketStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 687);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.lstURL);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlGrid);
            this.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmTicketStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ticket Status";
            this.Activated += new System.EventHandler(this.FrmTicketStatus_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.gdvAllEvents)).EndInit();
            this.CntMenuGrd1.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvEventsTicketsAvailable)).EndInit();
            this.CntMenuGrd2.ResumeLayout(false);
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstURL;
        private System.Windows.Forms.DataGridView gdvAllEvents;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.CheckBox ChkProxy;
        private System.Windows.Forms.Button btnAddUrl;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.DataGridView gdvEventsTicketsAvailable;
        private System.Windows.Forms.ContextMenuStrip CntMenuGrd1;
        private System.Windows.Forms.ToolStripMenuItem toolOpenEvent;
        private System.Windows.Forms.ToolStripMenuItem toolDeleteEvent;
        private System.Windows.Forms.ContextMenuStrip CntMenuGrd2;
        private System.Windows.Forms.ToolStripMenuItem openUrl;
        private System.Windows.Forms.ToolStripMenuItem tooldeleteUrl;
        private System.Windows.Forms.Panel pnlLog;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblGrid2Title;
        private System.Windows.Forms.Label lblGrid1Title;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape2;
        private Microsoft.VisualBasic.PowerPacks.RectangleShape rectangleShape1;
    }
}

