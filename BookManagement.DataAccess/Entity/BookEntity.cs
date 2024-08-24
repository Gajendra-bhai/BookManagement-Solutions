using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.DataAccess.Entity
{
    public class BookEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SBIN { get; set; }
        public int Price { get; set; }
        public string Discription { get; set; }
        public string CoverPhotoPath { get; set; }
        public int CategoryId { get; set; }
        public string Author { get; set; }
    }
}
