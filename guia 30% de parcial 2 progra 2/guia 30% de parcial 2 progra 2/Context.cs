using guia_30__de_parcial_2_progra_2;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ContextDB : DbContext
{
    public DbSet<Student> Estudiantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-4VS4OUL\\SQLEXPRESS;Database=PROGRA2;Trusted_Connection=True;");

    }
}