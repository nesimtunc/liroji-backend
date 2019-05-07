using System;
using System.Collections.Generic;
using DataAccess.Entities;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly IMongoCollection<T> _db;

        public Repository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("mongodb"));
            var database = client.GetDatabase("liroji");
            _db = database.GetCollection<T>(typeof(T).Name.ToLower());
        }


        public T Create(T entity)
        {
            _db.InsertOne(entity);
            return entity;
        }

        public void Delete(string id)
        {
            var item = GetById(id);
            item.IsDeleted = true;
            Update(item);
            // db.FindOneAndDelete(i => i.Id == id); // will delete from db
        }

        public IEnumerable<T> GetAll()
        {
            return _db.Find(item => item.IsDeleted == false).ToList();
        }

        public T GetById(string id)
        {
            return _db.Find(item => item.IsDeleted == false && item.Id == id).First();
        }

        public void Update(T entity)
        {
            _db.FindOneAndReplace(item => item.Id == entity.Id, entity);
        }
    }
}
