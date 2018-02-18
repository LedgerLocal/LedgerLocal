using Microsoft.EntityFrameworkCore;

namespace Common.Data.Infrastructure
{
    public interface IDatabaseFactory<T>
        where T : DbContext
    {
        T Get();

        void Refresh();
    }
}
