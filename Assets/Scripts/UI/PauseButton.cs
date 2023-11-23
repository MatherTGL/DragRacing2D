using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    private Animator animator;

    private void Start()
    {
        animator = pauseUI.GetComponent<Animator>();
    }

    public void ButtonPause()
    {
        pauseUI.SetActive(true);
        animator.Play("pauseON");
    }

    public void PauseOn()
    {
        Time.timeScale = 0f;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
    }

    public void ResumeButton()
    {
        
        Time.timeScale = 1f;
        animator.Play("pauseOFF");
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
