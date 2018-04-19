using UnityEngine;

namespace SketchMap {
    public class GravityFlip : MonoBehaviour {
        public void Flip() {
            Physics.gravity = new Vector3(Physics.gravity.x, Physics.gravity.z, Physics.gravity.y);
        }
    }
}