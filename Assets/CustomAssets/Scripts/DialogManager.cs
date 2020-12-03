using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Singleton
public class DialogManager : MonoBehaviour
{
    private static DialogManager Instance { get; set; }

    [SerializeField] // para que se vea en el inspector pero la variable siga siendo privada
    private GameObject DialogPane;
    private Text DialogTxt;
    private Text NpcNameTxt;
    private Button ContinueButton;
    private Text ContinueButtonTxt;

    private string _name;
    private int _dialogueIndex;
    private List<string> _dialogues = new List<string>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (DialogPane == null)
        {
            Debug.LogWarning("No se agregó un panel desde el inspector");
        }

        DialogTxt = DialogPane.transform.GetComponentInChildren<Text>();
        if (DialogTxt == null)
        {
            Debug.LogWarning("No se encontró el cuadro de texto del panel del dialogo");
        }

        NpcNameTxt = DialogPane.transform.GetChild(1).GetComponentInChildren<Text>();
        if (NpcNameTxt == null)
        {
            Debug.LogWarning("No se encontró el texto del segundo hijo del padre");
        }

        ContinueButton = DialogPane.transform.GetChild(2).GetComponent<Button>();
        if (ContinueButton == null)
        {
            Debug.LogWarning("No se encontró el botón como tercer hijo del padre");
        }
        else
        {
            ContinueButtonTxt = ContinueButton.transform.GetComponentInChildren<Text>();
            if (ContinueButtonTxt == null)
            {
                Debug.LogWarning("El botón no tiene text");
            }
        }

        DialogTxt.text = "Hola, bienvenido";
        NpcNameTxt.text = "???";
        ContinueButtonTxt.text = "Continuar";

        DialogPane.SetActive(false);
        ContinueButton.onClick.AddListener(delegate { ContinueDialogues(); });
    }

    public void GetDialogue(string name, string[] dialogues)
    {
        Debug.Log("Obteniendo dialogos");
        DialogPane.SetActive(true);
        _dialogueIndex = 0;
        _name = name;
        _dialogues = new List<string>(dialogues.Length);
        _dialogues.AddRange(dialogues);
        NpcNameTxt.text = name;
        CreateDialogues();
    }

    public void CreateDialogues()
    {
        DialogTxt.text = _dialogues[_dialogueIndex];
    }
    public void ContinueDialogues()
    {
        if (_dialogueIndex < _dialogues.Count - 1)
        {
            _dialogueIndex++;
            CreateDialogues();
        }
        else
        {
            Debug.Log("Terminó de hablar");
            DialogPane.SetActive(false);
        }
    }
}
