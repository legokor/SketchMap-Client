using UnityEngine;

namespace SketchMap {
    public class Player : MonoBehaviour {
        public Transform Parent;

        public static Player CreatePlayer(Transform Parent, Vector2 Position) {
            GameObject NewObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            NewObject.transform.localScale = new Vector3(.5f, .5f, .5f);
            NewObject.transform.position = Parent.position + Parent.rotation *
                new Vector3(Position.x / Parent.localScale.x, Position.y / Parent.localScale.y, -.5f / Parent.localScale.z);
            NewObject.GetComponent<Renderer>().material.color = Color.black;
            NewObject.AddComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            Player NewPlayer = NewObject.AddComponent<Player>();
            NewPlayer.Parent = Parent;
            return NewPlayer;
        }

        /// <summary>
        /// Don't let the player fall off the map when it's dragged too intensively.
        /// </summary>
        void FixedUpdate() {
            Vector3 LocalPosition = Quaternion.Inverse(Parent.rotation) * (transform.position - Parent.position);
            if (LocalPosition.z > 0 || LocalPosition.z < Parent.localScale.z * -3f)
                transform.position = Parent.position + Parent.rotation * new Vector3(LocalPosition.x, LocalPosition.y, -Parent.localScale.z);
        }
    }
}