﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------


namespace isima.DAL
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class IsimaEntities : DbContext
{
    public IsimaEntities()
        : base("name=IsimaEntities")
    {
<<<<<<< HEAD

=======
        public IsimaEntities()
            : base("name=IsimaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Map> Map { get; set; }
>>>>>>> 18f1f07a708427d89c7bb54d590e9c2057e653aa
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Map> Map { get; set; }

}

}

