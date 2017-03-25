using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SkiDay.WebApp.Models
{
    // Models returned by ResortsController actions.
    public class GetViewModel
    {
        public string Hometown { get; set; }
    }
}