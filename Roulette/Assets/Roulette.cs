using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Roulette : MonoBehaviour
{
    [SerializeField] GameObject playerTurnUI;

    bool[] slots = { false, false, false, false, false, false};
    bool playerTurn = true;
    int shotIndex = -1;


    // Start is called before the first frame update
    void Start()
    {

        int loadedSlot = Random.Range(1, slots.Length + 1);

        for (int i = 0; i < slots.Length; i++)
        {
            if (i == loadedSlot)
            {
                slots[i] = true;
            }
        }

        Debug.Log("Welcome to the Roulette game!");
        Debug.Log("Sign this waver: Name");
        Debug.Log("You start; there is 5 unloded slots and 1 loaded. If you choose to shoot yourself you will get" +
            "to shoot again.");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartRouletteGame()
    {
        if (playerTurn) 
        {
            PlayerTurn();
        }

        else
        {
            StartCoroutine(OpponentTurn());
        }
        shotIndex++;
    }

    void PlayerTurn()
    {
        playerTurnUI.SetActive(true);
    }

    IEnumerator OpponentTurn() 
    {
        yield return new WaitForSeconds(2f);
        if (Random.Range(1, 3) == 1) OpponentShootSelf();
        else OpponentShootsPlayer();
    }

    public void ShootOpponent()
    {
        if (slots[shotIndex])
        {
            Debug.Log("You shot the opponent and he died");
            //Win();
            return;
        }
        else
        {
            Debug.Log("You shot the opponent and it was a unloaded slot. His turn");
            playerTurn = false;
        }
        playerTurnUI.SetActive(false);
        StartRouletteGame();
    }

    public void ShootYourself()
    {
        if (slots[shotIndex])
        {
            Debug.Log("You shot yourself and died");
            //Loose;
            return;
        }

        Debug.Log("You shot yourself and it was a unloaded slot. Your turn");
        playerTurnUI.SetActive(false);
        StartRouletteGame();
    }

    public void OpponentShootSelf()
    {
        if (slots[shotIndex])
        {
            Debug.Log("The opponent shot himself and died :(");
            //Win();
            return;
        }
        else
        {
            Debug.Log("He shot himself with unloaded slot. His turn");
        }
        StartRouletteGame();
    }

    public void OpponentShootsPlayer()
    {
        if (slots[shotIndex])
        {
            Debug.Log("The opponent shot you and you died :(");
            //Loose;
            return;
        }

        Debug.Log("The opponent shot you with unloaded round. Your turn");
        playerTurn = true;
        StartRouletteGame();
    }
}
