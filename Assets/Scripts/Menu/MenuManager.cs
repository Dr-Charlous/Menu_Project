using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject _mainWindow;
    [SerializeField] GameObject _mainWindowChild;

    GameObject _actualWindow;
    GameObject _actualWindowChild;

    private void Start()
    {
        _actualWindow = _mainWindow;
        _actualWindowChild = _mainWindowChild;
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
}
