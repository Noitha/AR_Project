using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class SymbolColumn : MonoBehaviour
{
    //will be deleted
    public TextMeshProUGUI text;

    /// <summary>
    /// Symbols on this column.
    /// </summary>
    private List<Symbol> _symbols = new List<Symbol>();

    /// <summary>
    /// Current active symbol on this column.
    /// </summary>
    private Symbol _activeSymbol;

    private SymbolController _symbolController;

    private bool init = true;

    public bool isInAr;

    /// <summary>
    /// Initialize the column.
    /// </summary>
    public void Initialize(SymbolController symbolController)
    {
        _symbolController = symbolController;
        _symbols = GetComponentsInChildren<Symbol>().ToList();

        if (_symbols.Count == 0)
        {
            Debug.LogError("No Symbols");
            return;
        }

        _activeSymbol = _symbols[0];

        foreach (var symbol in _symbols)
        {
            symbol.Initialize(this);
            symbol.OnSymbolChanged += SymbolChanged;
            symbol.gameObject.SetActive(false);
        }

        if (isInAr)
        {
            _activeSymbol.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// Get the current active symbol of this column,
    /// </summary>
    /// <returns></returns>
    public Symbol GetCurrentActiveSymbol()
    {
        return _activeSymbol;
    }

    /// <summary>
    /// Gets triggered when a symbol changed.
    /// </summary>
    /// <param name="symbol"></param>
    private void SymbolChanged(Symbol symbol)
    {
        _activeSymbol = symbol;
        text.text = symbol.symbolMeaning;
        _symbolController.CheckSymbolAlignment();
        if (isInAr && init)
        {
            init = false;
            symbol.gameObject.SetActive(false);
        }
    }

    public void Next()
    {
        _activeSymbol.gameObject.SetActive(false);
        _activeSymbol = _activeSymbol.Index == _symbols.Count - 1 ? _symbols[0] : _symbols[_activeSymbol.Index + 1];
        _activeSymbol.gameObject.SetActive(true);
    }
}