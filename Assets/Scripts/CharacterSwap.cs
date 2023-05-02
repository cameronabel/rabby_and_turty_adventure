using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{

    public RabbitController rabby;
    public PlayerController turty;

    public CameraController cameraController;

    // Start is called before the first frame update
    void Start()
    {
        turty.activeCharacter = true;
        cameraController.target = turty.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire3"))
        {
            Swap();
        }
    }

    public void Swap()
    {
        if (turty.activeCharacter)
        {
            turty.activeCharacter = false;
            rabby.activeCharacter = true;
            cameraController.target = rabby.transform;
        }
        else
        {
            rabby.activeCharacter = false;
            turty.activeCharacter = true;
            cameraController.target = turty.transform;
        }
    }
}
