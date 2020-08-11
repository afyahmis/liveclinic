using LiveClinic.SharedKernel.Interfaces.Persistence;

namespace LiveClinic.SharedKernel.Infrastructure.Persistence
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
