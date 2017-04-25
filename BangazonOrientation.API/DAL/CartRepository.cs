﻿using BangazonOrientation.API.Interfaces;
using BangazonOrientation.API.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BangazonOrientation.API.DAL
{
    public class CartRepository : ICartRepository
    {
        IDbConnection _bangzonConnection;

        public CartRepository()
        {
            _bangzonConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SlytherBangConnection"].ConnectionString);
        }
        public CartRepository(IDbConnection connection)
        {
            _bangzonConnection = connection;
        }

        public void AddCart(int customerId)
        {
            var sql = @"insert into Cart(CustomerId, Active) values(@customerId, '1')";
            _bangzonConnection.Execute(sql, customerId);
        }

        public Cart GetActiveCart(int customerId)
        {
            var sql = @"SELECT CartId, CustomerId, PaymentId, Active 
                        FROM Cart 
                        WHERE CustomerId = @customerId AND Active = '1'";
            return (Cart)_bangzonConnection.Query(sql, customerId);
        }

        public void EditCartStatus(int cartId, int paymentId)
        {
            var sql = @"UPDATE Cart
                        SET PaymentId = @paymentId, Active = '0'
                        WHERE CartId = @cartId";
            _bangzonConnection.Execute(sql, new { paymentId, cartId });
        }

        public void EmptyCart(int customerId)
        {
            var sql=
            @" DELETE cdt
                FROM SlytherBang.dbo.Customer cust
                JOIN SlytherBang.dbo.Cart cart
                    ON cust.CustomerId = cart.CustomerId
                JOIN SlytherBang.dbo.CartDetail cdt
                    ON cart.CartId = cdt.CartId
                WHERE Active = '1'
                    AND cust.CustomerId = @customerId";
            _bangzonConnection.Execute(sql, customerId);
        }
    }
}