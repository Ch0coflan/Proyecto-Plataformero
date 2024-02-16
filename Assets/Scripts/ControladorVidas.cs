using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorVidas : MonoBehaviour
{
    public List<VistaVidas> heartViews = new List<VistaVidas>();

    public void UpdateLife(int amount)
    {

        foreach (var hearth in heartViews)
        {
            hearth.UpdateHeart(0);
        }

        int amountHearth = (int)amount / 2;

        for (int i = 0; i < amountHearth; i++)
        {
            heartViews[i].UpdateHeart(2);
        }

        int currentHearth = (int)amount % 2;
        heartViews[amountHearth].UpdateHeart(currentHearth);

    } 
}
