
public enum ObjectType
{
    Cube,Sphere,Capsule,Cylinder,NONE
}


public interface  IObjectType 
{
  
  public ObjectType ChangeType();
}
