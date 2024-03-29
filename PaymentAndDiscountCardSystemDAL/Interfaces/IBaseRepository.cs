﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentAndDiscountCardSystem.DAL.Interfaces
{
    public interface IBaseRepository<T> : IEnumerable<T>
    {
        List<T> Entities { get; }

        void Create(T entity);

        Task<T> Get(Guid id);

        Task<List<T>> Select();

        void Delete(T entity);

        Task<T> Update(T entity);

    }
}
