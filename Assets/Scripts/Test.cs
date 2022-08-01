using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private float gekkenummer;
    private int factor = 420;


    private void Awake()
    {
        kut();
    }

    private void kut()
    {
        gekkenummer = getdiehorensloerie((int)gekkenummer);
        Debug.Log(gekkenummer);
    }

    public int getdiehorensloerie(int lijpe)
    {
        return lijpe * factor;
    }
}
