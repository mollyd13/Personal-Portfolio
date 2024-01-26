using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetterManager : MonoBehaviour
{
    public GameObject closedLetter;
    public GameObject openLetter;
    public GameObject note;
    public GameObject noteFlipped;
    public GameObject hearts;
    public GameObject letterBG;
    public void letterClicked()
    {
        if (closedLetter.transform.localPosition.x == 0){
            closedLetter.SetActive(false);
            openLetter.SetActive(true);
        }
        LeanTween.scale(letterBG, new Vector3(1, 1, 1), .75f).setEase(LeanTweenType.easeOutSine);
        LeanTween.scale(closedLetter, new Vector3(5, 5, 1), 1);
        LeanTween.moveLocalX(closedLetter, 0, 1);
        LeanTween.moveLocalY(closedLetter, 0, 1);

    }

    public void openLetterClicked(){
        LeanTween.moveLocalY(openLetter,  -300, 2);
        LeanTween.scale(openLetter, new Vector3(0, 0, 0), 2);
        LeanTween.moveLocalY(note, 100, 1.25f);
        LeanTween.scale(note, new Vector3(5, 5, 5), 1.25f);
        
    }

    public void noteClicked(){
        LeanTween.rotateAroundLocal(note, Vector3.down, -90,  1);
        StartCoroutine(flipNoteDelay());
    }

    public IEnumerator flipNoteDelay(){
        yield return new WaitForSeconds(1);
        LeanTween.rotateAroundLocal(noteFlipped, Vector3.up, 90, 1);
        yield return new WaitForSeconds(.5f);
        hearts.SetActive(true);
    }

    public void endLetterSequence(){
        SceneManager.LoadScene("Menu");
    }
}
