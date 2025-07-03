using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeedController : MonoBehaviour
{

    [Tooltip("Button")]
    public Button takePhoto;        //사진찍는 버튼

    private SoundManager sound;

    [Tooltip("Date")]
    public Text date;
    private DateTime sysDate = DateTime.Now;

    private void Awake()
    {
        /*버튼*/
        takePhoto.onClick.AddListener(() => BtnPhoto());

    }

    public void Start()
    {
        sound = GetComponent<SoundManager>();
        string t_Date = sysDate.ToString("yyyy-MM-dd");//string으로 변환
        sysDate = DateTime.ParseExact(t_Date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture); //DateTime으로 변환
        GameData.date = t_Date;
        date.text = GameData.date;
    }

    public void BtnPhoto()
    {
        StartCoroutine(Delay());
    }
    IEnumerator Delay()
    {
        sound.Play(0);
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(4);
    }

}
