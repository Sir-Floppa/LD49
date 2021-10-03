using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ExitButton()
    {
        Application.Quit();
    }

    public void LoadLevel(int levelId)
    {
        SceneManager.LoadScene(levelId);
    }

    public void ShowCredits(GameObject creditsPanel)
    {
        if (!creditsPanel.activeInHierarchy)
        {
            creditsPanel.SetActive(true);
        }
        else
        {
            creditsPanel.SetActive(false);
        }
    } 
}
