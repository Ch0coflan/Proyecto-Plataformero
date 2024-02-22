using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{
    public List<VistaPuntos> Puntos = new List<VistaPuntos>();

    public void UpdatePoints(int points)
    {
        foreach (var valor in Puntos)
        {
            int currentNumber = points % 10;
            points /= 10;

            valor.SetNumber(currentNumber);
        }
    }
}
