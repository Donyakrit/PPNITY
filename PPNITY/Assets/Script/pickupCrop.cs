using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class pickupCrop : MonoBehaviour
{
    public bool isinside;
    public GameObject Ecanvas;
    public static int Cropremain;
    public TMP_Text CropText;
    public static int DirtCropPlanted;
    public static int SandCropPlanted;
    public static int ClayCropPlanted;
    public static int DirtCropPlantedSuccess;
    public static int SandCropPlantedSuccess;
    public static int ClayCropPlantedSuccess;
    public int CropDesire;


    // Start is called before the first frame update
    void Start()
    {
        isinside = false;
        DirtCropPlanted = 0;
        SandCropPlanted = 0;
        ClayCropPlanted = 0;
        DirtCropPlantedSuccess = 0;
        SandCropPlantedSuccess = 0;
        ClayCropPlantedSuccess = 0;
        Cropremain = 15;
    }

    // Update is called once per frame
    void Update()
    {
        if(isinside && Hand.Inhand == "Nothing" && Cropremain > 0)
        {
            Ecanvas.SetActive(true);
        }
        else
        {
            Ecanvas.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.E) && isinside == true && Hand.Inhand == "Nothing" && Cropremain > 0)
        {
            collect();
        }

        CropText.text = Cropremain.ToString();
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
        CropDesire = Random.Range(1,4);
        if(CropDesire == 1 && DirtCropPlanted < 5)
        {
            Pickup(1);
            Hand.Inhand = "Dirt";
        }
        else
        {
            if(CropDesire == 2 && SandCropPlanted < 5)
            {
                Pickup(2);
                Hand.Inhand = "Sand";
            }
            else
            {
                if (CropDesire == 3 && ClayCropPlanted < 5)
                {
                    Pickup(3);
                    Hand.Inhand = "Clay";
                }
                else
                {
                    if (DirtCropPlanted < 5)
                    {
                        Pickup(1);
                        Hand.Inhand = "Dirt";
                    }
                    else
                    {
                        if (SandCropPlanted < 5)
                        {
                            Pickup(2);
                            Hand.Inhand = "Sand";
                        }
                        else
                        {
                            if (ClayCropPlanted < 5)
                            {
                                Pickup(3);
                                Hand.Inhand = "Clay";
                            }
                        }
                    }
                }
            }
        }
        Cropremain -= 1;
    }

    void Pickup(int Crop)
    {

    }
}
