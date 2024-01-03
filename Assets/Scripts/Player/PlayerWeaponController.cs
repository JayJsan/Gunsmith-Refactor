using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    [Header("Configuration")]
    public float handSpeed = 10f;
    public float handDistance = 0.5f;
    public float tooCloseDistance = 2f;
    public KeyCode fireKey = KeyCode.Mouse0;
    [Header("References")]
    public Transform hand;
    public Gun gun;

    // #### VARIABLES ####
    private Vector3 target;
    private Vector3 clampedPosition;
    private bool tooClose;

    void Update()
    {
        target = MouseChecker.instance.GetMousePosition();
        CheckIfHandIsOnTarget();
        MoveHand();
        ShootOnKey();
    }   

    #region MOVEMENT
    private void MoveHand()
    {

        if (!tooClose)
        {
            clampedPosition = transform.position + Vector3.ClampMagnitude(target - transform.position, handDistance);

            hand.position = Vector3.Lerp(hand.position, clampedPosition, handSpeed * Time.deltaTime);
            //hand.position = clampedPosition;
        }
        else
        {
            // // 
            // clampedPosition = transform.position + Vector3.ClampMagnitude(target - transform.position, 20);

            // // get direction towards target from hand
            Vector3 direction = target - hand.position;

            // // move hand away from target in opposite direction
            hand.position -= direction * handSpeed * Time.deltaTime;

            // clamp hand position to maximum distance
            hand.position = Vector3.ClampMagnitude(hand.position - transform.position, handDistance * 3f) + transform.position;

            // // set clampposition to minimum distance
            // float XdistanceOfAvoidance = 1f;
            // float YdistanceOfAvoidance = 1f;

            // if (clampedPosition.x < 0)
            //     XdistanceOfAvoidance = -XdistanceOfAvoidance;

            // if (clampedPosition.y < 0)
            //     YdistanceOfAvoidance = -YdistanceOfAvoidance;

            // clampedPosition.x = Mathf.Clamp(clampedPosition.x, transform.position.x + XdistanceOfAvoidance, 100f);
            // clampedPosition.y = Mathf.Clamp(clampedPosition.y, transform.position.y + YdistanceOfAvoidance, 100f);

            // hand.position = clampedPosition;
        }
    }

    private void CheckIfHandIsOnTarget()
    {
        if (Vector3.Distance(hand.position, target) < tooCloseDistance)
        {
            tooClose = true;
        }

        if (Vector3.Distance(hand.position, target) > tooCloseDistance * 2)
        {
            tooClose = false;
        }
        
        
        // if mouse is near player + radius of player
        // if ((Vector3.Distance(target, transform.position)) < tooCloseDistance)
        // {
        //     tooClose = true;
        // }
        // else
        // {
        //     tooClose = false;
        // }
    }
    #endregion

    #region EXECUTION
    private void ShootOnKey()
    {
        if (Input.GetKey(fireKey))
            gun.Execute();

        if (Input.GetKeyUp(fireKey))
            gun.Stop();
    }
    #endregion
}
