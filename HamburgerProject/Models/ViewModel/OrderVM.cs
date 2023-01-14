using HamburgerProject.Models.Entities;

namespace HamburgerProject.Models.ViewModel
{
    public class OrderVM
    {
        public List<Menu> MenuList { get; set; }
        public List<Order> OrderList { get; set; }
        public Extra Extra { get; set; }
        public Menu Menu { get; set; }  
        public Order Order { get; set; }
        public List<Extra> ExtraList { get; set; }
        public OrderVM()
        {
            MenuList= new List<Menu>();
            ExtraList= new List<Extra>();
            OrderList=new List<Order>();
        }
    }
}
