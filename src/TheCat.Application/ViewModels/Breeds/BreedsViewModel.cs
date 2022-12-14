using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TheCat.Application.ViewModels.Breeds;
using TheCat.Domain.Entities;

namespace TheCat.Application.ViewModels.AnuncioTheCat
{
    public class BreedsViewModel:BaseViewModels
    {

        [Key]
        public string id { get; set; }

        [Required(ErrorMessage = "name is required.")]
        [MinLength(3)]
        [MaxLength(50)]
        [DisplayName("name")]
        public string name { get; set; }

        [Required(ErrorMessage = "temperament is required.")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("temperament")]
        public string temperament { get; set; }

        [Required(ErrorMessage = "origin is required.")]
        [MinLength(3)]
        [MaxLength(50)]
        [DisplayName("origin")]
        public string origin { get; set; }

        [Required(ErrorMessage = "description is required.")]
        [MinLength(3)]
        [MaxLength(500)]
        [DisplayName("description")]
        public string description { get; set; }

        public ICollection<BreedsImagesViewModel> BreedsImages { get; set; }

    }
}
