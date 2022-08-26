using UnityEngine;
using Zenject;

namespace GameScene.EnemyEntities
{
    public class EnemyInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _meleeEnemyPrefab;
        [SerializeField] private GameObject _rangeEnemyPrefab;

        public override void InstallBindings()
        {
            Container.BindFactory<EnemyType, IEnemy, EnemyFactory>().FromFactory<EnemyFactory.Custom>();
            
            Container.BindInterfacesAndSelfTo<EnemyMelee>().FromSubContainerResolve()
                .ByNewPrefabInstaller<EnemyMeleeInstaller>(_meleeEnemyPrefab)
                .AsTransient();
            Container.BindInterfacesAndSelfTo<EnemyRange>().FromSubContainerResolve().
                ByNewPrefabInstaller<EnemyRangeInstaller>(_rangeEnemyPrefab)
                .AsTransient();
        }
    }

    public class EnemyRangeInstaller : Installer
    {
        public override void InstallBindings()
        {
            
        }
    }

    public class EnemyRange : IEnemy
    {
    }

    public class EnemyMeleeInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<EnemyMelee>().AsSingle();
            Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
        }
    }
    
}