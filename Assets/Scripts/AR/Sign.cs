using System.Collections.Generic;
using UnityEngine;

namespace AR
{
    public class Sign : MonoBehaviour
    {

    
        public List<Texture2D> textures;

        private int texIndex = 0;
        private MeshRenderer _meshRenderer;
    
        // Start is called before the first frame update
        void Start()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void changeSign()
        {
            _meshRenderer.material.mainTexture = textures[(texIndex++)%texIndex];
        }
    
    }
}
