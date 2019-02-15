using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public static int score = 1000;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        //if the ApplePicker HighScore already exists read it
        if (PlayerPrefs.HasKey("ApplePickerHighScore"))
        {
            score = PlayerPrefs.GetInt("ApplePickerHighScore");
        }

        PlayerPrefs.SetInt("ApplePickerHighScore", score);
    }

    // Update is called once per frame
    void Update()
    {
        //find a refrence to ScoreCounter GameObject
        //GameObject scoreGO = GameObject.Find("HighScore");
        //get the textMesh component of the GameObject
        TextMesh scoreGT = this.GetComponent<TextMesh>();
        //set the starting number of points to 0
        scoreGT.text = "High Score: " + score;
        if (score > PlayerPrefs.GetInt("ApplePickerHighScore"))
        {
            PlayerPrefs.SetInt("ApplePickerHighScore", score);
        }
    }
}
