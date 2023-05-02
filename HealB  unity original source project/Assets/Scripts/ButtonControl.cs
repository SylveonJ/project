using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject Menu;
    private bool sceneActive = false;
    public void TogglePause()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        sceneActive = !sceneActive; // �л�����״̬

        Menu.SetActive(sceneActive); // �����ȡ�������

     }

}
