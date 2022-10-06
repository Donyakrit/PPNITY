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
    public bool wantWater;
    bool isdead;
    public AudioSource Watering;
    public AudioSource PlantingSound;


    // Start is called before the first frame update
    void Start()
    {
        isinside = false;
        plantObject.SetActive(false);
        Barrear.SetActive(false);
        isPlanted = false;
        WaterCanvas.SetActive(false);
        DeadIcon.SetActive(false);
        wantWater = false;
        isdead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ((isinside && Hand.Inhand != "Nothing" && Hand.Inhand != "WaterCan" && isPlanted == false) | (isinside && Hand.Inhand == "WaterCan" && isPlanted && wantWater && !isdead))
        {
            Ecanvas.SetActive(true);
        }
        else
        {
            Ecanvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.E) && isinside == true && isPlanted == false && wantWater == false && Hand.Inhand != "Nothing" && Hand.Inhand != "WaterCan")
        {
            plant();
        }

        if (Input.GetKeyDown(KeyCode.E) && isinside == true && isPlanted && wantWater && Hand.Inhand == "WaterCan" && !isdead)
        {
            if (PlantType == "Dirt")
            {
                pickupCrop.DirtCropPlantedSuccess += 1;
            }
            else
            {
                if (PlantType == "Sand")
                {
                    pickupCrop.SandCropPlantedSuccess += 1;
                }
                else
                {
                    if (PlantType == "Clay")
                    {
                        pickupCrop.ClayCropPlantedSuccess += 1;
                    }
                }
            }
            Watering.Play();
            Hand.Point += 1;
            wantWater = false;
            WaterCanvas.SetActive(false);
        }

        if (isPlanted == true && wantWater == true)
        {
            WaterCanvas.SetActive(true);
            WaterFill.fillAmount = (waterTime - (currenTime - StartCountTime)) / waterTime;
        }

        if(!isdead && wantWater && isPlanted && WaterFill.fillAmount <= 0 && wantWater)
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
        PlantingSound.Play();
        isPlanted = true;
        StartCountTime = currenTime;
        wantWater = true;
    }

    void dead()
    {
        if (PlantType == "Dirt")
        {
            pickupCrop.DirtCropPlantedSuccess += 1;
        }
        else
        {
            if (PlantType == "Sand")
            {
                pickupCrop.SandCropPlantedSuccess += 1;
            }
            else
            {
                if (PlantType == "Clay")
                {
                    pickupCrop.ClayCropPlantedSuccess += 1;
                }
            }
        }
        Hand.Point -= 1;
        isdead = true;
        Barrear.SetActive(false);
        WaterCanvas.SetActive(false);
        DeadIcon.SetActive(true);
    }
}