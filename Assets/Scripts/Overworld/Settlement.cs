using UnityEngine;

[System.Serializable]
public class Settlement : MonoBehaviour {
    public int level = 1;    

    public void Interact(bool show) {
        gameObject.transform.Find("Settlement Menu").gameObject.SetActive(show);
    }
}
