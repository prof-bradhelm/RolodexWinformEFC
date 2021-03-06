﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
 

namespace RolodexWinformEFC.Models
{
    public class RolodexContext : DbContext
    {
        public DbSet<RolodexEntry> Rolodex { get; set; }
        public DbSet<RolodexContact> Contacts { get; set; }

        // configuring the connection
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=rolodex.db");
            base.OnConfiguring(optionsBuilder);
        }

        // code-first programming our data model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class RolodexContact
    {
        public int RolodexContactId { get; set; }

        public virtual RolodexEntry Owner { get; set; }

        public string HowToContact { get; set; }

        public override string ToString()
        {
            return HowToContact;
        }

    }

    public class RolodexEntry
    {
        // EFC only cares about the data properties
        public int RolodexEntryId { get; set; }     // primary key

        public string LastName { get; set; }
        public string FirstNameMI { get; set; }

        public DateTime? BirthDate { get; set; }    // question mark makes it nullable

        // navigation properties
        public virtual List<RolodexContact> ContactInfo { get; set; }

        // add helper functions to interact with individual entries
        public override string ToString()
        {
            return LastName + ", " + FirstNameMI;
        }

        public ListViewItem GetListViewItem()
        {
            ListViewItem lvi = new ListViewItem();

            lvi.Text = ToString();
            lvi.Tag = RolodexEntryId;
            lvi.SubItems.Add(BirthDate.ToString());
            return lvi;
        }

    }


}
