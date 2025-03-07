global using AutoMapper;
global using MediatR;
global using System.Runtime.Serialization;
global using System.Text.Json.Serialization;
global using WMS.Application.DTOs.EquipmentDTOs;
global using WMS.Application.DTOs.InventoryIssueDTOs;
global using WMS.Application.DTOs.InventoryReceiptDTOs;
global using WMS.Application.DTOs.MaterialDTOs;
global using WMS.Application.DTOs.PartyDTOs;
global using WMS.Application.DTOs.StorageDTOs;
global using WMS.Application.ErrorNotifications.ErrorDetails;
global using WMS.Application.Exceptions;
global using WMS.Application.Queries.InventoryReceiptQueries.InventoryReceipts;
global using WMS.Application.Queries.MaterialQueries.MaterialSublots;
global using WMS.Domain.AggregateModels.EquipmentAggregate;
global using WMS.Domain.AggregateModels.InventoryIssueAggregate;
global using WMS.Domain.AggregateModels.InventoryReceiptAggregate;
global using WMS.Domain.AggregateModels.MaterialAggregate;
global using WMS.Domain.AggregateModels.PartyAggregate;
global using WMS.Domain.AggregateModels.StorageAggregate;
global using WMS.Domain.Enum;
global using WMS.Domain.InterfaceRepositories.IEquipment;
global using WMS.Domain.InterfaceRepositories.IInventoryIssue;
global using WMS.Domain.InterfaceRepositories.IInventoryReceipt;
global using WMS.Domain.InterfaceRepositories.IMaterial;
global using WMS.Domain.InterfaceRepositories.IParty;
global using WMS.Domain.InterfaceRepositories.IStorage;





