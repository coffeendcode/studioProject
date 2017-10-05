using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuButton : MonoBehaviour {

    public void sceneSelect(string level)
    {
        Time.timeScale = 1.0f;
        GameObject.Find("GameManager").GetComponent<gameManager>().loadLevelAsync(level);
    }

    public void exitApp()
    {
        Application.Quit();
    }

    public void resume()
    {
        Time.timeScale = 1.0f;
        GameObject.Find("GameManager").GetComponent<gameManager>().pauseMenu.SetActive(false);
    }

    public void activateMenu(GameObject menu)
    {
        menu.SetActive(true);
    }

    public void deActivateMenu(string name)
    {
        GameObject.Find(name).SetActive(false);
    }

    public void deActivateButton(Button button)
    {
        button.interactable = false;
    }

    public void activateButton(Button button)
    {
        button.interactable = true;
    }
}
