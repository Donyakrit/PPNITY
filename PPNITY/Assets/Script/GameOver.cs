using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Clear;
    public GameObject TimeUp;
    public GameObject PlayerController;
    public AudioSource TimeUpSound;
    public AudioSource BGMusic;
    public string nextScene;
    int count;
    float currenTime;
    float varTime;
    // Start is called before the first frame update
    void Start()
    {
        Clear.SetActive(false);
        TimeUp.SetActive(false);
        count = 0;
        varTime = 10000;
    }

    // Update is called once per frame
    void Update()
    {
        currenTime += Time.deltaTime;
        if(pickupCrop.Cropremain <= 0 && pickupCrop.ClayCropPlantedSuccess + pickupCrop.DirtCropPlantedSuccess + pickupCrop.SandCropPlantedSuccess >= 15)
        {
            if (count == 0)
            {
                varTime = currenTime;
                count += 1;
                BGMusic.Stop();
                TimeUpSound.Play();
                Clear.SetActive(true);
                PlayerController.GetComponent<PlayerController2>().enabled = false;
                PlayerController.GetComponent<CapsuleCollider>().enabled = true;
            }
        }

        if(Timer.ReminingTime == 0)
        {
            if (count == 0)
            {
                varTime = currenTime;
                count += 1;
                BGMusic.Stop();
                TimeUpSound.Play();
                TimeUp.SetActive(true);
                PlayerController.GetComponent<PlayerController2>().enabled = false;
                PlayerController.GetComponent<CapsuleCollider>().enabled = true;
            }
        }

        if(currenTime - varTime >= 2)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
