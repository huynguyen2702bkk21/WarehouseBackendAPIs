namespace WMS.Application.Commands.MaterialCommands.MaterialClasses
{
    public class DeleteMaterialClassPropertyCommand : IRequest<bool>
    {
        public string MaterialClassId { get; set; }

        public DeleteMaterialClassPropertyCommand(string materialClassId)
        {
            MaterialClassId = materialClassId;
        }
    }
}
