using _Project.Scripts.Configs;
using _Project.Scripts.Entities;
using _Project.Scripts.Entities.Animals;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.Services
{
    public class SpawnService : ITickable
    {
        private readonly SpawnConfig _spawnConfig;
        private readonly RngService _rngService;
        private readonly IAnimalFactory _animalFactory;
        private float _timer;
        private readonly bool _initialized;

        public SpawnService(IAnimalFactory factory, SpawnConfig spawnConfig, RngService rngService)
        {
            _animalFactory = factory;
            _spawnConfig = spawnConfig;
            _rngService = rngService;
            _timer = _spawnConfig.SpawnInterval;
            _initialized = true;
        }

        private void SpawnAnimal()
        {
            var value = _rngService.Roll();
            var animalToSpawn = value > 0.5f ? typeof(Frog) : typeof(Snake);
            _animalFactory.CreateAnimal(animalToSpawn);
            _timer += _spawnConfig.SpawnInterval;
        }

        public void Tick()
        {
            if (!_initialized) return;
            _timer -= Time.deltaTime;
            if (_timer > 0) return;
            SpawnAnimal();
        }
    }
}