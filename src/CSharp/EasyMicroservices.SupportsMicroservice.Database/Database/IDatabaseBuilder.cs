using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.SupportsMicroservice.Database
{
    public interface IDatabaseBuilder
    {
        void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
    }
}
