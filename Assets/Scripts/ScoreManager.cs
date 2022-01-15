using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    int score = 0;
    // Start is called before the first frame update

    private void Awake() {
        instance = this;
    }

    void Start()
    {
        scoreText.text = "Score: " + score.ToString()  ;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddPoint(){
        score += 1;
    }

    public void ResetPoint(){
        score = 0;
    }

    public void RemovePoints(int points)
    {
        score -= points;
    }
}
