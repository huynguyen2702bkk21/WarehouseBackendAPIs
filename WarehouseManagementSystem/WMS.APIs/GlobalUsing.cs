global using MediatR;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
global using WMS.Application.Commands.MaterialCommands.MaterialClasses;
global using WMS.Application.Commands.PartyCommands.Customers;
global using WMS.Application.Commands.PartyCommands.Persons;
global using WMS.Application.Commands.PartyCommands.Suppliers;
global using WMS.Application.Commands.StorageCommands.Locations;
global using WMS.Application.Commands.StorageCommands.Warehouses;
global using WMS.Application.DTOs.InventoryIssueDTOs;
global using WMS.Application.DTOs.InventoryReceiptDTOs;
global using WMS.Application.DTOs.MaterialDTOs;
global using WMS.Application.DTOs.PartyDTOs;
global using WMS.Application.DTOs.StorageDTOs;
global using WMS.Application.ErrorNotifications;
global using WMS.Application.Exceptions;
global using WMS.Application.Mapping;
global using WMS.Application.Queries.InventoryIssueQueries.IssueSubLots;
global using WMS.Application.Queries.InventoryReceiptQueries.ReceiptLots;
global using WMS.Application.Queries.InventoryReceiptQueries.ReceiptSubLots;
global using WMS.Application.Queries.MaterialQueries.MaterialClasses;
global using WMS.Application.Queries.PartyQueries.Customers;
global using WMS.Application.Queries.PartyQueries.Persons;
global using WMS.Application.Queries.PartyQueries.Suppliers;
global using WMS.Application.Queries.StorageQueries.Locations;
global using WMS.Application.Queries.StorageQueries.Warehouses;
global using WMS.Domain.InterfaceRepositories.IInventoryIssue;
global using WMS.Domain.InterfaceRepositories.IInventoryReceipt;
global using WMS.Domain.InterfaceRepositories.IMaterial;
global using WMS.Domain.InterfaceRepositories.IParty;
global using WMS.Domain.InterfaceRepositories.IStorage;
global using WMS.Infrastructure;
global using WMS.Infrastructure.Repositories.InventoryIssueRepositories;
global using WMS.Infrastructure.Repositories.InventoryReceiptRepositories;
global using WMS.Infrastructure.Repositories.MaterialRepositories;
global using WMS.Infrastructure.Repositories.PartyRepositories;
global using WMS.Infrastructure.Repositories.StorageRepositories;
global using WMS.Application.Queries.InventoryIssueQueries.InventoryIssueEntries;
global using WMS.Application.Queries.InventoryIssueQueries.InventoryIssues;
global using WMS.Application.DTOs.PartyDTOs.People;
global using WMS.Application.Commands.InventoryIssueCommands.InventoryIssues;





