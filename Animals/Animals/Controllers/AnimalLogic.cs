using Animals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals.Controllers
{
    public class AnimalLogic
    {
        private AnimalContext _animalDbContext = new AnimalContext();
        public List<Animal>GetAll()
        {
            using (_animalDbContext=new AnimalContext())
            {
                List<Animal>listAnimal=_animalDbContext.Animals.ToList();
                return listAnimal;
            }
        }
        public void Create(Animal animal)
        {
            using (_animalDbContext = new AnimalContext())
            {
                _animalDbContext.Animals.Add(animal);
                _animalDbContext.SaveChanges();
            }


        }
        public Animal Get(int id)
        {
            using (_animalDbContext = new AnimalContext())
            {
                Animal findedAnimal = _animalDbContext.Animals.Find(id);
                if (findedAnimal !=null)
                {
                    _animalDbContext.Entry(findedAnimal).Reference(x=>x.Breeds).Load();                 
                }
                return findedAnimal;

            }
        }
        public void Update(int id, Animal newAnimal)
        {
            using (_animalDbContext=new AnimalContext())
            {
                Animal findedAnimal = _animalDbContext.Animals.Find(id);
                if (findedAnimal==null)
                {
                    return;
                }
                findedAnimal.Name = newAnimal.Name;
                findedAnimal.Age=newAnimal.Age;
                findedAnimal.BreedId=newAnimal.BreedId;
                _animalDbContext.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            using (_animalDbContext=new AnimalContext())
            {
                Animal findedAnimal = _animalDbContext.Animals.Find(id);
                _animalDbContext.Animals.Remove(findedAnimal);
                _animalDbContext.SaveChanges();

            }
        }
    }
}
