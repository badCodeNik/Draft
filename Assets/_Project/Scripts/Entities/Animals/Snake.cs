using System;
using _Project.Scripts.AnimalsConfigs.PredatorData;
using _Project.Scripts.Entities.Interfaces;
using _Project.Scripts.Movement;
using _Project.Scripts.Services;
using UnityEngine;

namespace _Project.Scripts.Entities.Animals
{
    public class Snake : Predator, IMovable, IEdible
    {
        private SnakeData _snakeData;

        public override void Eat(Animal animal)
        {
            var edible = animal as IEdible;
            edible?.BeEaten();
        }

        public Transform Transform => transform;
        public Vector3 Direction { get; set; } = Vector3.forward;
        public Vector3 Position => transform.position;
        public IMovementStrategy MovementStrategy { get; private set; }

        public override void Init(CollisionMediator collisionMediator)
        {
            base.Init(collisionMediator);
            _snakeData = AnimalData as SnakeData;
            MovementStrategy = new LinearMovementStrategy(_snakeData.Speed);
        }

        public event Action<Animal> OnEaten;

        public void BeEaten()
        {
            OnEaten?.Invoke(this);
        }
    }
}