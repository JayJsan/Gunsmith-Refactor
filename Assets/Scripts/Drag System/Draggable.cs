using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=FdxvTcHJiA8
// https://www.youtube.com/watch?v=I17uqTxbWK0
public class Draggable : MonoBehaviour
{
    public bool isDragging = false;

    private Collider2D m_collider;
    private DragController m_dragController;

    void Start()
    {
        m_collider = GetComponent<Collider2D>();
        m_dragController = DragController.Instance;
    }
}
