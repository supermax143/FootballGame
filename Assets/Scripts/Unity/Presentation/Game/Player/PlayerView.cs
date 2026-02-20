using UnityEngine;

namespace Unity.Game
{
    /// <summary>
    /// Unity view component for Player.
    /// Handles visual representation and sprite color management.
    /// </summary>
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] 
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            CacheSpriteRenderer();
        }

        private void OnValidate()
        {
            CacheSpriteRenderer();
        }

        private void CacheSpriteRenderer()
        {
            if (_spriteRenderer == null)
            {
                _spriteRenderer = GetComponent<SpriteRenderer>();
            }
        }

        /// <summary>
        /// Sets the color of the player sprite.
        /// </summary>
        /// <param name="color">The color to apply to the sprite.</param>
        public void SetSpriteColor(Color color)
        {
            if (_spriteRenderer != null)
            {
                _spriteRenderer.color = color;
            }
        }

        /// <summary>
        /// Gets the current sprite color.
        /// </summary>
        /// <returns>Current sprite color.</returns>
        public Color GetSpriteColor()
        {
            return _spriteRenderer != null ? _spriteRenderer.color : Color.white;
        }

        /// <summary>
        /// Sets the sprite of the player.
        /// </summary>
        /// <param name="sprite">The sprite to apply.</param>
        public void SetSprite(Sprite sprite)
        {
            if (_spriteRenderer != null)
            {
                _spriteRenderer.sprite = sprite;
            }
        }
    }
}

