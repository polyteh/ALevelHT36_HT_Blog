using BlogDAL.Repository;
using System.Collections.Generic;

namespace BlogBL
{
    public interface IGenereicService<BLModel>
        where BLModel : class
       
    {
        BLModel FindById(int id);
        IEnumerable<BLModel> GetAll();
        void AddItem(BLModel newBLModel);
        void Update(BLModel updateItem);
        void Delete(BLModel deleteItem);
    }

    public abstract class GenericService<BLModel, DModel> : IGenereicService<BLModel>
        where BLModel : class
        where DModel : class
    {
        private readonly IGenericRepository<DModel> _repositroy;
        public GenericService(IGenericRepository<DModel> repository)
        { 
            _repositroy = repository;
        }

        public void AddItem(BLModel newBLModel)
        {
            DModel newDLModel = Map(newBLModel);
            _repositroy.Create(newDLModel);
        }

        public void Delete(BLModel deleteItem)
        {
            DModel deleteDLModel = Map(deleteItem);
            _repositroy.Remove(deleteDLModel);
        }

        public virtual BLModel FindById(int id)
        {
            var entity = _repositroy.FindById(id);
            return Map(entity);
        }

        public IEnumerable<BLModel> GetAll()
        {
            var listEntity = _repositroy.Get();           
            return Map(listEntity);
        }

        /// <summary>
        /// convert Dal model to Bl molder
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract BLModel Map(DModel entity);
        public abstract DModel Map(BLModel blmodel);

        public abstract IEnumerable<BLModel> Map(IList<DModel> entity);
        public abstract IEnumerable<DModel> Map(IList<BLModel> entity);

        public void Update(BLModel updateBLItem)
        {
            DModel updateDLModel = Map(updateBLItem);
            _repositroy.Update(updateDLModel);
        }
    }
}
