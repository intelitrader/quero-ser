using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace MySolution.Models
{
    static class TransfersReport
    {
        static readonly string header = 
        $"Necessidade de Transferência Armazém para CO\n\nProduto\tQtCO\tQtMin\tQtVendas\tEstq.após\tNecess.\tTransf. de\n\t\t\t\t\tVendas\t\t\tArm p/ CO\n";
        public static void Save(IEnumerable<SellModel> sells, IEnumerable<ProductModel> products)
        {
            
            StringBuilder sb = new StringBuilder();
            sb.Append(header);
            Dictionary<uint, int> totalSold = ProductModel.GetTotalSoldByProdCode();
            ProductModel[] productsArr = products.ToArray();

            var tmp = 0;

            foreach (var item in products)
            {
                sb.Append(item.ProdCode+
                "\t"+item.InitialQt+
                "\t"+item.MinimunQt+
                "\t"+totalSold[item.ProdCode]+
                "\t\t"+ (tmp = item.InitialQt - totalSold[item.ProdCode]));
                if ((tmp = item.MinimunQt - tmp) < 0){tmp = 0;};
                sb.Append("\t\t" + (tmp));
                if (tmp > 1 && tmp < 10){tmp = 10;};
                sb.Append("\t" + (tmp) + "\n");
            }
            
            var content = sb.ToString();
            File.WriteAllText("transfere.txt", content);
        }
        
        
    }
}