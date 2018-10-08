using UnityEngine;

public class NonChargableWeapon : Weapon
{
    [SerializeField] private GameObject _bullet;

    protected override GameObject CurrentBullet => _bullet;
}