using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampSound : MonoBehaviour
{
    public GameObject sound;

    public void Stamp()
    {
        sound.SetActive(true);
    }
}
