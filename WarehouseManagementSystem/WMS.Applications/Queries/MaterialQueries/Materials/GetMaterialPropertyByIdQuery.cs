namespace WMS.Application.Queries.MaterialQueries.Materials
{
    public class GetMaterialPropertyByIdQuery : IRequest<MaterialPropertyDTO>
    {
        public string MaterialPropertyId { get; set; }

        public GetMaterialPropertyByIdQuery(string materialPropertyId)
        {
            MaterialPropertyId = materialPropertyId;
        }
    }
}
