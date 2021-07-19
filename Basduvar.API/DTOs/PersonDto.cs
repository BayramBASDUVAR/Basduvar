using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Basduvar.API.DTOs
{
    public class PersonDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir")]
        public string Name { get; set; }
        public string SurName { get; set; }
        public DateTime DogumTarihi { get; set; }
    }
}
