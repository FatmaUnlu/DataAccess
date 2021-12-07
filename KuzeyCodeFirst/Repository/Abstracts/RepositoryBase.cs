using KuzeyCodeFirst.Data;
using KuzeyCodeFirst.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyCodeFirst.Repository.Abstracts
{
    public abstract class RepositoryBase<T, TId> : IRepository<T,TId> where T : BaseEntity, new() //new burda hem baseEntityden kalıtım alsın hem de default constructorı ile de çalışsın anlamına gelir
    {
        protected KuzeyContext _context;
        public DbSet<T> Table { get;protected set; } //tabloları ifade eder Örneğin public Urun urun ifadesi gibi
        protected RepositoryBase()
        {
            _context = new KuzeyContext();
            Table = _context.Set<T>(); //context içerisindeki referanı vermek için kullanıldı.
        }
        public virtual void Add(T entity, bool isSavaLater = false)
        {
            Table.Add(entity);
            if (!isSavaLater)
            {
                this.Save();
            }
        }

        public virtual IQueryable<T> Get(Func<T, bool> predicate = null)
        {
            return predicate == null ? Table : Table.Where(predicate).AsQueryable();
        }
        public virtual IQueryable<T> Get(string[] includes, Func<T, bool> predicate = null) //kategorileri çekerken ürünler de gelsin dşyebiliriz. .INclude lar için bu şekilde kullanılır
        {
            IQueryable<T> query = Table;

            foreach (var include in includes)
            {
                query = Table.Include(include);
            }
            return predicate == null ? query : query.Where(predicate).AsQueryable();
        }

        public virtual T GetById(TId id)//ıd ye göre aramalarda kullanılır.
        {
            return Table.Find(id);
        }

        public virtual void Remove(T entity, bool isSavaLater = false)
        {
            Table.Remove(entity);
            if (!isSavaLater)
            {
                this.Save();
            }
        }

        public virtual int Save()
        {
            return _context.SaveChanges();
        }

        public virtual void Update(T entity, bool isSavaLater = false)
        {
            Table.Update(entity);
            if (!isSavaLater)
            {
                this.Save();
            }
        }
    }
}
