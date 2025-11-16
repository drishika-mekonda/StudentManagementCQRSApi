using Microsoft.EntityFrameworkCore;
using StudentManagementCQRSApi.Models;

namespace StudentManagementCQRSApi.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }
        public DbSet<Student> Students => Set<Student>();
    }
}
