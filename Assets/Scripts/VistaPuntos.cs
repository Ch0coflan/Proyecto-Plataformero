using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VistaPuntos : MonoBehaviour
{
    public List<Sprite> values = new List<Sprite>();

    private Image imageRender;

    private void Awake()
    {
        imageRender = GetComponent<Image>();
    }

    public void SetNumber(int number)
    {
        imageRender.sprite = values[number];
    }

}
