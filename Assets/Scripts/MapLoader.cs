using System.IO;
using UnityEngine;

namespace SketchMap {
    public class MapLoader : MonoBehaviour {
        FilePicker Picker;

        void Start() {
            Picker = new FilePicker();
            Picker.Folder = PlayerPrefs.GetString("LoaderLocation", "\\");
            Picker.OnFileLoaded += OnLoad;
        }

        public void OpenBrowser() {
            Picker.Show();
        }

        void OnLoad(FileInfo Picked) {
            Transform Map = MapStats.Instance.Reload().transform;
            string[] Elements = File.ReadAllLines(Picked.FullName);
            foreach (string Element in Elements) {
                string[] Split = Element.Split(' ');
                if (Split[0].Equals("Wall"))
                    Wall.CreateWall(Map, new Vector2(float.Parse(Split[1]), float.Parse(Split[2])), new Vector2(float.Parse(Split[3]), float.Parse(Split[4])),
                        new Color(float.Parse(Split[5]) / 255, float.Parse(Split[6]) / 255, float.Parse(Split[7]) / 255));
                else if (Split[0].Equals("Gem"))
                    Gem.CreateGem(Map, new Vector2(float.Parse(Split[1]), float.Parse(Split[2])),
                        new Color(float.Parse(Split[3]) / 255, float.Parse(Split[4]) / 255, float.Parse(Split[5]) / 255));
            }
        }

        void OnGUI() {
            Picker.OnGUI(500);
        }

        void OnApplicationQuit() {
            PlayerPrefs.SetString("LoaderLocation", Picker.Folder);
            PlayerPrefs.Save();
        }
    }
}