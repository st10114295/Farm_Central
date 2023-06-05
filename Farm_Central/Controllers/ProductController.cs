using Farm_Central.DataAccessLayer;
using Farm_Central.Models;
using Farm_Central.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;

namespace Farm_Central.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            List<ProductViewModel> productList = new List<ProductViewModel>();
            if (products != null)
            {
                foreach (var product in products)
                {
                    var ProductViewModel = new ProductViewModel()
                    {
                        ProductId = product.ProductId,
                        FarmerName = product.FarmerName,
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        ProductPrice = product.ProductPrice,
                        DateManufactured = product.DateManufactured,
                    };
                    productList.Add(ProductViewModel);
                }

                return View(productList);
            }
            return View(productList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = new Product()
                    {
                        FarmerName = productData.FarmerName,
                        ProductName = productData.ProductName,
                        ProductDescription = productData.ProductDescription,
                        ProductPrice = productData.ProductPrice,
                        DateManufactured = productData.DateManufactured

                    };
                    _context.Products.Add(product);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Product Added Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Data Is Not Valid!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit(int ProductId)
        {
            try
            {
                var product = _context.Products.SingleOrDefault(x => x.ProductId == ProductId);

                if (product != null)
                {
                    var productView = new ProductViewModel()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        ProductPrice = product.ProductPrice,
                        DateManufactured = product.DateManufactured

                    };


                    return View(productView);
                }
                else
                {
                    TempData["errorMessage"] = $"There Are No Details Available With The Id: {ProductId}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Edit(ProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var product = new Product()
                    {
                        ProductId = model.ProductId,
                        ProductName = model.ProductName,
                        ProductDescription = model.ProductDescription,
                        ProductPrice = model.ProductPrice,
                        DateManufactured = model.DateManufactured,
                        FarmerName = model.FarmerName

                    };
                    _context.Products.Update(product);
                    _context.SaveChanges();
                    TempData["successMessage"] = " Details Updated Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = "Data Is Invalid!";
                    return View();
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }

        [HttpGet]
        public IActionResult Delete(int ProductId)
        {
            try
            {
                var product = _context.Products.SingleOrDefault(x => x.ProductId == ProductId);

                if (product != null)
                {
                    var productView = new ProductViewModel()
                    {
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        ProductDescription = product.ProductDescription,
                        ProductPrice = product.ProductPrice,
                        DateManufactured = product.DateManufactured

                    };


                    return View(productView);
                }
                else
                {
                    TempData["errorMessage"] = $"There Are No Details Available With The Id: {ProductId}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Delete(ProductViewModel model)
        {
            
            {
                try
                {
                    var product = _context.Products.SingleOrDefault(x => x.ProductId == model.ProductId);

                    if (product != null)
                    {
                        _context.Products.Remove(product);
                        _context.SaveChanges();
                        TempData["successMessage"] = "Product Details Deleted Successfully!";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["errorMessage"] = $"There Are No Details Available With The Id: {model.ProductId}";
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {

                    TempData["errorMessage"] = ex.Message;
                    return View(model);
                }
            }
        }
        }
    }


