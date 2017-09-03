using System;
using Microsoft.EntityFrameworkCore;
using VideoMenuAppDAL.Entities;

namespace VideoMenuAppDAL.Context
{
    public class InMemoryContext : DbContext
    {
        static DbContextOptions<InMemoryContext> options =
            new DbContextOptionsBuilder<InMemoryContext>().UseInMemoryDatabase("TheDB").Options;


        //Options that we want in memory
        public InMemoryContext() : base(options)
        {
            
        }

        public DbSet<Video> Videos { get; set; }
    }
}
