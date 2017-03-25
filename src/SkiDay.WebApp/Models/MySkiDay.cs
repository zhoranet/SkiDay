using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SkiDay.WebApp.Models
{
    public class MySkiDay
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Resort { get; set; }
        public DateTime Date { get; set; }
        public bool Powder { get; set; }
        public bool Backcountry { get; set; }
        public string UserId { get; set; }
        public DateTime Added { get; set; }
        public DateTime? Updated { get; set; }
    }
}