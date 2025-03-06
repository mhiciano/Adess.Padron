using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adess.Padron.Application.Contracts
{
    public interface IHttpClientService
    {
        Task<string> GetAsync(string url, HttpMethod method, Dictionary<string,string>? headers = null);
    }
}
