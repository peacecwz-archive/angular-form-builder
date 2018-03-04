using System;
using System.Collections.Generic;
using System.Text;
using FormBuilder.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Repository
{
    public class FormBuilderDbContext : DbContext
    {
        public FormBuilderDbContext(DbContextOptions<FormBuilderDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<FormAnswer> FormAnswers { get; set; }

    }
}
