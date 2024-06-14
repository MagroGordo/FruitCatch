using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public void TransitionFruitCatch()
    {
        SceneManager.LoadScene(2);
    }

    public void TransitionMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void TransitionSecondMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void TransitionShop()
    {
        SceneManager.LoadScene(3);
    }

    public void TransitionBarn()
    {
        SceneManager.LoadScene(4);
    }

    public void ExitGame()
    {
        Application.Quit();
        PlayerPrefs.Save();
    }
}
