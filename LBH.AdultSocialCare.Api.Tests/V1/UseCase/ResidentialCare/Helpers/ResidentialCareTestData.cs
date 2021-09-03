using Bogus;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCare;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LBH.AdultSocialCare.Api.Tests.V1.UseCase.ResidentialCare.Helpers
{
    public class ResidentialCareTestData
    {
        private List<ResidentialCarePackage> _residentialCarePackages;
        private List<User> _users;
        private List<Client> _clients;

        private readonly Faker<Client> _clientFaker;
        private readonly Faker<ResidentialCarePackage> _residentialCarePackageFaker;

        private static DateTime _startDate = DateTime.ParseExact("20100101", "yyyyMMdd", CultureInfo.InvariantCulture);
        private static DateTime _endDate = DateTime.UtcNow;

        private enum Visibility
        {
            Good,
            Bad,
            Trial
        }

        public ResidentialCareTestData()
        {
            _users = new List<User>()
            {
                new User
                {
                    AccessFailedCount = 0,
                    ConcurrencyStamp = "1",
                    Email = "testuser@gmail.com",
                    EmailConfirmed = true,
                    Id = new Guid("115e5c77-5943-4a39-bafb-32f45f33a9bf"),
                    LockoutEnabled = false,
                    LockoutEnd = null,
                    NormalizedEmail = "TESTUSER@GMAIL.COM",
                    NormalizedUserName = "TESTUSER@GMAIL.COM",
                    PasswordHash = "abcdefgh",
                    PhoneNumber = "555 7755 7755",
                    PhoneNumberConfirmed = true,
                    SecurityStamp = null,
                    TwoFactorEnabled = false,
                    UserName = "testUser@gmail.com",
                    Name = "Test User"
                }
            };

            _clients = new List<Client>()
            {
                new Client
                {
                    DateCreated = DateTimeOffset.Now,
                    CreatorId = new Guid("115e5c77-5943-4a39-bafb-32f45f33a9bf"),
                    Id = new Guid("66a15dcd-37a4-457c-b1e1-3a0ea67cdd56"),
                    HackneyId = 100000,
                    FirstName = Faker.Name.First(),
                    MiddleName = Faker.Name.Middle(),
                    LastName = Faker.Name.Last(),
                    DateOfBirth = DateTime.Now.AddYears(-30),
                    PreferredContact = Faker.Phone.Number(),
                    CanSpeakEnglish = Faker.Enum.Random<Visibility>().ToString(),
                    AddressLine1 = Faker.Address.StreetName(),
                    AddressLine2 = string.Join(" ", Faker.Address.StreetAddress(), Faker.Address.UkPostCode()),
                    AddressLine3 =
                        string.Join(" ", Faker.Address.City(), Faker.Address.UsState(),
                            Faker.Address.ZipCode()),
                    Town = Faker.Address.City(),
                    County = Faker.Address.UkCounty(),
                    PostCode = Faker.Address.UkPostCode(),
                    PrimarySupportReasonId = null
                }
            };

            // _clients.AddRange(_clientFaker.Generate(5));

            _residentialCarePackages = new List<ResidentialCarePackage>()
            {
                new ResidentialCarePackage
                {
                    DateCreated = DateTimeOffset.Now,
                    CreatorId = new Guid("115e5c77-5943-4a39-bafb-32f45f33a9bf"),
                    UpdaterId = null,
                    Id = new Guid("e5109a28-31fb-4e59-b433-0f2745f96a16"),
                    ClientId = new Guid("e5109a28-31fb-4e59-b433-0f2745f96a16"),
                    Client = null,
                    IsFixedPeriod = true,
                    StartDate = DateTimeOffset.Now.AddDays(-100),
                    EndDate = DateTimeOffset.Now.AddDays(100),
                    HasRespiteCare = true,
                    HasDischargePackage = true,
                    IsThisAnImmediateService = true,
                    IsThisUserUnderS117 = false,
                    TypeOfStayId = 1,
                    NeedToAddress = string.Join(" ", Faker.Lorem.Sentences(3)),
                    TypeOfResidentialCareHomeId = 1,
                    StatusId = 1,
                    Status = null,
                    StageId = null,
                    Stage = null,
                    SupplierId = null,
                    AssignedUserId = null,
                    PaidUpTo = DateTimeOffset.Now.AddDays(-50),
                    PreviousPaidUpTo = null,
                    Supplier = null,
                    TypeOfCareHome = null,
                    TypeOfStayOption = null,
                    ResidentialCareAdditionalNeeds = null,
                    PackageReclaims = null,
                    ResidentialCareApprovalHistories = null,
                    ResidentialCareBrokerageInfo = null
                }
            };

            _clientFaker = new Faker<Client>()
                    .StrictMode(false)
                    .RuleFor(p => p.FirstName, f => f.Name.FirstName(f.Person.Gender))
                    .RuleFor(p => p.MiddleName, f => f.Name.FirstName(f.Person.Gender))
                    .RuleFor(p => p.LastName, f => f.Name.LastName(f.Person.Gender))
                    .RuleFor(p => p.DateCreated, f => DateTimeOffset.UtcNow)
                ;
            _residentialCarePackageFaker = new Faker<ResidentialCarePackage>()
                    .StrictMode(false)
                    .RuleFor(s => s.StartDate, f => f.Date.Between(_startDate, _endDate.AddYears(-2)))
                    .RuleFor(s => s.StartDate, f => f.Date.Between(_endDate.AddYears(-2), _endDate))
                    .RuleFor(s => s.ClientId, f => f.PickRandom(_clients).Id)
                    .RuleFor(s => s.CreatorId, f => f.PickRandom(_users).Id)
                ;
        }

        public List<ResidentialCarePackage> GetAllResidentialCarePackages()
        {
            _residentialCarePackages.AddRange(_residentialCarePackageFaker.Generate(_clients.Count - 1));

            for (var i = 0; i < _residentialCarePackages.Count; i++)
            {
                _residentialCarePackages[i].ClientId = _clients[i].Id;
            }

            return _residentialCarePackages;
        }

        public ResidentialCarePackage GetSingleResidentialCarePackage(Guid residentialCarePackageId)
        {
            var res = _residentialCarePackages.SingleOrDefault(p => p.Id.Equals(residentialCarePackageId));
            return res;
        }

        public List<Client> GetAllClients()
        {
            return _clients;
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public Faker<ResidentialCarePackage> GetResidentialCarePackageFaker()
        {
            return _residentialCarePackageFaker;
        }

        public Faker<Client> GetClientFaker()
        {
            return _clientFaker;
        }
    }
}
