using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartHolder : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame

    public void OnMouseOver() {
        Debug.Log("OnMouseOver");
        if (Input.GetMouseButtonUp(0)) {
            Debug.Log("OnMouseUp");
            spriteRenderer.color = Color.white;
        }
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("OnMouseDown");
            spriteRenderer.color = Color.red;            
        }
    }
    
    public void OnMouseEnter() {
        spriteRenderer.color = new Color (1f, 1f, 1f, 0.5f);
    }

    public void OnMouseExit() {
        spriteRenderer.color = new Color (1f, 1f, 1f, 1f);
    }

    public void OnMouseUp() {
        Debug.Log("OnMouseUp");
        spriteRenderer.color = Color.white;
    }

    public void OnMouseDown() {
        Debug.Log("OnMouseDown");
        spriteRenderer.color = Color.red;
    }
}
