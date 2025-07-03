using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    [Tooltip("Button")]
    public Button startGame;
    public Button back;
    public Button home;

    [Tooltip("UiObject")]
    public GameObject startUi;
    public GameObject successUi;

    public GameObject[] pzComplete;
    public GameObject[] pzFind;
    public GameObject[] pzHint;
    public GameObject[] pzMarker;
    public GameObject[] puzzlePiece;
    public GameObject paper;
    public List<int> temp = new List<int>();

    public GameObject clearSound;
    private SoundManager sound;
    private int length = 10;



    private bool gameEnd; //퍼즐성공 후 메인화면으로 돌아가기 위한 변수값
    
    private void Awake()
    {
        startGame.onClick.AddListener(() => BtnStart());
        back.onClick.AddListener(() => BtnBack());
        home.onClick.AddListener(() => BtnHome());
        instance = this;
        ArPuzzle.state = true;
        for (int i = 0; i < puzzlePiece.Length; i++)
        {
            puzzlePiece[i].SetActive(false);
            pzHint[i].SetActive(true);
        }
        paper.SetActive(false);
    }
    private void Start()
    {
        gameEnd = false;
        sound = GetComponent<SoundManager>();

        
        for (int i = 0; i < PuzzleBools.pzBool; i++)
        {
            while(temp.Count < 5)
            {
                int num = Random.Range(0, 10);
                if (!temp.Contains(num))
                {
                    temp.Add(num);
                }
            }
        }

        for(int i = 0; i < temp.Count; i++)
        {
            pzComplete[temp[i]].SetActive(true);
            pzHint[temp[i]].SetActive(false);
            pzMarker[temp[i]].SetActive(false);
        }
    }
           
    private void Update()
    {
        if (gameEnd)
        {
            clearSound.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                ArPuzzle.state = false;
                SceneManager.LoadScene(3);

            }
        }
    }

    public void Success()
    {
        successUi.SetActive(true);

        StartCoroutine(EndDelay());
    }


    public void BtnStart()
    {
        sound.Play(0);
        startUi.SetActive(false);
    }
    public void BtnBack()
    {
        ArPuzzle.state = false;
        sound.Play(0);
        SceneManager.LoadScene(0);
    }
    public void BtnHome()
    {
        sound.Play(0);
        ArPuzzle.state = false;
        SceneManager.LoadScene(0);
    }

    IEnumerator EndDelay()
    {
        yield return new WaitForSeconds(2.0f);
        gameEnd = true;
    }


}
