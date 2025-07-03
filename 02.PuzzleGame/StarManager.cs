using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarManager : MonoBehaviour
{
    public static StarManager instance;
    public Transform parent;
    public Image[] star;
    public Sprite twinkle;
    public Sprite unlight;
    public int count;
    public bool checker;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        checker = false;
        count = -1;
        for(int i=0; i<star.Length; i++)
        {
            star[i].sprite = unlight;
        }
    }
    public void Update()
    {
        if (count > -1)
        {
            checker = true;
        }
        if (checker)
        {
            star[count].sprite = twinkle;
        }

        
    }


}
