namespace WMS.Application.Commands.MaterialCommands.Materials
{
    public class CreateMaterialCommand : IRequest<bool>
    {
        public string MaterialId { get; set; }
        public string MaterialName { get; set; }
        public string MaterialClassId { get; set; }
        public List<CreateMaterialPropertyCommand> Properties { get; set; }

        public CreateMaterialCommand(string materialId, string materialName, string materialClassId, List<CreateMaterialPropertyCommand> properties)
        {
            MaterialId = materialId;
            MaterialName = materialName;
            MaterialClassId = materialClassId;
            Properties = properties;
        }
    }
}
