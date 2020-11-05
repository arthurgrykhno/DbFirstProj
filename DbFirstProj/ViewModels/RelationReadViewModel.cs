using System;

namespace DbFirstProj.ViewModels
{
    public class RelationReadViewModel
    {
        public Guid RelationId { get; set; }

        public Guid RelationAddressId { get; set; }

        public Guid CountryId { get; set; }

        public bool IsDisabled { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string TelephoneNumber { get; set; }

        public string EMailAddress { get; set; }

        public string CountryName { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public int? Number { get; set; }
    }
}
