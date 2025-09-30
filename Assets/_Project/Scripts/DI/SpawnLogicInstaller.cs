using _Project.Scripts.Services;
using Zenject;

namespace _Project.Scripts.DI
{
    public class SpawnLogicInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<AnimalFactory>().AsSingle();
            Container.BindInterfacesAndSelfTo<SpawnService>().AsSingle().NonLazy();
        }
    }
}