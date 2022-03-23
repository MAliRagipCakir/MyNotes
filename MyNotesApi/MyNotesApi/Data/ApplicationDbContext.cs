using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNotesApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Note>().HasData(
                            new Note() { Id = 1, Title = "Sample Note 1", Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer ut sapien id purus sagittis pellentesque. Donec egestas quam ut lorem semper, nec varius tortor congue. Nam est mauris, dictum non nunc at, tempus tristique odio. Pellentesque iaculis tortor sem, in elementum magna eleifend ut." },
                            new Note() { Id = 2, Title = "Sample Note 2", Content = "Etiam eu ligula fringilla mi placerat convallis. Aliquam tempus, mauris id tempus commodo, quam justo gravida nibh, scelerisque condimentum metus velit et felis. Morbi mi ipsum, maximus blandit condimentum ut, consectetur vitae ante. Ut viverra mollis metus, sollicitudin gravida felis imperdiet sed." }
                            );
        }

    }
}
