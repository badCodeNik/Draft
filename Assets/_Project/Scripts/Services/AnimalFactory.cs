using System;
using System.Collections.Generic;
using _Project.Scripts.Configs;
using _Project.Scripts.Entities;
using _Project.Scripts.Entities.Interfaces;
using _Project.Scripts.Movement;
using _Project.Scripts.UI;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Project.Scripts.Services
{
    public interface IAnimalFactory
    {
        void CreateAnimal(Type type);
    }

    public class AnimalFactory : IAnimalFactory
    {
        private readonly Dictionary<Type, Queue<Animal>> _pools = new();
        private readonly Dictionary<Type, Animal> _prefabs = new();
        private readonly int _poolSize = 10;

        private readonly MovementSystem _movementSystem;
        private readonly AnimalRegistry _registry;
        private readonly CollisionMediator _collisionMediator;
        private readonly ILevelBoundsProvider _levelBoundsProvider;
        private readonly IUIService _uiService;

        public AnimalFactory(MovementSystem movementSystem, AnimalRegistry registry,
            CollisionMediator collisionMediator, ILevelBoundsProvider levelBoundsProvider, IUIService uiService)
        {
            _movementSystem = movementSystem;
            _registry = registry;
            _collisionMediator = collisionMediator;
            _levelBoundsProvider = levelBoundsProvider;
            _uiService = uiService;

            InitializePools();
        }

        private void InitializePools()
        {
            foreach (var type in _registry.GetAllTypes())
            {
                if (_registry.TryGetAnimal(type, out var prefab))
                {
                    _prefabs[type] = prefab;
                    _pools[type] = new Queue<Animal>();

                    for (int i = 0; i < _poolSize; i++)
                    {
                        var instance = Object.Instantiate(prefab);
                        instance.gameObject.SetActive(false);
                        _pools[type].Enqueue(instance);
                    }
                }
            }
        }


        public void CreateAnimal(Type type)
        {
            Animal animalInstance;

            if (_pools.TryGetValue(type, out var pool) && pool.Count > 0)
            {
                animalInstance = pool.Dequeue();
            }
            else
            {
                if (_prefabs.TryGetValue(type, out var prefab))
                {
                    animalInstance = Object.Instantiate(prefab);
                }
                else
                {
                    Debug.LogError($"Prefab for {type} not found!");
                    return;
                }
            }

            if (animalInstance is Predator) _uiService.IncrementPredatorsCount();
            SetupAnimal(animalInstance);
        }

        private void SetupAnimal(Animal animalInstance)
        {
            var position = _levelBoundsProvider.GetRandomPositionOnFloor();
            animalInstance.transform.position = position;
            animalInstance.transform.rotation = Quaternion.identity;
            animalInstance.gameObject.SetActive(true);

            animalInstance.Init(_collisionMediator);

            if (animalInstance is IMovable movable)
                _movementSystem.Register(movable);
            if (animalInstance is IEdible edible)
                edible.OnEaten += ReturnToPool;
        }

        private void ReturnToPool(Animal animal)
        {
            var type = animal.GetType();
            if (animal is Predator) _uiService.DecrementPredatorsCount();
            if (animal is Prey) _uiService.IncrementDeadPreyCount();
            if (animal is IMovable movable)
                _movementSystem.Unregister(movable);
            if (animal is IEdible edible)
                edible.OnEaten -= ReturnToPool;

            animal.gameObject.SetActive(false);

            if (_pools.TryGetValue(type, out var pool))
            {
                pool.Enqueue(animal);
            }
            else
            {
                Object.Destroy(animal.gameObject);
            }
        }
    }
}