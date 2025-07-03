using System.Collections;
using System.Collections.Generic;
using System;
using Unity.MARS.Providers;
using Unity.MARS.Settings;
using Unity.XRTools.ModuleLoader;
using UnityEngine;
using UnityEngine.UI;

public class ArPuzzle : MonoBehaviour, IUsesFunctionalityInjection, IUsesSessionControl
{
    IProvidesFunctionalityInjection IFunctionalitySubscriber<IProvidesFunctionalityInjection>.provider { get; set; }
    IProvidesSessionControl IFunctionalitySubscriber<IProvidesSessionControl>.provider { get; set; }
    

    public int pzNum;
    public Animator magnifier;
    public GameObject arMask;
    public GameObject paper;
    public GameObject pzPiece;
    public int index;
    public static bool state;


    private void OnEnable()
    {
        if (state)
        {
            index++;
            print(0);
            if (index == 1)
            {
                transform.GetChild(0).gameObject.SetActive(true);
                StarManager.instance.count += 1;
                paper.SetActive(true);
                pzPiece.SetActive(true);
                Paper.index = pzNum;
                StartCoroutine(Delay());
                print(1);
            }
            else
            {
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            index = 0;
        }
        
    }
    

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(0.5f);
        this.PauseSession();
        magnifier.SetBool("state", false);
        arMask.SetActive(false);
        print(2);
    }

}
