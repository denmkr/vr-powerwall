using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickAction : MonoBehaviour, IPointerClickHandler
{
    private GameObject m_Pointer_Dot;
    private GameObject canvas;
    private GameObject colorfulDot;

    void Start()
    {
        colorfulDot = GameObject.Find("ColorfulDot");
        m_Pointer_Dot = GameObject.Find("Dot");
        canvas = GameObject.Find("Canvas");
    }
 
    public void OnPointerClick(PointerEventData eventData)
    {
        /*GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Renderer rend = sphere.GetComponent<Renderer>();
        rend.material.color = this.gameObject.GetComponent<Image>().color;

       Instantiate(sphere, new Vector3(m_Pointer_Dot.transform.position.x, m_Pointer_Dot.transform.position.y, canvas.transform.position.z), Quaternion.identity);*/

        //Material mat = newDot.AddComponent<Material>().SetColor(this.gameObject.GetComponent<Image>().color);
        var renderer = colorfulDot.GetComponent<Renderer>();
        renderer.material.color = this.gameObject.GetComponent<Image>().color;

       // var renderer = new Renderer();
        //renderer.material.color = this.gameObject.GetComponent<Image>().color;

        //Material myNewMaterial = new Material(Shader.Find("Unlit/Color"));
        // myNewMaterial.color = this.gameObject.GetComponent<Image>().color;
        //print(myNewMaterial.color);

        /*var clr = ColorUtility.ToHtmlStringRGB(this.gameObject.GetComponent<Image>().color);
        print(clr);
        ButtonTransitioner bt = new ButtonTransitioner();
        bt.setMaterialColor(clr); */

    }
}