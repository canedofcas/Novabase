using Novabase.Domain.Entities;
using Novabase.Domain.Queries;
using Novabase.Domain.Repositories;
using System;
using System.Collections.Generic;

namespace Novabase.Domain.Tests.Repositories
{
    public class FakeCountryCodeRepository : ICountryCodeRepository
    {
        public CountryCode GetAllByName(string name)
        {
            return new CountryCode()
            {
                Id = 1,
                Name = "Brazil",
                IsoAlpha2 = "BR",
                IsoAlpha3 = "",
                NumericCode = 25,
                Cctld = ".br"
            };
        }
    }
}
