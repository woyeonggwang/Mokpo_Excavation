using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PuzzleControl : MonoBehaviour
{
    public static PuzzleControl instance;

    [Header("Puzzle")]
    public GameObject[] puzzle;
    public GameObject[] unclickImg;
    public GameObject[] pzHint;
    public GameObject pzActiveEff;

    [Header("paper")]
    public GameObject paperParent;
    public Image paper;
    public Sprite[] paperSpr;

    [Header("Star")]
    public Image[] star;
    public Sprite[] starSpr;
    [HideInInspector]public int countStar;
    public GameObject enableChecker;

    [Header("QR인식")]
    public static bool stateQR;
    public GameObject webcamTxt;


    [Header("버튼")]
    public Button magnifier;
    public Button closePaper;
    public Button popupClose;

    [Header("기타")]
    public GameObject clearSound;
    public GameObject magifierLight;
    public GameObject ui00;
    [HideInInspector]public List<int> ranIdx = new List<int>();
    public Animator magAnim;

    private bool gameEnd;
    private bool magClicked;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameEnd = false;
        magClicked = false;
        countStar = 0;

        //랜덤수 생성
        {
            for (int i = 0; i < 5; i++)
            {
                while (ranIdx.Count < 5)
                {
                    int num = Random.Range(0, 10);
                    if (!ranIdx.Contains(num))
                    {
                        ranIdx.Add(num);
                    }
                }
            }
            for(int i=0; i<ranIdx.Count; i++)
            {
                unclickImg[ranIdx[i]].SetActive(true);
                pzHint[ranIdx[i]].SetActive(false);
            }
        }
        //랜덤수 생성

        BtnSetter();


    }

    private void Update()
    {
        if (gameEnd)
        {
            clearSound.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene(3);
            }
        }
        
        if (magClicked)
        {
            CheckQR();
        }
        GameCheck();
    }

    private void BtnSetter()
    {
        magnifier.onClick.AddListener(() => MagBtn());
        closePaper.onClick.AddListener(() => CloseBtn());
        popupClose.onClick.AddListener(() => ClosePopup());
    }

    private void MagBtn()
    {
        magAnim.SetBool("state", true);
        magClicked = true;
        stateQR = true;
        webcamTxt.SetActive(true);
    }
    private void CheckQR()
    {
        if (ReadQr.strBarcodeRead == "Piece00" && !unclickImg[0].activeInHierarchy) 
        { 
            StartCoroutine(PzActivator(0));
            if (!stateQR)
            {
                webcamTxt.SetActive(false);
            }
        }
        else if (ReadQr.strBarcodeRead == "Piece01" && !unclickImg[1].activeInHierarchy) 
        { 
            StartCoroutine(PzActivator(1));
            if (!stateQR)
            {
                webcamTxt.SetActive(false);
            }
        }
        else if (ReadQr.strBarcodeRead == "Piece02" && !unclickImg[2].activeInHierarchy) 
        { 
            StartCoroutine(PzActivator(2));
            if (!stateQR)
            {
                webcamTxt.SetActive(false);
            }
        }
        else if (ReadQr.strBarcodeRead == "Piece03" && !unclickImg[3].activeInHierarchy) 
        { 
            StartCoroutine(PzActivator(3));
            if (!stateQR)
            {
                webcamTxt.SetActive(false);
            }
        }
        else if (ReadQr.strBarcodeRead == "Piece04" && !unclickImg[4].activeInHierarchy) 
        { 
            StartCoroutine(PzActivator(4));
            if (!stateQR)
            {
                webcamTxt.SetActive(false);
            }
        }
        else if (ReadQr.strBarcodeRead == "Piece05" && !unclickImg[5].activeInHierarchy) 
        { 
            StartCoroutine(PzActivator(5));
            if (!stateQR)
            {
                webcamTxt.SetActive(false);
            }
        }
        else if (ReadQr.strBarcodeRead == "Piece06" && !unclickImg[6].activeInHierarchy) 
        { 
            StartCoroutine(PzActivator(6));
            if (!stateQR)
            {
                webcamTxt.SetActive(false);
            }
        }
        else if (ReadQr.strBarcodeRead == "Piece07" && !unclickImg[7].activeInHierarchy) 
        { 
            StartCoroutine(PzActivator(7));
            if (!stateQR)
            {
                webcamTxt.SetActive(false);
            }
        }
        else if (ReadQr.strBarcodeRead == "Piece08" && !unclickImg[8].activeInHierarchy) 
        { 
            StartCoroutine(PzActivator(8));
            if (!stateQR)
            {
                webcamTxt.SetActive(false);
            }
        }
        else if (ReadQr.strBarcodeRead == "Piece09" && !unclickImg[9].activeInHierarchy) 
        { 
            StartCoroutine(PzActivator(9));
            if (!stateQR)
            {
                webcamTxt.SetActive(false);
            }
        }
        else
        {
            stateQR = true;
        }
    }
    IEnumerator PzActivator(int index)
    {
        enableChecker.SetActive(true);
        magifierLight.SetActive(false);
        magAnim.SetBool("state", false);
        yield return new WaitForSeconds(1f);
        magClicked = false;
        puzzle[index].SetActive(true);
        pzActiveEff.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        unclickImg[index].SetActive(true);
        pzActiveEff.SetActive(false);
        paper.sprite = paperSpr[index];
        paperParent.SetActive(true);
        enableChecker.SetActive(false);
        
        yield return new WaitForSeconds(2f);
        magifierLight.SetActive(true);
    }
    public void GameCheck()
    {
        for(int i=0; i<countStar; i++)
        {
            star[i].sprite = starSpr[1];
        }
        

    }
    public void ClosePopup()
    {
        ui00.SetActive(false);
    }
    public void CloseBtn()
    {
        paperParent.SetActive(false);
        if (countStar > 4)
        {
            gameEnd = true;
        }
    }

}
