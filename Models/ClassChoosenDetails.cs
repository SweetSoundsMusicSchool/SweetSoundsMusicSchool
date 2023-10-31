using Microsoft.AspNetCore.Mvc.Rendering;

namespace Capstone1.Models
{
    public class ClassChoosenDetails
    {
        public string Location { get; set; } = string.Empty;

        public string Lesson { get; set; } = String.Empty;

        //public string ClassDate { get; set; } = String.Empty;



        public List<SelectListItem> All { get; } = new List<SelectListItem>
        {
            new SelectListItem {
                Value = "Geogrgetown, Children 0 to 4 Years",
                Text = "Geogrgetown,  Children 0 to 4 Years. \n Tuesdays @ 10:30 AM"
            },
            new SelectListItem {
                Value = "Geogrgetown, Children 0 to 18 Months",
                Text = "Geogrgetown, Children 0 to 18 Months, Tuesdays @ 11:45 AM"
            },
            new SelectListItem {
                Value = "Oakville, Children 0 to 4 Years",
                Text = "Oakville, Children 0 to 4 Years. Wednesdays @ 10:30 AM"
            },
            new SelectListItem {
                Value = "Oakville, Children 0 to 18 Months",
                Text = "Oakville, Children 0 to 18 Months. Wednesdays @ 11:45 AM"
            },
             new SelectListItem {
                Value = "Milton, Children 0 to 4 Years",
                Text = "Milton, Children 0 to 4 Years. Thursdays @ 10:45 AM"
            },
              new SelectListItem {
                Value = "Milton, Children 0 to 18 Months",
                Text = "Milton, Children 0 to 18 Months. Wednesdays @ 11:45 AM"
            },
        };
        public List<SelectListItem> Locations { get; } = new List<SelectListItem>
        {
            new SelectListItem {
                Value = "Milton",
                Text = "Milton, Thursdays"
            },
            new SelectListItem {
                Value = "Geogrgetown",
                Text = "Geogrgetown, Tuesdays"
            },
            new SelectListItem {
                Value = "Oakville",
                Text = "Oakville, Wednesdays"  },
        };

       
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
