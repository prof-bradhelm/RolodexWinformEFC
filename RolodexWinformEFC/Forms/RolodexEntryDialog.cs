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
    public partial class RolodexEntryDialog : Form
    {
        // container to pass information in and out of the dialog
        public RolodexEntry RolodexEntry { get; set; }

        public RolodexEntryDialog()
        {
            InitializeComponent();
        }

        public void Scatter(object sender, EventArgs e)
        {
            if (RolodexEntry!=null)
            {
                tbLastName.Text = RolodexEntry.LastName;
                tbFirstNameMI.Text = RolodexEntry.FirstNameMI;
                dtpBirthDate.Checked = (RolodexEntry.BirthDate != null);
                if (RolodexEntry.BirthDate.HasValue)
                    dtpBirthDate.Value = RolodexEntry.BirthDate.Value;
            }
        } // end of Scatter()

        public void Gather(object sender, EventArgs e)
        {
            if (RolodexEntry == null)
                RolodexEntry = new RolodexEntry();

            RolodexEntry.LastName = tbLastName.Text;
            RolodexEntry.FirstNameMI = tbFirstNameMI.Text;
            if (dtpBirthDate.Checked)
            {
                RolodexEntry.BirthDate = dtpBirthDate.Value;
            } else
            {
                RolodexEntry.BirthDate = null;
            }
        } // end of Gather()

    }
}
