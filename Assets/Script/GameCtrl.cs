using UnityEngine;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour
{
    [SerializeField] private Slider _chargeBar;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private AudioSource _musicIntro;
    [SerializeField] private AudioSource _musicLoop;
    private int _score;

    [SerializeField] private Text _textScore;

    private float _weaponCharge;

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;
            _textScore.text = $"Score: {Score}";
        }
    }
    public float WeaponCharge
    {
        get { return _weaponCharge; }
        set
        {
            _weaponCharge = value;
            _chargeBar.value = value;
        }
    }

    private void Awake()
    {
        _gameOverPanel.SetActive(false);
        _musicIntro.playOnAwake = false;
        _musicIntro.loop = false;
        _musicIntro.Play();
        _musicLoop.playOnAwake = false;
        _musicLoop.loop = true;
        _musicLoop.PlayDelayed(_musicIntro.clip.length);
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}