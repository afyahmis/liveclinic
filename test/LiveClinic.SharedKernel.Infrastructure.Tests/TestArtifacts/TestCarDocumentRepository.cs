using LiveClinic.SharedKernel.Infrastructure.Persistence;
using LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts.Domain;
using LiveClinic.SharedKernel.Interfaces.Persistence;

namespace LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts
{
    public class TestCarDocumentRepository : DocumentRepository<TestCar>, ITestCarDocumentRepository
    {
        public TestCarDocumentRepository(IDatabaseSettings settings) : base(settings)
        {
        }

        public string DocName()
        {
            throw new System.NotImplementedException();
        }
    }
}
