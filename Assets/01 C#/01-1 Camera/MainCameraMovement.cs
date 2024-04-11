using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float OffsetX = 0;
    [SerializeField] private float OffsetY = 0;
    [SerializeField] private float OffsetZ = -10;

    private Vector3 cameraPos;

    private void LateUpdate()
    {

        cameraPos.x = player.gameObject.transform.position.x + OffsetX;
        cameraPos.y = player.gameObject.transform.position.y + OffsetY;
        cameraPos.z = player.gameObject.transform.position.z + OffsetZ;

        transform.position = cameraPos;
    }

}
