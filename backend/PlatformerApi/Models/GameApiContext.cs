using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformerApi.Models
{
    public class GameApiContext : DbContext
    {
        

        public GameApiContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<GameStats> GameStatsItems { get; set; }

    }
}
