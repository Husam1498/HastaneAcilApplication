using Bussiness.Abstract;
using DataAccess.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.Concrete
{
    public class HastaManager : IHastaService
    {
        private IHastaRepository _repository;

        public HastaManager(IHastaRepository repository)
        {
            _repository = repository;
           
        }

        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(Hasta entity)
        {
            if (Validaton(entity)) { 
            
                _repository.Create(entity);
            }

        }

        public void Delete(Hasta entity)
        {
            if (Validaton(entity))
            {

                _repository.Delete(entity);
            }
        }

        public List<Hasta> GetAll()
        {
           return _repository.GetAll();
        }

        public Hasta GetById(int id)
        {
           return _repository.GetById(id);
        }

        public void Update(Hasta entity)
        {
            if (Validaton(entity))
            {
                _repository.Update(entity);
            }
        }

        public bool Validaton(Hasta entity)
        {

            var isValid = true;
            if (entity == null)
            {
                ErrorMessage += "Entity boş geldi";
                isValid = false;
            }
            if (entity.HastaFullname.Length > 30 || entity.HastaFullname.Length < 5)
            {
                ErrorMessage += "Hasta adı en az 5 karakter en fazla 30 karakter olmalıdır";
                isValid = false;
            }
           
            return isValid;
        }
    }
}
