using GameScene.Camera.Systems;
using UnityEngine;
using Zenject;

namespace GameScene.Camera
{
    public class CameraInstaller : MonoInstaller
    {
        [SerializeField] private VCsTargetSetter.VCs _vcsSettings;
        [SerializeField] private CameraSwitcher.CameraAnimations _switcherSettings;

        public override void InstallBindings()
        {
            Container.BindInstance(_vcsSettings);
            Container.BindInstance(_switcherSettings);
            
            Container.Bind<VCsTargetSetter>().AsSingle();
            Container.Bind<CameraSwitcher>().AsSingle();
            Container.Bind<CameraRule>().AsSingle().NonLazy();
        }
    }
}