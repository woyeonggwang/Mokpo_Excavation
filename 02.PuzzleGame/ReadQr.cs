using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;    //ZXing.dll ����Ʈ �� ����.

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
        //ī�޶� ȭ�� ũ�� ���� //�⺻ �� ��ũ�� �ʺ�, ����
        screenRect = new Rect(0, 0, 1920, 1080);
        webcam = new WebCamTexture();
        //�о� ���̴� �� ķ �ؽ��� ���� ���� �ƴϸ�
        //if (webcam != null)
        //{
            //ī�޶� ���� �÷���.  
            //���� ���� ��Ű�� �ʹٸ� -> camTexture.Stop(); 
            //QR�ڵ� �ν� �� ���� �Ѿ�ٸ� �ݵ�� Stop�� ���־�� ī�޶� ������.
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
        //OnGUI�� ���� ȭ�鿡 ����ȭ
        //ī�޶� ȭ�� ũ��, ī�޶� ���� �ؽ��� ��(�� ķ �ؽ���), ȭ�鿡 ���� �׸���
        //GUI.DrawTexture(screenRect, webcam, ScaleMode.ScaleToFit);

        try
        {
            //Decode�� ���� QRcode �о� ���̱�. 
            IBarcodeReader barcodeReader = new BarcodeReader();
            if (webcam.isPlaying)
            {
                var result = barcodeReader.Decode(webcam.GetPixels32(), webcam.width, webcam.height);
                //���� ��� ���� ���� �ƴϸ�
                if (result != null)
                {
                    //�ν��� QRcode�� �ؽ�Ʈ ���� �α�.
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
