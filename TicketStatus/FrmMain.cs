using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Diagnostics;

namespace TicketStatus
{
    public partial class FrmTicketStatus : Form
    {
        public List<SetUrl> URLList = new List<SetUrl>();
        Timer T = new Timer();

        public FrmTicketStatus()
        {
            InitializeComponent();
            FillGrid();
            LoadUrl();
            btnAddUrl.Click += new EventHandler(btnAddURl_Click);
            txtURL.KeyDown += new KeyEventHandler(txtURl_KeyDown);
            T.Tick += new EventHandler(T_Tick);
            T.Interval = 5000;
            T.Start();
        }

        private void LoadUrl()
        {
            string lcPath = Path.GetDirectoryName(Application.ExecutablePath);
            if (File.Exists(Path.GetDirectoryName(Application.ExecutablePath) + "\\url.txt"))
            {
                string[] lines = System.IO.File.ReadAllLines("url.txt");
                foreach (string line in lines)
                {
                    LoadPage(line.ToString(),false);
                }
            }
        }

        private void txtURl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAddUrl.PerformClick();       
            }
        }

        private void btnAddURl_Click(object sender, EventArgs e)
        {
            if (txtURL.Text.Trim() != "" && txtURL.Text.ToLower().Contains("axs.com") && Uri.IsWellFormedUriString(txtURL.Text.Trim(), UriKind.RelativeOrAbsolute))
            {
                String cUrl = txtURL.Text.Trim();
                txtURL.Text = "";
                LoadPage(cUrl,ChkProxy.Checked);
                FillDataGrid();
            }
            else

                MessageBox.Show("Enter valid URL");
                txtURL.Text = "";
                txtURL.Focus();
        }
 
        //private void DisplayUrl(string strUrl)
        //{
        //    if (strUrl.Trim() != "" && strUrl.ToLower().Contains("axs.com") && Uri.IsWellFormedUriString(strUrl.Trim(), UriKind.RelativeOrAbsolute))
        //    {
        //        if (webURLDisplay.Url == null || webURLDisplay.Url.ToString().ToLower() != strUrl.ToString().ToLower())
        //        {
        //            WaitImage.Visible = true;
        //            webURLDisplay.ScriptErrorsSuppressed = true;
        //            webURLDisplay.Navigate(strUrl);
        //            webURLDisplay.DocumentCompleted += webURLDisplay_DocumentCompleted;
        //        }
        //    }
        //}

        //private void webURLDisplay_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        //{
        //    webURLDisplay.DocumentCompleted -= webURLDisplay_DocumentCompleted;
        //    try 
        //    {
        //        webURLDisplay.Document.Body.InnerHtml = webURLDisplay.Document.GetElementById("layout-body-block").OuterHtml;
        //    }
        //    catch
        //    {
        //        try
        //        {
        //            webURLDisplay.Document.Body.InnerHtml = webURLDisplay.Document.GetElementById("page-relative-block").OuterHtml;
        //        }
        //        catch { }
        //    }
        //    WaitImage.Visible = false;
        //}

        private void FillGrid()
        {
            GrdURLlist.Rows.Clear();
            GrdURLlist.ColumnCount = 5;
            GrdURLlist.Columns[0].Name = "Event Name";
            GrdURLlist.Columns[0].ReadOnly = true;

            GrdURLlist.Columns[1].Name = "Event Time";
            GrdURLlist.Columns[1].ReadOnly = true;

            GrdURLlist.Columns[2].Name = "Status";
            GrdURLlist.Columns[2].ReadOnly = true;
            //GrdURLlist.Columns[2].Visible = false;
            
            GrdURLlist.Columns[3].Name = "Event URL";
            GrdURLlist.Columns[3].ReadOnly = true;
            GrdURLlist.Columns[3].DisplayIndex = 4;

            GrdURLlist.Columns[4].Name = "Sale Start on";
            GrdURLlist.Columns[4].ReadOnly = true;
            GrdURLlist.Columns[4].DisplayIndex = 3;

            GrdEventPending.Rows.Clear();
            GrdEventPending.ColumnCount = 5;
            GrdEventPending.Columns[0].Name = "Event Name";
            GrdEventPending.Columns[0].ReadOnly = true;
            GrdEventPending.Columns[0].DisplayIndex = 0;

            GrdEventPending.Columns[1].Name = "Event Time";
            GrdEventPending.Columns[1].ReadOnly = true;
            GrdEventPending.Columns[1].DisplayIndex = 1;

            GrdEventPending.Columns[2].Name = "Status";
            GrdEventPending.Columns[2].ReadOnly = true;
            GrdEventPending.Columns[2].DisplayIndex = 2;
            GrdEventPending.Columns[2].Visible = false;

            GrdEventPending.Columns[3].Name = "Event URL";
            GrdEventPending.Columns[3].ReadOnly = true;
            GrdEventPending.Columns[3].DisplayIndex = 4;

            GrdEventPending.Columns[4].Name = "Sale Start on";
            GrdEventPending.Columns[4].ReadOnly = true;
            GrdEventPending.Columns[4].DisplayIndex = 3;


            //GrdEventPending.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(GrdEventPending_RowPrePaint);
            GrdURLlist.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(GrdURLlist_RowPrePaint);
        }

        private void GrdURLlist_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (Convert.ToString(GrdURLlist.Rows[e.RowIndex].Cells[2].Value).ToLower() == "expired" || Convert.ToString(GrdURLlist.Rows[e.RowIndex].Cells[2].Value).ToLower() == "error")
            {
            //    GrdURLlist.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
            //    GrdURLlist.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Green;
            //}
            //else if (Convert.ToString(GrdURLlist.Rows[e.RowIndex].Cells[2].Value).ToLower() == "remind me")
            //{
            //    GrdURLlist.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.HotPink;
            //    GrdURLlist.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.HotPink;
            //}
            //else
            //{
                GrdURLlist.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                GrdURLlist.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
            }
        }
  
        private void T_Tick(object sender, EventArgs e)
        {
            T.Stop();
            LoadPage();
            T.Start();
            FillDataGrid();
        }
               
        private void FillDataGrid()
        {
 
            foreach (SetUrl ListUrl in URLList)
            {

                int rowIndex = -1;
                foreach (DataGridViewRow row in GrdURLlist.Rows)
                {
                    if (row.Cells[3].Value != null) // Need to check for null if new row is exposed
                    {
                        if (row.Cells[3].Value.ToString().ToLower().Equals(ListUrl.URL.ToLower()))
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }
                }
                if (rowIndex == -1)
                {
                    GrdURLlist.Rows.Add(ListUrl.EventName, ListUrl.EventTime, ListUrl.EventStatus, ListUrl.URL, ListUrl.EventOnSale);
                }
                else
                {
                    GrdURLlist.Rows[rowIndex].Cells[2].Value = ListUrl.EventStatus;
                }


                if (ListUrl.EventStatus.Trim().ToLower() == "select tickets")
                {
                    rowIndex = -1;
                    foreach (DataGridViewRow row in GrdEventPending.Rows)
                    {
                        if (row.Cells[3].Value != null) // Need to check for null if new row is exposed
                        {
                            if (row.Cells[3].Value.ToString().ToLower().Equals(ListUrl.URL.ToLower()))
                            {
                                rowIndex = row.Index;
                                break;
                            }
                        }
                    }
                    if (rowIndex == -1)
                    {
                        GrdEventPending.Rows.Add(ListUrl.EventName, ListUrl.EventTime, ListUrl.EventStatus, ListUrl.URL, ListUrl.EventOnSale);
                    }
                    else
                    {
                        GrdEventPending.Rows[rowIndex].Cells[2].Value = ListUrl.EventStatus;
                    }
                }
            }

            if (GrdURLlist.RowCount != 0)
            {
                GrdURLlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                GrdURLlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }


            if (GrdEventPending.RowCount != 0)
            {
                GrdEventPending.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                GrdEventPending.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void SetText(string text)
        {
            this.lstURL.Items.Add(text);
            this.lstURL.SetSelected(this.lstURL.Items.Count - 1,true);
        }

        private void LoadPage(string cURL,Boolean lChkProxy)
        {
            
            if (lChkProxy) 
            {
                SetText("<< Add URL With Proxy >> " + cURL.Trim());
            }
            else
            {
                SetText("<< Add URL >> " + cURL.Trim());
            }

            System.ComponentModel.BackgroundWorker MyWorker = new System.ComponentModel.BackgroundWorker();
            MyWorker.DoWork += (ab, ee) =>
            {
                SetUrl ListUrl = URLList.Find(delegate(SetUrl p) { return p.URL  == cURL; });
                if (ListUrl == null)
                { 
                    URLList.Add(new SetUrl(cURL, lChkProxy));
                    ListUrl = URLList.Find(delegate(SetUrl p) { return p.URL == cURL; });
                }
                else
                {
                    if (!ListUrl.IsBusy)                     
                        ListUrl.CheckStatus(cURL);
                }
                ee.Result = ListUrl;
            };

            MyWorker.RunWorkerCompleted += (ab, ee) =>
            {
                SetUrl ListUrl = ee.Result as SetUrl;
                if (ListUrl.UseProxy && ListUrl.URLProxy.Address.LocalPath.ToString().Trim() != "")
                {
                    this.SetText(" << Add Event Name >> '" + ListUrl.EventName + "' (" + ListUrl.URLProxy.Address.ToString().Trim() + ":" + ListUrl.URLProxy.Address.Port.ToString().Trim() + ") Current Status Is " + ListUrl.EventStatus.ToString());
                }
                else
                {
                    this.SetText(" << Add Event Name >> '" + ListUrl.EventName + "' Current Status Is " + ListUrl.EventStatus.ToString());
                }
                MyWorker.Dispose();
            };
           MyWorker.RunWorkerAsync();

        }
      
        private void LoadPage()
        {
            foreach (SetUrl ListUrl in URLList)
            {
                if (ListUrl.UseProxy)
                {
                    SetText(" << Check Status : >> '" + ListUrl.EventName.Trim() + "' (" + ListUrl.URLProxy.Address.ToString().Trim() + ":" + ListUrl.URLProxy.Address.Port.ToString().Trim() + ")");
                }
                else
                {
                    SetText(" << Check Status : >> " + ListUrl.EventName.Trim());
                }
                if (!ListUrl.IsBusy)
                {
                    System.ComponentModel.BackgroundWorker MyWorker = new System.ComponentModel.BackgroundWorker();
                    MyWorker.DoWork += (ab, ee) =>
                    {
                        ListUrl.CheckStatus(ListUrl.URL);
                        ee.Result = ListUrl;
                    };
                    MyWorker.RunWorkerCompleted += (ab, ee) =>
                    {
                        SetUrl ListUrlUpdated = ee.Result as SetUrl;
                        if (ListUrlUpdated.UseProxy && ListUrlUpdated.URLProxy.Address.ToString().Trim() != "")
                        {
                            this.SetText(" << Event Name >> '" + ListUrl.EventName + "' (" + ListUrl.URLProxy.Address.ToString().Trim() + ":" + ListUrl.URLProxy.Address.Port.ToString().Trim() + ") Updated Status Is " + ListUrl.EventStatus.ToString());
                        }
                        else
                        {
                            this.SetText(" << Event Name >> '" + ListUrl.EventName + "' Updated Status Is " + ListUrl.EventStatus.ToString());
                        }
                        MyWorker.Dispose();
                    };
                    MyWorker.RunWorkerAsync();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
 
        private void FrmTicketStatus_Activated(object sender, EventArgs e)
        {
            try
            {
                string _ClipText = (string)Clipboard.GetDataObject().GetData(DataFormats.Text).ToString().ToLower();
                if (_ClipText.Trim() != "" && _ClipText.ToLower().Contains("axs.com") && Uri.IsWellFormedUriString(_ClipText.Trim(), UriKind.RelativeOrAbsolute))
                {
                    txtURL.Text = _ClipText;
                    //DisplayUrl(txtURL.Text.ToString());
                }
            }
            catch
            { }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                T.Dispose();
                base.Dispose(disposing);
            }
        }

        private void txtURL_Leave(object sender, EventArgs e)
        {
            //DisplayUrl(txtURL.Text.ToString());
        }
      
        private void openUrl_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = GrdEventPending.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete != -1)
            {
                string strURL = GrdEventPending.Rows[rowToDelete].Cells[3].Value.ToString();

                Process myProcess = new Process();
                try
                {
                    myProcess.StartInfo.UseShellExecute = true;
                    myProcess.StartInfo.FileName = strURL;
                    myProcess.Start();
                }
                catch { }
            }
        }

        private void toolOpenEvent_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = GrdURLlist.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete != -1)
            {
                string strURL = GrdURLlist.Rows[rowToDelete].Cells[3].Value.ToString();
                Process myProcess = new Process();
                try
                {
                    myProcess.StartInfo.UseShellExecute = true;
                    myProcess.StartInfo.FileName = strURL;
                    myProcess.Start();
                }
                catch { }
            }
        }
        
        private void tooldeleteUrl_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = GrdEventPending.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete != -1)
            {
                string strURL = GrdEventPending.Rows[rowToDelete].Cells[3].Value.ToString();
                GrdEventPending.Rows.RemoveAt(rowToDelete);
                GrdEventPending.ClearSelection();
                foreach (DataGridViewRow row in GrdURLlist.Rows)
                {
                    if (row.Cells[3].Value.ToString().Equals(strURL))
                    {
                        GrdURLlist.Rows.RemoveAt(row.Index);
                    }
                }

                SetUrl ListUrl = URLList.Find(delegate(SetUrl p) { return p.URL == strURL; });
                if (ListUrl != null)
                {
                    URLList.Remove(ListUrl);
                    SetText(" << Deleted Event  >> '" + ListUrl.EventName.Trim() + "'");
                    FillDataGrid();
                }

            }
        }

        private void toolDeleteEvent_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = GrdURLlist.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete != -1)
            {
                string strURL = GrdURLlist.Rows[rowToDelete].Cells[3].Value.ToString();
                GrdURLlist.Rows.RemoveAt(rowToDelete);
                GrdURLlist.ClearSelection();
                foreach (DataGridViewRow row in GrdEventPending.Rows)
                {
                    if (row.Cells[3].Value.ToString().Equals(strURL))
                    {
                        GrdEventPending.Rows.RemoveAt(row.Index);
                    }
                }

                SetUrl ListUrl = URLList.Find(delegate(SetUrl p) { return p.URL == strURL; });
                if (ListUrl != null)
                {
                    URLList.Remove(ListUrl);
                    SetText(" << Deleted Event  >> '" + ListUrl.EventName.Trim() + "'");
                    FillDataGrid();
                }

            }
        }

        private void toolOpenHere_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete =    GrdURLlist.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete != -1)
            {
                string strURL = GrdURLlist.Rows[rowToDelete].Cells[3].Value.ToString();
                //DisplayUrl(strURL);
            }
        }

        private void toolOpenHere2_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = GrdEventPending.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete != -1)
            {
                string strURL = GrdEventPending.Rows[rowToDelete].Cells[3].Value.ToString();
                //DisplayUrl(strURL);
            }
        }

    }
}
