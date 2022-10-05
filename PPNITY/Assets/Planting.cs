using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Planting : MonoBehaviour
{
    public bool isinside;
    bool isPlanted;
    public GameObject Ecanvas;
    public GameObject Barrear;
    public GameObject plantObject;
    public string PlantType;


    // Start is called before the first frame update
    void Start()
    {
        isinside = false;
        plantObject.SetActive(false);
        Barrear.SetActive(false);
        isPlanted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isinside && Hand.Inhand == PlantType && isPlanted == false)
        {
            Ecanvas.SetActive(true);
        }
        else
        {
            Ecanvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && isinside == true && Hand.Inhand == PlantType && isPlanted == false)
        {
            plant();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
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

    void plant()
    {
        if (Hand.Inhand == "Dirt")
        {
            pickupCrop.DirtCropPlanted += 1;
        }
        else
        {
            if (Hand.Inhand == "Sand")
            {
                pickupCrop.SandCropPlanted += 1;
            }
            else
            {
                if (Hand.Inhand == "Clay")
                {
                    pickupCrop.ClayCropPlanted += 1;
                }
            }
        }
        Hand.Inhand = "Nothing";
        plantObject.SetActive(true);
        Barrear.SetActive(true);
        isPlanted = true;
    }

    void Pickup(int Crop)
    {

    }
}