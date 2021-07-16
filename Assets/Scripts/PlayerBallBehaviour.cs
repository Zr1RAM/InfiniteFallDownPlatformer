using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBallBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInputs();
    }

    void PlayerInputs()
    {
        if(Input.GetMouseButton(0))
        {
            RotatingTheStage();
        }
    }
    void RotatingTheStage()
    {
        
    }
}
