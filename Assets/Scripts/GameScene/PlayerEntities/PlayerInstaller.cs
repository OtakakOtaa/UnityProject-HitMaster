using GameScene.PlayerEntities.View;
using Zenject;

namespace GameScene.PlayerEntities
{
    public class PlayerInstaller : MonoInstaller
    {
        private readonly string _playerPrefabPath = "Player";
    
        public override void InstallBindings()
        {
            var player = Container.InstantiatePrefabResource(_playerPrefabPath).GetComponent<PlayerView>();
            Container.Bind<PlayerView>().FromInstance(player);
            Container.BindInterfacesAndSelfTo<PlayerService>().AsSingle().NonLazy();
        }
    }
}