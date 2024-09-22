
using Il2CppSystem.Linq;
using System.Linq;
using UnityEngine;
namespace MH
{
    class KB
    {
        public static bool GetKeysDown(KeyCode[] keys)
        {
            if (keys.Any(k => Input.GetKeyDown(k)) && keys.All(k => Input.GetKey(k)))
            {
                return true;
            }
            return false;
        }
    }
}