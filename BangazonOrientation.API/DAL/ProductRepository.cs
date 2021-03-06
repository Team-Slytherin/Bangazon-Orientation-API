﻿using BangazonOrientation.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BangazonOrientation.API.Models;
using System.Data;
using Dapper;

namespace BangazonOrientation.API.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProductRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }
        public void AddProduct(Product newProduct)
        {
            var sql = $@"INSERT into SlytherBang.dbo.Product
                        (ProductName,
                         ProductPrice)
                        VALUES
                        ({newProduct.ProductName},
                         {newProduct.ProductPrice});";
            _dbConnection.Execute(sql);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            var sql = $@"SELECT * FROM SlytherBang.dbo.Product;";
            return _dbConnection.Query<Product>(sql).ToList();
        }

        public Product GetOneProduct(int productId)
        {
            var sql = $@"SELECT *
                        FROM SlytherBang.dbo.Product
                        WHERE ProductId = {productId};";
            var result = _dbConnection.Query<Product>(sql).ToList();
            return result.FirstOrDefault();
        }

        public void UpdateProduct(Product productToUpdate)
        {
            var sql = $@"UPDATE Product
                        SET ProductName = '{productToUpdate.ProductName}',
                            ProductPrice = '{productToUpdate.ProductPrice}'
                        WHERE ProductId = {productToUpdate.ProductId}";
            _dbConnection.Execute(sql);
        }
    }
}