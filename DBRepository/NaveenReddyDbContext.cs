using DBRepository.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBRepository
{
   public class NaveenReddyDbContext: DbContext
    {
        public NaveenReddyDbContext()
        {
        }

        public NaveenReddyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PersonalInfo> Tbl_PersonalInfo { get; set; }
        public DbSet<EducationDetails> Tbl_EducationDetails { get; set; }
        public DbSet<AddressDetails> Tbl_AddressDetails { get; set; }
        public DbSet<ReligiousDetails> Tbl_ReligiousDetails { get; set; }
        public DbSet<FamilyDetails> Tbl_FamilyDetails { get; set; }
        public DbSet<LoginDetails> Tbl_LoginDetails { get; set; }
        public DbSet<LoginHistory> Tbl_LoginHistory { get; set; }
        public DbSet<ProfessionalDetails> Tbl_ProfessionalDetails { get; set; }
        public DbSet<Images> Tbl_Images { get; set; }
        public DbSet<Story> Tbl_Story { get; set; }
        public DbSet<PartnerInfo> Tbl_Partner { get; set; }
    }
}
