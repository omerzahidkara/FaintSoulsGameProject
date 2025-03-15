using System;
using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox; // Diyalog kutusu UI objesi
    [SerializeField] Text dialogText; // Diyalog metnini tutan UI ��esi
    [SerializeField] int lettersPerSecond; // Yaz� animasyonu h�z�

    public event Action OnShowDialog; // Diyalog a��ld���nda tetiklenen olay
    public event Action OnHideDialog; // Diyalog kapand���nda tetiklenen olay
    public static DialogManager Instance { get; private set; } // Singleton eri�imi

    private void Awake()
    {
        Instance = this; // Tek bir DialogManager olmas�n� sa�l�yoruz
    }

    int currentLine = 0; // �u anda hangi sat�rda oldu�umuzu takip eden de�i�ken
    Dialog dialog; // Mevcut diyalog verisi
    bool isTyping; // Yaz� animasyonu devam ediyor mu?

    public IEnumerator ShowDialog(Dialog dialog)
    {
        yield return new WaitForEndOfFrame();
        OnShowDialog?.Invoke(); // Diyalog ba�lad���n� bildir

        this.dialog = dialog;
        dialogBox.SetActive(true); // Diyalog kutusunu a�
        StartCoroutine(TypeDialog(dialog.Lines[0])); // �lk sat�r� yazd�rmaya ba�la
    }

    public void HandleUpdate()
    {
        // Kullan�c� "F" tu�una bast���nda ve yaz� tamamlanm��sa ilerle
        if (Input.GetKeyUp(KeyCode.F) && !isTyping)
        {
            ++currentLine;
            if (currentLine < dialog.Lines.Count)
            {
                StartCoroutine(TypeDialog(dialog.Lines[currentLine])); // Sonraki sat�ra ge�
            }
            else
            {
                dialogBox.SetActive(false); // Diyalog kutusunu kapat
                currentLine = 0; // Sat�r s�f�rla
                OnHideDialog?.Invoke(); // Diyalog bitti�ini bildir
            }
        }
    }

    public IEnumerator TypeDialog(string line)
    {
        isTyping = true;
        dialogText.text = ""; // �nce metni temizle

        foreach (var letter in line.ToCharArray())
        {
            dialogText.text += letter; // Harf harf ekle
            yield return new WaitForSeconds(1f / lettersPerSecond); // Animasyon h�z�
        }

        isTyping = false;
    }
}
