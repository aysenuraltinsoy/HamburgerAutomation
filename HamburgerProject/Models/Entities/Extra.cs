using HamburgerProject.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HamburgerProject.Models.Entities
{
    public class Extra
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; } 
        public decimal Price { get; set; } 

        public virtual List<Order> Orders { get; set; }
        public override string ToString()
        {
            return Name;
        }

        //public Status Status { get; set; }
    }
}
