using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace GameScene
{
    public class GameInput : ITickable
    {
        public event UnityAction OnTap;

        public void Tick()
        {
            ListenTaps();
        }

        private void ListenTaps()
        {
            if(Input.GetMouseButton(0)) 
                OnTap?.Invoke();
        }
    }
}
