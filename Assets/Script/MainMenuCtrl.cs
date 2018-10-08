using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCtrl : MonoBehaviour
{
    private AsyncOperation _asyncOperationSceneLoad;

    private void Start()
    {
        _asyncOperationSceneLoad = SceneManager.LoadSceneAsync("Game");
        _asyncOperationSceneLoad.allowSceneActivation = false;
    }

    public void Play()
    {
        _asyncOperationSceneLoad.allowSceneActivation = true;
    }
}