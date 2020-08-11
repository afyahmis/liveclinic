namespace LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts.Domain
{
    public class TestCarModelViewModel
    {
        public string Name { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"{Name} {Year}";
        }
    }
}
