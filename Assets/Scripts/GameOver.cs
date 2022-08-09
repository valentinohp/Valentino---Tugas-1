using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text score;
    public GameObject highscore;

    // Start is called before the first frame update
    void Start()
    {
        score.text = PlayerPrefs.GetInt("Score").ToString();
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("Highscore"))
        {
            highscore.SetActive(true);
            PlayerPrefs.SetInt("Highscore", PlayerPrefs.GetInt("Score"));
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("Main");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
