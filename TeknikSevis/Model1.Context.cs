﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeknikSevis
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DbTeknikServisEntities : DbContext
    {
        public DbTeknikServisEntities()
            : base("name=DbTeknikServisEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TBLADMIN> TBLADMIN { get; set; }
        public virtual DbSet<TBLARIZADETAY> TBLARIZADETAY { get; set; }
        public virtual DbSet<TBLCARI> TBLCARI { get; set; }
        public virtual DbSet<TBLDEPARTMAN> TBLDEPARTMAN { get; set; }
        public virtual DbSet<TBLFATURABILGI> TBLFATURABILGI { get; set; }
        public virtual DbSet<TBLFATURADETAY> TBLFATURADETAY { get; set; }
        public virtual DbSet<TBLGIDER> TBLGIDER { get; set; }
        public virtual DbSet<TBLKATEGORI> TBLKATEGORI { get; set; }
        public virtual DbSet<TBLNOTLARIM> TBLNOTLARIM { get; set; }
        public virtual DbSet<TBLPERSONEL> TBLPERSONEL { get; set; }
        public virtual DbSet<TBLURUN> TBLURUN { get; set; }
        public virtual DbSet<TBLURUNHAREKET> TBLURUNHAREKET { get; set; }
        public virtual DbSet<TBLURUNKABUL> TBLURUNKABUL { get; set; }
        public virtual DbSet<TBLURUNTAKIP> TBLURUNTAKIP { get; set; }
        public virtual DbSet<TBLHAKKIMIZDA> TBLHAKKIMIZDA { get; set; }
        public virtual DbSet<TBLILETISIM> TBLILETISIM { get; set; }
        public virtual DbSet<TBLILCELER> TBLILCELER { get; set; }
        public virtual DbSet<TBLILLER> TBLILLER { get; set; }
    
        public virtual ObjectResult<urunkategori_Result> urunkategori()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<urunkategori_Result>("urunkategori");
        }
    
        public virtual ObjectResult<string> makskategori()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("makskategori");
        }
    
        public virtual ObjectResult<string> maksmarka()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("maksmarka");
        }
    
        public virtual ObjectResult<string> maksil()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("maksil");
        }
    
        public virtual ObjectResult<string> maksdepartman()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("maksdepartman");
        }
    
        public virtual ObjectResult<string> mindepartman()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("mindepartman");
        }
    }
}
