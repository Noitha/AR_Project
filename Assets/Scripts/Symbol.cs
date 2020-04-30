using UnityEngine;

public class Symbol : MonoBehaviour
{
    public string symbolMeaning;
    public delegate void SymbolChanged(Symbol symbol);
    public event SymbolChanged OnSymbolChanged;
    private MeshRenderer _meshRenderer;
    
    public void Initialize()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    
    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
    
    public void Show()
    {
        _meshRenderer.enabled = true;
        OnSymbolChanged?.Invoke(this);
    }

    public void Hide()
    {
        _meshRenderer.enabled = false;
    }
}