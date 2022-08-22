using UnityEngine;

namespace GameScene.Camera
{
    public class CameraFollowing
    {
        private Transform _camera; 
        
        private Transform _target;
        private Vector3 _cashedTarget;

        public CameraFollowing(Transform target, Transform camera)
        {
            _camera = camera;
            _target = target;
            
            SaveTargetPosition();
        }
        
        public void Follow()
        {
            if (TargetPositionChanged())
                _camera.position += CalculateChangingTargetPosition();
            
            SaveTargetPosition();
        }
        
        private void SaveTargetPosition() =>
            _cashedTarget = _target.transform.position;

        private Vector3 CalculateChangingTargetPosition() => 
            _target.transform.position - _cashedTarget;
        
        private bool TargetPositionChanged() =>
            _cashedTarget != _target.position;
    }
}