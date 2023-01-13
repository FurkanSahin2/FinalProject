using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{

    // "Çıplak Class Kalmasın" Standartı 
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
