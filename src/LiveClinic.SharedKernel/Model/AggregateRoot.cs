using System;

namespace LiveClinic.SharedKernel.Model
{
    public abstract class AggregateRoot : Entity<string>
    {
        protected AggregateRoot()
        {
            Id = Guid.NewGuid().ToString().ToLower();
        }
    }
}
