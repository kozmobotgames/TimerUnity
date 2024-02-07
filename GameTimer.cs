using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public bool timerOn;
    public float timeRemaining;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("timeValue"))
        {
            timeRemaining = PlayerPrefs.GetFloat("timeValue");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining >= 0 && timerOn)
        {
            timeRemaining += Time.deltaTime;
            PlayerPrefs.SetFloat("timeValue", timeRemaining);
            updateTimer(timeRemaining);
        }
        else
        {
            timerOn = false;
        }
    }

    void updateTimer(float timer)
    {
        timer += 1;
        float min = Mathf.FloorToInt(timer / 60);
        float sec = Mathf.FloorToInt(timer % 60);

        timerText.text = string.Format("{00} : {1:00}", min, sec);
    }

    public void startTimer()
    {
        timerOn = true;
    }

    public void stopTimer()
    {
        timerOn = false;
    }

    public void nextScene()
    {
        SceneManager.LoadScene(1);
    }

    public void previousScene()
    {
        SceneManager.LoadScene(0);
    }

    public void resetTimer()
    {
        timeRemaining = 0;
        updateTimer(timeRemaining);
        PlayerPrefs.SetFloat("timeValue", timeRemaining);
    }
}
