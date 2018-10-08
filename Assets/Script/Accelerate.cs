using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Accelerate : MonoBehaviour
{
    [SerializeField] private float _acceleration;
    [SerializeField] private Movement _movement;

    private void Update()
    {
        if (_movement) _movement.Speed += _acceleration;
    }
}