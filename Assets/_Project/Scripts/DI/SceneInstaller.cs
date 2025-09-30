using _Project.Scripts.Services;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.DI
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelBoundsProvider _levelBoundsProvider;

        public override void InstallBindings()
        {
            Container
                .Bind<ILevelBoundsProvider>()
                .To<LevelBoundsProvider>()
                .FromInstance(_levelBoundsProvider);
        }
    }
}