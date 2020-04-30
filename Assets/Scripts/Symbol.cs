using System;
using UnityEngine;

public class Symbol : MonoBehaviour
{
    public string symbolMeaning;
    public delegate void SymbolChanged(Symbol symbol);
    public event SymbolChanged OnSymbolChanged;
    private MeshRenderer _meshRenderer;


    private void OnEnable()
    {
        ParticleSystem sys = GetComponent<ParticleSystem>();
        if (sys != null)
        {
            sys.Play();
        }
    }

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
        gameObject.SetActive(true);
        OnSymbolChanged?.Invoke(this);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}