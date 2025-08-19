using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagToChestStrategy : IMovementStrategy
{
    private Transform chest;
    private float speed;
    private float frequency;
    private float amplitude;

    private float timeOffset;

    public ZigZagToChestStrategy(float speed, float frequency = 3f, float amplitude = 1f)
    {
        this.speed = speed;
        this.frequency = frequency;
        this.amplitude = amplitude;

        chest = GameObject.FindWithTag("Chest")?.transform;
        timeOffset = Random.Range(0f, 100f); //Para que la oscilacion varie entre enemigos
    }

    public void Move(Transform self)
    {
        if (chest == null) return;

        Vector2 toTarget = (chest.position - self.position).normalized;

        //Obtengo la dirección perpendicular para el zigzag
        Vector2 perpendicular = new Vector2(-toTarget.y, toTarget.x);

        //Oscilación en esa dirección
        float wave = Mathf.Sin((Time.time + timeOffset) * frequency) * amplitude;
        Vector2 zigzag = toTarget + perpendicular * wave;

        self.position += (Vector3)(zigzag.normalized * speed * Time.deltaTime);
    }
}
