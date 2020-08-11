﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using LiveClinic.SharedKernel.Model;

namespace LiveClinic.SharedKernel.Infrastructure.Tests.TestArtifacts.Domain
{
    [Table(nameof(TestCarModel))]
    public class TestCarModel : Entity<Guid>
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public TestTrim Trim { get; set; } = new TestTrim();
        public string TestCarId { get; set; }

        public TestCarModel()
        {
            Id=Guid.NewGuid();
        }

        public TestCarModel(string name, int year, TestTrim trim, string testCarId)
        {
            Name = name;
            Year = year;
            Trim = trim;
            TestCarId = testCarId;
        }


        public override string ToString()
        {
            return $"{Name} {Year} ({Trim})";
        }

        public void ChangeTrim(string transmission, string fuelType)
        {
            Trim.Transmission = transmission;
            Trim.FuelType = fuelType;
        }
    }
}
