namespace WMS.Application.Queries.MaterialQueries.Materials
{
    public class GetMaterialsByClassIdQuery : IRequest<IEnumerable<MaterialDTO>>
    {
        public string ClassId { get; set; }

        public GetMaterialsByClassIdQuery(string classId)
        {
            ClassId = classId;
        }
    }
}
