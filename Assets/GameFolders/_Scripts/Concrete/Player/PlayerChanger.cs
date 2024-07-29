using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ObjectnType
{
    public GameObject item;
    public ObjectType type;
}
public class PlayerChanger : MonoBehaviour
{
    public ObjectType type;

    [SerializeField] List<ObjectnType> gameObjects = new List<ObjectnType>();


    void Start()
    {

        type = ObjectType.Cube;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Changer"))
        {
                Debug.Log("Changer");
            if (other.TryGetComponent(out TypeBox typeBox))
            {
                type = typeBox.ChangeType();
            }

            foreach (ObjectnType current in gameObjects)
            {
                if (current.type != type)
                {
                    current.item.SetActive(false);
                }
                else
                {
                    current.item.SetActive(true);
                }
            }
        }
    }

}
