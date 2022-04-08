using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationOrders.Data;
using WebApplicationOrders.Models;

namespace WebApplicationOrders.Controllers
{
    public class OrderController : Controller
    {
        private PagesProductsContext _context;

        public OrderController(PagesProductsContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Create()
        {
            OrderVM model = new OrderVM
            {
                ProductItems = _context.Product.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList(),
                Order = new Order()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Order.Include(o => o.ItemOrdered).ToListAsync());
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                string[] fruitIds = Request.Form["Order.ItemOrdered"].ToString().Split(",");
                foreach (string fruitId in fruitIds)
                {
                    var product = _context.Product.Find(Convert.ToInt32(fruitId));
                    order.ItemOrdered.Add(product);
                }

                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }


        public IActionResult Edit(int id)
        {
            if (id == 0 || id < 0)
            {
                return NotFound();
            }

            OrderVM model = new OrderVM
            {
                ProductItems = _context.Product.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }).ToList(),
                Order = _context.Order.Find(id)

            };
            return View(model);
        }







        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , Order order)
        {
            if (ModelState.IsValid)
            {
                string[] fruitIds = Request.Form["Order.ItemOrdered"].ToString().Split(",");
                var products = _context.Order.Include(x => x.ItemOrdered).FirstOrDefault(x => x.Id == id );
                products.ItemOrdered.Clear();

                foreach (string fruitId in fruitIds)
                {
                    var product = _context.Product.Find(Convert.ToInt32(fruitId)); 
                    products.ItemOrdered.Add(product);
                }

                _context.Update(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);

        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.Include(x => x.ItemOrdered).FirstOrDefaultAsync(x => x.Id == id);
                
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            _context.Order.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovieExists(int id)
        {
            return _context.Order.Any(e => e.Id == id);
        }
    }



}
