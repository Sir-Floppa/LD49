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
}
