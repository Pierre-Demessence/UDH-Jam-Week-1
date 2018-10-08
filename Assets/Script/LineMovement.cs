using UnityEngine;

public class LineMovement : Movement
{
    [SerializeField] private Vector2 _direction;
    public Vector2 Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public override Vector2 Velocity()
    {
        return Direction.normalized * Speed;
    }
}