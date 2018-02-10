﻿using AutoMapper;
using CoreTemplate.Accessors.Interfaces;
using CoreTemplate.Accessors.Models.DTO;
using CoreTemplate.Managers.Interfaces;
using CoreTemplate.ViewModels.Genre;
using System.Collections.Generic;

namespace CoreTemplate.Managers.Managers
{
    public class GenreManager : IGenreManager
    {
        private IGenreAccessor _genreAccessor;

        public GenreManager(IGenreAccessor genreAccessor)
        {
            _genreAccessor = genreAccessor;
        }

        public GenreViewModel Get(int? id)
        {
            var dto = id.HasValue ? _genreAccessor.Get(id.Value) : new GenreDTO();
            var vm = Mapper.Map<GenreViewModel>(dto);

            return vm;
        }

        public GenresViewModel GetAll()
        {
            var dtos = _genreAccessor.GetAll();
            var vms = Mapper.Map<List<GenreViewModel>>(dtos);

            return new GenresViewModel { Genres = vms };
        }

        public GenreViewModel Save(GenreViewModel vm)
        {
            var dto = Mapper.Map<GenreDTO>(vm);
            dto = _genreAccessor.Save(dto);
            vm = Mapper.Map<GenreViewModel>(dto);

            return vm;
        }

        public GenreViewModel Delete(int id)
        {
            var dto = _genreAccessor.Delete(id);
            var vm = Mapper.Map<GenreViewModel>(dto);

            return vm;
        }
    }
}