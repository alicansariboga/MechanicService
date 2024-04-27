global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;

global using MediatR;

global using MechanicService.Application.Interfaces;
global using MechanicService.Application.Features.Mediator.Results.AboutResults;
global using MechanicService.Application.Features.Mediator.Queries.AboutQueries;
global using MechanicService.Application.Features.Mediator.Commands.AboutCommands;

global using MechanicService.Application.Features.Mediator.Results.AddressResults;
global using MechanicService.Application.Features.Mediator.Queries.AddressQueries;
global using  MechanicService.Application.Features.Mediator.Commands.AddressCommands;

global using MechanicService.Application.Features.Mediator.Results.BannerResults;
global using MechanicService.Application.Features.Mediator.Queries.BannerQueries;
global using MechanicService.Application.Features.Mediator.Commands.BannerCommands;

global using MechanicService.Application.Features.Mediator.Results.FeatureResults;
global using MechanicService.Application.Features.Mediator.Queries.FeatureQueries;
global using MechanicService.Application.Features.Mediator.Commands.FeatureCommands;

global using MechanicService.Application.Features.Mediator.Results.ServiceResults;
global using MechanicService.Application.Features.Mediator.Queries.ServiceQueries;
global using MechanicService.Application.Features.Mediator.Commands.ServiceCommands;

global using MechanicService.Application.Features.Mediator.Results.CarBrandResults;
global using MechanicService.Application.Features.Mediator.Queries.CarBrandQueries;
global using MechanicService.Application.Features.Mediator.Commands.CarBrandCommands;

global using MechanicService.Application.Features.Mediator.Results.CarModelResults;
global using MechanicService.Application.Features.Mediator.Queries.CarModelQueries;
global using MechanicService.Application.Features.Mediator.Commands.CarModelCommands;

global using MechanicService.Application.Features.Mediator.Results.FaqResults;
global using MechanicService.Application.Features.Mediator.Queries.FaqQueries;
global using MechanicService.Application.Features.Mediator.Commands.FaqCommands;

global using MechanicService.Application.Features.Mediator.Results.TestimonialResults;
global using MechanicService.Application.Features.Mediator.Queries.TestimonialQueries;
global using MechanicService.Application.Features.Mediator.Commands.TestimonialCommands;

global using MechanicService.Application.Features.Mediator.Results.LocationResults;
global using MechanicService.Application.Features.Mediator.Queries.LocationQueries;
global using MechanicService.Application.Features.Mediator.Commands.LocationCommands;

global using MechanicService.Application.Features.Mediator.Results.PricingResults;
global using MechanicService.Application.Features.Mediator.Queries.PricingQueries;
global using MechanicService.Application.Features.Mediator.Commands.PricingCommands;

global using MechanicService.Application.Features.Mediator.Results.SocialMediaResults;
global using MechanicService.Application.Features.Mediator.Queries.SocialMediaQueries;
global using MechanicService.Application.Features.Mediator.Commands.SocialMediaCommands;

global using MechanicService.Application.Features.Mediator.Results.TeamResults;
global using MechanicService.Application.Features.Mediator.Queries.TeamQueries;
global using MechanicService.Application.Features.Mediator.Commands.TeamCommands;

global using MechanicService.Application.Features.Mediator.Results.BlogResults;
global using MechanicService.Application.Features.Mediator.Queries.BlogQueries;
global using MechanicService.Application.Features.Mediator.Commands.BlogCommands;

global using MechanicService.Application.Features.Mediator.Results.CategoryResults;
global using MechanicService.Application.Features.Mediator.Queries.CategoryQueries;
global using MechanicService.Application.Features.Mediator.Commands.CategoryCommands;

global using MechanicService.Application.Features.Mediator.Results.LocationCityResults;
global using MechanicService.Application.Features.Mediator.Queries.LocationCityQueries;

global using MechanicService.Application.Features.Mediator.Results.LocationDistrictResults;
global using MechanicService.Application.Features.Mediator.Queries.LocationDistrictQueries;
global using MechanicService.Application.Features.Mediator.Commands.LocationDistrictCommands;

global using MechanicService.Application.Features.Mediator.Results.ReservationResults;
global using MechanicService.Application.Features.Mediator.Queries.ReservationQueries;

global using MechanicService.Application.Features.Mediator.Results.ReservationCarResults;
global using MechanicService.Application.Features.Mediator.Queries.ReservationCarQueries;

global using MechanicService.Application.Features.Mediator.Results.ReservationPersonResults;
global using MechanicService.Application.Features.Mediator.Queries.ReservationPersonQueries;

global using MechanicService.Application.Features.Mediator.Results.ReservationServiceResults;
global using MechanicService.Application.Features.Mediator.Queries.ReservationServiceQueries;

global using MechanicService.Application.Features.Mediator.Commands.ReservationCommands;

global using MechanicService.Application.Interfaces.ReservationInterfaces;

// Statistics
global using MechanicService.Application.Features.Mediator.Results.StatisticsResults;
global using MechanicService.Application.Features.Mediator.Queries.StatisticsQueries;
global using MechanicService.Application.Interfaces.StatisticsInterfaces;

global using MechanicService.Application.Features.Mediator.Results.ContactResults;
global using MechanicService.Application.Features.Mediator.Queries.ContactQueries;
global using MechanicService.Application.Features.Mediator.Commands.ContactCommands;

global using MechanicService.Application.Features.Mediator.Results.CustomerResults;
global using MechanicService.Application.Features.Mediator.Queries.CustomerQueries;
