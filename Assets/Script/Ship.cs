using UnityEngine;

public class Ship : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed = 5;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        var velocity = Vector2.zero;
        if (Input.GetKey(KeyCode.UpArrow))
            velocity.y = _speed;
        if (Input.GetKey(KeyCode.DownArrow))
            velocity.y = -_speed;
        if (Input.GetKey(KeyCode.LeftArrow))
            velocity.x = -_speed;
        if (Input.GetKey(KeyCode.RightArrow))
            velocity.x = _speed;

        _rigidbody2D.velocity = velocity;
    }
}