using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Personel
    {
        [Key]
        public int Id_Person { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }

    }
}