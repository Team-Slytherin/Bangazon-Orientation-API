﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using BangazonOrientation.API.Interfaces;
using BangazonOrientation.API.Models;
using Dapper;

namespace BangazonOrientation.API.DAL
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly IDbConnection _dbConnection;
        public CustomerRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }
        public void AddNewCustomer(Customer newCustomer)
        {
            var sql = @"INSERT into SlytherBang.dbo.Customer 
                        (CustomerName,
                         CustomerStreetAddress,
                         CustomerCity,
                         CustomerState,
                         CustomerZip, 
                         CustomerPhone)
                        Values
                        (@CustomerName,
                         @CustomerStreetAddress,
                         @CustomerCity,
                         @CustomerState,
                         @CustomerZip, 
                         @CustomerPhone);";
            _dbConnection.Execute(sql, newCustomer);
        }

        public void EditCustomer(Customer editingCustomer)
        {
            throw new NotImplementedException();
        }

        public Customer GetSingleCustomer(int customerId)
        {
            var sql = $@"SELECT *
                        FROM SlytherBang.dbo.Customer
                        WHERE CustomerId = {customerId};";

            var result =_dbConnection.Query<Customer>(sql).ToList();

            return result.FirstOrDefault();
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var sql = $@"SELECT * FROM SlytherBang.dbo.Customer;";

            return _dbConnection.Query<Customer>(sql).ToList();

        }
    }
}