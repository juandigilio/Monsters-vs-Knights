using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public ParallaxLayer[] layers;
    public Camera mainCamera;
    
    public void Start()
    {
        for (int i = 0; i < layers.Length; i++)
        {
            layers[i].Initialize(mainCamera);
        }
    }

    public void Update()
    {
        Directions direction = Directions.None;

        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > 150.0f)
            {
                direction = Directions.Right;
            }
            else
            {
                direction = Directions.Left;
            }    
        }
        
        for (int i = 0; i < layers.Length; i++)
        {
            layers[i].Move(direction);
        }
    }
}

public enum Directions
{
    None,
    Left,
    Right
}