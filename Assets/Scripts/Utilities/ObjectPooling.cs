using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
    [Serializable]
    public class Preallocation
    {
        public GameObject gameObject;
        public int count;
        public bool expandable;
    }

    public class ObjectPooling : MonoSingleton<ObjectPooling>
    {
        public List<Preallocation> preAllocations;
        [SerializeField] List<GameObject> pooledGobjects;

        protected override void Awake()
        {
            base.Awake();
            pooledGobjects = new List<GameObject>();

            foreach (Preallocation item in preAllocations)
            {
                for (int i = 0; i < item.count; ++i)
                    pooledGobjects.Add(CreateGobject(item.gameObject));
            }
        }

        public GameObject Spawn(string tag)
        {
            for (int i = 0; i < pooledGobjects.Count; ++i)
            {
                if (!pooledGobjects[i].activeSelf && pooledGobjects[i].CompareTag(tag))
                {
                    pooledGobjects[i].SetActive(true);
                    return pooledGobjects[i];
                }
            }

            for (int i = 0; i < preAllocations.Count; ++i)
            {
                if (preAllocations[i].gameObject.CompareTag(tag))
                    if (preAllocations[i].expandable)
                    {
                        GameObject obj = CreateGobject(preAllocations[i].gameObject);
                        pooledGobjects.Add(obj);
                        obj.SetActive(true);
                        return obj;
                    }
            }

            return null;
        }

        GameObject CreateGobject(GameObject item)
        {
            var gobject = Instantiate(item, transform);
            gobject.SetActive(false);
            return gobject;
        }
    }
}