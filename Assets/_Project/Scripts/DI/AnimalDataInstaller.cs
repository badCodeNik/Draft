using _Project.Scripts.AnimalsConfigs;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.DI
{
    public class AnimalDataInstaller : MonoInstaller
    {
        [SerializeField] private AnimalData[] _animalData;

        public override void InstallBindings()
        {
            foreach (var data in _animalData)
            {
                Container.BindInstance(data).AsSingle();
            }
        }
    }
}