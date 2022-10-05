using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Planting : MonoBehaviour
{
    public bool isinside;
    bool isPlanted;
    public GameObject Ecanvas;
    public GameObject Barrear;
    public GameObject plantObject;
    public GameObject WaterCanvas;
    public Image WaterFill;
    public string PlantType;
    float currenTime;
    float StartCountTime;
    public float waterTime;
    public GameObject DeadIcon;


    // Start is called before the first frame update
    void Start()
    {
        isinside = false;
        plantObject.SetActive(false);
        Barrear.SetActive(false);
        isPlanted = false;
        WaterCanvas.SetActive(false);
        DeadIcon.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.E) && isinside == true && isPlanted == false)
        {
            plant();
        }

        if (isPlanted)
        {
            WaterCanvas.SetActive(true);
            WaterFill.fillAmount = (waterTime - (currenTime - StartCountTime)) / waterTime;
        }

        if(isPlanted && WaterFill.fillAmount <= 0)
        {
            dead();
        }

        currenTime += Time.deltaTime;
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
            if (PlantType == "Dirt")
            {
                pickupCrop.DirtCropPlanted += 1;
                Planted();
            }
            else
            {
                if (PlantType == "Sand")
                {
                    pickupCrop.SandCropPlanted += 1;
                    Planted();
                }
                else
                {
                    if (PlantType == "Clay")
                    {
                        pickupCrop.ClayCropPlanted += 1;
                        Planted();
                    }
                }
            }
        if (Hand.Inhand == PlantType)
        {
            Hand.Point += 1;
        }
        else
        {
            dead();
        }
        Hand.Inhand = "Nothing";
        plantObject.SetActive(true);
        Barrear.SetActive(true);
        isPlanted = true;
    }

    void Planted()
    {
        StartCountTime = currenTime;
    }

    void dead()
    {
        Hand.Point -= 1;
        Barrear.SetActive(false);
        WaterCanvas.SetActive(false);
        DeadIcon.SetActive(true);
    }
}