using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateChecker : MonoBehaviour
{
    public void OnEnable()
    {
        PuzzleControl.instance.countStar += 1;
    }
}
