using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyWebAPI.Models
{
    public class Associate
    {
        [Key]
        public int IdAssociate { get; set; }
        [Required]
        [MaxLength(150)]
        public string FnameAssociate { get; set; }

        [MaxLength(50)]
        public string MnameAssociate { get; set; }

        [MaxLength(100)]
        public string LnameAssociate { get; set; }

        [MaxLength(100)]

        [DataType(DataType.Date)]
        public DateTime? DOBAssociate { get; set; }

        [MaxLength(14)]
        public string? PhoneAssociate { get; set; }

        [Required]
        [Phone]
        [MaxLength(14)]
        public string? CelAssociate { get; set; }

        [MaxLength(100)]
        public string? EmailAssociate { get; set; }

        public bool? OwnerStatus { get; set; }
        public bool? IsAssociateUseRegister { get; set; }

        public bool? IdRegisterAssociate { get; set; }

        [MaxLength(150)]
        public string? StreetAssociate { get; set; }

        [MaxLength(75)]
        public string? CountyAssociate { get; set; }

        [MaxLength(10)]
        public string? ZipCodeAssociate { get; set; }

        [MaxLength(2)]
        public string? StateAssociate { get; set; }

        public bool? DisplayAccontHeaderA { get; set; }

        public int IdUser { get; set; }
    }
}
