using HamburgerProject.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace HamburgerProject.Models.Entities
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public decimal TotalPrice { get; set; }
        public Enum.Size Size { get; set; }
        public virtual Menu Menu{ get; set; }
        public virtual Extra? Extra { get; set; }

        //public Status Status { get; set; }
    }
}
