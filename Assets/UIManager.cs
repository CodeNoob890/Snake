using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    public int count = 0;

    private static UIManager instance;

    public static UIManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if(instance == null)
            instance = this;
    }

    public void UpdateUI()
    {
        text.text = count.ToString();
    }

}
