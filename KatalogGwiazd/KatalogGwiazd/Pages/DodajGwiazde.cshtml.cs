using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace KatalogGwiazd.Pages
{
    public class DodajGwiazdeModel : PageModel
    {

        public UserModel Star { get; set; }
        List<UserModel> Stars = new List<UserModel>();

        [BindProperty]
        public IFormFile Photo { get; set; }


        public void OnGet()
        {
            
        }
        public void OnPost(UserModel star)
        {
            
            string absolutpath = "G:/Programowanie 2/razor pages projekt 2/KatalogGwiazd/KatalogGwiazd/wwwroot/images/";
            if (Photo != null)
            {
                
                if (star.PhotoCode != null)
                {
                    string filePath = Path.Combine(absolutpath, star.PhotoCode);
                    System.IO.File.Delete(filePath);
                }
                using (var fileStream = new FileStream(Path.Combine(absolutpath, Photo.FileName), FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
                    star.PhotoCode = Photo.FileName;
            }

            using (var db = new DBContext())
            {
                if (star.Name.Length > 0)
                {
                    db.Add(star);
                    //db.Remove(new UserModel() { Id = 2 });
                    //db.Star.Update
                    //star.Id = 3;
                    //db.Update(star);
                    db.SaveChanges();
                    Response.Redirect("/Index");
                }
            }

            
            using (var db = new DBContext())
            {
                Stars = db.Star.ToList();

            }
            
        }

    }
}
