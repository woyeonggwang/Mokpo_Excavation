using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle : MonoBehaviour
{

    public GameObject particle;
    public Animator pz;
    public GameObject pzComplete;
    public GameObject hint;

    public void OnEnable()
    {
        particle.SetActive(true);
        pz.SetBool("state", true);
        hint.SetActive(false);
    }
    public void OnDisable()
    {
        try
        {
            particle.SetActive(false);

        }
        catch
        {

        }
        pz.SetBool("state", false);
    }
    public void AnimComplete()
    {
        pzComplete.SetActive(true);
        particle.SetActive(false);
    }


}
