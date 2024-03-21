using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtainTransition : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator transition;

    [Header("Attributes")]
    [SerializeField] private float waitTime = 3f;

    private void Start()
    {
        transition.SetTrigger("Up");
    }

    public void Transition()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        PlayerPrefs.Save();
    }

    public void TransitionBack()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
        PlayerPrefs.Save();
    }

    public void Exit()
    {
        StartCoroutine(ExitGame());
        PlayerPrefs.Save();
    }

    IEnumerator ExitGame()
    {
        transition.SetTrigger("Down"); 
        yield return new WaitForSeconds(waitTime);
        Application.Quit();
        PlayerPrefs.Save();
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Down");

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(levelIndex);
    }
}
