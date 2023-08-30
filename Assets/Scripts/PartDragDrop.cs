using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartDragDrop : MonoBehaviour
{
    private bool m_isDragging = false;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnMouseEnter() {
        spriteRenderer.color = new Color (1f, 1f, 1f, 0.5f);
    }

    public void OnMouseDrag() {
        m_isDragging = true;
        spriteRenderer.color = new Color (1f, 1f, 1f, 0.1f);
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(worldPosition.x, worldPosition.y, 0f);
    }

    public void OnMouseUp() {
        // Player has released the object
        spriteRenderer.color = new Color (1f, 1f, 1f, 1f);
        m_isDragging = false;
    }

    public void OnMouseDown() {
        // Player has grabbed the object
    }
    public void OnMouseExit()
    {   
        //spriteRenderer.color = new Color (1f, 1f, 1f, 1f);
    }
}
