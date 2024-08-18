using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.DataAccess.Entity;

namespace BookManagement.DataAccess.ServiceInterface
{
    public interface ICategoryRepository
    {
        List<CategoryEntity> GetAll();
        bool Add(CategoryEntity entity);
        bool Delete(int CategoryId);
        void Update(CategoryEntity entity);

        CategoryEntity GetById(int CategoryId);

    }
}
