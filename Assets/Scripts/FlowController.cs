using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowController : MonoBehaviour
{
    bool is_paused;
    bool game_ended;

    public GameObject pause_image; 
    public GameObject start_button;


    public static FlowController instance;

    void Awake(){
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        is_paused = false; 
        game_ended = true; // Initialized to true before game starts
        pause_image.SetActive(false);
        start_button.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
            if(!game_ended){
            is_paused = !is_paused;
            }
        }

        if(!game_ended){
            start_button.SetActive(false);
            
            if (is_paused){
                Time.timeScale = 0;
                pause_image.SetActive(true);
                
            }
            else{
                Time.timeScale = 1;
                pause_image.SetActive(false);
            }
        }
        else{
            start_button.SetActive(true);
        }   
    }

    public void StartGame(){
        if (game_ended){
            ScoreManager.instance.ResetPoint();
            game_ended = false;
        }
    }
}
