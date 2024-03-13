using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
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

namespace PetFinder.Application.Features.Locations.Queries.GetListLocaitonByDynamic
{
    public class GetListLocationByDynamicQuery : IRequest<LocationListModel>
    {
        public PageRequest PageRequest { get; set; }
        public Dynamic Dynamic { get; set; }
    }
    public class GetListLocationByDynamicQueryHandler : IRequestHandler<GetListLocationByDynamicQuery, LocationListModel>
    {
        private readonly IMapper _mapper;
        private readonly ILocationRepository _locationRepository;

        public GetListLocationByDynamicQueryHandler(IMapper mapper, ILocationRepository locationRepository)
        {
            _mapper = mapper;
            _locationRepository = locationRepository;
        }

        public async Task<LocationListModel> Handle(GetListLocationByDynamicQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Location> locations = await _locationRepository.GetListByDynamicAsync(request.Dynamic,
                                              index: request.PageRequest.Page,
                                              size: request.PageRequest.PageSize);
            LocationListModel mappedLocationListModel = _mapper.Map<LocationListModel>(locations);

            return mappedLocationListModel;
        }
    }
}
