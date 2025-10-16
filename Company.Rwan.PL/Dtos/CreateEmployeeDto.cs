using System.ComponentModel.DataAnnotations;

namespace Company.Rwan.PL.Dtos
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage ="Name is Required !!")]
        public string Name { get; set; }

        [Range(22, 60,ErrorMessage ="Age must be between 22 and 60")]
        public int? Age { get; set; }
        [DataType(DataType.EmailAddress,ErrorMessage ="Email is not valid!!")]
        public string Email { get; set; }
        [RegularExpression(@"^[A-Za-z0-9\s,.-]+$", ErrorMessage = "Address can only contain letters, numbers, spaces, commas, periods, or hyphens")]
        public string Address { get; set; }
        [Phone]
        public string Phone { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        [System.ComponentModel.DisplayName("Hiring Date")]
        public DateTime HiringDate { get; set; }
        [System.ComponentModel.DisplayName("Created At")]
        public DateTime CreateAt { get; set; }
    }
}
