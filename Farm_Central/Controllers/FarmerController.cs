using Farm_Central.DataAccessLayer;
using Farm_Central.Models;
using Farm_Central.Models.DBEntities;
using Microsoft.AspNetCore.Mvc;

namespace Farm_Central.Controllers
{
    public class FarmerController : Controller
    {
        private readonly FarmerDbContext _context;

        public FarmerController(FarmerDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var farmers = _context.Farmers.ToList();
            List<FarmerViewModel> farmerList = new List<FarmerViewModel>();

            if (farmers != null)
            {
                foreach (var farmer in farmers)
                {
                    var FarmerViewModel = new FarmerViewModel()
                    {
                        Id = farmer.Id,
                        FullName = farmer.FullName,
                        City = farmer.City,
                        ContactNum = farmer.ContactNum,
                    };
                    farmerList.Add(FarmerViewModel);
                }

                return View(farmerList);
            }
            return View(farmerList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FarmerViewModel farmerData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var farmer = new Farmer()
                    {
                        FullName = farmerData.FullName,
                        City = farmerData.City,
                        ContactNum = farmerData.ContactNum
                    };
                    _context.Farmers.Add(farmer);
                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Farmer Added Successfully!";
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
        public IActionResult Edit(int Id)
        {
            try
            {
                var farmer = _context.Farmers.SingleOrDefault(x => x.Id == Id);

                if (farmer != null)
                {
                    var farmerView = new FarmerViewModel()
                    {
                        Id = farmer.Id,
                        FullName = farmer.FullName,
                        City = farmer.City,
                        ContactNum = farmer.ContactNum
                    };


                    return View(farmerView);
                }
                else
                {
                    TempData["errorMessage"] = $"There Are No Details Available With The Id: {Id}";
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
        public IActionResult Edit(FarmerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var farmer = new Farmer()
                    {
                        Id = model.Id,
                        FullName = model.FullName,
                        City = model.City,
                        ContactNum = model.ContactNum
                    };
                    _context.Farmers.Update(farmer);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Farmer Details Updated Successfully!";
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
        public IActionResult Delete(int Id)
        {
            try
            {
                var farmer = _context.Farmers.SingleOrDefault(x => x.Id == Id);

                if (farmer != null)
                {
                    var farmerView = new FarmerViewModel()
                    {
                        Id = farmer.Id,
                        FullName = farmer.FullName,
                        City = farmer.City,
                        ContactNum = farmer.ContactNum
                    };


                    return View(farmerView);
                }
                else
                {
                    TempData["errorMessage"] = $"There Are No Details Available With The Id: {Id}";
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
        public IActionResult Delete(FarmerViewModel model)
        {
            try
            {
                var farmer = _context.Farmers.SingleOrDefault(x => x.Id == model.Id);

                if (farmer != null)
                {
                    _context.Farmers.Remove(farmer);
                    _context.SaveChanges();
                    TempData["successMessage"] = "Farmer Details Deleted Successfully!";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = $"There Are No Details Available With The Id: {model.Id}";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
   
  