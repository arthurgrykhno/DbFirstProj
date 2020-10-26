using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbFirstProj.ViewModels
{
    public class RelationPostViewModel
    {
        public string Name { get; set; }

        public string FullName { get; set; }

        public string TelephoneNumber { get; set; }

        public string EMailAddress { get; set; }

        public string CountryId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostalCode { get; set; }

        public int? Number { get; set; }
    }
}
