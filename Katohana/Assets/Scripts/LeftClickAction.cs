using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using Valve.VR.Extras;

public class LeftClickAction : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler
{
    public Color32 m_NormalColor = Color.white;
    public Color32 m_HoverColor = Color.red;
    public Color32 m_DownColor = Color.green;
    public Color32 m_ClickColor = Color.blue;

    public GameObject m_Pointer_Dot;

    private Image m_Image = null;
    private bool _rotateLeft = false;
    private bool _rotateRight = false;
    private RectTransform m_rectTransform = null;
    public bool selected;
    public GameObject WindowPrefab;
    private SteamVR_LaserPointer laserPointer;


    //Dragging 
    private bool dragging;

    private void Awake()
    {
        m_Image = GetComponent<Image>();
        m_rectTransform = GetComponent<RectTransform>();
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
        selected = false;
        // create new element dynamically
        //createNewElement();
    }

    private void Update()
    {
        if (_rotateRight == true) rotationRightObjection();
        if (_rotateLeft == true) rotationLeftObjection();
        if (dragging)
        {
            transform.position = new Vector3(m_Pointer_Dot.transform.position.x, m_Pointer_Dot.transform.position.y, 2);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        print("Click");

        m_Image.color = m_ClickColor;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Down");
        // _rotateRight = true;
        dragging = true;
        m_Image.color = m_DownColor;
    }
    public void OnPointerLeft(PointerEventData eventData)
    {
        print("Down");
        _rotateLeft = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        print("Enter");
        m_Image.color = m_HoverColor;

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print("Exit");
        // _rotateLeft = false;
        // _rotateRight = false;
        m_Image.color = m_NormalColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
        print("Up");
    }

    public void OnSelect(BaseEventData eventData)
    {

    }

    public void PointerInside(object sender, PointerEventArgs e)
    {

        if (e.target.name == this.gameObject.name && selected == false)
        {
            selected = true;
            m_Image.color = m_HoverColor;
            Debug.Log("pointer is inside this object" + e.target.name);
        }
    }
    public void PointerOutside(object sender, PointerEventArgs e)
    {

        if (e.target.name == this.gameObject.name && selected == true)
        {
            selected = false;
            Debug.Log("pointer is outside this object" + e.target.name);
        }
    }
    public bool get_selected_value()
    {
        return selected;
    }
    private void rotationRightObjection()
    {
        Vector3 rotationEuler = new Vector3(0, 0, 0);
        rotationEuler += Vector3.forward * 30 * Time.deltaTime;
        // m_rectTransform.rotation = Quaternion.Euler(rotationEuler);
        m_rectTransform.Rotate(new Vector3(0, 0, 10));


    }
    private void rotationLeftObjection()
    {
        Vector3 rotationEuler = new Vector3(0, 0, 0);
        rotationEuler += Vector3.forward * -30 * Time.deltaTime;
        // m_rectTransform.rotation = Quaternion.Euler(rotationEuler);
        m_rectTransform.Rotate(new Vector3(0, 0, 10));


    }

    private void createNewElement()
    {
        GameObject mCanvas = GameObject.Find("Canvas");

        GameObject go = GameObject.Instantiate(WindowPrefab);
        go.transform.SetParent(mCanvas.transform);
        //go.transform.localScale = new Vector3(1, 1, 1);
        go.transform.localPosition = new Vector3(10, -47, 0);

        

        GameObject button = new GameObject();
        button.transform.SetParent(mCanvas.transform);
        button.transform.localPosition = new Vector3(10, -47, 0);

        return;
    }
    private void activateElement()
    {

    }

    void Testmethod()
    {
        Debug.Log("Button Pressed");
    }
}

