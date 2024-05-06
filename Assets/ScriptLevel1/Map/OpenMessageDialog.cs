using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMessageDialog : MonoBehaviour
{
    [SerializeField] private OpenDoor openDoor;
    [SerializeField] private GameObject dialogMessage;
    private void Awake()
    {
        
    }
    private void Start()
    {
        openDoor.OnOpenDoorCallMessageTask += OpenDoor_OnOpenDoorCallMessageTask;
    }

    private void OpenDoor_OnOpenDoorCallMessageTask(object sender, OpenDoor.OnOpenDoorCallMessageTaskEventArg e)
    {
        if (e.isOpenDoor)
        {
            Show();
        }
        else
        {
            Hide();
        }
    }
    private void Show()
    {
        dialogMessage.SetActive(true);
    }
    public void Hide()
    {
        dialogMessage.SetActive(false);
    }
}
