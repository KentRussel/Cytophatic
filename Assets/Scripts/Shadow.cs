using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapShadow : MonoBehaviour
{
    // The object that will cast the shadow
    public GameObject shadowCaster;

    // The object that will receive the shadow
    public GameObject shadowReceiver;

    // The material that will be used to render the shadow
    public Material shadowMaterial;

    // The color of the shadow
    public Color shadowColor = Color.black;

    // The scale of the shadow
    public Vector3 shadowScale = new Vector3(1, 1, 1);

    // The offset of the shadow from the shadow caster
    public Vector3 shadowOffset = new Vector3(0, 0.01f, 0);

    // The layer on which the shadow will be rendered
    public int shadowLayer = 0;

    // The layer on which the character is rendered
    public int characterLayer = 0;

    void Start()
    {
        // Create the shadow object
        GameObject shadow = new GameObject("Shadow");
        shadow.transform.parent = shadowCaster.transform;
        shadow.transform.position = shadowCaster.transform.position + shadowOffset;
        shadow.transform.localScale = shadowScale;

        // Add a sprite renderer and a box collider to the shadow object
        SpriteRenderer shadowRenderer = shadow.AddComponent<SpriteRenderer>();
        BoxCollider2D shadowCollider = shadow.AddComponent<BoxCollider2D>();

        // Set the shadow material and color
        shadowRenderer.material = shadowMaterial;
        shadowRenderer.material.color = shadowColor;

        // Set the shadow sprite to be the same as the shadow caster's sprite
        shadowRenderer.sprite = shadowCaster.GetComponent<SpriteRenderer>().sprite;

        // Set the shadow collider to be the same size as the shadow sprite
        shadowCollider.size = shadowRenderer.sprite.bounds.size;

        // Set the shadow layer
        shadow.layer = shadowLayer;

        // Set the character layer
        shadowCaster.layer = characterLayer;

        // Set the shadow receiver to ignore the character layer
        Physics2D.IgnoreLayerCollision(shadowReceiver.layer, characterLayer);
    }
}

public class Shadow : MonoBehaviour
{
    // The object that will cast the shadow
    public GameObject shadowCaster;

    // The object that will receive the shadow
    public GameObject shadowReceiver;

    // The material that will be used to render the shadow
    public Material shadowMaterial;

    // The color of the shadow
    public Color shadowColor = Color.black;

    // The scale of the shadow
    public Vector3 shadowScale = new Vector3(1, 1, 1);

    // The offset of the shadow from the shadow caster
    public Vector3 shadowOffset = new Vector3(0, 0.01f, 0);

    // The layer on which the shadow will be rendered
    public int shadowLayer = 0;

    void Start()
    {
        // Create the shadow object
        GameObject shadow = new GameObject("Shadow");
        shadow.transform.parent = shadowCaster.transform;
        shadow.transform.position = shadowCaster.transform.position + shadowOffset;
        shadow.transform.localScale = shadowScale;

        // Add a mesh renderer and a mesh filter to the shadow object
        MeshRenderer shadowRenderer = shadow.AddComponent<MeshRenderer>();
        MeshFilter shadowFilter = shadow.AddComponent<MeshFilter>();

        // Set the shadow material and color
        shadowRenderer.material = shadowMaterial;
        shadowRenderer.material.color = shadowColor;

        // Set the shadow layer
        shadow.layer = shadowLayer;

        // Set the shadow mesh to be the same as the shadow receiver's mesh
        shadowFilter.mesh = shadowReceiver.GetComponent<MeshFilter>().mesh;
    }
}
