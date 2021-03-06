﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStoreRepository;

namespace OnlineStoreService
{
    public interface ITypeService : IBaseService
    {
        string GetTypeName(int id);
    }

    public class TypeService : BaseService, ITypeService 
    {
        private ITypesRepository _typesRepository;

        public TypeService(ITypesRepository typesRepository)
        {
            _typesRepository = typesRepository;
        }

        public string GetTypeName(int id)
        {
            return _typesRepository.Get(id).Name;
        }
    }
}
