using UnityEngine;

public class TypeBox : MonoBehaviour, IObjectType
{
    [SerializeField] ObjectType type;
    public ObjectType ChangeType()
    {
        return type;
    }

    
}
