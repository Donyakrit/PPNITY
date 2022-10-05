using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pickupWatercan : MonoBehaviour
{
    public bool isinside;
    public GameObject Ecanvas;
    public GameObject Self;


    // Start is called before the first frame update
    void Start()
    {
        isinside = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isinside && Hand.Inhand == "Nothing" | Hand.Inhand == "WaterCan")
        {
            Ecanvas.SetActive(true);
        }
        else
        {
            Ecanvas.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E) && isinside == true && Hand.Inhand == "Nothing" | Hand.Inhand == "WaterCan")
        {
            Pickup();
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
        
    }

    void Pickup()
    {
        if (Hand.Inhand == "WaterCan")
        {
            Hand.Inhand = "Nothing";
            Self.GetComponent<MeshRenderer>().enabled = true;
            Self.GetComponent<MeshCollider>().enabled = true;
        }
        else
        {
            Hand.Inhand = "WaterCan";
            Self.GetComponent<MeshRenderer>().enabled = false;
            Self.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
