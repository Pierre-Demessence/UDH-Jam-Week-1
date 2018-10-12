using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCtrl : MonoBehaviour
{
    private AsyncOperation _asyncOperationSceneLoad;
    [SerializeField] private Slider _chargeBar;
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private AudioSource _musicIntro;
    [SerializeField] private AudioSource _musicLoop;
    private int _score;

    [SerializeField] private Text _textPlayerHealth;

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

    public void UpdatePlayerHealth(float health)
    {
        _textPlayerHealth.text = $"Health: {health}/10";
    }

    public void GoMainMenu()
    {
        Time.timeScale = 1;
        _asyncOperationSceneLoad.allowSceneActivation = true;
    }

    private void Start()
    {
        _asyncOperationSceneLoad = SceneManager.LoadSceneAsync("MainMenu");
        _asyncOperationSceneLoad.allowSceneActivation = false;
    }

    private void Awake()
    {
        Score = 0;
        _gameOverPanel.SetActive(false);
        
        UpdatePlayerHealth(10);

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

    public void AddPoints(int points)
    {
        Score += points;
    }
}