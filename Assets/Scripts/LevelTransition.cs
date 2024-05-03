using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtainTransition : MonoBehaviour
{
    //[Header("References")]
    //[SerializeField] private Animator transition;

    [Header("Attributes")]
    [SerializeField] private float waitTime = 3f;

    private void Start()
    {
        //transition.SetTrigger("Up");
    }

    public void TransitionFruitCatch()
    {
        StartCoroutine(LoadLevel(2));
    }

    public void TransitionMainMenu()
    {
        StartCoroutine(LoadLevel(0));
    }

    public void TransitionSecondMenu()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void TransitionShop()
    {
        StartCoroutine(LoadLevel(3));
    }

    public void ExitGame()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator QuitGame()
    {
        //transition.SetTrigger("Down"); 
        yield return new WaitForSeconds(waitTime);
        Application.Quit();
        PlayerPrefs.Save();
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //transition.SetTrigger("Down");

        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelIndex);
    }
}
