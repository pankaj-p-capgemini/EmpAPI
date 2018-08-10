using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Transactions;
using BusinessEntities;
using DataModel;
using DataModel.UnitOfWork;
using DataModel.Repositories;

namespace BusinessServices
{
    public abstract class BaseServices<DTOEntity, UOW> : IServices<DTOEntity> where DTOEntity : class where UOW : EmployeeUOW, new()
    {
        private UOW _unitOfWork = new UOW();
        public UOW UnitOfWork
        {
            get { return _unitOfWork; }
            set { _unitOfWork = value; }
        }

        public BaseServices()
        {

        }

        /// <summary>
        /// Fetches product details by id
        /// </summary>
        /// <param name="pkid"></param>
        /// <returns></returns>
        public DTOEntity FindByID(int pkid)
        {
            var entity = _unitOfWork.EmployeeRepository.GetByID(pkid);
            if (entity != null)
            {
                Mapper.CreateMap<Product, ProductEntity>();
                var productModel = Mapper.Map<Product, DTOEntity>(entity);
                return productModel;
            }
            return null;
        }

        /// <summary>  
        /// Fetches all the products.  
        /// </summary>  
        /// <returns></returns>  
        public IEnumerable<BusinessEntities.ProductEntity> GetAllProducts()
        {
            var products = _unitOfWork.EmployeeRepository.GetAll().ToList();
            if (products.Any())
            {
                Mapper.CreateMap<Product, ProductEntity>();
                var productsModel = Mapper.Map<List<Product>, List<ProductEntity>>(products);
                return productsModel;
            }
            return null;
        }

        /// <summary>  
        /// Creates a product  
        /// </summary>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public int CreateProduct(BusinessEntities.ProductEntity productEntity)
        {
            using (var scope = new TransactionScope())
            {
                var product = new Product
                {
                    ProductName = productEntity.ProductName
                };
                _unitOfWork.EmployeeRepository.Insert(product);
                _unitOfWork.Save();
                scope.Complete();
                return product.pkid;
            }
        }

        /// <summary>  
        /// Updates a product  
        /// </summary>  
        /// <param name="pkid"></param>  
        /// <param name="productEntity"></param>  
        /// <returns></returns>  
        public bool UpdateProduct(int pkid, BusinessEntities.ProductEntity productEntity)
        {
            var success = false;
            if (productEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.EmployeeRepository.GetByID(pkid);
                    if (product != null)
                    {
                        product.ProductName = productEntity.ProductName;
                        _unitOfWork.EmployeeRepository.Update(product);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        /// <summary>  
        /// Deletes a particular product  
        /// </summary>  
        /// <param name="pkid"></param>  
        /// <returns></returns>  
        public bool DeleteProduct(int pkid)
        {
            var success = false;
            if (pkid > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var product = _unitOfWork.EmployeeRepository.GetByID(pkid);
                    if (product != null)
                    {

                        _unitOfWork.EmployeeRepository.Delete(product);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
