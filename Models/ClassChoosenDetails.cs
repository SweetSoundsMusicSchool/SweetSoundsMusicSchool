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
                Value = "Geogrgetown, Children 0 to 4 Years. Tuesdays @ 10:30 AM",
                Text = "Geogrgetown,  Children 0 to 4 Years. Tuesdays @ 10:30 AM"
            },
            new SelectListItem {
                Value = "Geogrgetown, Children 0 to 18 Months, Tuesdays @ 11:45 AM",
                Text = "Geogrgetown, Children 0 to 18 Months. Tuesdays @ 11:45 AM"
            },
            new SelectListItem {
                Value = "Oakville, Children 0 to 4 Years.Wednesdays @ 10:30 AM",
                Text = "Oakville, Children 0 to 4 Years. Wednesdays @ 10:30 AM"
            },
            new SelectListItem {
                Value = "Oakville, Children 0 to 18 Months.  Wednesdays @ 11:45 AM",
                Text = "Oakville, Children 0 to 18 Months. Wednesdays @ 11:45 AM"
            },
             new SelectListItem {
                Value = "Milton, Children 0 to 4 Years. Thursdays @ 10:45 AM",
                Text = "Milton, Children 0 to 4 Years. Thursdays @ 10:45 AM"
            },
              new SelectListItem {
                Value = "Milton, Children 0 to 18 Months. Thursdays @ 11:45 AM",
                Text = "Milton, Children 0 to 18 Months. Thursdays @ 11:45 AM"
            },
        };
        
    }
}
