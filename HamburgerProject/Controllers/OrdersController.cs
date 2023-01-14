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
using HamburgerProject.Models.Enum;

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
           
            if (selectedExtra==null)
            {
                extra.Name = " ";
                extra.Price = 0;
                order.Extra = extra;
                order.TotalPrice = selectedMenu.Price;
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else if (selectedMenu==null && selectedExtra==null)
            {
                return View();
            }
            else
            {
                order.Extra = selectedExtra;
                order.TotalPrice = selectedMenu.Price + selectedExtra.Price;
                _context.Orders.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }
            
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
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ExtraMaterialMenu));
        }

        public async Task<IActionResult> UpdateExtra(int id)
        {
            return View(await _context.Extras.FindAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> UpdateExtra(Extra extra)
        {
            _context.Extras.Update(extra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ExtraMaterialMenu));
        }
        public async Task<IActionResult> DeleteExtra(Extra extra)
        {
            _context.Extras.Remove(extra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ExtraMaterialMenu));
        }
        [HttpPost]
        public async Task<IActionResult> AddMenu(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ExtraMaterialMenu));  
        }

        public async Task<IActionResult> UpdateMenu(int id)
        {
            return View(await _context.Menus.FindAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMenu(Menu menu)
        {
            _context.Menus.Update(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ExtraMaterialMenu));
        }

        public async Task<IActionResult> DeleteMenu(Menu menu)
        {
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ExtraMaterialMenu));
        }

        public async Task<IActionResult> ListOrders()
        {
            OrdersVM ordersVM = new OrdersVM();
            ordersVM.MenuList = await _context.Menus.ToListAsync();
            ordersVM.ExtraList = await _context.Extras.ToListAsync();
            ordersVM.OrderList = await _context.Orders.ToListAsync();
            var orderList=await _context.Orders.Include(x=>x.Extra).ToListAsync();
            ordersVM.CountOfOrder = orderList.Count;
            ordersVM.CountOfExtra = orderList.Where(x => x.Extra.Price != 0).Count();
            ordersVM.SumOfTotalPrice=orderList.Sum(x=>x.TotalPrice);
                     
            return View(ordersVM);
        }
    }
}
