using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    [SerializeField] private int aantalAanrakingenMetEenVrouw;

    [SerializeField] private float sigmaFactor;

    [SerializeField] private float voorhoofdDiameter;

    private float bitchesFactor;

    void Start()
    {
        bitchesFactor = Mathf.Ceil(aantalAanrakingenMetEenVrouw / sigmaFactor * Mathf.Sqrt(voorhoofdDiameter) * aantalAanrakingenMetEenVrouw / Mathf.DeltaAngle(sigmaFactor, voorhoofdDiameter));
        Debug.Log(bitchesFactor);
    }

}
