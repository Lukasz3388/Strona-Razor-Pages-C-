using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatalogGwiazd.Pages
{
    public class EdytujGwiazdeModel : PageModel
    {
        private readonly ILogger<EdytujGwiazdeModel> _logger;
        public string nazwa { get; set; }
        public string opis { get; set; }
        public int jakieid { get; set; }
        public UserModel Star1 { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }
        public List<UserModel> Stars { get; set; }
        public EdytujGwiazdeModel(ILogger<EdytujGwiazdeModel> logger)
        {
            _logger = logger;

        }


        public void OnGet(int id)
        {
            using (var db = new DBContext())
            {
                Stars = db.Star.ToList();

            }
            int k=0;
            int i = 0;
            while ( Stars[i].Id != id)
            {
                i++;
            }
            k = i;
            nazwa = Stars[k].Name;
            opis = Stars[k].Description;
            jakieid = Stars[k].Id;
        }
        public void OnPost(UserModel Star1)
        {
            string absolutpath = "G:/Programowanie 2/razor pages projekt 2/KatalogGwiazd/KatalogGwiazd/wwwroot/images/";
            if (Photo != null)
            {

                if (Star1.PhotoCode != null)
                {
                    string filePath = Path.Combine(absolutpath, Star1.PhotoCode);
                    System.IO.File.Delete(filePath);
                }
                using (var fileStream = new FileStream(Path.Combine(absolutpath, Photo.FileName), FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
                Star1.PhotoCode = Photo.FileName;
            }

            using (var db = new DBContext())
            {
                //db.Add(Star1);
                //db.Remove(new UserModel() { Id = 2 });

                //Star1.Id = jakieid;
                if (Star1.Name.Length > 0)
                {
                    db.Update(Star1);
                    db.SaveChanges();
                    Response.Redirect("/Index");
                }
            }


        }

    }
}
