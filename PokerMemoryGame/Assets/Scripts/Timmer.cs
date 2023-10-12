using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timmer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 75f;
    [SerializeField] Text countDownText;

    [SerializeField] private GameObject LosePanel;

    private void Start()
    {

        currentTime = startingTime;
        Time.timeScale = 1.0f;
    }


    private void FixedUpdate()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");

        if (currentTime <= 3)
        {
            countDownText.color = Color.red;
        }

        if (currentTime <= 0) 
        {
            currentTime = 0;
            LosePanel.SetActive(true);
            Time.timeScale = 0f;
        }

    }

}
