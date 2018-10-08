using UnityEngine;

public class OscillateMovement : Movement
{
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _magnitude;

    private Vector2 _velocity;

    public override Vector2 Velocity()
    {
        return _velocity;
    }

    private void Update()
    {
        _velocity = _direction.normalized * (Mathf.PingPong(Time.time, 2) - 1)  * _magnitude;
    }
}