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
    public class AcilServisAlanManager : IAcilServisAlanService
    {
        private IAcilServisAlanRepository _repository;

        public AcilServisAlanManager(IAcilServisAlanRepository repository)
        {
            _repository = repository;
           
        }

        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(AcilServisAlan entity)
        {
            if (Validaton(entity)) { 
            
                _repository.Create(entity);
            }
        }

        public void Delete(AcilServisAlan entity)
        {
            _repository.Delete(entity);
        }

        public List<AcilServisAlan> GetAll()
        {
           return _repository.GetAll();
        }

        public AcilServisAlan GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(AcilServisAlan entity)
        {

            if (Validaton(entity)) { 
                _repository.Update(entity);
            }
        }

        public bool Validaton(AcilServisAlan entity)
        {

            var isValid = true;
            if (entity == null)
            {
                ErrorMessage += "Entity boş geldi";
                isValid = false;
            }
            if (entity.AlanName.Length > 30 || entity.AlanName.Length < 5)
            {
                ErrorMessage += "Hasta adı en az 5 karakter en fazla 30 karakter olmalıdır";
                isValid = false;
            }

            return isValid;
        }
    }
}
