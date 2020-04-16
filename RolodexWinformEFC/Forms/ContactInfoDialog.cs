using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using RolodexWinformEFC.Models;

namespace RolodexWinformEFC.Forms
{
    public partial class ContactInfoDialog : Form
    {
        public RolodexContact ContactInfo { get; set; }

        public ContactInfoDialog()
        {
            InitializeComponent();
        }

        public void Scatter()
        {
            if (ContactInfo != null)
            {
                tbContactInfo.Text = ContactInfo.HowToContact;
            }
        }

        public void Gather()
        {
            if (ContactInfo == null)
                ContactInfo = new RolodexContact();

            ContactInfo.HowToContact = tbContactInfo.Text;
        }

        private void ContactInfoDialog_Load(object sender, EventArgs e)
        {
            Scatter();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Gather();
        }
    }
}
