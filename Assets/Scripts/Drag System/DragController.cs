using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=FdxvTcHJiA8
// https://www.youtube.com/watch?v=I17uqTxbWK0
public class DragController : MonoBehaviour
{
    public Draggable LastDragged => m_lastDragged;
    private bool m_isDragActive = false;
    private Vector2 m_screenPosition;
    private Vector3 m_worldPosition;
    private Draggable m_lastDragged;
    public static DragController Instance { get; private set; }

    void Awake() {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
        DontDestroyOnLoad(gameObject);
    }
    void Update() {
        if (m_isDragActive && (Input.GetMouseButtonUp(0))) {
            Drop();
            return;
        }
        if (Input.GetMouseButton(0)) 
        {
            Vector3 mousePos = Input.mousePosition;
            m_screenPosition = new Vector2(mousePos.x, mousePos.y);
        }
        else
        {
            return;
        }

        m_worldPosition = Camera.main.ScreenToWorldPoint(m_screenPosition);

        if (m_isDragActive) {
            Drag();
        } else {
            RaycastHit2D hit = Physics2D.Raycast(m_worldPosition, Vector2.zero);
            if (hit.collider != null) {
                Draggable draggable = hit.collider.GetComponent<Draggable>();
                if (draggable != null) {
                    m_lastDragged = draggable;
                    InitDrag();
                }
            }
        }
    }

    void InitDrag() {
        UpdateDragStatus(true);
    }
    void Drag() {
        m_lastDragged.transform.position = new Vector2(m_worldPosition.x, m_worldPosition.y);
    }
    void Drop() {
        UpdateDragStatus(false);
    }

    void UpdateDragStatus(bool isDragging) {
        m_isDragActive = m_lastDragged.isDragging = isDragging;
        gameObject.layer = isDragging ? Layer.Dragging : Layer.Default;
        // if (isDragging) {
        //     gameObject.layer = Layer.Dragging;
        // }
        // else {
        //     gameObject.layer = Layer.Default;
        // }
    }
}
