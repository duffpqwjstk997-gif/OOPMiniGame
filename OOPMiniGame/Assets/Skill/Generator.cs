using UnityEngine;

public class Generator
{
    public GameObject Generate(GameObject prefab, Vector3 position)
    {
       return GameObject.Instantiate(prefab, position, Quaternion.identity);
    }
}
