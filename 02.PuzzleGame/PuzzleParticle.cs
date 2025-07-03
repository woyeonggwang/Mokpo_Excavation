using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleParticle : MonoBehaviour
{
    public GameObject particle;


    public void OnEnable()
    {
        particle.SetActive(true);
    }

}
