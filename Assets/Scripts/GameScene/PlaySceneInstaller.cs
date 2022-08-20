using MarkEntities.System;
using UnityEngine;
using Zenject;

namespace GameScene
{
    public class PlaySceneInstaller : MonoInstaller
    {
        [SerializeField] private MarksProvider _marksProvider;

        public override void InstallBindings()
        {
            Container.Bind<MarksProvider>().FromInstance(_marksProvider);
            Container.Bind<GameInput>().AsSingle().NonLazy();
            Container.Bind<GameSceneStartGate>().AsSingle().NonLazy();
        }
    }
}