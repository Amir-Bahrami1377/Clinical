using Clinical.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinical.Infra.Data.Context;
public class ClinicalContext:DbContext
{
    #region Constructor
    public ClinicalContext(DbContextOptions<ClinicalContext> options) : base(options)
    {

    }
    #endregion

    #region User
    public DbSet<User> Users { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasQueryFilter(c => !c.IsDeleted);
        base.OnModelCreating(modelBuilder);
    }
}
