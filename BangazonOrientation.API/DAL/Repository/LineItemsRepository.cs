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

        public List<LineItem> GetLineItem(int lineItemDetailsId)
        {   
            var sql = $@"select CartDetailId as LineItemDetailId, CartId as LineItemId, Qty, ProductId from SlytherBang.dbo.CartDetail where CartId = {lineItemDetailsId}";

            return _dbConnection.Query<LineItem>(sql).ToList();
        }

        public IEnumerable<LineItem> GetAllLineItems(int cartId)
        {
            throw new NotImplementedException();
        }

        public void EditLineItem()
        {
            throw new NotImplementedException();
        }

        public void AddLineItem(LineItem lineItem)
        {
                                                                                                              
            var sql = $@"INSERT into SlytherBang.dbo.CartDetail(CartId, Qty, ProductId) Values({lineItem.LineItemId}, {lineItem.Qty}, {lineItem.ProductId})";

            _dbConnection.Execute(sql, lineItem);

            //return _dbConnection.Query<LineItem>(sql).ToList();
        }
    }
}