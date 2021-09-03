using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Tests.V1.DataGenerators;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.Tests
{
    public class DataGenerator
    {
        private readonly DatabaseContext _context;

        public DataGenerator(DatabaseContext context)
        {
            _context = context;

            NursingCare = new NursingCareGenerator(_context);
        }

        public NursingCareGenerator NursingCare { get; }
    }
}
