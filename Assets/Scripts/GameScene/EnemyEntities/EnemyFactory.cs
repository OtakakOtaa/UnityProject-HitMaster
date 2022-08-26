using Zenject;

namespace GameScene.EnemyEntities
{
    public class EnemyFactory : PlaceholderFactory<EnemyType, IEnemy>
    {
        
        public class Custom : IFactory<EnemyType, IEnemy>
        {
            private readonly DiContainer _container;
            
            public Custom(DiContainer container)
            {
                _container = container;
            }
            
            public IEnemy Create(EnemyType type) =>
                type switch
                {
                    EnemyType.Range => _container.Instantiate<EnemyRange>(),
                    EnemyType.Melee => _container.Instantiate<EnemyMelee>(),
                };
        } 
    }
}