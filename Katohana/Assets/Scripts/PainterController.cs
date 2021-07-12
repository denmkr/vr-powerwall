using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Valve.VR;
using System;

public class PainterController : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler
{

    public GameObject panel;
    public void OnPointerClick(PointerEventData eventData)
    {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == "ColorfulDot(Clone)");
        var cubes = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.Contains("Cube"));
        var spheres = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name.Contains("Sphere"));

        if (objects.Count() > 0)
        {
            foreach (GameObject item in objects)
            {
                Destroy(item);
            }
        }
        if (cubes.Count() > 0)
        {
            foreach (GameObject item in cubes)
            {
                Destroy(item);
            }
        }
        if (spheres.Count() > 0)
        {
            foreach (GameObject item in spheres)
            {
                Destroy(item);
            }
        }


        panel.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
