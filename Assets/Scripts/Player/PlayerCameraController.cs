using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [Header("Configuration")]
    public float cameraSmoothness = 1f;
    public float maxDistance = 2f;
    [Header("References")]
    public Transform player;
    public Transform cameraTarget;
    public CinemachineVirtualCamera vcam;
    // #### VARIABLES ####
    private Vector3 mousePos = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Transform>();
        vcam.Follow = cameraTarget;

        // Update damping
        vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_XDamping = cameraSmoothness;
        vcam.GetCinemachineComponent<CinemachineFramingTransposer>().m_YDamping = cameraSmoothness;
    }

    // Update is called once per frame
    void Update()
    {
        CalculateCameraTargetPositon();
        mousePos = MouseChecker.instance.GetMousePosition();
    }

    private void CalculateCameraTargetPositon()
    {
        Vector3 targetPos = (player.position + mousePos) / 2f; // this is the magic that makes everything work, i am too epy to understand it but having this
        // here makes the camera be accurately over the mouse position

        // I JUST FIGURED IT OUt/
        // the first element A ((player.position)) acts as the origin point
        // you add the mouse position to get the position of the mouse relative to the player instead of the camera
        // although i dont know why you divide by two though

        targetPos.x = Mathf.Clamp(targetPos.x, player.position.x - maxDistance, player.position.x + maxDistance);
        targetPos.y = Mathf.Clamp(targetPos.y, player.position.y - maxDistance, player.position.y + maxDistance);
        cameraTarget.position = targetPos;
    }
}
