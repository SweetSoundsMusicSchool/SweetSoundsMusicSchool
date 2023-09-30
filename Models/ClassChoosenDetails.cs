using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone1.Models
{
    public class ClassChoosenDetails
    {
        public string Location { get; set; } = string.Empty;

        public List<SelectListItem> Locations { get; } = new List<SelectListItem>
        {
            new SelectListItem {
                Value = "Milton",
                Text = "Milton"
            },
            new SelectListItem {
                Value = "Geogrgetown",
                Text = "Geogrgetown"
            },
            new SelectListItem {
                Value = "Oakville",
                Text = "Oakville"  },
        };

        public string Lesson { get; set; } = String.Empty;
        public List<SelectListItem> Lessons { get; } = new List<SelectListItem>
        {
            new SelectListItem { 
                Value = "Private Piano Lessons (0 to 4 Years)", 
                Text = "Private Piano Lessons (0 to 4 Years)" 
            },
            new SelectListItem { 
                Value = "PreSchool Piano Foundation  (2 to 4 Years)", 
                Text = "PreSchool Piano Foundation  (2 to 4 Years)"
            },
            new SelectListItem { 
                Value = "Early Years Music", 
                Text = "Early Years Music"  },
        };
    }
}
