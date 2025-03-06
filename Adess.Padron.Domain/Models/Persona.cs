using System.Xml.Serialization;

namespace Adess.Padron.Domain.Models
{
    [XmlRoot("Root")]
    public class Persona
    {
        public string mun_ced { get; set; }
        public string seq_ced { get; set; }
        public string ver_ced { get; set; }
        public string nombres { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string fecha_nac { get; set; }
        public string lugar_nac { get; set; }
        public string ced_a_num { get; set; }
        public string ced_a_seri { get; set; }
        public string ced_a_sexo { get; set; }
        public string sexo { get; set; }
        public string cod_nacion { get; set; }
        public string desc_nacionalidad { get; set; }
        public string est_civil { get; set; }
        public string fecha_expiracion { get; set; }
        public string categoria { get; set; }
        public string desc_categoria { get; set; }
        public string estatus { get; set; }
        public string fotourl { get; set; }
        public string fotourlfull { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public int responsetime { get; set; }
    }
}
