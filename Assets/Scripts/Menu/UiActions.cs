using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiActions : MonoBehaviour
{
    [SerializeField] GameObject _mainWindow;
    [SerializeField] GameObject _mainWindowChild;
    [SerializeField] TMP_Dropdown _drop;

    GameObject _actualWindow;
    GameObject _actualWindowChild;

    private void Start()
    {
        _actualWindow = _mainWindow;
        _actualWindowChild = _mainWindowChild;
        ChangeResolution(_drop);
    }

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeWindow(GameObject obj)
    {
        _actualWindow.SetActive(false);
        _actualWindow = obj;
        _actualWindow.SetActive(true);
    }

    public void ChangeWindowChild(GameObject obj)
    {
        _actualWindowChild.SetActive(false);
        _actualWindowChild = obj;
        _actualWindowChild.SetActive(true);
    }

    public void ChangeResolution(TMP_Dropdown drop)
    {
        if (drop.value == 0)
            Screen.SetResolution(3840, 2160, true);
        else if (drop.value == 1)
            Screen.SetResolution(2560, 1440, true);
        else if (drop.value == 2)
            Screen.SetResolution(1920, 1080, true);
        else if (drop.value == 3)
            Screen.SetResolution(1366, 768, true);
        else if (drop.value == 4)
            Screen.SetResolution(1280, 720, true);
        else if (drop.value == 5)
            Screen.SetResolution(1024, 768, true);
        else if (drop.value == 6)
            Screen.SetResolution(640, 480, true);
        else if (drop.value == 7)
            Screen.SetResolution(400, 240, true);
        else if (drop.value == 8)
            Screen.SetResolution(256, 192, true);
    }
}
