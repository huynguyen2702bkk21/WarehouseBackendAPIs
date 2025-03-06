using System.ComponentModel.DataAnnotations.Schema;

namespace WMS.Application.Commands.EquipmentCommands.EquipmentProperties
{
    public class CreateEquipmentPropertyCommand : IRequest<bool>
    {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyValue { get; set; }
        public string UnitOfMeasure { get; set; }
        public string EquipmentId { get; set; }

        public CreateEquipmentPropertyCommand()
        {
        }

        public CreateEquipmentPropertyCommand(string propertyId, string propertyName, string propertyValue, string unitOfMeasure, string equipmentClassId)
        {
            PropertyId = propertyId;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            UnitOfMeasure = unitOfMeasure;
            EquipmentId = equipmentClassId;
        }
    }
}