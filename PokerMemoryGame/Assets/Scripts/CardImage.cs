using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardImage : MonoBehaviour
{
    [SerializeField] private GameObject faceCardDown;
  
    [SerializeField] private GameUI gameController;

    private void OnMouseDown()
    {
        if (faceCardDown.activeSelf && gameController.canOpen)
        {
            faceCardDown.SetActive(false);
            gameController.imageOpened(this);
            
        }
    }

    private int _spriteId;

    public int spriteId
    {
        get { return _spriteId; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _spriteId = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    
    public void Open()
    {
        faceCardDown.SetActive(false);
        StartCoroutine(cardDesapeared());
    }

    IEnumerator cardDesapeared()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    public void Close()
    {
        faceCardDown.SetActive(true);
    }

}
