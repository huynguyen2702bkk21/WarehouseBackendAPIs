namespace WMS.Application.Commands.MaterialCommands.MaterialClasses
{
    public class UpdateMaterialClassCommand : IRequest<bool>
    {
        public string MaterialClassId { get; set; }
        public string ClassName { get; set; }
        public List<MaterialClassPropertyDTO> Properties { get; set; }

        public UpdateMaterialClassCommand()
        {
        }

        public UpdateMaterialClassCommand(string materialClassId, string className, List<MaterialClassPropertyDTO> properties)
        {
            MaterialClassId = materialClassId;
            ClassName = className;
            Properties = properties;
        }
    }
}