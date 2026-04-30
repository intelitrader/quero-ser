namespace Intelitrader.Domain.Services;

public class DescontoService
{
    private const decimal PrecoBase = 42.00m;
    private readonly Dictionary<int, decimal> _descontos = new() {
        { 1, 0m }, { 2, 0.05m }, { 3, 0.10m }, { 4, 0.15m }, { 5, 0.20m }
    };

    public decimal CalcularMelhorPreco(List<int> livrosIds)
    {
        var contagens = livrosIds.GroupBy(id => id).Select(g => g.Count()).OrderByDescending(c => c).ToList();
        return Resolver(contagens, new Dictionary<string, decimal>());
    }

    private decimal Resolver(List<int> grupos, Dictionary<string, decimal> memo)
    {
        grupos = grupos.Where(g => g > 0).OrderByDescending(g => g).ToList();
        if (!grupos.Any()) return 0;

        string chave = string.Join(",", grupos);
        if (memo.TryGetValue(chave, out decimal cached)) return cached;

        decimal precoMinimo = decimal.MaxValue;
        for (int i = 1; i <= grupos.Count; i++)
        {
            var proximoPasso = new List<int>(grupos);
            for (int j = 0; j < i; j++) proximoPasso[j]--;

            decimal custo = (i * PrecoBase * (1 - _descontos[i])) + Resolver(proximoPasso, memo);
            precoMinimo = Math.Min(precoMinimo, custo);
        }
        return memo[chave] = precoMinimo;
    }
}