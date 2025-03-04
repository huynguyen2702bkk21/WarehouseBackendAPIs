namespace WMS.Application.Commands.MaterialCommands.MaterialClasses
{
    public class UpdateMaterialClassCommand : IRequest<bool>
    {
        public string MaterialClassId { get; set; }
        public string ClassName { get; set; }
        public List<CreateMaterialClassPropertyCommand> Properties { get; set; }

        public UpdateMaterialClassCommand()
        {
        }

        public UpdateMaterialClassCommand(string materialClassId, string className, List<CreateMaterialClassPropertyCommand> properties)
        {
            MaterialClassId = materialClassId;
            ClassName = className;
            Properties = properties;
        }
    }
}