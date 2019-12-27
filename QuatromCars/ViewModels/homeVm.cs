using QuatromCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuatromCars.ViewModels
{
    public class homeVm
    {
        public List<SliderTop> slider { get; set; }
        public List<News> News { get; set; }
        public List<Product> products { get; set; }
        public List<CarsGalery> CarsGa { get; set; }
        public List<AvtoParth> AvtoPa { get; set; }
    }
}