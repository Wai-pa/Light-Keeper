using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    private PauseMenu pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = PauseMenu.instance;
    }

    // Update is called once per frame
    void Update()
    {
        var currentCamera = Camera.current;
        if (currentCamera == null || pauseMenu.GameIsPaused())
        {
            return;
        }

        var mouseWorldPosition = currentCamera.ScreenToWorldPoint(Input.mousePosition);
        var direction = mouseWorldPosition - transform.position;

        var rotationAngle = Vector2.SignedAngle(Vector3.right, direction);

        transform.localRotation = Quaternion.AngleAxis(rotationAngle, Vector3.forward);
    }
}
