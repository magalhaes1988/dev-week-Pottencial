using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dev_week_Pottencial.src.Models;

namespace dev_week_Pottencial.src.Persistence
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
            
        }
        
        private DbSet<Person> _pessoas;
        private DbSet<Contracts> _contracts;
        public DbSet<Person> Pessoas
        {
            get { return _pessoas; }
            set { _pessoas = value; }
        }

        public DbSet<Contracts> Contracts
        {
            get { return _contracts; }
            set { _contracts = value; }
        }

        //Aqui fazemos as configuracoes do Modelo para o BD
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(
                e=> {
                    e.HasKey(v => v.Id);
                    e.HasMany(v => v.Contratos).WithOne().HasForeignKey(c =>  c.IdPessoa);
                }
            );

            modelBuilder.Entity<Contracts>(
                e => {
                    e.HasKey(v => v.Id);
                }
            );
        }       

    }
}