using System;

namespace HttpServices.Models.Responses
{
    public class ResidentResponse
    {
        public string MosaicId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public AddressResponse Address { get; set; }
        public string ActivePackage { get; set; }
        public Guid? ActivePackageId { get; set; }
    }
}
