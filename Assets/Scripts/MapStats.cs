using UnityEngine;
using UnityEngine.UI;

namespace SketchMap {
    public class MapStats : MonoBehaviour {
        public GameObject Table;
        public Text GemCount;

        static Text _GemCount;
        static int _RemainingGems;

        static GameObject GameTable;

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

        public static MapStats Instance { get; private set; }

        void Awake() {
            Instance = this;
            _GemCount = GemCount;
        }

        public GameObject Reload() {
            if (GameTable)
                Destroy(GameTable);
            RemainingGems = 0;
            GameTable = Instantiate(Table);
            Player.CreatePlayer(GameTable.transform, new Vector2(0, 0));
            return GameTable;
        }
    }
}