using _Project.Scripts.Configs;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.DI
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private SpawnConfig _spawnConfig;
        [SerializeField] private AnimalRegistry _animalRegistry;

        public override void InstallBindings()
        {
            Container.BindInstance(_spawnConfig).AsSingle();
            Container.BindInstance(_animalRegistry).AsSingle();
        }
    }
}