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
        rabby.spriteRenderer.color = new Color(.5f, .5f, .5f, 1f);
        turty.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
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
            turty.spriteRenderer.color = new Color(.5f, .5f, .5f, 1f);
            rabby.activeCharacter = true;
            rabby.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            cameraController.target = rabby.transform;
        }
        else
        {
            rabby.activeCharacter = false;
            rabby.spriteRenderer.color = new Color(.5f, .5f, .5f, 1f);
            turty.activeCharacter = true;
            turty.spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            cameraController.target = turty.transform;
        }
    }
}
