
using System.Collections.Generic;

using UnityEngine;


public class ObjectPool : ISingleton<ObjectPool>
{
    private Dictionary<string, List<GameObject>> PooledGameObjectsByPrefabName;

    public ObjectPool()
    {
        PooledGameObjectsByPrefabName = new Dictionary<string, List<GameObject>>();
    }

    public GameObject Spawn(GameObject prefabs)
    {
        GameObject result = null;
        if (PooledGameObjectsByPrefabName.TryGetValue(prefabs.name, out List<GameObject> list))
        {
            if (list.Count > 0)
            {
                result = list[list.Count - 1];
                result.SetActive(true);

                list.RemoveAt(list.Count - 1);
            }
            else
            {
                result = GameObject.Instantiate(prefabs);
                result.name = prefabs.name;
            }
        }
        else
        {
            PooledGameObjectsByPrefabName[prefabs.name] = new List<GameObject>();
            result = GameObject.Instantiate(prefabs);
            result.name = prefabs.name;
        }
        return result;
    }

    public void Despawn(GameObject gameObject)
    {
        gameObject.SetActive(false);
        PooledGameObjectsByPrefabName[gameObject.name].Add(gameObject);
    }
}
