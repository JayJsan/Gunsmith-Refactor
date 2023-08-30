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
    [SerializeField]
    [Range(0f, 1f)]
    private float m_sizePercentage = 0.5f;
    private bool m_isConnected = false;

    [SerializeField]
    private float m_scaleAnimationSpeed = 30f;
    void Start()
    {
        m_collider = GetComponent<Collider2D>();
        m_dragController = DragController.Instance;
    }

    void FixedUpdate() {
        foreach (Connection c in GetComponentsInChildren<Connection>()) {
            if (c.IsConnected()) {
                m_isConnected = true;
                break;
            } else {
                m_isConnected = false;
            }
        }

        if (isDragging || m_isConnected || GetComponent<Connective>().PartType == Connection.Part.Holder) {
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, m_scaleAnimationSpeed * Time.deltaTime);
        } else {
            Vector3 size = Vector3.one * m_sizePercentage;
            transform.localScale = Vector3.Lerp(transform.localScale, size, m_scaleAnimationSpeed * Time.deltaTime);
        }
    }
}
