﻿using interworks_assignment.Models.CustomerManagement;
using interworks_assignment.Models.DiscountManagement;

namespace interworks_assignment.Repositories
{
    public interface IDiscountRepository:IRepository<Discount>
    {
        public void DeleteDiscount(int id);
    }
}
