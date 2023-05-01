using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quero_ser.model;

namespace quero_ser.repositories
{
    public interface IProductsRepository
    {
        public string[] ReadFile(string path);
        public List<Product> FormatProductListFile(string[] lines);

    }
}