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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Transition();
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TransitionBack();
        }
        
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Exit();
        }
    }
    public void Transition()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void TransitionBack()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void Exit()
    {
        StartCoroutine(ExitGame());
    }

    IEnumerator ExitGame()
    {
        transition.SetTrigger("Down"); 
        yield return new WaitForSeconds(waitTime);
        Application.Quit();

    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Down");

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(levelIndex);
    }
}
