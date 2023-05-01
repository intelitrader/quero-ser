using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quero_ser.repositories
{
    public interface IProductsRepository
    {
        public string[] ReadFile(string path);
    }
}