using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Parallax : MonoBehaviour
{
    [SerializeField] private List<Transform> layers = new List<Transform>();
    [SerializeField] private List<GameObject> firsts = new List<GameObject>();
    [SerializeField] private List<GameObject> lasts = new List<GameObject>();

    [SerializeField] private Transform trigger_1;
    [SerializeField] private Transform trigger_2;

    [SerializeField] private Parallax parallax_2;


    private List<float> spriteSizes = new List<float>();
    private List<float> layerSizes = new List<float>();


    public void Start()
    {
        for (int i = 0; i < layers.Count; i++)
        {
            spriteSizes.Add(lasts[i].GetComponent<SpriteRenderer>().bounds.size.x);
            layerSizes.Add(GetLayerSize(layers[i], spriteSizes[i]));
        }
    }

    public void UpdatePositions(float speed)
    {
        for (int i = 0; i < layers.Count; i++)
        {
            UpdateLayer(layers[i], firsts[i].transform, lasts[i].transform, parallax_2.layers[i], parallax_2.firsts[i].transform, parallax_2.lasts[i].transform, speed, spriteSizes[i], layerSizes[i]);
        }
    }

    private float GetLayerSize(Transform layer, float size)
    {
        return layer.childCount * size;
    }

    private void UpdateLayer(Transform layer, Transform first, Transform last, Transform layer_2, Transform first_2, Transform last_2, float speed, float size, float layerSize)
    {
        if (speed > 0)
        {
            if (last.position.x + size > trigger_1.transform.position.x && last.position.x < trigger_2.transform.position.x)
            {
                layer.position += Vector3.left * speed * Time.deltaTime;
                layer_2.position = new Vector3(layer.position.x + layerSize, layer_2.position.y, 0);
            }
            else
            {
                layer_2.position += Vector3.left * speed * Time.deltaTime;
                layer.position = new Vector3(layer_2.position.x + layerSize, layer.position.y, 0);
            }
        }
        else if (speed < 0)
        {          
            if (first.position.x - size > trigger_1.transform.position.x && first_2.position.x < trigger_1.position.x)
            {
                layer.position += Vector3.left * speed * Time.deltaTime; // Movimiento hacia la derecha
                layer_2.position = new Vector3(layer.position.x - layerSize, layer_2.position.y, 0);
                

                Debug.Log("fist");
               // Debug.Log("layer1 pos: " + layer.position);
               // Debug.Log("layer2 pos: " + layer_2.position);
            }
            else
            {
                layer_2.position += Vector3.left * speed * Time.deltaTime; // Movimiento hacia la derecha
                layer.position = new Vector3(layer_2.position.x - layerSize, layer.position.y, 0);
                Debug.Log("second");
               // Debug.Log("layer1 pos: " + layer.position);
               // Debug.Log("layer2 pos: " + layer_2.position);
            }
        }
    }
}
