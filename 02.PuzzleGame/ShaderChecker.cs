using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShaderChecker : MonoBehaviour
{
    public GameObject clearPopup;
    public Image roll;
    float ShowupValue;
    private bool state;
    private void Awake()
    {
        state = false;
        roll.material.SetFloat("_Showup", 0f);
    }

    private void OnEnable()
    {
        state = true;
    }
    private void Update()
    {
        print(state);
        if (state)
        {
            // ShowupValue <-- º¯°æ
            ShowupValue += 0.35f * Time.deltaTime;
            roll.material.SetFloat("_Showup", Mathf.Clamp(ShowupValue, 0, 1));
            StartCoroutine(Delay());
        }
    }

    public void Check()
    {
        clearPopup.SetActive(true);
    }
    public void OnDisable()
    {
        clearPopup.SetActive(false);
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(3f);
        Check();
    }
}
