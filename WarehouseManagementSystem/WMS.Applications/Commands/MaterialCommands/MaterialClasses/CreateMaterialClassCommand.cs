namespace WMS.Application.Commands.MaterialCommands.MaterialClasses
{
    public class CreateMaterialClassCommand : IRequest<bool>
    {
        public string MaterialClassId { get; set; }
        public string ClassName { get; set; }

        public MaterialClassPropertyDTO PropertyDTO { get; set; }

        public CreateMaterialClassCommand(string materialClassId, string className, MaterialClassPropertyDTO propertyDTO)
        {
            MaterialClassId = materialClassId;
            ClassName = className;
            PropertyDTO = propertyDTO;
        }
    }
}
