using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoBehaviour
{
    public static bool state;
    public static int index;
    public Button close;
    public GameObject paper;
    public GameObject magLight;
    public Image paperImg;
    public Sprite[] paperSprite;
    private SoundManager sound;
    private bool checkEnd;
    private int count;
    private void Awake()
    {
        close.onClick.AddListener(() => BtnClose());
    }
    private void Start()
    {
        sound = GetComponent<SoundManager>();
        checkEnd = false;
    }

    private void Update()
    {
        paperImg.sprite = paperSprite[index];
        if (checkEnd)
        {
            
            //StartCoroutine(Delay());
        }
    }
    public void BtnClose()
    {
        count++;
        magLight.SetActive(true);
        sound.Play(0);
        if (count==5)
        {
            checkEnd = true;   
        }
        else
        {
            paper.SetActive(false);
        }
    }

    IEnumerator Delay()
    {
        
        yield return new WaitForSeconds(0.1f);
        GameController.instance.Success();
        paper.SetActive(false);
    }


}
