using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPicture : MonoBehaviour
{
    [Tooltip("face")]
    public RawImage face;
    public Text name;
    public Text date;

    private void Start()
    {
        if (GameData.texture != null) face.texture = GameData.texture;
        if (GameData.name != null) name.text = GameData.name;
        if (GameData.date != null) date.text = GameData.date;
    }
}
