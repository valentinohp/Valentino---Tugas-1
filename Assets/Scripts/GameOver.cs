using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TMP_Text score;

    // Start is called before the first frame update
    void Start()
    {
        score.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
