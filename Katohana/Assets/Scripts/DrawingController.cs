using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using System;
using System.Linq;

public class DrawingController : MonoBehaviour
{

    public SteamVR_Action_Boolean m_gripClick;
    public SteamVR_Input_Sources handType;
    public GameObject panel;

    //Get Controllers
    private GameObject rightController;
    private List<Vector2> positions;

    // Change the color of the shapes
    private GameObject penDot;
    private Color penColor;
    private GameObject dot;

    //Action flags
    private bool down;

    void Start()
    {
        down = false;
        positions = new List<Vector2>();
        rightController = GameObject.Find("Controller (right)");
        m_gripClick.AddOnStateDownListener(TriggerDown, handType);
        m_gripClick.AddOnStateUpListener(TriggerUp, handType);
        dot = GameObject.Find("Dot");

        penDot = GameObject.Find("ColorfulDot");
        penColor = Color.white;
    }

    void Update()
    {
        if (down)
        {
            Vector2 rightControlerPosition = new Vector2(rightController.transform.position.x, rightController.transform.position.y);
            positions.Add(rightControlerPosition);
        }

        penColor = penDot.GetComponent<Renderer>().material.color;
    }

    private void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (panel.activeInHierarchy)
        {
             down = false;
             float sumX = 0, avgX;
             float sumY = 0, avgY;

             for (int i=0;i<positions.Count;i++)
             {
                 sumX += positions[i].x;
                 sumY += positions[i].y;
             }

             avgX = sumX / positions.Count;
             avgY = sumY / positions.Count;

             List<float> dists = new List<float>();

            Vector2 centroid = new Vector2(avgX, avgY);

            for (int i = 0; i < positions.Count; i++)
             {
                 
                 float dist = Vector2.Distance(positions[i], centroid);

                 dists.Add(dist);
             }

            

             var maxDist = dists.Max();
             var minDist = dists.Min();

            var avgDist = dists.Average();

            float k = avgDist / maxDist;

            if (k > 0.75)
            {
                Vector3 pos = new Vector3(dot.transform.position.x - (avgDist * 5) / 2, dot.transform.position.y - (avgDist * 5) / 2, panel.transform.position.z + 1);
                //Vector3 pos = new Vector3(centroid.x - (avgDist * 5) / 2, centroid.y + (avgDist * 10), panel.transform.position.z);
                /*GameObject circle = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                circle.transform.position = new Vector3(panel.transform.position.x, panel.transform.position.y, panel.transform.position.z+1);
                circle.transform.localScale = new Vector3(avgDist * 40, avgDist * 40, 0);
                circle.GetComponent<Renderer>().material.color = penColor;*/
                CreatePrimitive(pos, PrimitiveType.Sphere, avgDist * 5, penColor);
            }
            else
            {
                /*GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.position = new Vector3(panel.transform.position.x, panel.transform.position.y, panel.transform.position.z + 1);
                cube.transform.localScale = new Vector3(avgDist * 40, avgDist * 40, 0);
                cube.GetComponent<Renderer>().material.color = penColor;*/
                //Vector3 pos = new Vector3(centroid.x - (avgDist * 5) / 2, centroid.y + (avgDist * 10), panel.transform.position.z -3);
                Vector3 pos = new Vector3(dot.transform.position.x - (avgDist * 5) / 2, dot.transform.position.y - (avgDist * 5) / 2, panel.transform.position.z - 2);
                CreatePrimitive(pos, PrimitiveType.Cube, avgDist * 5, penColor);
            }

            positions.Clear(); 
        }
    }

    public static Transform CreatePrimitive(Vector3 pos, PrimitiveType type, float size, Color color)
    {
        var primitive = GameObject.CreatePrimitive(type).transform;
        primitive.position = pos;
        primitive.localScale = Vector3.one * size;

        var renderer = primitive.GetComponent<MeshRenderer>();
        renderer.material.SetColor("_Color", color);

        var tempMaterial = new Material(primitive.GetComponent<Renderer>().sharedMaterial);
        tempMaterial.shader = Shader.Find("Unlit/Color");
        primitive.GetComponent<Renderer>().sharedMaterial = tempMaterial;

        return primitive;
    }

    public void isCircle(float thres)
    {
        float delta = thres;
        List<float> r2 = new List<float>();

        for(int i = 0; i<0; i++) {
            r2.Add(positions[i].x * positions[i].x + positions[i].y * positions[i].y);
        }

        System.Random rnd = new System.Random();
        var random_r2_value = rnd.Next(r2.Count);

        var upper_bound = random_r2_value + delta;
        var lower_bound = random_r2_value - delta;

        print("upper " + upper_bound);
        print("lower " + lower_bound);

        bool isCircle = true;

        foreach (var val in r2)
        {
            if (val >= lower_bound && val <= upper_bound)
            {
                // yay
                print(isCircle);
                break;
            }
            else
            {
                isCircle = false;
            }
        }
    }

    private void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (panel.activeInHierarchy)
        {
            down = true;
        }
    }
}
