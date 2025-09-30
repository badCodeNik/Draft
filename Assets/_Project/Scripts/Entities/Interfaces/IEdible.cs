using System;

namespace _Project.Scripts.Entities.Interfaces
{
    public interface IEdible
    {
        event Action<Animal> OnEaten;
        void BeEaten();
    }
}