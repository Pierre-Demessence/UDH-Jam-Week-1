using UnityEngine;

public class AlwaysFire : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private void Update()
    {
        _weapon.Fire();
    }
}