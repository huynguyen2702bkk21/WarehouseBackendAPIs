global using AutoMapper;
global using MediatR;
global using System.Runtime.Serialization;
global using System.Text.Json.Serialization;
global using WMS.Application.Commands.InventoryIssueCommands.InventoryIssueEntries;
global using WMS.Application.Commands.InventoryIssueCommands.InventoryIssues;
global using WMS.Application.Commands.InventoryIssueCommands.IssueLots;
global using WMS.Application.Commands.InventoryReceiptCommands.InventoryReceiptEntries;
global using WMS.Application.Commands.InventoryReceiptCommands.InventoryReceipts;
global using WMS.Application.Commands.InventoryReceiptCommands.ReceiptLots;
global using WMS.Application.DTOs.EquipmentDTOs;
global using WMS.Application.DTOs.InventoryIssueDTOs;
global using WMS.Application.DTOs.InventoryReceiptDTOs;
global using WMS.Application.DTOs.InventoryTrackingDTOs;
global using WMS.Application.DTOs.MaterialDTOs;
global using WMS.Application.DTOs.PartyDTOs;
global using WMS.Application.DTOs.PartyDTOs.People;
global using WMS.Application.DTOs.StorageDTOs;
global using WMS.Application.ErrorNotifications.ErrorDetails;
global using WMS.Application.Exceptions;
global using WMS.Application.Queries.InventoryReceiptQueries.InventoryReceipts;
global using WMS.Application.Queries.MaterialQueries.MaterialSublots;
global using WMS.Application.Services.InventoryReceiptServices;
global using WMS.Application.Services.InventoryIssueServices;
global using WMS.Domain.AggregateModels.EquipmentAggregate;
global using WMS.Domain.AggregateModels.InventoryIssueAggregate;
global using WMS.Domain.AggregateModels.InventoryLogAggregate;
global using WMS.Domain.AggregateModels.InventoryReceiptAggregate;
global using WMS.Domain.AggregateModels.MaterialAggregate;
global using WMS.Domain.AggregateModels.PartyAggregate;
global using WMS.Domain.AggregateModels.PartyAggregate.People;
global using WMS.Domain.AggregateModels.StorageAggregate;
global using WMS.Domain.DomainEvents.InventoryLogEvents;
global using WMS.Domain.DomainEvents.MaterialLotDomainEvents;
global using WMS.Domain.Enum;
global using WMS.Domain.InterfaceRepositories.IEquipment;
global using WMS.Domain.InterfaceRepositories.IInventoryIssue;
global using WMS.Domain.InterfaceRepositories.IInventoryLog;
global using WMS.Domain.InterfaceRepositories.IInventoryReceipt;
global using WMS.Domain.InterfaceRepositories.IMaterial;
global using WMS.Domain.InterfaceRepositories.IParty;
global using WMS.Domain.InterfaceRepositories.IParty.People;
global using WMS.Domain.InterfaceRepositories.IStorage;
global using WMS.Application.Commands.InventoryIssueCommands.IssueSubLots;








