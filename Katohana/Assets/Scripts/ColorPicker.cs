using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{

    // Touchpad axis
    public SteamVR_Action_Vector2 touchpad_Touch;
    public SteamVR_Input_Sources handType;

   // private GameObject chosenColor;
    private GameObject indicator;
    private GameObject dot;

    // Start is called before the first frame update
    void Start()
    {
        touchpad_Touch.AddOnAxisListener(getAxis, handType);
        //chosenColor = GameObject.Find("ChosenColor");
        indicator = GameObject.Find("Indicator");
        dot = GameObject.Find("ColorfulDot");

        //chosenColor.GetComponent<Image>().color = Color.green;
    }

    private void getAxis(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {
        //print(axis);
        float r = Mathf.Sqrt(axis.x * axis.x + axis.y * axis.y);
        float angle = Mathf.Atan2(axis.y, axis.x);

        //print("r " + r);
        float degree = angle * Mathf.Rad2Deg;
        

        if (degree < 0) degree = 360 + degree;
        //print(degree);
        float normDeg = degree / 360;
        //print("norm " + normDeg);


        //float normRad = r - (-1) / 1 - (-1);

        var color = Color.HSVToRGB(normDeg, r, 1);
        //chosenColor.GetComponent<Image>().color = color;
        indicator.transform.localPosition = new Vector3(axis.x * 200, axis.y * 200, indicator.transform.localPosition.z);
        dot.GetComponent<Renderer>().material.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
