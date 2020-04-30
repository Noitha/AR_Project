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
            symbol.Initialize();
            symbol.OnSymbolChanged += SymbolChanged;
            symbol.gameObject.SetActive(false);
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
        _activeSymbol.Hide();
        _activeSymbol = symbol;
        text.text = symbol.symbolMeaning;
        _symbolController.CheckSymbolAlignment();
    }
}