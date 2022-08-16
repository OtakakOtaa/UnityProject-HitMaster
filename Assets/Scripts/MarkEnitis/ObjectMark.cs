using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectMark : MonoBehaviour
{
    [SerializeField] private MarksType _type;
    
    [SerializeField] private int _priority;
    public int Priority => _priority;
    
    [SerializeField] private Color _color;
    [Range(0.5f, 20f), SerializeField] private float _radius;
    
    private Color _gizmosSavedColor;
    
    public MarksType Type => _type;

    private void OnDrawGizmos()
    {
      _gizmosSavedColor = Gizmos.color;
        Gizmos.color = _color;
        
        Gizmos.DrawSphere(transform.position, _radius);
        Gizmos.color = _gizmosSavedColor;
    }
}
