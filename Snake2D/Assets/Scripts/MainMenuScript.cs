using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject menuBox;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MenuButton()
    {
         if (menuBox.activeSelf == false)
        {
            Time.timeScale = 0;
            menuBox.SetActive(true);
        }
    }
    public void ResumeGameButton()
    {
        menuBox.SetActive(false);
        Time.timeScale = 1;
    }
    public void RestartGameButton() 
    {
        SceneManager.LoadScene(0);
        menuBox.SetActive(false);
        Time.timeScale = 1;
    }
    public void SettingGameButton()
    {

    }
    public void ExitButton() 
    {
        Application.Quit();
    }
}
