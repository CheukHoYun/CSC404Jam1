using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    bool is_paused;
    bool game_ended;

    // Start is called before the first frame update
    void Start()
    {
        is_paused = false; 
        game_ended = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if(game_ended){
            // reset score and all objects to their initial placement
        }
        else if (is_paused){
            Time.timeScale = 0;
        }
        else{
            Time.timeScale = 1;
        }
    }
}
