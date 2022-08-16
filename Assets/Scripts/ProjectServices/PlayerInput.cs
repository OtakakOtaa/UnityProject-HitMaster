using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class PlayerInput : ITickable
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
