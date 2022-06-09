using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatalogGwiazd.Pages
{
    public class UsunGwiazdeModel : PageModel
    {
        private readonly ILogger<UsunGwiazdeModel> _logger;

        public int jakieid { get; set; }
        public UserModel Star2 { get; set; }
        public List<UserModel> Stars { get; set; }
        public UsunGwiazdeModel(ILogger<UsunGwiazdeModel> logger)
        {
            _logger = logger;

        }
        public void OnGet(int id)
        {

            using (var db = new DBContext())
            {
                //db.Add(Star1);
                //db.Remove(new UserModel() { Id = 2 });

                Stars = db.Star.ToList();
            }
            jakieid = id;
        }
        public void OnPost(UserModel Star2)
        {
            string absolutpath = "G:/Programowanie 2/razor pages projekt 2/KatalogGwiazd/KatalogGwiazd/wwwroot/images/";
            if (Star2.PhotoCode != null)
            {
                string filePath = Path.Combine(absolutpath, Star2.PhotoCode);
                System.IO.File.Delete(filePath);
            }
            using (var db = new DBContext())
            {
                //db.Add(Star1);
                //db.Remove(new UserModel() { Id = 2 });

                //Star1.Id = jakieid;

                db.Remove(Star2);
                db.SaveChanges();
                Response.Redirect("/Index");
            }

        }
    }
}
