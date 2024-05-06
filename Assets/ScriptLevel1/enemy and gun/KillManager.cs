using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillManager : MonoBehaviour
{
    public static KillManager instance;
    public List<GameObject> army;
    public static int amountKill;

    void Start()
    {
        amountKill = 0;
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    void Update()
    {
        
    }
    public void Sound()
    {
        foreach(GameObject go in army)
        {
            if (go == null)
            {
                amountKill++;
                Debug.Log("số mạng đã giết là : " + amountKill);
            }
        }
        if (amountKill == 0)
        {
            AudioManager.instance.OpenSFXSound("FirstBlood");
            AudioManager.instance.sfxSource.volume = 5f;
        }
        if (amountKill == 1)
        {
            AudioManager.instance.OpenSFXSound("doublekill");
            AudioManager.instance.sfxSource.volume = 5f;
        }
        if (amountKill == 2)
        {
            AudioManager.instance.OpenSFXSound("triperkill");
            AudioManager.instance.sfxSource.volume = 5f;
        }
        if (amountKill == 3)
        {
            AudioManager.instance.OpenSFXSound("qualdakill");
            AudioManager.instance.sfxSource.volume = 5f;
        }
        if (amountKill == 4)
        {
            AudioManager.instance.OpenSFXSound("megakill");
            AudioManager.instance.sfxSource.volume = 5f;
        }
    }
}
