using System.ComponentModel.DataAnnotations;

namespace Company.Rwan.PL.Dtos
{
    public class CreateDepartmentDto
    {
        [Required(ErrorMessage ="Cod is Required !")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Name is Required !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "CreateAt is Required !")]
        public DateTime CreateAt { get; set; }
    }
}
