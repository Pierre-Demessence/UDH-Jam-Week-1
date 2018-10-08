using UnityEngine;
using UnityEngine.UI;

public class InputCharger : MonoBehaviour
{
    private float _buttonDownTime;
    [SerializeField] private Slider _chargeBar;
    private GameCtrl _gameCtrl;
    [SerializeField] private float _timeForMaxCharge = 3;

    private float ChargePercent => Mathf.Clamp((Time.time - _buttonDownTime) / _timeForMaxCharge, 0, 1);

    private void Awake()
    {
        _gameCtrl = FindObjectOfType<GameCtrl>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) _buttonDownTime = Time.time;

        if (Input.GetButton("Fire1")) _gameCtrl.WeaponCharge = ChargePercent;

        if (Input.GetButtonUp("Fire1"))
        {
            _buttonDownTime = Time.time;
            _gameCtrl.WeaponCharge = ChargePercent;
        }
    }
}