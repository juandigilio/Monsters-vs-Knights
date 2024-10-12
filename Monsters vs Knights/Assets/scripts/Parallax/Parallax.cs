using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Transform layer_1;
    [SerializeField] private GameObject first_1;
    [SerializeField] private GameObject last_1;
    [SerializeField] private Transform layer_1_2;
    [SerializeField] private GameObject first_1_2;
    [SerializeField] private GameObject last_1_2;
    [SerializeField] private Transform layer_2;
    [SerializeField] private GameObject first_2;
    [SerializeField] private GameObject last_2;
    [SerializeField] private Transform layer_2_2;
    [SerializeField] private GameObject first_2_2;
    [SerializeField] private GameObject last_2_2;
    [SerializeField] private Transform layer_3;
    [SerializeField] private GameObject first_3;
    [SerializeField] private GameObject last_3;
    [SerializeField] private Transform layer_4;
    [SerializeField] private GameObject first_4;
    [SerializeField] private GameObject last_4;
    [SerializeField] private Transform trigger_1;
    [SerializeField] private Transform trigger_2;

    [SerializeField] private Parallax parallax_2;

    private float size_1;
    private float size_1_2;
    private float size_2;
    private float size_2_2;
    private float size_3;
    private float size_4;


    public void Start()
    {
        size_1 = last_1.GetComponent<SpriteRenderer>().bounds.size.x;
        size_1_2 = last_1_2.GetComponent<SpriteRenderer>().bounds.size.x;
        size_2 = last_2.GetComponent<SpriteRenderer>().bounds.size.x;
        size_2_2 = last_2_2.GetComponent<SpriteRenderer>().bounds.size.x;
        size_3 = last_3.GetComponent<SpriteRenderer>().bounds.size.x;
        size_4 = last_4.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    public void UpdatePositions(float speed)
    {
        UpdateLayer(layer_1, first_1.transform, last_1.transform, parallax_2.layer_1, parallax_2.first_1.transform, parallax_2.last_1.transform, speed, size_1);
        UpdateLayer(layer_1_2, first_1_2.transform, last_1_2.transform, parallax_2.layer_1_2, parallax_2.first_1_2.transform, parallax_2.last_1_2.transform, speed, size_1_2);
        UpdateLayer(layer_2, first_2.transform, last_2.transform, parallax_2.layer_2, parallax_2.first_2.transform, parallax_2.last_2.transform, speed * 0.8f, size_2);
        UpdateLayer(layer_2_2, first_2_2.transform, last_2_2.transform, parallax_2.layer_2_2, parallax_2.first_2_2.transform, parallax_2.last_2_2.transform, speed * 0.8f, size_2_2);
        UpdateLayer(layer_3, first_3.transform, last_3.transform, parallax_2.layer_3, parallax_2.first_3.transform, parallax_2.last_3.transform, speed * 0.5f, size_3);
        UpdateLayer(layer_4, first_4.transform, last_4.transform, parallax_2.layer_4, parallax_2.first_4.transform, parallax_2.last_4.transform, speed * 0.25f, size_4);
    }













    private void UpdateLayer(Transform layer, Transform first, Transform last, Transform layer_2, Transform first_2, Transform last_2, float speed, float size)
    {
        if (speed > 0)
        {
            if (last.position.x + size > trigger_1.transform.position.x && last.position.x < trigger_2.transform.position.x)
            {
                layer.position += Vector3.left * speed * Time.deltaTime;
                layer_2.position = new Vector3(last.position.x + size, layer_2.position.y, 0);
            }
            else
            {
                layer_2.position += Vector3.left * speed * Time.deltaTime;
                layer.position = new Vector3(last_2.position.x + size, layer.position.y, 0);
            }
        }
        else if (speed < 0)
        {
            if (first.position.x > trigger_1.transform.position.x && last.position.x < trigger_2.transform.position.x)
            {
                layer.position += Vector3.left * speed * Time.deltaTime;
                layer_2.position = new Vector3(first.position.x - size, layer_2.position.y, 0);
            }
            else
            {
                layer_2.position += Vector3.left * speed * Time.deltaTime;
                layer.position = new Vector3(first_2.position.x + size, layer.position.y, 0);
            }
        }
    }
}
