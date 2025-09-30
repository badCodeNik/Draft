using System;
using _Project.Scripts.Entities.Interfaces;

namespace _Project.Scripts.Entities
{
    public abstract class Prey : Animal, IEdible
    {
        public event Action<Animal> OnEaten;

        public abstract void JumpAway();
        public void BeEaten()
        {
            OnEaten?.Invoke(this);
        }
    }
}