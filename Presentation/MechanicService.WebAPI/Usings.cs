global using Microsoft.AspNetCore.Http;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;

global using MechanicService.Application.Interfaces;
global using MechanicService.Application.Services;
global using MechanicService.Persistence.Context;
global using MechanicService.Persistence.Repositories;

global using MechanicService.Application.Features.Mediator.Commands.AboutCommands;
global using MechanicService.Application.Features.Mediator.Queries.AboutQueries;

global using MechanicService.Application.Features.Mediator.Commands.FeatureCommands;
global using MechanicService.Application.Features.Mediator.Queries.FeatureQueries;

global using MechanicService.Application.Features.Mediator.Commands.ServiceCommands;
global using MechanicService.Application.Features.Mediator.Queries.ServiceQueries;

