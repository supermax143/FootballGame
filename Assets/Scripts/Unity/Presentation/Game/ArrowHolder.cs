using System.Threading.Tasks;
using Unity.Infrastructure.ResourceManager;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Assertions.Must;

namespace Unity.Presentation.Game
{
    public class ArrowHolder : MonoBehaviour
    {
        private  Vector3 _startPoint;
        private  Vector3 _targetPoint;

        private GameObject _view;
        private SpriteRenderer _viewSprite;
        
        public async Task Initialize(AssetReference arrowSource)
        {
            var arrowPrefab =
                await arrowSource.LoadAssetReference<GameObject>(arrowSource.AssetGUID);
            _view = Instantiate(arrowPrefab, transform);
            _viewSprite = _view.GetComponent<SpriteRenderer>();
            Hide();
        }
        
        public void Show(Vector3 position)
        {
            _startPoint = _targetPoint = position;
            _view.transform.position = position;
            gameObject.SetActive(true);
        }

        public void Move(Vector2 delta)
        {
            _targetPoint += (Vector3)delta;
            Vector3 direction = _targetPoint - _startPoint;
    
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _view.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            var length = _viewSprite.size;
            length.x = direction.magnitude;
            _viewSprite.size = length;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

    }
}