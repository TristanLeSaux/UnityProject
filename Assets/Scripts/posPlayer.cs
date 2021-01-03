using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posPlayer : MonoBehaviour {

    private Vector3 cameraBorderRightTop;
    private Vector3 cameraBorderLeftBottom;
    private Vector3 shipSize;
    private Vector3 shipOldCenterPosition;
    private Vector2 shipNewCenterPosition;

    // Start is called before the first frame update
    void Start() {
        cameraBorderLeftBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        cameraBorderRightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        shipSize = gameObject.GetComponent<SpriteRenderer>().bounds.size;       // Récupération de la taille de l'objet "ship".
    }

    // Update is called once per frame
    void Update() {
        shipOldCenterPosition = gameObject.GetComponent<Transform>().position;  // Récupération de la position de l'objet.
        shipNewCenterPosition = shipOldCenterPosition;  // Valeur par défaut (cas où l'objet est dans le champs de vision de la caméra).

        if (shipOldCenterPosition.x + (shipSize.x/2) > cameraBorderRightTop.x) { shipNewCenterPosition.x = cameraBorderRightTop.x - (shipSize.x/2); }     // L'objet veut sortir à droite 
        if (shipOldCenterPosition.x - (shipSize.x/2) < cameraBorderLeftBottom.x) { shipNewCenterPosition.x = cameraBorderLeftBottom.x + (shipSize.x/2); }       // L'objet veut sortir à gauche
        if (shipOldCenterPosition.y + (shipSize.y/2) > cameraBorderRightTop.y) { shipNewCenterPosition.y = cameraBorderRightTop.y - (shipSize.y/2); }       // L'objet veut sortir en haut
        if (shipOldCenterPosition.y - (shipSize.y/2) < cameraBorderLeftBottom.y) { shipNewCenterPosition.y = cameraBorderLeftBottom.y + (shipSize.y/2); } // L'objet veut sortir en bas

        gameObject.GetComponent<Rigidbody2D>().position = shipNewCenterPosition;
    }
}
