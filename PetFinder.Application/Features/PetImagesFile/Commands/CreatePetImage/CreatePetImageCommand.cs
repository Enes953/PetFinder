using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using PetFinder.Application.Abstractions.Storage;
using PetFinder.Application.Features.PetImagesFile.Dtos;
using PetFinder.Application.Services.Repositories;
using PetFinder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetFinder.Application.Features.PetImagesFile.Commands.CreatePetImage
{
    public class CreatePetImageCommand : IRequest<CreatedPetImageDto>
    {
        public string Id { get; set; }
        public IFormFileCollection? Files { get; set; }

        public class CreatePetImageCommandHandler : IRequestHandler<CreatePetImageCommand, CreatedPetImageDto>
        {
            IPetRepository _petRepository;
            IPetImageFileRepository _petImageFileRepository;
            IStorageService _storageService;
            IMapper _mapper;

            public CreatePetImageCommandHandler(IPetRepository petRepository, IPetImageFileRepository petImageFileRepository, IStorageService storageService, IMapper mapper)
            {
                _petRepository = petRepository;
                _petImageFileRepository = petImageFileRepository;
                _storageService = storageService;
                _mapper = mapper;
            }

            public async Task<CreatedPetImageDto> Handle(CreatePetImageCommand request, CancellationToken cancellationToken)
            {
                List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);

                Pet pet = await _petRepository.GetByIdAsync(request.Id);
                await _petImageFileRepository.AddRangeAsync(result.Select(r => new PetImageFile
                {
                    FileName = r.fileName,
                    FilePath = r.pathOrContainerName,
                    Storage = _storageService.StorageName,
                    Pets = new List<Pet>() { pet }
                }).ToList());
                await _petImageFileRepository.SaveAsync();
                return new();
            }
        }
    }  
}
