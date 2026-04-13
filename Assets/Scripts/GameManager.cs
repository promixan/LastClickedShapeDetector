using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text LastClickedShapeText;
    public Camera GameCamera;
    [SerializeField]
    protected string m_DefaultLastClickedText;

    void Start()
    {
        LastClickedShapeText.text = m_DefaultLastClickedText;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AbstractShapeController shape = DetectLastClickedShape();
            UpdateLastClickedShapeText(shape);
        }
    }

    // ABSTRACTION
    protected AbstractShapeController DetectLastClickedShape()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            return hit.collider.GetComponentInParent<AbstractShapeController>();
        }
        return null;
    }

    // ABSTRACTION
    protected void UpdateLastClickedShapeText(AbstractShapeController shape)
    {
        if (shape != null && LastClickedShapeText != null)
        {
            LastClickedShapeText.text = shape.Name;
        }
        else
        {
            LastClickedShapeText.text = m_DefaultLastClickedText;
        }
    }
}
