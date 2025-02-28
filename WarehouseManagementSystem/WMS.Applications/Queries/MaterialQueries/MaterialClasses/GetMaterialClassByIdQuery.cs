namespace WMS.Application.Queries.MaterialQueries.MaterialClasses
{
    public class GetMaterialClassByIdQuery : IRequest<MaterialClassDTO>
    {
        public string MaterialClassId { get; set; }

        public GetMaterialClassByIdQuery(string materialClassId)
        {
            MaterialClassId = materialClassId;
        }
    }
}
