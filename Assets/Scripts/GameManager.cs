using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int life = 3;
    public TMP_Text text;
    public GameObject lives;

    private void Awake() 
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
        }

    public void AddScore(int point)
    {
        score += point;
        text.text = score.ToString(); 
    }

    public void DecreaseLife()
    {
        lives.transform.Find("Life " + life).gameObject.SetActive(false);
        life--;
        
        if (life <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("Score", score);
        SceneManager.LoadScene("Game Over");
    }
}
