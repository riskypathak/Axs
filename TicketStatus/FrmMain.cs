using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TicketStatus
{
    public partial class FrmTicketStatus : Form
    {
        public List<Event> allEvents = new List<Event>();
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
                    LoadPage(line.ToString(), false);
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
                LoadPage(cUrl, ChkProxy.Checked);
                FillDataGrid();
            }
            else

                MessageBox.Show("Enter valid URL");
            txtURL.Text = "";
            txtURL.Focus();
        }

        private void FillGrid()
        {
            gdvAllEvents.Rows.Clear();
            gdvAllEvents.ColumnCount = 5;
            gdvAllEvents.Columns[0].Name = "Event Name";
            gdvAllEvents.Columns[0].ReadOnly = true;

            gdvAllEvents.Columns[1].Name = "Event Time";
            gdvAllEvents.Columns[1].ReadOnly = true;

            gdvAllEvents.Columns[2].Name = "Status";
            gdvAllEvents.Columns[2].ReadOnly = true;

            gdvAllEvents.Columns[3].Name = "Event URL";
            gdvAllEvents.Columns[3].ReadOnly = true;
            gdvAllEvents.Columns[3].DisplayIndex = 4;

            gdvAllEvents.Columns[4].Name = "Sale Start on";
            gdvAllEvents.Columns[4].ReadOnly = true;
            gdvAllEvents.Columns[4].DisplayIndex = 3;

            gdvEventsTicketsAvailable.Rows.Clear();
            gdvEventsTicketsAvailable.ColumnCount = 6;
            gdvEventsTicketsAvailable.Columns[0].Name = "Event Name";
            gdvEventsTicketsAvailable.Columns[0].ReadOnly = true;
            gdvEventsTicketsAvailable.Columns[0].DisplayIndex = 0;

            gdvEventsTicketsAvailable.Columns[1].Name = "Event Time";
            gdvEventsTicketsAvailable.Columns[1].ReadOnly = true;
            gdvEventsTicketsAvailable.Columns[1].DisplayIndex = 1;

            gdvEventsTicketsAvailable.Columns[2].Name = "Status";
            gdvEventsTicketsAvailable.Columns[2].ReadOnly = true;
            gdvEventsTicketsAvailable.Columns[2].DisplayIndex = 2;
            gdvEventsTicketsAvailable.Columns[2].Visible = false;

            gdvEventsTicketsAvailable.Columns[3].Name = "Event URL";
            gdvEventsTicketsAvailable.Columns[3].ReadOnly = true;
            gdvEventsTicketsAvailable.Columns[3].Visible = false;
            gdvEventsTicketsAvailable.Columns[3].DisplayIndex = 4;

            gdvEventsTicketsAvailable.Columns[4].Name = "Sale Start on";
            gdvEventsTicketsAvailable.Columns[4].ReadOnly = true;
            gdvEventsTicketsAvailable.Columns[4].DisplayIndex = 3;
            gdvEventsTicketsAvailable.Columns[4].Visible = false;

            gdvEventsTicketsAvailable.Columns[5].Name = "Seats";
            gdvEventsTicketsAvailable.Columns[5].ReadOnly = true;
            gdvEventsTicketsAvailable.Columns[5].DisplayIndex = 5;
            gdvEventsTicketsAvailable.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            gdvEventsTicketsAvailable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            gdvAllEvents.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(GrdURLlist_RowPrePaint);
        }

        private void GrdURLlist_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (Convert.ToString(gdvAllEvents.Rows[e.RowIndex].Cells[2].Value).ToLower() == "expired" || Convert.ToString(gdvAllEvents.Rows[e.RowIndex].Cells[2].Value).ToLower() == "error")
            {
                gdvAllEvents.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                gdvAllEvents.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
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

            foreach (Event ListUrl in allEvents)
            {

                int rowIndex = -1;
                foreach (DataGridViewRow row in gdvAllEvents.Rows)
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
                    gdvAllEvents.Rows.Add(ListUrl.EventName, ListUrl.EventTime, ListUrl.EventStatus, ListUrl.URL, ListUrl.EventOnSale);
                }
                else
                {
                    gdvAllEvents.Rows[rowIndex].Cells[2].Value = ListUrl.EventStatus;
                }


                if (ListUrl.EventStatus.Trim().ToLower() == "select tickets")
                {
                    rowIndex = -1;
                    foreach (DataGridViewRow row in gdvEventsTicketsAvailable.Rows)
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
                        gdvEventsTicketsAvailable.Rows.Add(ListUrl.EventName, ListUrl.EventTime, ListUrl.EventStatus, ListUrl.URL, ListUrl.EventOnSale, ListUrl.SeatStatus);
                    }
                    else
                    {
                        gdvEventsTicketsAvailable.Rows[rowIndex].Cells[2].Value = ListUrl.EventStatus;
                    }
                }
            }

            if (gdvAllEvents.RowCount != 0)
            {
                gdvAllEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                gdvAllEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }


            if (gdvEventsTicketsAvailable.RowCount != 0)
            {
                gdvEventsTicketsAvailable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                gdvEventsTicketsAvailable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

        }

        private void SetText(string text)
        {
            this.lstURL.Items.Add(text);
            this.lstURL.SetSelected(this.lstURL.Items.Count - 1, true);
        }

        private void LoadPage(string url, Boolean useProxy)
        {
            if (useProxy)
            {
                SetText("<< Add URL With Proxy >> " + url.Trim());
            }
            else
            {
                SetText("<< Add URL >> " + url.Trim());
            }

            System.ComponentModel.BackgroundWorker MyWorker = new System.ComponentModel.BackgroundWorker();

            MyWorker.DoWork += (ab, ee) =>
            {
                Event evnt = allEvents.Find(delegate(Event p) { return p.URL == url; });
                if (evnt == null)
                {
                    allEvents.Add(new Event(url, useProxy));
                    evnt = allEvents.Find(delegate(Event p) { return p.URL == url; });
                }
                else
                {
                    if (!evnt.IsBusy)
                        evnt.CheckStatus(url);
                }
                ee.Result = evnt;
            };

            MyWorker.RunWorkerCompleted += (ab, ee) =>
            {
                Event evnt = ee.Result as Event;
                if (evnt.UseProxy && evnt.URLProxy.Address.LocalPath.ToString().Trim() != "")
                {
                    this.SetText(" << Add Event Name >> '" + evnt.EventName + "' (" + evnt.URLProxy.Address.ToString().Trim() + ":" + evnt.URLProxy.Address.Port.ToString().Trim() + ") Current Status Is " + evnt.EventStatus.ToString());
                }
                else
                {
                    this.SetText(" << Add Event Name >> '" + evnt.EventName + "' Current Status Is " + evnt.EventStatus.ToString());
                }
                MyWorker.Dispose();
            };
            MyWorker.RunWorkerAsync();

        }

        private void LoadPage()
        {
            foreach (Event ListUrl in allEvents)
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
                        Event ListUrlUpdated = ee.Result as Event;
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
            Int32 rowToDelete = gdvEventsTicketsAvailable.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete != -1)
            {
                string strURL = gdvEventsTicketsAvailable.Rows[rowToDelete].Cells[3].Value.ToString();

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
            Int32 rowToDelete = gdvAllEvents.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete != -1)
            {
                string strURL = gdvAllEvents.Rows[rowToDelete].Cells[3].Value.ToString();
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
            Int32 rowToDelete = gdvEventsTicketsAvailable.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete != -1)
            {
                string strURL = gdvEventsTicketsAvailable.Rows[rowToDelete].Cells[3].Value.ToString();
                gdvEventsTicketsAvailable.Rows.RemoveAt(rowToDelete);
                gdvEventsTicketsAvailable.ClearSelection();
                foreach (DataGridViewRow row in gdvAllEvents.Rows)
                {
                    if (row.Cells[3].Value.ToString().Equals(strURL))
                    {
                        gdvAllEvents.Rows.RemoveAt(row.Index);
                    }
                }

                Event ListUrl = allEvents.Find(delegate(Event p) { return p.URL == strURL; });
                if (ListUrl != null)
                {
                    allEvents.Remove(ListUrl);
                    SetText(" << Deleted Event  >> '" + ListUrl.EventName.Trim() + "'");
                    FillDataGrid();
                }

            }
        }

        private void toolDeleteEvent_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = gdvAllEvents.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete != -1)
            {
                string strURL = gdvAllEvents.Rows[rowToDelete].Cells[3].Value.ToString();
                gdvAllEvents.Rows.RemoveAt(rowToDelete);
                gdvAllEvents.ClearSelection();
                foreach (DataGridViewRow row in gdvEventsTicketsAvailable.Rows)
                {
                    if (row.Cells[3].Value.ToString().Equals(strURL))
                    {
                        gdvEventsTicketsAvailable.Rows.RemoveAt(row.Index);
                    }
                }

                Event ListUrl = allEvents.Find(delegate(Event p) { return p.URL == strURL; });
                if (ListUrl != null)
                {
                    allEvents.Remove(ListUrl);
                    SetText(" << Deleted Event  >> '" + ListUrl.EventName.Trim() + "'");
                    FillDataGrid();
                }

            }
        }

        private void toolOpenHere_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = gdvAllEvents.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete != -1)
            {
                string strURL = gdvAllEvents.Rows[rowToDelete].Cells[3].Value.ToString();
                //DisplayUrl(strURL);
            }
        }

        private void toolOpenHere2_Click(object sender, EventArgs e)
        {
            Int32 rowToDelete = gdvEventsTicketsAvailable.Rows.GetFirstRow(DataGridViewElementStates.Selected);
            if (rowToDelete != -1)
            {
                string strURL = gdvEventsTicketsAvailable.Rows[rowToDelete].Cells[3].Value.ToString();
                //DisplayUrl(strURL);
            }
        }

    }
}
