using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public CinemachineVirtualCamera bolt1_Camera;
    public CinemachineVirtualCamera bolt2_Camera;
    public CinemachineVirtualCamera bolt4_Camera;

    private int currentCameraIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        bolt1_Camera.gameObject.SetActive(true);
        bolt2_Camera.gameObject.SetActive(false);
        bolt4_Camera.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.C))
        {
            switch(currentCameraIndex)
            {
                case 0:
                    bolt1_Camera.gameObject.SetActive(false);
                    bolt2_Camera.gameObject.SetActive(true);

                    ++currentCameraIndex;
                    break;

                case 1:
                    bolt2_Camera.gameObject.SetActive(false);
                    bolt4_Camera.gameObject.SetActive(true);

                    ++currentCameraIndex;
                    break;

                case 2:
                    bolt4_Camera.gameObject.SetActive(false);
                    bolt1_Camera.gameObject.SetActive(true);

                    currentCameraIndex = 0;
                    break;
            }
        }

    }
}
