﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatalogGwiazd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<UserModel> Stars { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            
        }


        public void OnGet()
        {
            using (var db = new DBContext())
            {
                Stars = db.Star.ToList();

            }
        }
    }
}
