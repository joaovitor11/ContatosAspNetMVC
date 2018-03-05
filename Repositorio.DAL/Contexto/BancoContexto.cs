using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Repositorio.Entidades;

namespace Repositorio.DAL
{
    public class BancoContexto : DbContext
    {
        public BancoContexto() : base("ConnDB") { }
        public DbSet<Contato> Contato { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

    }
}
