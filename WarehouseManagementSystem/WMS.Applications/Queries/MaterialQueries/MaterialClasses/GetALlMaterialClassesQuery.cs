using WMS.Application.DTOs.MaterialDTOs;

namespace WMS.Application.Queries.MaterialQueries.MaterialClasses
{
    public class GetALlMaterialClassesQuery : IRequest<IEnumerable<MaterialClassDTO>>
    {
        public GetALlMaterialClassesQuery()
        {
        }
    }
}
