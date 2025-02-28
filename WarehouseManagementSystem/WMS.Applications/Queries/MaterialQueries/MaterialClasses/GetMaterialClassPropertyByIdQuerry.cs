namespace WMS.Application.Queries.MaterialQueries.MaterialClasses
{
    public class GetMaterialClassPropertyByIdQuerry : IRequest<MaterialClassPropertyDTO>
    {
        public string MaterialClassPropertyId { get; set; }

        public GetMaterialClassPropertyByIdQuerry(string materialClassPropertyId)
        {
            MaterialClassPropertyId = materialClassPropertyId;
        }
    }
}
