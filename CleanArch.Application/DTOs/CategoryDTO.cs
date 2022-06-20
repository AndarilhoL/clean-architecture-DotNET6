using System.ComponentModel.DataAnnotations;

namespace CleanArch.Application.DTOs
{
    public  class CategoryDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage ="The name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
