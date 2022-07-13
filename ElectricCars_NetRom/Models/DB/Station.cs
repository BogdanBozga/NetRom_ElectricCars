using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ElectricCars_NetRom.Models.DB
{
    public partial class Station
    {
        public Station()
        {
            Plugs = new HashSet<Plug>();
        }
        

        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string Adress { get; set; } = null!;
        [Required]
        public string City { get; set; } = null!;

        public virtual ICollection<Plug> Plugs { get; set; }




        public string ShowMap()
        {       string Urll = "https://www.google.com/maps/search/?api=1&query=";
                string city = this.City;
                string address = this.Adress;
                string name = this.Name;
                name = name.Replace(" ", "+");
                name = name.Replace(",", "%2C");
                address = address.Replace(" ", "+");
                address = address.Replace(",", "%2C");
                Urll = Urll + name + "+" + city + "+" + address;
                return Urll;

        }
    }
}
