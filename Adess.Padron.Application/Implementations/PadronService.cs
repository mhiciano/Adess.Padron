using Adess.Padron.Application.Contracts;
using Adess.Padron.Domain.Models;
using System.Xml.Serialization;
using System.Xml;

namespace Adess.Padron.Application.Implementations
{
    public class PadronService(HttpClient httpClient) : IPadronService
    {
        private readonly HttpClient _httpClient = httpClient;

        private readonly string _baseUrl = "https://dataportal.jce.gob.do/idcons/IndividualDataHandler.aspx?ServiceID={0}&ID1={1}&ID2={2}&ID3={3}";
        private readonly string _servicio = "cb0b316e-5094-44ab-b2ee-143a910a4496";

        public async Task<Persona> GetPadronInfo(string cedula)
        {
            var persona = new Persona();
            try
            {
                string munCed, seqCed, verCed;

                munCed = "001";
                seqCed = "1780722";
                verCed = "2";

                string url = string.Format(_baseUrl, _servicio, munCed, seqCed, verCed);

                var request = new HttpRequestMessage(HttpMethod.Get, url);

                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2");

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                response.EnsureSuccessStatusCode();

                string xmlResponse = await response.Content.ReadAsStringAsync();

                persona = DeserializeXml<Persona>(xmlResponse);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la información: {ex.Message}");
            }

            return persona;
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
