using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JigsawPuzzle : MonoBehaviour
{
    public static int Count;
    public static int index;
    public GameObject puzzlePosSet;     //������ �־�� �� ������
    public GameObject puzzlePieceSet;   //���� ����
    public Image paper;
    public Sprite[] paperSprite;

    private void Start()
    {
        Paper.state = false;
    }

    private void Update()
    {
        if(Count == 10)
        {
            // ��;
            
            Paper.state = true;
            Debug.Log("Clear");
        }
        paper.sprite = paperSprite[index];
    }
}
