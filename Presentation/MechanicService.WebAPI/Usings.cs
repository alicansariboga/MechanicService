﻿global using Microsoft.AspNetCore.Http;
global using MediatR;
global using Microsoft.AspNetCore.Mvc;

global using MechanicService.Application.Interfaces;
global using MechanicService.Application.Services;
global using MechanicService.Persistence.Context;
global using MechanicService.Persistence.Repositories;

global using MechanicService.Application.Features.Mediator.Commands.AboutCommands;
global using MechanicService.Application.Features.Mediator.Queries.AboutQueries;

global using MechanicService.Application.Features.Mediator.Commands.AddressCommands;
global using MechanicService.Application.Features.Mediator.Queries.AddressQueries;

global using MechanicService.Application.Features.Mediator.Commands.BannerCommands;
global using MechanicService.Application.Features.Mediator.Queries.BannerQueries;

global using MechanicService.Application.Features.Mediator.Commands.FeatureCommands;
global using MechanicService.Application.Features.Mediator.Queries.FeatureQueries;

global using MechanicService.Application.Features.Mediator.Commands.ServiceCommands;
global using MechanicService.Application.Features.Mediator.Queries.ServiceQueries;

global using MechanicService.Application.Features.Mediator.Commands.CarBrandCommands;
global using MechanicService.Application.Features.Mediator.Queries.CarBrandQueries;

global using MechanicService.Application.Features.Mediator.Commands.CarModelCommands;
global using MechanicService.Application.Features.Mediator.Queries.CarModelQueries;

global using MechanicService.Application.Features.Mediator.Commands.FaqCommands;
global using MechanicService.Application.Features.Mediator.Queries.FaqQueries;

global using MechanicService.Application.Features.Mediator.Commands.TestimonialCommands;
global using MechanicService.Application.Features.Mediator.Queries.TestimonialQueries;

global using MechanicService.Application.Features.Mediator.Commands.LocationCommands;
global using MechanicService.Application.Features.Mediator.Queries.LocationQueries;

global using MechanicService.Application.Features.Mediator.Commands.PricingCommands;
global using MechanicService.Application.Features.Mediator.Queries.PricingQueries;

global using MechanicService.Application.Features.Mediator.Commands.SocialMediaCommands;
global using MechanicService.Application.Features.Mediator.Queries.SocialMediaQueries;

global using MechanicService.Application.Features.Mediator.Commands.TeamCommands;
global using MechanicService.Application.Features.Mediator.Queries.TeamQueries;

global using MechanicService.Application.Features.Mediator.Commands.BlogCommands;
global using MechanicService.Application.Features.Mediator.Queries.BlogQueries;

global using MechanicService.Application.Features.Mediator.Commands.CategoryCommands;
global using MechanicService.Application.Features.Mediator.Queries.CategoryQueries;

global using MechanicService.Application.Features.Mediator.Queries.LocationCityQueries;

global using MechanicService.Application.Features.Mediator.Commands.LocationDistrictCommands;
global using MechanicService.Application.Features.Mediator.Queries.LocationDistrictQueries;

global using MechanicService.Application.Interfaces.LocationsInterfaces;
global using MechanicService.Persistence.Repositories.LocationsRepositories;

global using MechanicService.Application.Features.Mediator.Commands.ReservationCommands;
global using MechanicService.Application.Features.Mediator.Queries.ReservationQueries;
global using MechanicService.Application.Features.Mediator.Queries.ReservationCarQueries;
global using MechanicService.Application.Features.Mediator.Queries.ReservationPersonQueries;
global using MechanicService.Application.Features.Mediator.Queries.ReservationServiceQueries;

// Statistics
global using MechanicService.Application.Features.Mediator.Queries.StatisticsQueries;

// Program.cs
global using MechanicService.Application.Interfaces.CarModelnterfaces;
global using MechanicService.Application.Interfaces.ReservationInterfaces;
global using MechanicService.Application.Interfaces.StatisticsInterfaces;
global using MechanicService.Persistence.Repositories.CarModelRepositories;
global using MechanicService.Persistence.Repositories.ReservationRepositories;
global using MechanicService.Persistence.Repositories.StatisticsRepositories;

global using MechanicService.Application.Features.Mediator.Commands.ContactCommands;
global using MechanicService.Application.Features.Mediator.Queries.ContactQueries;

global using MechanicService.Application.Features.Mediator.Queries.CustomerQueries;

global using MechanicService.Application.Features.Mediator.Queries.AppUserQueries;
global using MechanicService.Application.Features.Mediator.Commands.AppUserCommands;

global using MechanicService.Application.Features.Mediator.Queries.BranchOfficeQueries;
global using MechanicService.Application.Features.Mediator.Commands.BranchOfficeCommands;


