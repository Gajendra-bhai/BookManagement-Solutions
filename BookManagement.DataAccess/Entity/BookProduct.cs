using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DataAccess.Entity
{
    public class BookProduct
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string CoverPhotoPath { get; set; }
    }
}
