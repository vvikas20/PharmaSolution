using PharmaBusiness;
using PharmaBusinessObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaUI
{
    public partial class frmLogin : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        IApplicationFacade applicationFacade;

        public frmLogin()
        {
            try
            {
                InitializeComponent();
                this.FormBorderStyle = FormBorderStyle.None;
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

                applicationFacade = new ApplicationFacade(ExtensionMethods.LoggedInUser);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Login();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Login()
        {
            try
            {

                if (string.IsNullOrWhiteSpace(tbUserName.Text))
                {
                    MessageBox.Show("Please enter username !");
                    tbUserName.Focus();
                }
                else if (string.IsNullOrWhiteSpace(tbPassword.Text))
                {
                    MessageBox.Show("Please enter password !");
                    tbPassword.Focus();
                }
                else
                {
                    var user = applicationFacade.ValidateUser(tbUserName.Text, tbPassword.Text);

                    if (user != null)
                    {
                        ExtensionMethods.LoggedInUser = user;
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("User name or password is incorrect !!");
                        tbUserName.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception)
            {

                throw;
            }
        }


        private void tbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Login();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    Login();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // ExtensionMethods.FormLoad(this,  "Login");

            SendMessage(tbUserName.Handle, 0x1501, 1, "user name");
            SendMessage(tbPassword.Handle, 0x1501, 1, "password");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Add
            if (keyData == Keys.Escape)
            {
                Application.Exit();
                return true;
            }
            
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
