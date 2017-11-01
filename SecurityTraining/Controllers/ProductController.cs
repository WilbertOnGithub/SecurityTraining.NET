using System.Threading.Tasks;
using System.Web.Mvc;
using SecurityTraining.Models;

namespace SecurityTraining.Controllers
{
    public class ProductController : Controller
    {
        [Authorize(Roles = "Sales,Contact")]
        public ActionResult AddProduct()
        {
            return View();
        }

        [Authorize(Roles = "Sales,Contact")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddProduct(AddProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ApplicationDbContext context = new ApplicationDbContext();

            context.Products.Add(new Product {Order = model.Order, Name = model.Name});

            await context.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}