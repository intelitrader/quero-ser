using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace MySolution.Models
{
    static class DivergenciesReport
    {
        public static void Save(List<SellModel> sells, List<ProductModel> products)
        {
            
            StringBuilder sb = new StringBuilder();
            Dictionary<uint, ProductModel> productsD = products.ToDictionary(x => x.ProdCode);

            int i = 0;

            foreach (var item in sells)
            {
                if (item.Status == (StatusModel)999)
                {
                    sb.Append($"Linha {i+1} – Erro desconhecido. Acionar equipe de TI\n");
                }
                else if (!productsD.ContainsKey(item.ProdCode))
                {
                    sb.Append($"Linha {i+1} – Código de Produto não encontrado {item.ProdCode}\n");
                }
                else if (item.Status == (StatusModel)135)
                {
                    sb.Append($"Linha {i+1} – Venda cancelada\n");
                }
                else if (item.Status == (StatusModel)190)
                {
                    sb.Append($"Linha {i+1} – Venda não finalizada\n");
                }
                i++;
            }

            var content = sb.ToString();
            File.WriteAllText("DIVERGENCIAS.txt", content);
            
        }

    }
}