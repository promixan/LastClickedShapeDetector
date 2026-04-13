using UnityEngine;

public abstract class AbstractShapeController : MonoBehaviour
{
    // ENCAPSULATION
    public string Name { get; protected set; }

    void Start()
    {
        Name = GetName();
    }

    protected abstract string GetName();
}
