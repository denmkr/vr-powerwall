using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowPrefabScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject WindowPrefab = null;
    void Start()
    {
        WindowPrefab = GameObject.Find("WindowPrefab");
        //mWindow.AddComponent<MeshRenderer>();
        //mWindow.GetComponent<MeshRenderer>().enabled = false;
        WindowPrefab.transform.localScale = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
