using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class WeaponRenderer : MonoBehaviour
{
    [field: SerializeField]
    protected int playerSortingIndex = 0;

    protected SpriteRenderer weaponRenderer;

    private void Awake()
    {
        weaponRenderer = GetComponent<SpriteRenderer>();
    }

    public void renderInfrontPlayer(bool val)
    {
        if (val)
            weaponRenderer.sortingOrder = playerSortingIndex + 1;
    }
}
