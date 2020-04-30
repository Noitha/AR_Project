using UnityEngine;

public class Symbol : MonoBehaviour
{
    public string symbolMeaning;
    public delegate void SymbolChanged(Symbol symbol);
    public event SymbolChanged OnSymbolChanged;

    public bool isChangeable;

    public int Index { get; private set; }
    
    public SymbolColumn SymbolColumn { get; private set; }
    
    public void Initialize(SymbolColumn symbolColumn)
    {
        SymbolColumn = symbolColumn;
        Index = transform.GetSiblingIndex();
    }
    
    private void OnEnable()
    {
        OnSymbolChanged?.Invoke(this);
        
        ParticleSystem sys = GetComponent<ParticleSystem>();
        
        if (sys != null)
        {
            sys.Play();
        }
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}