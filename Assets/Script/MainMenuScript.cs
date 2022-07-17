using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject screen1;
    public GameObject screen2;

    private void Start()
    {
        MenuStartConfig();
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OptionMenu()
    {
        screen1.SetActive(false);
        screen2.SetActive(true);
    }

    public void MenuStartConfig()
    {
        screen2.SetActive(false);
        screen1.SetActive(true);
    }

}
