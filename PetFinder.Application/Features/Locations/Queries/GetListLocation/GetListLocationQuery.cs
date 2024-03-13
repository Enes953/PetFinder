using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using PetFinder.Application.Features.Locations.Models;
using PetFinder.Application.Services.Repositories;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;

namespace PetFinder.Application.Features.Locations.Queries.GetListLocation
{
    public class GetListLocationQuery:IRequest<LocationListModel>
    {
        public PageRequest PageRequest { get; set; }
    }
    public class GetListLocationQueryHandler : IRequestHandler<GetListLocationQuery, LocationListModel>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;

        public GetListLocationQueryHandler(IMapper mapper, ILocationRepository locationRepository)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
        }

        public async Task<LocationListModel> Handle(GetListLocationQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Location> locations = await _locationRepository.GetListAsync(
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize);
            LocationListModel mappedLocationListModel = _mapper.Map<LocationListModel>(locations);

            return mappedLocationListModel;
        }
    }
}
