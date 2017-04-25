using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BangazonOrientation.API.Interfaces;
using BangazonOrientation.API.Interfaces.Repository;
using BangazonOrientation.API.Models;
using System.Data;
using Dapper;

namespace BangazonOrientation.API.DAL.Repository
{
    public class LineItemsRepository : ILineItemsRepository
    {
        private readonly IDbConnection _dbConnection;

        public LineItemsRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public List<LineItem> GetLineItem(int lineItemId)
        {   
            var sql = $@"select CartDetailId as LineItemDetailId, CartId as LineItemId, Qty, ProductId from SlytherBang.dbo.CartDetail where CartDetailId = {lineItemId}";

            return _dbConnection.Query<LineItem>(sql).ToList();
        }

        public List<LineItem> GetAllLineItemsInCart(int cartId)
        {
            var sql = $@"select CartDetailId as LineItemDetailId, CartId as LineItemId, Qty, ProductId from SlytherBang.dbo.CartDetail where CartId = {cartId}";

            return _dbConnection.Query<LineItem>(sql).ToList();
        }

        public bool EditLineItem(LineItem lineItem)
        {
            // check that LineItemDetailId exist
            var result = GetLineItem(lineItem.LineItemDetailId);
            if (result.Count == 0)
            {
                return false;
            }
            var sql = $@"Update SlytherBang.dbo.CartDetail Set Qty = {lineItem.Qty}, CartId = {lineItem.LineItemId}, ProductId = {lineItem.ProductId} Where CartDetailId = {lineItem.LineItemDetailId}";

            _dbConnection.Execute(sql, lineItem);
            return true;
        }

        public void AddLineItem(LineItem lineItem)
        {
                                                                                                              
            var sql = $@"INSERT into SlytherBang.dbo.CartDetail(CartId, Qty, ProductId) Values({lineItem.LineItemId}, {lineItem.Qty}, {lineItem.ProductId})";

            _dbConnection.Execute(sql, lineItem);
        }
    }
}