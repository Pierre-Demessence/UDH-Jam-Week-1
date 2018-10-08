using UnityEngine;

public class InputFire : MonoBehaviour
{
    [SerializeField] private bool _canHold;
    [SerializeField] private Weapon _weapon;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) _weapon.Fire();

        if (Input.GetButton("Fire1") && _canHold) _weapon.Fire();

        if (Input.GetButtonUp("Fire1")) _weapon.Fire();
    }
}