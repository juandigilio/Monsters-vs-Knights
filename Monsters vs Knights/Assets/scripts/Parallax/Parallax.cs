using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //[SerializeField] private Player player;

    [SerializeField] private Transform layer_1;
    [SerializeField] private Transform layer_2;
    [SerializeField] private Transform layer_3;
    [SerializeField] private Transform layer_4;

    public void Update()
    {
        //correr animaciones de parallax (viento)
    }

    public void UpdatePositions(float speed)
    {
        layer_1.position += Vector3.left * speed * Time.deltaTime;
        layer_2.position += Vector3.left * (speed * 0.8f) * Time.deltaTime;
        layer_3.position += Vector3.left * (speed * 0.45f) * Time.deltaTime;
        layer_4.position += Vector3.left * (speed * 0.15f) * Time.deltaTime;
    }
}
