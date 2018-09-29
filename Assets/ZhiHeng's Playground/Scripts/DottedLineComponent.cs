using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DottedLineComponent : MonoBehaviour
{
    private LineRenderer m_LineRenderer;
    [SerializeField] private Material lineMat;
    [SerializeField] private float lineWidth;

    private Vector3 point1 = Vector3.zero;
    private Vector3 point2 = Vector3.zero;

    private void Update()
    {
        if (!m_LineRenderer)
            return;

        if(point1 != Vector3.zero && point2 != Vector3.zero)
        {
            m_LineRenderer.SetPosition(0, point1);
            m_LineRenderer.SetPosition(1, point2);
        }
        else
        {
            m_LineRenderer.SetPosition(0, transform.position);
            m_LineRenderer.SetPosition(1, transform.position);
        }
    }

    public void SetPoints(Vector3 point1, Vector3 point2)
    {
        this.point1 = point1;
        this.point2 = point2;
    }

    private void OnEnable()
    {
        if (!GetComponent<LineRenderer>())
            m_LineRenderer = gameObject.AddComponent<LineRenderer>();
        else
            m_LineRenderer = GetComponent<LineRenderer>();

        m_LineRenderer.positionCount = 2;

        m_LineRenderer.widthMultiplier = lineWidth;
        m_LineRenderer.material = lineMat;
    }

    private void OnDisable()
    {
        Destroy(m_LineRenderer);
    }
}
