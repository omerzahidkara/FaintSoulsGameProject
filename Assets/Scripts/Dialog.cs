
using System.Collections.Generic;
using UnityEngine;

// Bir diyalog i�eri�ini temsil eden s�n�f
[System.Serializable]
public class Dialog
{
    [SerializeField] List<string> lines; // Diyalog sat�rlar�n� i�eren liste

    public List<string> Lines
    {
        get { return lines; } // Diyalog metnini d��ar�dan eri�ilebilir hale getirir
    }
}
