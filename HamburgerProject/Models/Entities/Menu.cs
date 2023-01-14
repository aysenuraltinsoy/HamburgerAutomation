using HamburgerProject.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HamburgerProject.Models.Entities
{
    public class Menu
    {
        [Key]
        public int ID { get; set; }
        public string MenuName { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("Order")]
        public int? OrderID { get; set; }
        public virtual Order Order { get; set; }
        public override string ToString()
        {
            return MenuName;
        }
    }
}
