using UnityEngine;
using Zenject;

public class PlaySceneInstaller : MonoInstaller
{
    [SerializeField] private MarksProvider _marksProvider;
    public override void InstallBindings()
    {
        Container.Bind<PlayerFactory>().AsSingle().NonLazy();
        Container.Bind<MarksProvider>().FromInstance(_marksProvider);
        Container.Bind<GameStartGate>().AsSingle().NonLazy();
        Container.Bind<PlayerInput>().AsSingle().NonLazy();
    }
}