using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;    //ZXing.dll 임포트 후 선언.

public class ReadQr : MonoBehaviour
{
    public RawImage rawimage;
    WebCamTexture webcam;
    private Rect screenRect;
    private bool camActive;

    public static string strBarcodeRead;
    private void Awake()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        webcam = new WebCamTexture(1920, 1080, 30);
        foreach (WebCamDevice cam in devices)
        {
            if (!cam.isFrontFacing)
            {
                webcam = new WebCamTexture(0, Screen.width, Screen.height);
                webcam.deviceName = cam.name;
                webcam.Play();
            }
        }

        camActive = false;
    }
    private void Start()
    {
        
        strBarcodeRead = null;
        //카메라 화면 크기 조정 //기본 값 스크린 너비, 높이
        screenRect = new Rect(0, 0, 1920, 1080);
        webcam = new WebCamTexture();
        //읽어 들이는 웹 캠 텍스쳐 값이 널이 아니면
        //if (webcam != null)
        //{
            //카메라 동작 플레이.  
            //만약 정지 시키고 싶다면 -> camTexture.Stop(); 
            //QR코드 인식 후 씬이 넘어간다면 반드시 Stop을 해주어야 카메라가 꺼진다.
            //webcam.Play();
        //}
        

    }
    public void Update()
    {
        if (!PuzzleControl.stateQR)
        {
            webcam.Stop();
        }
        else
        {
            webcam.Play();
            rawimage.texture = webcam;
        }
        if (webcam.isPlaying)
        {
            rawimage.gameObject.SetActive(true);
        }
        else
        {
            rawimage.gameObject.SetActive(false);
        }

    }

    private void OnGUI()
    {
        //OnGUI를 통한 화면에 가시화
        //카메라 화면 크기, 카메라에 쓰일 텍스쳐 값(웹 캠 텍스쳐), 화면에 맟게 그리기
        //GUI.DrawTexture(screenRect, webcam, ScaleMode.ScaleToFit);

        try
        {
            //Decode를 통한 QRcode 읽어 들이기. 
            IBarcodeReader barcodeReader = new BarcodeReader();
            if (webcam.isPlaying)
            {
                var result = barcodeReader.Decode(webcam.GetPixels32(), webcam.width, webcam.height);
                //만약 결과 값이 널이 아니면
                if (result != null)
                {
                    //인식한 QRcode의 텍스트 값을 로그.
                    Debug.Log(result.Text);
                    strBarcodeRead = result.Text;
                    StartCoroutine(Delay());
                }
            }
            
        }
        catch (Exception ex)
        {
            Debug.LogWarning(ex.Message);
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        PuzzleControl.stateQR = false;
    }
}
