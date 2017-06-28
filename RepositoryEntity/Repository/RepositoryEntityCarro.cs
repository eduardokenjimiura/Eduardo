using RepositoryEntity.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace RepositoryEntity.Repository
{
    /// <summary>
    /// classe com implementação do repositorio específico entityFramework
    /// </summary>
    public class RepositoryEntityCarro : IRepositoryEntityCarro
    {
        #region Propriedades
        /// <summary>
        /// contexto do entity
        /// </summary>
        EntityModelo db = new EntityModelo();
        #endregion

        #region Métodos


        public void Add(CARRO entity)
        {

            db.CARRO.Add(entity);
            db.SaveChanges();

        }

        public IEnumerable<CARRO> All(bool @readonly = false)
        {
            var entidades = db.CARRO.ToList();
            return entidades;
        }

        public void Delete(CARRO entity)
        {

            //   db.CARRO.Remove(entity);
            db.Entry(entity).State = EntityState.Deleted;
            db.SaveChanges();


        }

        public IEnumerable<CARRO> Find(Expression<Func<CARRO, bool>> predicate, bool @readonly = false)
        {
            throw new NotImplementedException();
        }

        public CARRO Get(int id)
        {
            return db.CARRO.Where(_s => _s.ID == id).FirstOrDefault();
        }

        public void Update(CARRO entity)
        {
            db.CARRO.Attach(entity);
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
        #endregion
    }
}
