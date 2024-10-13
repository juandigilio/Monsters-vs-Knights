using System.Collections.Generic;
using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    //public Sprite sprite;
    public List<Sprite> sprites;
    public float parallaxSpeed;
    public int sortingOrder;
    
    private List<GameObject> spriteInstances = new List<GameObject>();
    private Camera mainCamera;
    private float spriteWidth;
    private int numberOfSprites;

    public void Initialize(Camera sceneCamera)
    {
        this.mainCamera = sceneCamera;
        spriteWidth = GetSpriteWidth();
        numberOfSprites = CalculateNumberOfSprites();

        CreateSprites();
    }

    private float GetSpriteWidth()
    {
        if (sprites == null || sprites.Count == 0)
        {
            Debug.LogError("No sprites assigned!");
            return 0;
        }
        
        SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
        spriteRenderer.sortingOrder = sortingOrder;

        float width = spriteRenderer.bounds.size.x;
        spriteRenderer.enabled = false;
        return width;
    }

    private int CalculateNumberOfSprites()
    {
        float screenWidth = mainCamera.orthographicSize * 2.0f * Screen.width / Screen.height;
        return Mathf.CeilToInt(screenWidth / spriteWidth) + 4;
    }

    private void CreateSprites()
    {
        float cameraLeftEdge = GetCameraLeftEdge();
        
        for (int i = 0; i < numberOfSprites; i++)
        {
            GameObject spriteInstance = new GameObject("ParallaxSprite_" + i);
            spriteInstance.transform.SetParent(transform);

            SpriteRenderer sr = spriteInstance.AddComponent<SpriteRenderer>();
            sr.sprite = GetRandomSprite();
            sr.sortingOrder = sortingOrder;

            float xPos = cameraLeftEdge + (i * spriteWidth);
            spriteInstance.transform.position = new Vector3(xPos, transform.position.y, transform.position.z);

            spriteInstances.Add(spriteInstance);
        }
    }
    
    private Sprite GetRandomSprite()
    {
        if (sprites == null || sprites.Count == 0)
        {
            Debug.LogError("No sprites available for random selection!");
            return null;
        }
        return sprites[Random.Range(0, sprites.Count)];
    }

    public void Move(Directions direction)
    {
        if (direction == Directions.None)
        {
            return;
        }

        float cameraLeftEdge = GetCameraLeftEdge();
        float cameraRightEdge = GetCameraRightEdge();

        Vector3 movement = direction == Directions.Right ? Vector3.left : Vector3.right;
        float edgeBoundary = direction == Directions.Right ? cameraLeftEdge - spriteWidth * 2 : cameraRightEdge + spriteWidth * 2;

        foreach (var spriteInstance in spriteInstances)
        {
            spriteInstance.transform.Translate(movement * parallaxSpeed * Time.deltaTime);

            if (IsSpriteOutOfBounds(spriteInstance, edgeBoundary, direction))
            {
                RepositionSprite(spriteInstance, direction);
            }
        }
    }

    private bool IsSpriteOutOfBounds(GameObject spriteInstance, float edgeBoundary, Directions direction)
    {
        if (direction == Directions.Right)
        {
            return spriteInstance.transform.position.x < edgeBoundary;
        }
        else
        {
            return spriteInstance.transform.position.x > edgeBoundary;
        }
    }

    private void RepositionSprite(GameObject spriteInstance, Directions direction)
    {
        if (direction == Directions.Right)
        {
            float rightmostX = GetRightmostSpriteX();
            spriteInstance.transform.position = new Vector3(rightmostX + spriteWidth - 0.01f, spriteInstance.transform.position.y, spriteInstance.transform.position.z);
        }
        else
        {
            float leftmostX = GetLeftmostSpriteX();
            spriteInstance.transform.position = new Vector3(leftmostX - spriteWidth + 0.01f, spriteInstance.transform.position.y, spriteInstance.transform.position.z);
        }
    }

    private float GetRightmostSpriteX()
    {
        float rightmostX = float.MinValue;
        foreach (var spriteInstance in spriteInstances)
        {
            if (spriteInstance.transform.position.x > rightmostX)
            {
                rightmostX = spriteInstance.transform.position.x;
            }
        }
        return rightmostX;
    }

    private float GetLeftmostSpriteX()
    {
        float leftmostX = float.MaxValue;
        foreach (var spriteInstance in spriteInstances)
        {
            if (spriteInstance.transform.position.x < leftmostX)
            {
                leftmostX = spriteInstance.transform.position.x;
            }
        }
        return leftmostX;
    }

    private float GetCameraLeftEdge()
    {
        return mainCamera.transform.position.x - (mainCamera.orthographicSize * Screen.width / Screen.height);
    }

    private float GetCameraRightEdge()
    {
        return mainCamera.transform.position.x + (mainCamera.orthographicSize * Screen.width / Screen.height);
    }
}
