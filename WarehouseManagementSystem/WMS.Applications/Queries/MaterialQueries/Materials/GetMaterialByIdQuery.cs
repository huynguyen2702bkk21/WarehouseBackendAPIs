namespace WMS.Application.Queries.MaterialQueries.Materials
{
    public class GetMaterialByIdQuery : IRequest<MaterialDTO>
    {
        public string MaterialId { get; set; }

        public GetMaterialByIdQuery(string materialId)
        {
            MaterialId = materialId;
        }
    }
}
