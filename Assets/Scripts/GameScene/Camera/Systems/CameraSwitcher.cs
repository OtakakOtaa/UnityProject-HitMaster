using System;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace GameScene.Camera.Systems
{
    public class CameraSwitcher
    {
        private readonly PlayableDirector _playable;
        private readonly CameraAnimations _animations;

        private readonly VCsTargetSetter.VCs _cameras;
        
        public CameraSwitcher(VCsTargetSetter.VCs cameras, CameraAnimations settings)
        {
            _animations = settings;
            _cameras = cameras;
            _playable = settings.Playable;
        }
        
        public void ToFitch()
        {
            _playable.playableAsset = _animations.ChangeToFightAnim;
            _playable.Play();
            SetShootingCamera(_cameras.FightCamera);
        }

        public void ToWalking()
        {
            _playable.playableAsset = _animations.ChangeToWalkingAnim;
            _playable.Play();
            SetShootingCamera(_cameras.WalkingCamera);
        }

        
        private void SetShootingCamera(CinemachineVirtualCamera camera)
        {
            ResetToZeroCamerasPriority();
            camera.Priority = 1;
        }

        private void ResetToZeroCamerasPriority()
        {
            _cameras.FightCamera.Priority = 0;
            _cameras.WalkingCamera.Priority = 0;
        }
        
        [Serializable] public class CameraAnimations
        {
            [SerializeField] private PlayableDirector _playableCameraSwitch;
            
            [Header("Animations")] 
            [SerializeField] private TimelineAsset _changeToFightAnim;
            [SerializeField] private TimelineAsset _changeToWalkingAnim;
            
            public PlayableDirector Playable => _playableCameraSwitch;
            
            public TimelineAsset ChangeToFightAnim => _changeToFightAnim;
            public TimelineAsset ChangeToWalkingAnim => _changeToWalkingAnim;

        }
    }
}