using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Valve.VR;
using Valve.VR.Extras;

public class LaserInput : MonoBehaviour
{
    // Start is called before the first frame update
    private SteamVR_LaserPointer steamVrLaserPointer;
    private bool isPointerIn = false;
    private bool isSelected = false;
    public GameObject WindowPrefab;
    void Start()
    {
        steamVrLaserPointer = gameObject.GetComponent<SteamVR_LaserPointer>();
        steamVrLaserPointer.PointerIn += OnPointerIn;
        steamVrLaserPointer.PointerOut += OnPointerOut;
        steamVrLaserPointer.PointerClick += OnPointerClick;
        WindowPrefab = GameObject.Find("WindowPrefab");
        //WindowPrefab.gameObject.SetActive(true);
        //GameObject.Find("WindowPrefab").SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnPointerClick(object sender, PointerEventArgs e)
    {
        IPointerClickHandler clickHandler = e.target.GetComponent<IPointerClickHandler>();
        if (clickHandler == null)
        {
            return;
        }
        if (e.target.name == "ButtonFolder1" && isPointerIn)
        {
            print("Button");
            WindowPrefab.transform.localScale = e.target.transform.localScale;
        }
        if (e.target.name == "ButtonCloseFolder1" && isPointerIn)
        {

            WindowPrefab.transform.localScale = new Vector3(0, 0, 0);
        }


        clickHandler.OnPointerClick(new PointerEventData(EventSystem.current));
    }

    private void OnPointerOut(object sender, PointerEventArgs e)
    {
        IPointerExitHandler pointerExitHandler = e.target.GetComponent<IPointerExitHandler>();
        if (pointerExitHandler == null)
        {
            return;
        }
        isPointerIn = false;
        isSelected = false;
        pointerExitHandler.OnPointerExit(new PointerEventData(EventSystem.current));
    }

    private void OnPointerIn(object sender, PointerEventArgs e)
    {
        IPointerEnterHandler pointerEnterHandler = e.target.GetComponent<IPointerEnterHandler>();
        if (pointerEnterHandler == null)
        {
            return;
        }
        isPointerIn = true;
       
        pointerEnterHandler.OnPointerEnter(new PointerEventData(EventSystem.current));
    }
}
