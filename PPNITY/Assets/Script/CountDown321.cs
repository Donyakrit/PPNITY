using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown321 : MonoBehaviour
{
    private IEnumerator coroutine;

    public TMP_Text Text321;
    public GameObject Text321Canvas;
    public GameObject PlayerController;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.GetComponent<PlayerController2>().enabled = false;
        PlayerController.GetComponent<CapsuleCollider>().enabled = true;
        coroutine = Wait(2.0f);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Wait(float waitTime)
    {
        Text321Canvas.SetActive(true);
        Text321.text = "3";
        yield return new WaitForSeconds(1);
        Text321.text = "2";
        yield return new WaitForSeconds(1);
        Text321.text = "1";
        yield return new WaitForSeconds(1);
        Text321.text = "Go!";
        yield return new WaitForSeconds(1);
        PlayerController.GetComponent<PlayerController2>().enabled = true;
        Text321Canvas.SetActive(false);
        PlayerController.GetComponent<CapsuleCollider>().enabled = false;
    }
}
