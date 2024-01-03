using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MouseChecker : MonoBehaviour
{

    public static MouseChecker instance;

    private Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMousePosition();
        SetMousePosition();
    }

    private void SetMousePosition()
    {
        transform.position = mousePosition;
    }

    private void CalculateMousePosition()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
    }

    public Vector2 GetMousePosition()
    {
        return mousePosition;
    }

    public Vector2 CalculateClampedMousePosition(float maxDistance, Transform target, out bool isClamped)
    {
        Vector3 mousePosition = GetMousePosition();
        Vector3 direction = mousePosition - target.position;
        direction.z = 0;
        direction = Vector2.ClampMagnitude(direction, maxDistance);

        if (direction.magnitude >= maxDistance) {
            isClamped = true;
        } else {
            isClamped = false;
        }

        Vector2 clampedMousePosition = target.position + direction;
        return clampedMousePosition;
    }
}
