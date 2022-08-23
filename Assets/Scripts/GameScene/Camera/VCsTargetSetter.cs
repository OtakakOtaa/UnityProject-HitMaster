using Cinemachine;
using UnityEngine;

namespace GameScene.Camera
{
    public class VCsTargetSetter
    {
        public InspectorSettings _cameras { get; private set; }

        private VCsTargetSetter(InspectorSettings settings)
        {
            _cameras = settings;
        }
        
        public void Set(Transform target)
        {
            BindVirtualCameraWithTarget(target, _cameras.WalkingCamera);
            BindVirtualCameraWithTarget(target, _cameras.FightCamera);
        }
        
        private void BindVirtualCameraWithTarget(Transform target, CinemachineVirtualCamera camera)
        {
            camera.Follow = target;
            camera.LookAt = target;
        }

        
        [SerializeField] public class InspectorSettings
        {
            [SerializeField] private CinemachineVirtualCamera _walkingCamera;
            [SerializeField] private CinemachineVirtualCamera _fightCamera;
            
            public CinemachineVirtualCamera WalkingCamera => _walkingCamera;
            public CinemachineVirtualCamera FightCamera => _fightCamera;
        }
    }
}