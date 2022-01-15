using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlowController : MonoBehaviour
{
    public bool is_paused;
    bool game_ended;

    public GameObject image; 

    // Start is called before the first frame update
    void Start()
    {
        is_paused = false; 
        game_ended = false; // Initialized to true before game starts
        image.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape")){
            is_paused = !is_paused;
        }

        if(game_ended){
            // reset score and all objects to their initial placement
        }
        else if (is_paused){
            Time.timeScale = 0;
            image.SetActive(true);
            
        }
        else{
            Time.timeScale = 1;
            image.SetActive(false);
        }
    }
}
