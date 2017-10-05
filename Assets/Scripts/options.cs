using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class options : MonoBehaviour {

    public Dropdown graphicsDrop;
    public Dropdown resDrop;

    void Start()
    {
        this.gameObject.SetActive(false);

        resDrop.onValueChanged.AddListener(delegate {
            resValueChangedHandler(resDrop);
        });

        graphicsDrop.onValueChanged.AddListener(delegate {
            graphicsValueChangedHandler(graphicsDrop);
        });

        if (QualitySettings.GetQualityLevel() == 0)
            SetGraphicsDropdownIndex(0);

        if (QualitySettings.GetQualityLevel() == 3)
            SetGraphicsDropdownIndex(3);

        if (QualitySettings.GetQualityLevel() == 5)
            SetGraphicsDropdownIndex(5);
    }

    private void Update()
    {
        Debug.Log("Quality: " + QualitySettings.GetQualityLevel());
    }

    void Destroy()
    {
        graphicsDrop.onValueChanged.RemoveAllListeners();
        resDrop.onValueChanged.RemoveAllListeners();
    }

    private void graphicsValueChangedHandler(Dropdown target)
    {
        Debug.Log("selected: " + target.value);
        if (target.value == 0)
        {
            QualitySettings.SetQualityLevel(0);
        }

        if (target.value == 1)
        {
            QualitySettings.SetQualityLevel(3);
        }

        if (target.value == 2)
        {
            QualitySettings.SetQualityLevel(5);
        }
    }

    private void resValueChangedHandler(Dropdown target)
    {
        if (target.value == 0)
        {
            Screen.SetResolution(1280, 1024, true);
            Debug.Log("Hello");
        }

        if (target.value == 1)
        {
            Screen.SetResolution(1680, 1050, true);
            Debug.Log("Hello");
        }

        if (target.value == 2)
        {
            Screen.SetResolution(1920, 1080, true);
            Debug.Log("Hello");
        }
    }

    public void SetGraphicsDropdownIndex(int index)
    {
        graphicsDrop.value = index;
    }

    public void SetResDropdownIndex(int index)
    {
        resDrop.value = index;
    }
}
