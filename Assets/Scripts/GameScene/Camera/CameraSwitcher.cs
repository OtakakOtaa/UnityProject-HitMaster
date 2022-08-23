using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

using EventSystem;
using GameScene.PlayerEntities.View;
using UnityEngine.Events;
using UnityEngine.Timeline;
using Zenject;

namespace GameScene.Camera
{
    public class CameraSwitcher
    {
        private PlayableDirector _playable;
        private InspectorSettings _settings;

        private VCsTargetSetter _vCsTargetSetter;
        
        public CameraSwitcher(VCsTargetSetter vCsTargetSetter)
        {
            _vCsTargetSetter = vCsTargetSetter;
        }
        
        public void ToFitch()
        {
            _playable.playableAsset = _settings.ChangeToFightAnim;
            _playable.Play();
            SetShootingCamera(_vCsTargetSetter._cameras.FightCamera);
        }

        public void ToWalking()
        {
            
        }

        private void SetShootingCamera(CinemachineVirtualCamera camera)
        {
            ResetToZeroCamerasPriority();
            camera.Priority = 1;
        }

        private void ResetToZeroCamerasPriority()
        {
            _vCsTargetSetter._cameras.FightCamera.Priority = 0;
            _vCsTargetSetter._cameras.WalkingCamera.Priority = 0;
        }
        
        [SerializeField] public class InspectorSettings
        {
            [SerializeField] private PlayableDirector _playableCameraSwitch;
            
            [Header("Animations")] 
            [SerializeField] private TimelineAsset _changeToFightAnim;
            
            public PlayableDirector Playable => _playableCameraSwitch;

            public TimelineAsset ChangeToFightAnim => _changeToFightAnim;
            
        }
    }
}