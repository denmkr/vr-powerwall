using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using Valve.VR;

public class ButtonTransitioner : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerDownHandler, IPointerClickHandler, IPointerUpHandler
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

    //Panel Controls
    public GameObject panel;
    private GameObject canvas;

    //Double Click
    float lastClick = 0f;
    float interval = 0.4f;

    //Dragging 
    private bool dragging;

    //Drawing
    private bool drawing;
    private bool stateDownStatus;

    private GameObject penDot;
    private GameObject pen;

    public SteamVR_Action_Boolean m_triggerButtonClick;
    public SteamVR_Input_Sources handType;
    private Renderer mat_color;


    //Squeeze -- Depth of the trigger
    public SteamVR_Action_Single squeeze;

    private void Awake()
    {
        drawing = false;
        penDot = GameObject.Find("ColorfulDot");
        m_Image = GetComponent<Image>();
        m_rectTransform = GetComponent<RectTransform>();
        canvas = GameObject.Find("Canvas");
        m_triggerButtonClick.AddOnStateDownListener(TriggerDown, handType);
        m_triggerButtonClick.AddOnStateUpListener(TriggerUp, handType);
        mat_color = penDot.GetComponent<Renderer>();
        pen = penDot;
    }

    private void Update()
    {
        float depth = squeeze.GetAxis(handType);

        if (_rotateRight == true) rotationRightObjection();
        if (_rotateLeft == true) rotationLeftObjection();
        if (dragging)
        {
            //transform.position = new Vector3(m_Pointer_Dot.transform.position.x,m_Pointer_Dot.transform.position.y,m_Pointer_Dot.transform.position.z);
            transform.position = new Vector3(m_Pointer_Dot.transform.position.x, m_Pointer_Dot.transform.position.y, canvas.transform.position.z);
        }
        if (gameObject.tag.Equals("paint") && panel.activeInHierarchy && !dragging)
        {
            if (depth != 0)
            {
                pen.transform.localScale = new Vector3(depth, depth, depth);
                Instantiate(pen, new Vector3(m_Pointer_Dot.transform.position.x, m_Pointer_Dot.transform.position.y, canvas.transform.position.z), Quaternion.identity);
            }
            //print("draw");
            //print(mat_color.material.color);
            
        }
        
        
           
      

    }

    
  
    public void OnPointerClick(PointerEventData eventData)
    {
        if ((lastClick + interval) > Time.time)
        {
            //is a double click 
            print("Double Click");
            panel.SetActive(true);
        }
        else
        {
            //is a single click 
            lastClick = Time.time;
        }
       
        m_Image.color = m_ClickColor;   
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Down");
        // _rotateRight = true;
   
        if(gameObject.tag.Equals("paint") && panel.activeInHierarchy)
        {
            drawing = true;
        }
        else
        {
            dragging = true;
        }

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
        if (gameObject.tag.Equals("paint") && panel.activeInHierarchy)
        {
            drawing = false;
        }
        else
        {
            dragging = false;
        }
        //dragging = false;
        print("Up");
    }

    public void TriggerDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        drawing = true;
    }

    public void TriggerUp(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        drawing = false; 
    }

    /* public void setMaterialColor(string color)
    {
        //print(rend.material.color);
        //mat_color.material.SetColor("red",rend.material.color);
        //penDot.GetComponent<Renderer>()
      
        if (color.Equals("0072FF"))
        {
            //pen.AddComponent<Renderer>().material.SetColor("Blue",blueDot.GetComponent<Renderer>().material.color);
            //print(ColorUtility.ToHtmlStringRGB(penDot.GetComponent<Renderer>().material.color));
            pen = GameObject.Find("BlueDot");
        } 
        
    }

    public Renderer getMaterialColor()
    {
        return mat_color;
    } */

    private void rotationRightObjection()
    {
        Vector3 rotationEuler = new Vector3(0,0,0);
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


}
