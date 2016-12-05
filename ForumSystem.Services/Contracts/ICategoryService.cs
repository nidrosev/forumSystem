﻿using ForumSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumSystem.Services.Contracts
{
    public interface ICategoryService
    {
        IQueryable<Category> GetAll();
        void Add(Category entity);
        void Update(Category entity);
        void Delete(object id);
        Category Find(object Id);
    }
}
