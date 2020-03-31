using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.EntityFrameworkCore;
using RolodexWinformEFC.Models;
using RolodexWinformEFC.Forms;

namespace RolodexWinformEFC
{
    public partial class Form1 : Form
    {
        
        
        
        public void LoadListView()
        {
            listView1.Items.Clear();

            using (RolodexContext context = new RolodexContext())
            {
                foreach (RolodexEntry re in context.Rolodex)
                {
                    listView1.Items.Add(re.GetListViewItem());
                }
            }
        } // LoadListView 





        public void AddRolodexEntry()
        {
            RolodexEntryDialog red = new RolodexEntryDialog();
            if (red.ShowDialog()==DialogResult.OK)
            {
                using (RolodexContext context = new RolodexContext())
                {
                    context.Rolodex.Add(red.RolodexEntry);
                    context.SaveChanges();
                    LoadListView();
                }
            }
        } // AddRolodexEntry





        public void UpdateRolodexEntry()
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            RolodexEntry current;
            using (RolodexContext context = new RolodexContext())
            {
                int id = (int)listView1.SelectedItems[0].Tag;
                current = context.Rolodex.Find(id);
            }

            if (current==null)
            {
                MessageBox.Show("Could not find record");
                return;
            }

            RolodexEntryDialog red = new RolodexEntryDialog();
            red.RolodexEntry = current;

            if (red.ShowDialog() == DialogResult.OK)
            {
                using (RolodexContext context = new RolodexContext())
                {
                    context.Rolodex.Update(red.RolodexEntry);
                    context.SaveChanges();
                    LoadListView();
                }
            }
        } // UpdateRolodexEntry




        public void DeleteRolodexEntry()
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            RolodexEntry current;
            using (RolodexContext context = new RolodexContext())
            {
                int id = (int)listView1.SelectedItems[0].Tag;
                current = context.Rolodex.Find(id);
            }

            if (current == null)
            {
                MessageBox.Show("Could not find record");
                return;
            }

            if (
                MessageBox.Show("Are you sure?", "Delete Entry", MessageBoxButtons.YesNo) ==
                    DialogResult.Yes
               )
            {
                using (RolodexContext context = new RolodexContext())
                {
                    context.Rolodex.Remove(current);
                    context.SaveChanges();
                    LoadListView();
                }
            }

        }  // DeleteRolodexEntry




        public Form1()
        {
            InitializeComponent();
        }

        private void Form_Load(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            LoadListView();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            AddRolodexEntry();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            UpdateRolodexEntry();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            DeleteRolodexEntry();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
            listView1.Columns.Clear();
            listView1.Columns.Add("Name");
            listView1.Columns.Add("Birthdate");
        }

        private void samllIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }
    }  // class Form1
}
