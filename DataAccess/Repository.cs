using System;
using System.Collections.Generic;
using DataAccess.Entities;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {

        private readonly IMongoCollection<T> db;

        public Repository(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("mongodb"));
            var database = client.GetDatabase("liroji");
            db = database.GetCollection<T>(typeof(T).Name.ToLower());
        }


        public T Create(T entity)
        {
            db.InsertOne(entity);
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
            return db.Find(item => item.IsDeleted == false).ToList();
        }

        public T GetById(string id)
        {
            return db.Find(item => item.IsDeleted == false && item.Id == id).First();
        }

        public void Update(T entity)
        {
            db.FindOneAndReplace(item => item.Id == entity.Id, entity);
        }
    }
}
