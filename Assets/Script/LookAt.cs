using UnityEngine;

public class LookAt : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 3;
    
    public GameObject Target { get; set; }

    private void Update()
    {
        if (Target == null) return;
        var vectorToTarget = Target.transform.position - transform.position;
        var angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        var q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _rotationSpeed);
    }
}