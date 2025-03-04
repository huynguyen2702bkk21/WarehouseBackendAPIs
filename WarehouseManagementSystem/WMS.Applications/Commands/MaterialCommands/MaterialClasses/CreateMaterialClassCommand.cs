namespace WMS.Application.Commands.MaterialCommands.MaterialClasses
{
    public class CreateMaterialClassCommand : IRequest<bool>
    {
        public string MaterialClassId { get; set; }
        public string ClassName { get; set; }

        public List<CreateMaterialClassPropertyCommand> Properties { get; set; }

        public CreateMaterialClassCommand(string materialClassId, string className, List<CreateMaterialClassPropertyCommand> properties)
        {
            MaterialClassId = materialClassId;
            ClassName = className;
            Properties = properties;
        }
    }
}
