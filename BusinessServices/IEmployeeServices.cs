using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BusinessEntities;

namespace BusinessServices
{
    public interface IEmployeeServices<DTOEntity> : IServices<DTOEntity> where DTOEntity : class
    {
        // add new method definition here, if you want
    }
}
