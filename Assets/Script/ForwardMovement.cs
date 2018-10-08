using UnityEngine;

public class ForwardMovement : Movement
{
    public override Vector2 Velocity()
    {
        return transform.right * Speed;
    }
}