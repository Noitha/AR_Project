using UnityEngine;

namespace AR
{
    public class GameController : MonoBehaviour
    {
        /// <summary>
        /// Singleton instance.
        /// </summary>
        public static GameController Instance { get; private set; }

        public SymbolController symbolController;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            InitializeGame();
        }

        private void InitializeGame()
        {
            symbolController.Initialize();
        }
    }
}