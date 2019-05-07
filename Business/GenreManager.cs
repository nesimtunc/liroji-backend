using System;
using System.Collections.Generic;
using Business.Models;
using Microsoft.Extensions.Configuration;

namespace Business
{
    public class GenreManager: IManager<Genre>
    {

        private readonly DataAccess.Repository<DataAccess.Entities.Genre> _repository;

        public GenreManager(IConfiguration config)
        {
            _repository = new DataAccess.Repository<DataAccess.Entities.Genre>(config);
        }

        public Genre Create(Genre model)
        {
            if (model.CreatedBy == null)
            {
                throw new Exception("Needs user Id");
            }
            if (model.Name == null)
            {
                throw new Exception("Needs model name");
            }
            DataAccess.Entities.Genre entity = new DataAccess.Entities.Genre()
            {
                Name = model.Name,
                CreatedBy = model.CreatedBy
            };
            _repository.Create(entity);
            model.Id = entity.Id;
            model.CreatedAt = entity.CreatedAt;
            return model;
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            var entities = _repository.GetAll();
            List<Genre> models = new List<Genre>();
            foreach (var item in entities)
            {
                models.Add(new Genre
                {
                    Id = item.Id,
                    Name = item.Name,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy
                });
            }
            return models;
        }

        public Genre GetById(string id)
        {
            var genre = _repository.GetById(id);
            return new Genre
            {
                Id = genre.Id,
                Name = genre.Name,
                CreatedAt = genre.CreatedAt,
                CreatedBy = genre.CreatedBy
            };
        }

        public void Update(Genre model)
        {
            DataAccess.Entities.Genre entity = new DataAccess.Entities.Genre
            {
                Id = model.Id,
                Name = model.Name,
                CreatedAt = model.CreatedAt,
                CreatedBy = model.CreatedBy
            };
            _repository.Update(entity);
        }
    }
}
