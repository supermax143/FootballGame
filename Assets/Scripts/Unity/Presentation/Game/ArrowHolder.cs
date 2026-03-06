using System.Threading.Tasks;
using Unity.Infrastructure.ResourceManager;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Unity.Presentation.Game
{
    public class ArrowHolder : MonoBehaviour
    {
        private  Vector3 _startPoint;
        private  Vector3 _targetPoint;

        private GameObject _view;
        
        public async Task Initialize(AssetReference arrowSource)
        {
            var arrowPrefab =
                await arrowSource.LoadAssetReference<GameObject>(arrowSource.AssetGUID);
            _view = Instantiate(arrowPrefab, transform);
            Hide();
        }
        
        public void Show(Vector3 position)
        {
            _startPoint = _targetPoint = position;
            gameObject.SetActive(true);
        }

        public void Move(Vector2 delta)
        {
            _startPoint += (Vector3)delta;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

    }
}