using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectible : MonoBehaviour
{
    public GameObject collectible_game_object;
    public string collectible_name = "item";

    public GameObject Collect() {
        Debug.Log("Collected " + collectible_name);
        collectible_game_object.SetActive(false);
        return collectible_game_object;
    }

    public void ReleaseCollectible(Vector3 position) {
        Debug.Log("Releasing collectible " + collectible_name);
        collectible_game_object.SetActive(true);
    }
}
