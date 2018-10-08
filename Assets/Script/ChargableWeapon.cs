using System;
using System.Collections.Generic;
using UnityEngine;

public class ChargableWeapon : Weapon
{
    [SerializeField] private List<ChargedBullet> _chargedBullets;
    private GameCtrl _gameCtrl;

    private float WeaponCharge => _gameCtrl.WeaponCharge;

    protected override GameObject CurrentBullet => _chargedBullets.FindLast(cb => WeaponCharge >= cb.MinCharge).Bullet;

    private void Awake()
    {
        _gameCtrl = FindObjectOfType<GameCtrl>();
        _chargedBullets = _chargedBullets.FindAll(cb => cb.Bullet != null);
        _chargedBullets.Sort((cb1, cb2) => Mathf.RoundToInt(cb1.MinCharge - cb2.MinCharge));
    }

    [Serializable]
    private struct ChargedBullet
    {
        public GameObject Bullet;
        public float MinCharge;
    }
}