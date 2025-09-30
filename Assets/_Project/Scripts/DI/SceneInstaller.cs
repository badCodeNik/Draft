using _Project.Scripts.Movement;
using _Project.Scripts.Services;
using _Project.Scripts.UI;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.DI
{
    public class SceneInstaller : MonoInstaller
    {
        [SerializeField] private LevelBoundsProvider _levelBoundsProvider;
        [SerializeField] private UIService _uiService;

        public override void InstallBindings()
        {
            Container.Bind<RngService>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIService>()
                .FromInstance(_uiService)
                .AsSingle();
            Container
                .Bind<ILevelBoundsProvider>()
                .To<LevelBoundsProvider>()
                .FromInstance(_levelBoundsProvider);
            Container.BindInterfacesAndSelfTo<MovementSystem>().AsSingle();
            Container.Bind<CollisionMediator>().AsSingle();
        }
    }
}