using DbFirstProj.Services.BusinessLogic.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DbFirstProj.ViewModels
{
    public class RelationPostViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        [Number]
        [MinLength(10), MaxLength(10)]
        public string TelephoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string EMailAddress { get; set; }
        [Required]
        public string CountryId { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        [Number]
        public int Number { get; set; }
    }
}
