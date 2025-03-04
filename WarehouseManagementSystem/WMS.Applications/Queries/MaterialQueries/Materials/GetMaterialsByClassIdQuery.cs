namespace WMS.Application.Queries.MaterialQueries.Materials
{
    public class GetMaterialsByClassIdQuery : IRequest<MaterialClassDTO>
    {
        public string ClassId { get; set; }

        public GetMaterialsByClassIdQuery(string classId)
        {
            ClassId = classId;
        }
    }
}
