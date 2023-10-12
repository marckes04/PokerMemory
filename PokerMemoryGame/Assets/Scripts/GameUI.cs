using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    private CardImage firstOpen;
    private CardImage secondOpen;
   
    private int score = 0;
    private int attempts = 0;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text attemptsText;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private GameObject PausePanel;

    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    public void imageOpened(CardImage startObject)
    {
        if (firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId)
        {
            score++;
            scoreText.text = " " + score;
            if (score >= 12)
                winLevel();

            firstOpen.Open();
            secondOpen.Open();

        }
        else
        {
            yield return new WaitForSeconds(0.5f);
            firstOpen.Close();
            secondOpen.Close();
        }
        attempts++;
        attemptsText.text = " " + attempts;

        firstOpen = null;
        secondOpen = null;
    }


    private void winLevel()
    {
        WinPanel.SetActive(true);
        Time.timeScale = 0f;
    }


    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }


    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
