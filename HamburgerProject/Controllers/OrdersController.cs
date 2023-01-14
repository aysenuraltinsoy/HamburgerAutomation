using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HamburgerProject.Models.Context;
using HamburgerProject.Models.Entities;
using HamburgerProject.Models.ViewModel;

namespace HamburgerProject.Controllers
{
    public class OrdersController : Controller
    {
        private readonly HamburgerDbContext _context;

        public OrdersController(HamburgerDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            OrderVM orderVM=new OrderVM();
            orderVM.MenuList= await _context.Menus.ToListAsync();
            orderVM.ExtraList=await _context.Extras.ToListAsync();
            orderVM.OrderList = await _context.Orders.ToListAsync();
            
            return  View(orderVM);
        }


        [HttpPost]
        public async Task<IActionResult> GiveOrder(Order order,Menu menu,Extra extra)
        {
            Menu selectedMenu = await _context.Menus.FirstOrDefaultAsync(x => x.MenuName == menu.MenuName);
            order.Menu = selectedMenu;
            Extra selectedExtra = await _context.Extras.FirstOrDefaultAsync(x => x.Name == extra.Name);
            order.Extra = selectedExtra;
            order.TotalPrice = selectedMenu.Price + selectedExtra.Price;
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> ExtraMaterialMenu()
        {
            OrderVM orderVM = new OrderVM();
            orderVM.MenuList = await _context.Menus.ToListAsync();
            orderVM.ExtraList = await _context.Extras.ToListAsync();
            return View(orderVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddExtra(Extra extra)
        {
            await _context.Extras.AddAsync(extra);
            return View(extra);
        }

    }
}
