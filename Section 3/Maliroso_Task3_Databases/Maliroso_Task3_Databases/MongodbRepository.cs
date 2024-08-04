using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maliroso_Task3_Databases
{
    public class MongoDbRepository
    {
        private readonly MongoDbContext _db;

        public MongoDbRepository(MongoDbContext db)
        {
            _db = db;
        }

        public void AddCustomer(Customer customer)
        {
            _db.Customers.InsertOne(customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _db.Customers.Find(customer => true).ToList();
        }

        public void UpdateCustomer(Customer customer)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.CustomerId, customer.CustomerId);
            _db.Customers.ReplaceOne(filter, customer);
        }

        public void DeleteCustomer(ObjectId customerId)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.CustomerId, customerId);
            _db.Customers.DeleteOne(filter);
        }
    }

}
