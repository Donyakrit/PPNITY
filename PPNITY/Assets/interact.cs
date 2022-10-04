using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interact : MonoBehaviour
{
    public bool isinside;
    public GameObject Ecanvas;
    public int TrashWeight;

    // Start is called before the first frame update
    void Start()
    {
        isinside = false;
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
            collect();
        }
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
