namespace WMS.Application.Queries.MaterialQueries.Materials
{
    public class GetMaterialsByClassId : IRequest<MaterialClassDTO>
    {
        public string ClassId { get; set; }

        public GetMaterialsByClassId(string classId)
        {
            ClassId = classId;
        }
    }
}
