namespace LiveClinic.SharedKernel.Interfaces.Persistence
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get;  }
        string DatabaseName { get;  }
    }
}
