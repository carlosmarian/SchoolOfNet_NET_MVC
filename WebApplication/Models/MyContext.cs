using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class MyContext : DbContext
    {
        //Ao subir a aplicação ele irá mapear com a estrutura de banco.
        public DbSet<Pessoa> Pessoa { get; set; }
        // public DbSet<OutrasClasses> OutrasClasses { get; set; }

    }
}