using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSwitcher : MonoBehaviour
{
    public GameObject bolt_1;
    public GameObject bolt_2;
    public GameObject bolt_4;

    public HovercraftController bolt1_Controller;
    public HovercraftController bolt2_Controller;
    public HovercraftController bolt4_Controller;

    private int currentShipIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        bolt1_Controller = bolt_1.GetComponent<HovercraftController>();
        bolt2_Controller = bolt_2.GetComponent<HovercraftController>();
        bolt4_Controller = bolt_4.GetComponent<HovercraftController>();

        bolt1_Controller.enabled = true;
        bolt2_Controller.enabled = false;
        bolt4_Controller.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {

            switch(currentShipIndex)
            {
                case 0:
                    bolt1_Controller.enabled = false;
                    bolt2_Controller.enabled = true;

                    ++currentShipIndex;
                    break;

                case 1:
                    bolt2_Controller.enabled = false;
                    bolt4_Controller.enabled = true;

                    ++currentShipIndex;
                    break;

                case 2:
                    bolt4_Controller.enabled = false;
                    bolt1_Controller.enabled = true;

                    currentShipIndex = 0;
                    break;
            }

        }
    }
}
