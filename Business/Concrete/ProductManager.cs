using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Result;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Core.Aspects.Validation;
using System.Transactions;
using Core.Autofac.Transaction;
using Core.Autofac.Caching;
using Business.BusinessAspects.Autofac;
using Core.Autofac.Performance;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Autofac.Logging;


namespace Business.Concrete
{
    public class ProductManager : IProductService
    {

        private IProductDal _productDal;


        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        //bu ifade bize ef ile calısıtıgımız senaryoda diyelim ef i degistirmek istdgimizde yada 2 tanesini aynı anda kullanmak istedigimizde her seferinde degistrimemek için yazdıımız bir sey

        //biz yukarda productDal'ı _productDal'a ekledik ve asagıda kullandık 
        //olası bi degisimde sadece yukardaki atama'yı degistiricez ve bitecek


        [ValidationAspects(typeof(ProductValidator))] // Bu ifade, ProductValidator sınıfını kullanarak Product nesnesinin doğrulamasını yapar.
        [CacheRemoveAspect(pattern: "IProductService.Get")] // Bu ifade, IProductService.Get metodu çağrıldığında cache'i temizler.
        public IResult Add(Product product)
        {
            IResult result = CheckIfProductNameExist(product.ProductName);
            if (result != null)
            {
                return result; // Eğer ürün adı zaten varsa, bu sonucu döner.
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
        private IResult CheckIfProductNameExist(string productName)
        {
            if (_productDal.Get(p => p.ProductName == productName) != null)
            {
                return new SuccessResult();
            }
            return null;
        }// Bu metot, ürün adının veritabanında zaten var olup olmadığını kontrol eder. Eğer varsa, başarılı bir sonuç döner; yoksa null döner.

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }


        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }


        [SecuredOperation("product.list,admin")] // Bu ifade, sadece "product.list" veya "admin" rolüne sahip kullanıcıların bu metodu çağırabilmesini sağlar.
        [CacheAspect(duration: 1)]
        [LogAspect(typeof(FileLogger))] // Bu ifade, metot çağrıldığında loglama işlemini gerçekleştirir.
        public IDataResult<List<Product>> GetByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(filter: p => p.CategoryId == categoryId).ToList());
        }


        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        [PerformanceAspect(interval: 5)] // Bu ifade, metot performansını ölçer ve 5 saniyeden uzun süren işlemler için uyarı verir.
        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList().ToList());
        }


        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductUpdated);

        }
    }
}
