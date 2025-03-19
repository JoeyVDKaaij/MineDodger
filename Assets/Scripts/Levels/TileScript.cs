using System.Linq;
using TMPro;
using UnityEngine;
using JoUnityAddOn.SceneManagement;

public class TileScript : MonoBehaviour
{
    [Header("Tile Settings")]
    [SerializeField, Tooltip("Set if the tile contains a bomb.")]
    private bool containsBomb = false;
    [SerializeField, Tooltip("Set if the tile contains a bomb.")]
    private TextMeshProUGUI counter;
    
    private TileScript[] _surroundingTiles = new TileScript[8];
    private int _surroundingBombsCount = 0;

    // Setup the tile
    private void Start()
    {
        // Checking tiles and remembering the amount of bombs would be useless if you can't check the amount in-game ;)
        
        if (counter != null)
        {
            if (!containsBomb)
            {
                _surroundingBombsCount = CheckTiles();
                
                if (_surroundingBombsCount > 0)
                {
                    counter.GetComponent<TextMeshProUGUI>().text = $"{_surroundingBombsCount}";
                }
                else
                {
                    counter.GetComponent<TextMeshProUGUI>().text = "";
                }
            }
            
            counter.gameObject.SetActive(false);
        }
        else if (!containsBomb)
            Debug.LogWarning("Counter is missing! Please set counter in the inspector.", gameObject);
    }

    // Checks how many bombs are around the tile
    private int CheckTiles()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, Vector3.one * 1.5f, Quaternion.identity, LayerMask.GetMask("Ground"));
        
        int bombCount = 0;

        int tileId = 0;
        foreach (Collider tileCollider in colliders)
        {
            if (tileCollider.transform.GetComponent<TileScript>() != null && tileCollider.gameObject != gameObject)
            {
                _surroundingTiles[tileId] = tileCollider.transform.GetComponent<TileScript>();
                tileId++;
                
                if (tileCollider.transform.GetComponent<TileScript>().ContainsBomb) bombCount++;
            }
        }
        
        return bombCount;
    }

    public void ShowCounter()
    {
        if (containsBomb)
        {
            ActivateBomb();
            return;
        }
        
        if (!counter.gameObject.activeInHierarchy && _surroundingBombsCount > 0)
        {
            counter.gameObject.SetActive(true);
            return;
        }
        
        if (_surroundingBombsCount == 0)
        {
            foreach (TileScript tile in _surroundingTiles)
            {
                tile.ShowCounter();
            }
        }
    }

    private void ActivateBomb()
    {
        SceneManager.ReloadScene();
    }
        
    public bool ContainsBomb
    {
        get { return containsBomb; }
    }
}
