using System;
using System.Threading.Tasks;

namespace PDEXLib
{
    public interface IPDEXRequester
    {
        void Authentication(string user, string password);
        Task<bool> AuthenticationAsync(string user, string password);

        Cabimento GetCabimento();
        Task<Cabimento> GetCabimentoAsync();
    }
}
