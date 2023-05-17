using BooksAPI.Entitites;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Intrinsics;

namespace BooksAPI
{
    public class AppDBContext:DbContext
    {
        public AppDBContext([NotNullAttribute] DbContextOptions options ): base( options )
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Many to Many intersection
            modelBuilder.Entity<BookGeners>()
                .HasKey(t => new { t.bookID, t.generID });

            modelBuilder.Entity<Book>()
                .HasOne(t => t.author)
                .WithMany(a => a.authorBooks)
                .HasForeignKey(t => t.authorID);

            modelBuilder.Entity<Book>()
                .HasOne(t => t.editorial)
                .WithMany(a => a.books)
                .HasForeignKey( t => t.editorialID);

            modelBuilder.Entity<Book>()
                .HasOne(t => t.saga)
                .WithMany(a => a.books)
                .HasForeignKey(t => t.sagaID);

        }




        public DbSet<Gener> gener { get; set; }
        public DbSet<Book> book { get;set; }
        //public DbSet<HomeBook> HomeBook { get; set; }
        public DbSet<BookGeners> bookgener { get; set; }
        public DbSet<Author> author { get; set; }   
        public DbSet<Saga> saga { get; set; }
        public DbSet<Editorial> editorial { get; set; }
    }
}
