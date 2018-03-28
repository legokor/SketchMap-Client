using UnityEngine;
using UnityEngine.UI;

namespace SketchMap {
    public class MapStats : MonoBehaviour {
        public Text GemCount;

        static Text _GemCount;
        static int _RemainingGems;

        public static int RemainingGems {
            get {
                return _RemainingGems;
            }
            set {
                _RemainingGems = value;
                if (_GemCount)
                    _GemCount.text = value.ToString();
            }
        }

        void Start() {
            _GemCount = GemCount;
        }

        public static void Reset() {
            RemainingGems = 0;
        }
    }
}