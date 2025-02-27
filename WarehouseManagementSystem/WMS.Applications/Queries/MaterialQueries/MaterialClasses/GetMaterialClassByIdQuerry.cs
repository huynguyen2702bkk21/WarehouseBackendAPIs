using WMS.Application.DTOs.MaterialDTOs;

namespace WMS.Application.Queries.MaterialQueries.MaterialClasses
{
    public class GetMaterialClassByIdQuerry : IRequest<MaterialClassDTO>
    {
        public string MaterialClassId { get; set; }

        public GetMaterialClassByIdQuerry(string materialClassId)
        {
            MaterialClassId = materialClassId;
        }
    }
}
