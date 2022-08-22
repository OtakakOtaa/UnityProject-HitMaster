using EventSystem;
using GameScene.PlayerEntities.View;
using UnityEngine;
using Zenject;

namespace GameScene.Camera
{
    public class MainCamera : MonoBehaviour
    {
        private CameraFollowing _cameraFollowing;

        [Inject]
        public void DiConstructor(EventManager eventManager)
        {
            eventManager.AddListener<StartGameEvent>(evt => Initialize());
        }

        private void LateUpdate()
        {
            _cameraFollowing.Follow();
        }

        private void Initialize()
        {
            var player = FindObjectOfType<PlayerView>().transform;
            _cameraFollowing = new CameraFollowing(player, transform);
        }
        
    }
}