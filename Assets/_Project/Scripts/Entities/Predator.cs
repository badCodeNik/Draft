using _Project.Scripts.Entities.Interfaces;

namespace _Project.Scripts.Entities
{
    public abstract class Predator : Animal, IEater
    {
        public abstract void Eat(Animal animal);
    }
}