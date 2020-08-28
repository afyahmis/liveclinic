using System;
using System.Collections.Generic;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.EncounterManager.Core.Domain.Common
{
    public class Period : ValueObject<Period>
    {
        public DateTime StartDate { get;  }
        public DateTime? EndDate { get;  }

        public Period(DateTime startDate)
        {
            StartDate = startDate;
        }

        public Period(DateTime startDate, DateTime endDate):this(startDate)
        {
            EndDate = endDate;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StartDate;
            yield return EndDate;
        }
    }
}
