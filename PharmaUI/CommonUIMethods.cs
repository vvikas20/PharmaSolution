using PharmaBusinessObjects.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI
{

    public class TransactionForm
    {
        public int FormNo { get; set; }
        public string FormName { get; set; }
        public bool Visible { get; set; }
        public string ControlName { get; set; }
    }

    public static class ExtensionMethods
    {
        private static List<TransactionForm> TransactionForms = new List<TransactionForm>();

        public static PharmaBusinessObjects.Master.UserMaster LoggedInUser { get; set; }
        public static string FontFamily = "Microsoft Sans Serif";


        public static int FontSize = 9;
        public static Panel MainPanel;

        public const string MatchEmailPattern = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                                                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                            [0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                                                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				                                            [0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                                                + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";

        public static List<Control> GetAllControls(Control container, List<Control> list)
        {
            foreach (Control c in container.Controls)
            {

                if (c.Controls.Count > 0)
                    list = GetAllControls(c, list);
                else
                    list.Add(c);
            }

            return list;
        }



        public static List<Control> GetAllControls(Control container)
        {
            return GetAllControls(container, new List<Control>());
        }


        public static void DisableAllTextBoxAndComboBox(Control frm, Control ctrlToEnable = null)
        {
            foreach (Control c in frm.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    DisableAllTextBoxAndComboBox(c);
                }
                else
                {
                    if (c is TextBox)
                    {
                        TextBox tb = (TextBox)c;

                        if (!(tb.Enabled == false || tb.ReadOnly == true))
                        {
                            c.BackColor = Color.White;
                        }
                    }

                    else if (c is ComboBox)
                    {
                        if (c.Enabled == true)
                        {
                            c.BackColor = Color.White;
                        }
                    }
                    else if (c is MaskedTextBox)
                    {
                        if (c.Enabled == true)
                        {
                            c.BackColor = Color.White;
                        }
                    }
                }
            }

            if (ctrlToEnable != null)
            {
                ctrlToEnable.BackColor = Color.LightPink;

            }
        }

        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T)property.GetCustomAttributes(attrType, false).First();
        }

        public static decimal? SafeConversionDecimal(string inputVal)
        {
            decimal outputVal;
            if (!decimal.TryParse(inputVal, out outputVal))
            {
                return null;
            }
            else
            {
                return outputVal;
            }
        }

        public static double? SafeConversionDouble(string inputVal)
        {
            double outputVal;
            if (!double.TryParse(inputVal, out outputVal))
            {
                return null;
            }
            else
            {
                return outputVal;
            }
        }

        internal static void FormLoad(Form form, string lblText)
        {

            List<Control> allControls = ExtensionMethods.GetAllControls(form);

            allControls.ForEach(k => { if (k is ComboBox) { ((ComboBox)k).FlatStyle = FlatStyle.Flat;  } });
            allControls.ForEach(k => { if (k is TextBox) { ((TextBox)k).CharacterCasing = CharacterCasing.Upper; } });

            // Exclude.GetExcludedControls(
            allControls = allControls.Where(x => !Exclude.GetExcludedControls().Where(p => p.Name == x.Name).Any()).ToList();

            //allControls.ForEach(k =>{ if (k.Name != "lblSearch" && k.Name != "txtSearch" && k.Name != "lblPersonRouteType") { k.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize); } });

            allControls.ForEach(k => { k.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize); });

            LoadPanel(form, lblText);
        }

        public static void LoadPanel(Form form, string lblText)
        {
            Panel panel1 = new Panel();
            panel1.Location = new Point(0, 0);
            panel1.BackColor = Color.Gray;
            panel1.Width = form.Width;
            panel1.Height = 50;
            panel1.Dock = DockStyle.Fill;
            panel1.Margin = new Padding(3, 3, 3, 3);
            panel1.Padding = new Padding(3, 3, 3, 3);
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);

            Label lbl = new Label();
            lbl.Width = (int)(panel1.Width);
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Top = 10;
            lbl.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, 14, FontStyle.Bold);
            lbl.Text = lblText;
            lbl.ForeColor = Color.White;
            panel1.Controls.Add(lbl);

            form.Controls.Add(panel1);
        }

        internal static void AddFooter(Form form)
        {
            Panel panel1 = new Panel();
            panel1.Location = new Point(0, form.Height - 50);
            panel1.Width = form.Width;
            panel1.Height = 40;
            panel1.Dock = DockStyle.Fill;
            panel1.Margin = new Padding(3, 3, 3, 3);
            panel1.Padding = new Padding(3, 3, 3, 3);
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right);

            TableLayoutPanel tblPanel = new TableLayoutPanel();
            tblPanel.Width = form.Width;
            tblPanel.Height = 34;
            //panel1.Dock = DockStyle.Fill;
            tblPanel.Margin = new Padding(3, 3, 3, 3);
            tblPanel.Padding = new Padding(3, 3, 3, 3);
            tblPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tblPanel.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
            tblPanel.RowCount = 1;
            tblPanel.BackColor = Color.Gray;
            tblPanel.ColumnCount = 5;
            tblPanel.ColumnStyles.Clear();

            for (int x = 0; x < tblPanel.ColumnCount; x++)
                tblPanel.ColumnStyles.Add(new ColumnStyle() { Width = 20F, SizeType = SizeType.Percent });

            panel1.Controls.Add(tblPanel);

            Label lbl = new Label();
            lbl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl.Text = "<End> Close Dialog";
            lbl.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize);
            lbl.ForeColor = Color.White;
            tblPanel.Controls.Add(lbl, 0, 0);


            Label lbl1 = new Label();
            lbl1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl1.Text = "<Ctrl + F1> Open Dialog";
            lbl1.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize);
            lbl1.ForeColor = Color.White;
            tblPanel.Controls.Add(lbl1, 1, 0);

            Label lbl2 = new Label();
            lbl2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl2.Text = "<Enter|Tab> Focus Next Control";
            lbl2.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize);
            lbl2.ForeColor = Color.White;
            tblPanel.Controls.Add(lbl2, 2, 0);

            Label lbl3 = new Label();
            lbl3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl3.Text = "<Arrow Key> Change date in Datepicker";
            lbl3.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize);
            lbl3.ForeColor = Color.White;
            tblPanel.Controls.Add(lbl3, 3, 0);

            Label lbl4 = new Label();
            lbl4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl4.Text = "<End> Save Purchase Entry";
            lbl4.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize);
            lbl4.ForeColor = Color.White;
            tblPanel.Controls.Add(lbl4, 4, 0);

            form.Controls.Add(panel1);
        }

        internal static void HomeFormLoad(Form form, string lblText)
        {

            List<Control> allControls = ExtensionMethods.GetAllControls(form);
            allControls.ForEach(k => { if (k.Name != "lblHmHeading" && k.GetType() != typeof(GroupBox)) { k.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, ExtensionMethods.FontSize); } });

            Panel panel1 = new Panel();
            panel1.Location = new Point(0, 0);
            panel1.BackColor = Color.Gray;
            panel1.Width = form.Width;
            panel1.Height = 50;
            panel1.Dock = DockStyle.Fill;
            panel1.Margin = new Padding(3, 3, 3, 3);
            panel1.Padding = new Padding(3, 3, 3, 3);
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);

            Label lbl = new Label();
            lbl.Width = (int)(panel1.Width);
            lbl.Dock = DockStyle.Fill;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Top = 10;
            lbl.Font = new System.Drawing.Font(ExtensionMethods.FontFamily, 14, FontStyle.Bold);
            lbl.Text = lblText;
            lbl.ForeColor = Color.White;
            panel1.Controls.Add(lbl);

            form.Controls.Add(panel1);
        }

        public static void AddFormToPanel(Form frm, Panel pnl)
        {
            foreach (Form control in pnl.Controls)
            {
                control.Close();
                pnl.Controls.Remove(control);
            }

            pnl.Controls.Add(frm);
        }

        public static void AddChildFormToPanel(Control parentForm, Control childFrm, Panel pnl)
        {
            pnl.Controls[parentForm.Name].Visible = false;
            pnl.Controls.Add(childFrm);
        }

        public static void RemoveChildFormToPanel(Control parentForm, Control childFrm, Panel pnl)
        {
            if (pnl.Controls.Count > 0)
            {
                pnl.Controls.Remove(childFrm);

                if (pnl.Controls.Count > 0)
                {
                    if (parentForm != null && pnl.Controls[parentForm.Name] != null)
                    {
                        pnl.Controls[parentForm.Name].Visible = true;
                    }
                }
                else
                {
                    frmDefault dform = new frmDefault();
                    AddFormToPanel(dform, MainPanel);
                    dform.Show();
                }
            }
        }


        public static void AddTrasanctionFormToPanel(Control childFrm, Panel pnl)
        {
            int max = TransactionForms.Count() + 1;

            childFrm.Name = max.ToString() + "_" + childFrm.Name;

            if (max > 1)
            {
                pnl.Controls[TransactionForms.Where(p => p.FormNo == (max - 1)).FirstOrDefault().FormName].Visible = false;
            }
            else
            {
                foreach (Form control in pnl.Controls)
                {
                    control.Close();
                    pnl.Controls.Remove(control);
                }
            }

            TransactionForms.Add(new TransactionForm() { FormNo = max, FormName = childFrm.Name, Visible = true });
            pnl.Controls.Add(childFrm);
        }

        public static void RemoveTransactionFormToPanel(Control childFrm, Panel pnl)
        {

            string[] form = childFrm.Name.Split('_');

            if (form[0] == "1")
            {
                TransactionForm tform = TransactionForms.Where(p => p.FormName == childFrm.Name).FirstOrDefault();
                TransactionForms.Remove(tform);

                pnl.Controls.Remove(childFrm);

                frmDefault dform = new frmDefault();
                AddFormToPanel(dform, MainPanel);
                dform.Show();

            }
            else
            {
                TransactionForm tform = TransactionForms.Where(p => p.FormName == childFrm.Name).FirstOrDefault();
                TransactionForms.Remove(tform);
                pnl.Controls.Remove(childFrm);

                pnl.Controls[TransactionForms.Where(p => p.FormNo == 1).FirstOrDefault().FormName].Visible = true;

            }
        }




        public static void SetFormProperties(Form frm)
        {
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.ControlBox = false;
            frm.Text = "";
            frm.TopLevel = false;
            frm.AutoScroll = true;
            frm.ShowIcon = false;
            frm.Dock = DockStyle.Fill;
            frm.AutoSize = false;
            frm.AutoSizeMode = AutoSizeMode.GrowOnly;

        }

        public static void SetChildFormProperties(Form frm)
        {
            frm.FormBorderStyle = FormBorderStyle.FixedSingle;
            frm.ControlBox = false;
            frm.Text = "";
            frm.ShowIcon = false;
            frm.TopLevel = true;
            frm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            frm.StartPosition = FormStartPosition.CenterScreen;

            foreach (Control btn in frm.Controls)
            {
                if (btn is Button)
                {
                    if (btn.Name.ToLower().Contains("cancel"))
                    {
                        frm.CancelButton = (Button)btn;
                        break;
                    }
                }
            }
        }

        public static int? SafeConversionInt(string inputVal)
        {
            int outputVal;

            if (!int.TryParse(inputVal, out outputVal))
            {
                return null;
            }
            else
            {
                return outputVal;
            }
        }

        public static bool IsValidEmail(string emailaddress)
        {
            if (emailaddress != null) return System.Text.RegularExpressions.Regex.IsMatch(emailaddress, MatchEmailPattern);
            else return false;
        }

        public static void EnterKeyDownForTabEvents(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c.Controls.Count > 0)
                {
                    EnterKeyDownForTabEvents(c);
                }
                else
                {
                    c.KeyDown -= C_KeyDown;
                    c.KeyDown += C_KeyDown;
                }
            }
        }


        private static void C_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }


        /// <summary>
        /// Converts a List to a datatable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }


        public static void GridSelectionOnSearch(DataGridView dgv, string searchColumnName, string searchString, Label searchResultStatus)
        {
            bool flag = true;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                int rowIndex = row.Index;
                dgv.Rows[rowIndex].DefaultCellStyle = new DataGridViewCellStyle { ForeColor = Color.Black, BackColor = Color.White };
            }

            if (dgv.CurrentRow != null)
            {
                dgv.CurrentRow.Selected = false;
            }

            if (string.IsNullOrEmpty(searchString))
                return;

            int rowIndex1 = 0;
            bool searchedTextFound = false;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[searchColumnName].Value.ToString().Replace(" ", "").ToLower().StartsWith(searchString.ToLower().Replace(" ", "")))
                {
                    int row2 = row.Index;
                    if (flag)
                    {
                        searchedTextFound = true;
                        rowIndex1 = row.Index;
                        dgv.ClearSelection();
                        flag = false;
                    }
                    dgv.Rows[row2].DefaultCellStyle = new DataGridViewCellStyle { ForeColor = Color.DarkGreen, BackColor = Color.LightBlue };
                }
            }

            if (!searchedTextFound)
            {
                searchResultStatus.Visible = true;
            }
            else
            {
                searchResultStatus.Visible = false;
            }

            dgv.FirstDisplayedScrollingRowIndex = rowIndex1;
            dgv.Rows[rowIndex1].Selected = true;
            dgv.Rows[rowIndex1].Cells[searchColumnName].Selected = true;
        }

        public static void SetGridDefaultProperty(DataGridView dgv)
        {


            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.DefaultCellStyle.SelectionBackColor = Color.Pink;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Visible = false;
            }

            //if (!dgv.ColumnHeadersVisible)
            //    dgv.ColumnHeadersVisible = true;
        }

        public static string ConvertToAppDateFormat(DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static DateTime ConvertToSystemDateFormat(string dateTime)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            string sep = culture.DateTimeFormat.DateSeparator;

            dateTime = dateTime.Replace("-", sep);

            string dtFrmt = "dd{0}MM{0}yyyy";

            return DateTime.ParseExact(dateTime, string.Format(dtFrmt,sep), CultureInfo.InvariantCulture);
        }

        public static bool IsValidDate(string inputDate)
        {
            bool isValidDate = false;

            DateTime dt;

            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            string sep = culture.DateTimeFormat.DateSeparator;

            string dtFrmt = "dd{0}MM{0}yyyy";

            inputDate = inputDate.Replace("-", sep);

            if (DateTime.TryParseExact(inputDate, string.Format(dtFrmt, sep), CultureInfo.InvariantCulture, DateTimeStyles.None, out dt) || String.IsNullOrWhiteSpace(inputDate))
            {
                isValidDate = true;
            }

            return isValidDate;
        }
    }
}
