using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCard : MonoBehaviour
{
    public RenderTexture Face;
    [Tooltip("Camera")]
    public RawImage rawimage;
    public GameObject[] timer;
    public GameObject createCard;
    private WebCamTexture webcam;


    private void Awake()
    {
        webcam = new WebCamTexture(1920, 1080, 30);
        webcam.Play();
        rawimage.texture = webcam;
    }

    public void GetPhoto()
    {
        print(1);
        StartCoroutine(PhotoDelay());
    }


    IEnumerator PhotoDelay()
    {
        print(2);
        yield return new WaitForSeconds(1f*Time.deltaTime);
        timer[0].SetActive(true);
        yield return new WaitForSeconds(1f * Time.deltaTime);
        timer[1].SetActive(true);
        yield return new WaitForSeconds(1f * Time.deltaTime);
        timer[2].SetActive(true);
        yield return new WaitForSeconds(1f * Time.deltaTime);
        timer[3].SetActive(true);
        yield return new WaitForSeconds(1f * Time.deltaTime);
        timer[4].SetActive(true);
        webcam.Stop();
        GameData.texture = rawimage.texture;

    }

}
