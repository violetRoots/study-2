using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private float horizontalClampBounds;

    [SerializeField] private PlayerController player;

    private void Update()
    {
        var camera = Camera.main;
        var mousePos = Input.mousePosition;
        var mouseWorldPos = camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, Vector3.Distance(camera.transform.position, player.transform.position)));
        var playerPos = player.transform.position;
        playerPos.x = mouseWorldPos.x;
        player.transform.position = playerPos;
    }
}
