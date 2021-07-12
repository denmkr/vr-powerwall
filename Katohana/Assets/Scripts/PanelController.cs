using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PanelController : MonoBehaviour
{
    public GameObject panel;
    public Slider slider;
    public GameObject dot;

    public void changeValue()
    {
        dot.transform.localScale = new Vector3(slider.value, slider.value, slider.value);
        print(slider.value);
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
    }
}
