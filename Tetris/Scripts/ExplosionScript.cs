using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    
    
    public float cubeSize = 0.2f;
    public int cubesInRow = 2;

    float cubesPivotDistance;
    Vector3 cubesPivot;

    public float explosionForce = 70f;
    public float explosionRadius = 3f;
    public float explosionUpward = 0.4f;

    // Use this for initialization
  
    void Start()
    {


        //calculate pivot distance
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        //use this value to create pivot vector)
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);

    }

    // Update is called once per frame
    void Update()
    {
     
    }

    

    public void explode(GameObject go)
    {
        //make object disappear
        go.SetActive(false);

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for (int x = 0; x < cubesInRow; x++)
        {
            for (int y = 0; y < cubesInRow; y++)
            {
                for (int z = 0; z < cubesInRow; z++)
                {
                    createPiece(x, y, z,go);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = go.transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        //add explosion force to all colliders in that overlap sphere
        foreach (Collider hit in colliders)
        {
            //get rigidbody from collider object
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                //add explosion force to this body with given parameters
                rb.AddExplosionForce(explosionForce, go.transform.position, explosionRadius, explosionUpward);
            }
        }

    }

    void createPiece(int x, int y, int z,GameObject go)
    {
        Color colorMaterial = go.GetComponent<MeshRenderer>().material.color;
        //create piece
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        piece.GetComponent<MeshRenderer>().material.SetColor("_Color", colorMaterial);
        //set piece position and scale
        piece.transform.position = go.transform.position + new Vector3(cubeSize * x, cubeSize * y, cubeSize * z) - cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigidbody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;
        piece.GetComponent<BoxCollider>().isTrigger = true;
       
        //piece.transform.SetParent(pieces.transform);
    }

}