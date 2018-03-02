using System;
using System.Collections.Generic;
using System.Text;
using BuilderForm.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuilderForm.Repository
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
