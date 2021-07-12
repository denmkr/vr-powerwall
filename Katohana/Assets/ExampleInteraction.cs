using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ExampleInteraction : MonoBehaviour
{
    public GameObject exampleCube;
    public SteamVR_Action_Boolean grabPinch;
    //public SteamVR_Behaviour_Pose pose;
    public SteamVR_Input_Sources inputSource = SteamVR_Input_Sources.Any;

    // Start is called before the first frame update
   

    void OnEnable()
    { 
            //grabPinch.AddOnStateDownListener(Press, inputSource);
        grabPinch.AddOnStateDownListener(Press, inputSource);
        
    }


    private void OnDisable()
    {
        
            grabPinch.RemoveOnStateDownListener(Press, inputSource);
       
    }

    private void Press(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //put your stuff here
        Debug.Log("Success");

        Ray raycast = new Ray(transform.parent.position, transform.parent.forward);
        RaycastHit hit;
        bool bHit = Physics.Raycast(raycast, out hit);

        if (bHit) {
            GameObject go = Instantiate(exampleCube);
            go.transform.position = hit.point;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        Ray raycast = new Ray(transform.parent.position, transform.parent.forward);
        RaycastHit hit;
        bool bHit = Physics.Raycast(raycast, out hit);

        if(bHit) transform.position = hit.point;
      }
}
