using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateName : MonoBehaviour
{

    [Tooltip("Name")]
    public Text name;

    [Tooltip("Home/Next")]
    public Button home;
    public Button next;

    public void Start()
    {
        
    }

    private void BtnNext()
    {
        if (name.text.Length > 0)
        {
            GameData.name = name.text;

        }
    }

}
