using EventSystem;
using UnityEngine;
using Zenject;

public class ProjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindEventSystem();
    }

    private void BindEventSystem()
    {
        Container.Bind<EventManager>().AsSingle().NonLazy();
        Container.Bind<GlobalEventsList>().AsSingle().NonLazy();
    } 
}