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
    public class DoktorManager : IDoktorService
    {   
        private IDoktorRepository _repository;
        public DoktorManager(IDoktorRepository repository)
        {
            _repository = repository;
        }
        public string ErrorMessage { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(Doktor entity)
        {
            if (Validaton(entity))
            {
                _repository.Create(entity);
            }
        }

        public void Delete(Doktor entity)
        {
            if (Validaton(entity))
            {
                _repository.Delete(entity);
            }
        }

        public List<Doktor> GetAll()
        {
            return _repository.GetAll();
        }

        public Doktor GetById(int id)
        {
            return _repository.GetById(id); 
        }

        public void Update(Doktor entity)
        {
            if (Validaton(entity))
            {
                _repository.Update(entity);
            }
        }

        public bool Validaton(Doktor entity)
        {
            var isValid = true;
            if (entity==null) {
                ErrorMessage += "Entity boş geldi";
                isValid = false;
            }
            if(entity.DoktorFUllname.Length>30 || entity.DoktorFUllname.Length < 5)
            {
                ErrorMessage += "Doktor adı en az 5 karakter en fazla 30 karakter olmalıdır";
                isValid = false;
            }
            if (entity.AlanId == null)
            {
                ErrorMessage += "Doktorun Çalıştırğı servis boş olamaz ";
            }


            return isValid;
        }
    }
}
