using AutoMapper;

namespace MuctrService.Application.Common.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile);
    }
}
