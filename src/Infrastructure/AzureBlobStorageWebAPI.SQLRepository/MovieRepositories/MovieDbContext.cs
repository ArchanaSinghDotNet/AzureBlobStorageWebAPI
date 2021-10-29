using Microsoft.EntityFrameworkCore;
using AzureBlobStorageWebAPI.Domain.MovieDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureBlobStorageWebAPI.SQLRepository.MovieRepositories
{
    public class MovieDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Server Name=DESKTOP-4D07MO6\SQLEXPRESS01;Database=AzureBlobStorageWebAPIDB;Integrated Security=True;Connect Timeout=30";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
