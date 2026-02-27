using UnityEngine;

namespace Unity.Game
{
    
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] 
        private SpriteRenderer _spriteRenderer;

        private void OnValidate()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }


        public void SetSpriteColor(Color color)
        {
            if (_spriteRenderer != null)
            {
                _spriteRenderer.color = color;
            }
        }

       
    }
}

