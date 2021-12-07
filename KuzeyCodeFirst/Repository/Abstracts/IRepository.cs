using KuzeyCodeFirst.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuzeyCodeFirst.Repository.Abstracts
{
    public interface  IRepository <T, in TId> where T : BaseEntity //T nin tipiyle ilgili şart yazılır where ile. İn kelimesi TId nin içeride değiştirilmemesini garanti eder. 
    {
        T GetById(TId id); //
        IQueryable<T> Get(Func<T , bool> predicate = null); //predicate null gelirse başka, dolu gelirse başka işlem yapılacak. Datanın nasıl geleceği tutulur IQuarable ile. Liste mi vs.

        void Add(T entity, bool isSavaLater = false); //isSaveLater ifadesi true ise savechange çalıştırılır, false ise çalıştırılmaz. True ise Save diye bir metot olmak zorunda. Tüm kayıtlar eklendiği anda değil de en son kaydedilecek ise bu kullanılır. Örneğin 10 kayıt eklendi 10 u da eklendikten sonra kaydeder. Kullanılamazsa her seferinde kaydetmek gerekecek.

        void Remove(T entity, bool isSavaLater = false);
        void Update(T entity, bool isSavaLater = false);
        int Save();

    }
}
