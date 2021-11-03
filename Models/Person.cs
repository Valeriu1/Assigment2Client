using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models {
public class Person {
    
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "First name is required."), MaxLength(128)]

    public string FirstName { get; set; }
    [Required(ErrorMessage = "Last name is required."), MaxLength(128)]

    
    public string LastName { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    
    
    [Range(1, 150, ErrorMessage = "Please enter a real age")]
    public int Age { get; set; }
    [Range(1, 800, ErrorMessage = "Please enter a real weight")]
    public float Weight { get; set; }
    [Range(1, 300, ErrorMessage = "Please enter a real height")]
    public int Height { get; set; }
    [Required]
    public string Sex { get; set; }
}


}