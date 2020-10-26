using System;

namespace DbFirstProj.ViewModels
{
    public class CountryReadViewModel
    {
        public Guid CountryId { get; set; }

        public string CountryName { get; set; }

        public string PostalCodeFormat { get; set; }
    }
}
