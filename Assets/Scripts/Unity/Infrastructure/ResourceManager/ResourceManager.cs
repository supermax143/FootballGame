using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Infrastructure.ResourceManager
{
   public class ResourceManager : IResourceManager
   {
      public Task<T> Load<T>(string key, string tag)
         where T : Object => AddressableExtention.Load<T>(key, tag);
   }
}