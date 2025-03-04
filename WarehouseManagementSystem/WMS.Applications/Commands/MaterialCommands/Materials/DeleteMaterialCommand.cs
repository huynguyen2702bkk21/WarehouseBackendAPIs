namespace WMS.Application.Commands.MaterialCommands.Materials
{
    public class DeleteMaterialCommand : IRequest<bool>
    {
        public string MaterialId { get; set; }

        public DeleteMaterialCommand(string materialId)
        {
            MaterialId = materialId;
        }
    }
}
