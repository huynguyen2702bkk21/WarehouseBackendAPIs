using WMS.Application.DTOs.MaterialDTOs;

namespace WMS.Application.Queries.MaterialQueries.MaterialClasses
{
    public class GetAllMaterialClassPropertiesQuerry : IRequest<IEnumerable<MaterialClassPropertyDTO>>
    {
        public GetAllMaterialClassPropertiesQuerry()
        {
        }
    }
}
