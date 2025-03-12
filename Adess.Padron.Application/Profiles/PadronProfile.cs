using System.Globalization;
using Adess.Padron.Domain.Models;
using AutoMapper;

namespace Adess.Padron.Application.Profiles
{
    public class PadronProfile : Profile
    {
        public PadronProfile()
        {
            CreateMap<Persona, PadronElectoral>()
                .ForMember(x => x.MunCed, src => src.MapFrom(x => x.mun_ced))
                .ForMember(x => x.SeqCed, src => src.MapFrom(x => x.seq_ced))
                .ForMember(x => x.VerCed, src => src.MapFrom(x => x.ver_ced))
                .ForMember(x => x.Nombres, src => src.MapFrom(x => x.nombres))

                .ForMember(x => x.Apellido1, src => src.MapFrom(x => x.apellido1))
                .ForMember(x => x.Apellido2, src => src.MapFrom(x => x.apellido2))
                .ForMember(x => x.FechaNacimiento, src => src.MapFrom(x => DateTime.ParseExact(x.fecha_nac, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)))
                .ForMember(x => x.LugarNacimiento, src => src.MapFrom(x => x.lugar_nac))
                .ForMember(x => x.CedNum, src => src.MapFrom(x => x.ced_a_num))
                .ForMember(x => x.CedSeri, src => src.MapFrom(x => x.ced_a_seri))
                .ForMember(x => x.CedSexo, src => src.MapFrom(x => x.ced_a_sexo))
                .ForMember(x => x.CodNacionalidad, src => src.MapFrom(x => x.cod_nacion))
                .ForMember(x => x.FechaExpiracion, src => src.MapFrom(x => DateTime.ParseExact(x.fecha_expiracion, "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)))
                .ForMember(x => x.Categoria, src => src.MapFrom(x => x.categoria))
            //    .ForMember(x => x.CategoriaDescripcion, src => src.MapFrom(x => x.desc_categoria))
                .ForMember(x => x.Estatus, src => src.MapFrom(x => x.estatus));
        }
    }
}
