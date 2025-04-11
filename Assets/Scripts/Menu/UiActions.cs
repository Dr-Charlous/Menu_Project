using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UiActions : MonoBehaviour
{
    [SerializeField] GameObject _mainWindow;
    [SerializeField] GameObject _mainWindowChild;
    [SerializeField] TMP_Dropdown _drop;
    [SerializeField] Sprite _spriteDrop;
    [SerializeField] Resolution[] _resolutions;
    [SerializeField] int[] _frameRates;
    [SerializeField] string[] _Graphisms;

    GameObject _actualWindow;
    GameObject _actualWindowChild;
    Vector2Int _actualScreenSize;
    bool _isFullScreen = true;
    bool _isVSync = true;

    private void Start()
    {
        _actualWindow = _mainWindow;
        _actualWindowChild = _mainWindowChild;

        _resolutions = Screen.resolutions;
        _drop.ClearOptions();

        List<string> names = new List<string>();
        for (int i = 0; i < _resolutions.Length; i++)
        {
            names.Add($"{_resolutions[i].width}x{_resolutions[i].height}");
        }
        _drop.AddOptions(names);
        _drop.value = _resolutions.Length - 1;

        ChangeResolution(_drop);
    }

    //Main buttons
    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //Obj display
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

    //Settings
    public void ChangeResolution(TMP_Dropdown drop)
    {
        _actualScreenSize = new Vector2Int(_resolutions[drop.value].width, _resolutions[drop.value].height);
        Screen.SetResolution(_actualScreenSize.x, _actualScreenSize.y, _isFullScreen);
    }

    public void ChangeGraphism(TMP_Dropdown drop)
    {
        Debug.Log(_Graphisms[drop.value]);
    }

    public void ChangeFrameRate(TMP_Dropdown drop)
    {
        Application.targetFrameRate = _frameRates[drop.value];
    }

    public void ChangeFullScreen(GameObject obj)
    {
        _isFullScreen = !_isFullScreen;
        obj.SetActive(_isFullScreen);
        Screen.SetResolution(_actualScreenSize.x, _actualScreenSize.y, _isFullScreen);
    }

    public void ChangeVSync(GameObject obj)
    {
        _isVSync = !_isVSync;
        obj.SetActive(_isVSync);

        if (_isVSync)
            QualitySettings.vSyncCount = 1;
        else
            QualitySettings.vSyncCount = 0;
    }
}
