using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;

public class CanvasController : MonoBehaviour
{
    //This script is arranging the position and rotation according to VR controllers
    private GameObject canvas;
    private GameObject dot;
    private GameObject cameraRig;
    private GameObject camera;
    private Vector3 leftTopCorner;
    private Vector3 rightBottomCorner;
    private Vector3 prevCanvasPos;

    //Get Controllers
    private GameObject leftController;
    private GameObject rightController;

    //Menu button
    public SteamVR_Action_Boolean m_MenuButtonClick;
    public SteamVR_Input_Sources handType;
    public int counter = 0;

    private void Awake()
    {
        canvas = GameObject.Find("Canvas");
        //canvas.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        //print(Screen.currentResolution);
    }

    void Start()
    {
        cameraRig = GameObject.Find("[CameraRig]");
        camera = GameObject.Find("Camera");
        dot = GameObject.Find("Dot");
        leftController = GameObject.Find("Controller (left)");
        rightController = GameObject.Find("Controller (right)");

        m_MenuButtonClick.AddOnStateDownListener(TriggerDown, handType);

        Vector3 pos = new Vector3(canvas.gameObject.transform.position.x + 50, canvas.gameObject.transform.position.y, canvas.gameObject.transform.position.z);
        //canvas.gameObject.transform.position += pos;
        prevCanvasPos = canvas.gameObject.transform.position;
        //print(canvas.gameObject.transform.position);
    }

    public void getControllerRotation()
    {
        InputTracking.Recenter();

        //rightController.transform.rotation = Quaternion.Euler(new Vector3(0, 30, 0));
       // rightController.transform.eulerAngles += new Vector3(0, 30, 0);
        //print(rightController.transform.eulerAngles);
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        //print("Menu pressed");

 
            leftTopCorner = dot.gameObject.transform.position;
          

        //RectTransform rt = canvas.GetComponent(typeof(RectTransform)) as RectTransform;
        //rt.sizeDelta = new Vector2(100, 100);

        //canvas.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(rightBottomCorner.x - leftTopCorner.x, rightBottomCorner.y - leftTopCorner.y);

        //float height = canvas.gameObject.GetComponent<RectTransform>().rect.height;

        //canvas.gameObject.transform.position = (leftTopCorner + rightBottomCorner) / 2;
        //canvas.gameObject.transform.position = new Vector3(leftTopCorner.x, leftTopCorner.y, canvas.gameObject.transform.position.z);
        

        // Vector3 targetDir =  canvas.transform.position - dot.transform.position;
        Vector3 canvasZ = new Vector2(prevCanvasPos.x, prevCanvasPos.z);
        Vector3 dotZ = new Vector2(dot.transform.position.x, dot.transform.position.z);
        float angleZ = Vector2.Angle(canvasZ, dotZ);

        int signZ = Vector3.Cross(canvasZ, dotZ).z < 0 ? -1 : 1;
        if (signZ < 0)
        {
            angleZ = -angleZ;
            print(signZ);
        }

        // float r = Mathf.Sqrt(Mathf.Pow(prevCanvasPos.x,2)+ Mathf.Pow(prevCanvasPos.z, 2));
        //canvas.gameObject.transform.position = new Vector3(r * Mathf.Sin(angle), canvas.gameObject.transform.position.y, r * Mathf.Cos(angle));

        //cameraRig.gameObject.transform.rotation = Quaternion.Euler(cameraRig.gameObject.transform.rotation.x , cameraRig.gameObject.transform.rotation.y + (angle + Mathf.Deg2Rad), cameraRig.gameObject.transform.rotation.z);
        camera.gameObject.transform.Rotate(new Vector3(0, 360 - angleZ, 0), Space.World);
        cameraRig.gameObject.transform.Rotate(new Vector3(0, angleZ, 0), Space.World);

        /*
        Vector3 canvasY = new Vector2(prevCanvasPos.y, prevCanvasPos.z);
        Vector3 dotY = new Vector2(dot.transform.position.y, dot.transform.position.z);
        float angleY = Vector2.Angle(canvasY, dotY);
        float angleY = Vector2.Angle(canvasY, dotY);

        int signY = Vector3.Cross(canvasY, dotY).y < 0 ? -1 : 1;
        if (signY < 0)
        {
            angleY = -angleY;
            print(signY);
        }

        camera.gameObject.transform.Rotate(new Vector3(360 - angleY, 0, 0), Space.World);
        cameraRig.gameObject.transform.Rotate(new Vector3(angleY, 0, 0), Space.World);
        */


    }

}
