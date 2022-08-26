using System;
using Cinemachine;
using UnityEngine;

namespace GameScene.Camera.Systems
{
    public class VCsTargetSetter
    {
        private readonly VCs _cameras;

        private VCsTargetSetter(VCs cameras)
        {
            _cameras = cameras;
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

        
        [Serializable] public class VCs
        {
            [SerializeField] private CinemachineVirtualCamera _walkingCamera;
            [SerializeField] private CinemachineVirtualCamera _fightCamera;
            
            public CinemachineVirtualCamera WalkingCamera => _walkingCamera;
            public CinemachineVirtualCamera FightCamera => _fightCamera;
        }
    }
}