using UnityEngine;

namespace AR
{
    public class Symbol : MonoBehaviour
    {
        public string symbolMeaning;
        public delegate void SymbolChanged(Symbol symbol);
        public event SymbolChanged OnSymbolChanged;

        public bool isChangeable;

        public bool isBook;

        public int Index { get; private set; }
    
        public SymbolColumn SymbolColumn { get; private set; }


        private MeshRenderer _meshRenderer;
        private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

        public void Initialize(SymbolColumn symbolColumn)
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshRenderer.material.SetColor(EmissionColor, Color.white);
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

        public void Highlight(bool correct)
        {
            _meshRenderer.material.SetColor(EmissionColor, correct ? Color.green : Color.white);
        }
    }
}