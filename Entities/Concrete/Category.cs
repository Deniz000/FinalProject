using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category:IEntity  //işaretleme-referans tutucu
    {
        // ÇCK standartı - Eğer bu clas interitance tutmuyorsa
        public int CategoryId { get; set; } // bunlar hep sql de tablo
        public string CategoryName { get; set; }
    }
}
