using Adess.Padron.Application.Contracts;
using Adess.Padron.Domain.Models;
using System.Xml.Serialization;
using System.Xml;
using Microsoft.Extensions.Configuration;

namespace Adess.Padron.Application.Implementations
{
    public class PadronService : IPadronService
    {

        private readonly IConfiguration _configuration;

        private readonly IHttpClientService _httpClient;

        public PadronService(IConfiguration configuration, IHttpClientService httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        private readonly string _pathUrl = "idcons/IndividualDataHandler.aspx?ServiceID={0}&ID1={1}&ID2={2}&ID3={3}";

        public async Task<Persona> GetPadronInfo(string numCedula)
        {
            var persona = new Persona();

            var cedula = new Cedula(numCedula);

            try
            {
                var url = BuildRequestUrl(cedula.MunCed, cedula.SeqCed, cedula.VerCed);

                var header = new Dictionary<string, string>
                {
                    { "User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2" }
                };

                var xmlResponse = await _httpClient.GetAsync(url,HttpMethod.Get, header);

                persona = DeserializeXml<Persona>(xmlResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la información: {ex.Message}");
            }

            return persona;
        }

        private string BuildRequestUrl(string munCed, string seqCed, string verCed)
        {
            string baseUrl = _configuration["padron:baseUrl"];
            string serviceId = _configuration["padron:service"];
            return string.Format(baseUrl + _pathUrl, serviceId, munCed, seqCed, verCed);
        }

        private static T DeserializeXml<T>(string xml)
        {
            try
            {
                var objDoc = new XmlDocument();

                objDoc.LoadXml(xml);

                string newXml = objDoc.DocumentElement!.InnerXml;

                var serializer = new XmlSerializer(typeof(T));
                using var stringReader = new StringReader($"<Root>{newXml}</Root>");
                return (T)serializer.Deserialize(stringReader);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al deserializar XML: {ex.Message}");
                return default;
            }
        }
    }
}
