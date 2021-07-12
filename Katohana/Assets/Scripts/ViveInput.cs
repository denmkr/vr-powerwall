using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System;

// Zooming
public class ViveInput : MonoBehaviour
{
    //Menu button
    public SteamVR_Action_Boolean m_gripClick;
    public SteamVR_Input_Sources handType;

    //Get Controllers
    private GameObject leftController;
    private GameObject rightController;
    private GameObject canvas;

    private float prevCanvasZ;
    private float prevAngle, angle;
    private float prevXPosition, positionX, prevYPosition, positionY;

    private int count;

    void Start()
    {
        angle = 0;
        positionX = 0;
        positionY = 0;
        m_gripClick.AddOnStateDownListener(TriggerDown, handType);
        leftController = GameObject.Find("Controller (left)");
        rightController = GameObject.Find("Controller (right)");
        canvas = GameObject.Find("Canvas");
        prevCanvasZ = canvas.transform.position.z;


    }

    void Update()
    {
       // print(m_MenuButtonClick.state);
        if (m_gripClick.state)
        {
       
            Vector2 leftControlerPosition = new Vector2(leftController.transform.position.x, leftController.transform.position.y);
            Vector2 rightControlerPosition = new Vector2(rightController.transform.position.x, rightController.transform.position.y);

            float positionX = (leftControlerPosition.x + rightControlerPosition.x) / 2;
            float positionY = (leftControlerPosition.y + rightControlerPosition.y) / 2;

            float positionXDelta = prevXPosition - positionX;
            float positionYDelta = prevYPosition - positionY;

            float x = (positionXDelta * 10);
            float y = (positionYDelta * 10);

            //float x = canvas.transform.position.x + (positionXDelta / 5);
            //float y = canvas.transform.position.y + (positionYDelta / 5);

            // -41 x 33 
           
            // -10 y 10 
       

            if ((canvas.transform.position.y >= -10 && canvas.transform.position.y <= 10) && (canvas.transform.position.x >= -40 && canvas.transform.position.x <= 33))
                canvas.transform.position = new Vector3(x, y, canvas.transform.position.z);
            else
            {
                if (canvas.transform.position.y < -10) canvas.transform.position = new Vector3(canvas.transform.position.x, -10, canvas.transform.position.z);
                if (canvas.transform.position.y > 10) canvas.transform.position = new Vector3(canvas.transform.position.x, 10, canvas.transform.position.z);
                if (canvas.transform.position.x < -40) canvas.transform.position = new Vector3(-40, canvas.transform.position.y, canvas.transform.position.z);
                if (canvas.transform.position.x > 33) canvas.transform.position = new Vector3(33, canvas.transform.position.y, canvas.transform.position.z);

             
            }

            //angle = Quaternion.Angle(leftController.transform.rotation, rightController.transform.rotation);
            angle = (float) Math.Sqrt(Mathf.Pow(rightControlerPosition.x - leftControlerPosition.x, 2) + Mathf.Pow(rightControlerPosition.y - leftControlerPosition.y, 2));

            float angleDelta = prevAngle - angle;
            float z = canvas.transform.position.z - (angleDelta * 10);

            if (Math.Abs(angleDelta) > 0.001)
            {
                if (z >= (prevCanvasZ - 10) && z <= (prevCanvasZ + 20))
                {
                    canvas.transform.position = new Vector3(canvas.transform.position.x, canvas.transform.position.y, z);
                }
            }

        }
        prevAngle = angle;
        // prevXPosition = positionX;
        // prevYPosition = positionY;
        //prevCanvasZ = canvas.transform.position.z;

    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        print("Zoom");
        

        Vector2 leftControlerPosition = new Vector2(leftController.transform.position.x, leftController.transform.position.y);
        Vector2 rightControlerPosition = new Vector2(rightController.transform.position.x, rightController.transform.position.y);

        float positionX = (leftControlerPosition.x + rightControlerPosition.x) / 2;
        float positionY = (leftControlerPosition.y + rightControlerPosition.y) / 2;

        prevXPosition = positionX;
        prevYPosition = positionY;

        angle = (float) Math.Sqrt(Mathf.Pow(rightControlerPosition.x - leftControlerPosition.x, 2) + Mathf.Pow(rightControlerPosition.y - leftControlerPosition.y, 2));
        prevAngle = angle;
        //Debug.Log("Trigger is down");
        // print("left: " + leftController.transform.rotation);
        // print("right: " + rightController.transform.rotation);
        /*  float angle = Quaternion.Angle(leftController.transform.rotation, rightController.transform.rotation);
          print(angle);
          if(angle <= 100)
          {
              var z = canvas.transform.position.z - 1;
              if(z >= -16)
                  canvas.transform.position = new Vector3(canvas.transform.position.x, canvas.transform.position.y, z);
          }
          else
          {
              var z = canvas.transform.position.z + 1;
              if(z <= -12)
                  canvas.transform.position = new Vector3(canvas.transform.position.x, canvas.transform.position.y, z);
          } */

    }
}
