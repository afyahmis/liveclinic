namespace LiveClinic.SharedKernel.Interfaces.Persistence
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
