using Microsoft.AspNetCore.Mvc;
using collegemainatanceportal.Data;
using collegemainatanceportal.Models;
using System.Linq;

namespace collegemainatanceportal.Controllers
{
    public class ComplaintController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComplaintController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1️⃣ LIST ALL COMPLAINTS
        public IActionResult Index()
        {
            var complaints = _context.Complaints.ToList();
            return View(complaints);
        
        var role = HttpContext.Session.GetString("Role");

            if (role == "Admin")
            {
                // Admin ku only fully approved complaints
                var data = _context.Complaints
                    .Where(c => c.StaffStatus == "Approved" )
                    .ToList();

                return View(data);
            }

            return View(_context.Complaints.ToList());
        }
        public IActionResult StaffPage()
        {
            var data = _context.Complaints.ToList();
            return View(data);
        }
      
        // 2️⃣ SHOW CREATE FORM
        public IActionResult Create()
        {
           if (HttpContext.Session.GetString("Role") != "Student")
                {
                    return RedirectToAction("Index", "Complaint");
                }

                return View();
        }
       
        

        public IActionResult Category(string category)
        {
            var complaints = _context.Complaints
                            .Where(c => c.Category == category)
                            .ToList();

            return View(complaints);
        }
        // 3️⃣ SAVE NEW COMPLAINT
        [HttpPost]
        public async Task<IActionResult> Create(Complaint complaint, IFormFile imageFile)
        {
            if (HttpContext.Session.GetString("Role") != "Student")
            {
                return RedirectToAction("Index", "Complaint");
            }
            {
                if (imageFile != null)
                {
                    string folder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                    string path = Path.Combine(folder, fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    complaint.ImagePath = "/images/" + fileName;
                }

                complaint.Status = "Pending";
                _context.Complaints.Add(complaint);
                _context.SaveChanges();
                return RedirectToAction("Index");
           }
        }
        [HttpPost]
        public IActionResult StaffApprove(int id, string status)
        {
            var complaint = _context.Complaints.Find(id);

            if (complaint != null)
            {
                complaint.StaffStatus = status;
                _context.SaveChanges();

            }

            return RedirectToAction("StaffPage");
        }
        [HttpPost]
      





        // 4️⃣ SHOW EDIT PAGE
        public IActionResult Edit(int id)
        {
            if
                (HttpContext.Session.GetString("Role") != "Admin")
            {
                return RedirectToAction("Index");
            }
            var complaint = _context.Complaints.Find(id);
            return View(complaint);
        }

        [HttpPost]
        public IActionResult Edit(Complaint complaint)
        {
                if (HttpContext.Session.GetString("Role") != "Admin")
                {
                    return RedirectToAction("Index");
                }
                var data = _context.Complaints.Find(complaint.Id);

            if (data != null)
            {
                data.Status = complaint.Status;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
               
        // 6️⃣ DELETE CONFIRM PAGE
        public IActionResult Delete(int id)
        {
            var complaint = _context.Complaints.Find(id);
            if (complaint == null)
                return NotFound();

            return View(complaint);
        }

        // 7️⃣ DELETE CONFIRMED
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var complaint = _context.Complaints.Find(id);
            _context.Complaints.Remove(complaint);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        public IActionResult UpdateStatus(int id, string status)
        {
            var complaint = _context.Complaints.Find(id);

            if (complaint != null)
            {
                complaint.Status = status;
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
    }


