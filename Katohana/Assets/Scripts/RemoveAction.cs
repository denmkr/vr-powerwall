using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

public class RemoveAction : MonoBehaviour
{
    public void RemoveAll()
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
    }
}
