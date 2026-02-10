using System.Threading.Tasks;
using UnityEngine;

namespace Unity.Infrastructure.ResourceManager
{
   public interface IResourceManager
   {
      Task<T> Load<T>(string key, string tag)
         where T : Object;
   }
}