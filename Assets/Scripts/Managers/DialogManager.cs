using Assets.ScriptableObjects.Chanels;
using Assets.ScriptableObjects.Dialog;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour, IDialogNodeVisitor
{
    [SerializeField] private Image characterImage;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private DialogChanel dialogChanel;

    [SerializeField] private GameObject buttonsPanel;
    [SerializeField] private GameObject buttonPrefab;

    private List<GameObject> buttons = new List<GameObject>();

    private DialogSequencer dialogSequencer;

    private void Awake()
    {
        dialogSequencer = new DialogSequencer();

        dialogSequencer.OnNodeStart += dialogChanel.RaiseNodeStart;

        dialogChanel.OnDialogStart += dialogSequencer.StartDialog;
        dialogChanel.OnNodeStart += HandleStartNode;
    }

    private void OnDestroy()
    {
        dialogSequencer.OnNodeStart -= dialogChanel.RaiseNodeStart;

        dialogChanel.OnDialogStart -= dialogSequencer.StartDialog;
        dialogChanel.OnNodeStart -= HandleStartNode;
    }

    private void HandleStartNode(DialogNode node)
    {
        DrawLine(node.Line);
        node.Visit(this);
    }

    private void DrawLine(NarrationLine line)
    {
        characterImage.sprite = line.Character.Avatar;
        characterName.text = line.Character.Name;
        dialogText.text = line.Text;
    }

    private void CreateButton(string text)
    {
        var button = Instantiate(buttonPrefab);
        button.transform.SetParent(buttonsPanel.transform);
        button.GetComponentInChildren<TextMeshProUGUI>().text = text; ;

        buttons.Add(button);
    }

    private void ClearButtons()
    {
        foreach (var button in buttons)
        {
            Destroy(button.gameObject);
        }

        buttons.Clear();
    }

    public void Visit(ChoiceDialogNode node)
    {
        ClearButtons();
        foreach (var choice in node.Choices)
        {
            CreateButton(choice.Preview);
        }
    }

    public void Visit(LinearDialogNode node)
    {
        ClearButtons();
        CreateButton("Next");
    }
}
