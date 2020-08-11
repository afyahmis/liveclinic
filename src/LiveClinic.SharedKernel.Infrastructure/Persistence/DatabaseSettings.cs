using LiveClinic.SharedKernel.Interfaces.Persistence;

namespace LiveClinic.SharedKernel.Infrastructure.Persistence
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get;  }
        public string DatabaseName { get;  }

        public DatabaseSettings(string connectionString, string databaseName)
        {
            ConnectionString = connectionString;
            DatabaseName = databaseName;
        }
    }
}
