using TMPro;
using UnityEngine;
using JoUnityAddOn.SceneManagement;

public class TileScript : MonoBehaviour
{
    [Header("Tile Settings")]
    [SerializeField, Tooltip("Set if the tile contains a bomb.")]
    private bool containsBomb = false;
    [SerializeField, Tooltip("Set the offset of the death animation.")]
    private Vector3 deathAnimationOffSet = Vector3.zero;
    [SerializeField, Tooltip("Set the counter text component.")]
    private TextMeshProUGUI counter;
    
    [Header("Counter Settings")]
    [SerializeField, Tooltip("Set if the tile should show a counter at the start of the scene.")]
    private bool showCounter;
    [SerializeField, Tooltip("Set if the counter should show a ? instead of a number.")]
    private bool questionMarkTile = false;
    
    private TileScript[] _surroundingTiles = new TileScript[8];
    private int _surroundingBombsCount = 0;
    private bool counterShown = false;

    // Setup the tile
    private void Start()
    {
        // Checking tiles and remembering the amount of bombs would be useless if you can't check the amount in-game ;)
        
        if (counter != null)
        {
            if (!containsBomb)
            {
                _surroundingBombsCount = CheckTiles();
                
                if (_surroundingBombsCount > 0 && !questionMarkTile)
                {
                    counter.GetComponent<TextMeshProUGUI>().SetText($"{_surroundingBombsCount}");
                }
                else if (questionMarkTile)
                {
                    counter.GetComponent<TextMeshProUGUI>().SetText("?");
                }
                else
                {
                    counter.GetComponent<TextMeshProUGUI>().SetText("");
                }
            }
            
            if (showCounter)
            {
                ShowCounter();
            }
            else counter.gameObject.SetActive(false);
        }
        else if (!containsBomb)
            Debug.LogWarning("Counter is missing! Please set counter in the inspector.", gameObject);
    }

    // Checks how many bombs are around the tile
    private int CheckTiles()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, Vector3.one * 2f, Quaternion.identity, LayerMask.GetMask("Ground"));
        
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
        if (counterShown)
            return;
            
        counterShown = true;
        
        if (containsBomb)
        {
            ActivateBomb();
            return;
        }
        
        if (!counter.gameObject.activeInHierarchy && (_surroundingBombsCount > 0 || questionMarkTile))
        {
            counter.gameObject.SetActive(true);
            return;
        }
        
        if (_surroundingBombsCount == 0 && !questionMarkTile)
        {
            foreach (TileScript tile in _surroundingTiles)
            {
                if (tile != null)
                    tile.ShowCounter();
            }
        }
    }

    private void ActivateBomb()
    {
        if (DeathAnimationScript.instance != null)
            DeathAnimationScript.instance.PlayDeathAnimation(transform.parent.position + deathAnimationOffSet);
        else
            SceneManager.ReloadScene();
    }
        
    public bool ContainsBomb
    {
        get { return containsBomb; }
    }
}
