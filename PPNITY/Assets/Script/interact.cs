using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class interact : MonoBehaviour
{
    public bool isinside;
    public GameObject Ecanvas;
    public int TrashWeight;
    public TMP_Text WeightText;
    public Image Fillbar;
    float fill;
    public float fillMax;
    bool collecting;
    public GameObject CollectBar;

    // Start is called before the first frame update
    void Start()
    {
        isinside = false;
        collecting = false;
        fill = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isinside)
        {
            Ecanvas.SetActive(true);
        }
        else
        {
            Ecanvas.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E) && isinside == true && Backpack.CurrenWeight + TrashWeight <= Backpack.MaxWeight)
        {
            collecting = true;
        }

        if(Input.GetKeyUp(KeyCode.E) || isinside == false)
        {
            collecting = false;
        }

        if (collecting == true)
        {
            CollectBar.SetActive(true);
            fill += Time.deltaTime;
            Fillbar.fillAmount = fill / fillMax;
        }
        else
        {
            CollectBar.SetActive(false);
            fill = 0;
            Fillbar.fillAmount = fill / fillMax;
        }

        if(fill / fillMax >= 1)
        {
            collect();
        }

        WeightText.text = TrashWeight.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            isinside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isinside = false;
        }
    }

    void collect()
    {
        Backpack.CurrenWeight += TrashWeight;
        Destroy(gameObject);
    }
}
