using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public class PlayerScore : MonoBehaviour
    {
        public static float score;
    }

    public class Collectable : MonoBehaviour
    {
        float scoreValue = 10;
        private void OnTriggerEnter(Collider other)
        {
            PlayerScore.score += scoreValue;
            Destroy(gameObject);
        }
    }
}
