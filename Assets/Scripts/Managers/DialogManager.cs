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
    [SerializeField] private Button buttonPrefab;

    private List<Button> buttons = new List<Button>();

    private DialogSequencer dialogSequencer;

    private void Awake()
    {
        dialogSequencer = new DialogSequencer();

        dialogSequencer.OnNodeStart += dialogChanel.RaiseNodeStart;

        dialogChanel.OnDialogStart += dialogSequencer.StartDialog;
        dialogChanel.OnDialogEnd += dialogSequencer.EndDialog;
        dialogChanel.OnNodeRequest += dialogSequencer.StartNode;
        dialogChanel.OnNodeStart += HandleStartNode;
    }

    private void OnDestroy()
    {
        dialogSequencer.OnNodeStart -= dialogChanel.RaiseNodeStart;

        dialogChanel.OnDialogStart -= dialogSequencer.StartDialog;
        dialogChanel.OnDialogEnd -= dialogSequencer.EndDialog;
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

    private void CreateButton(LinearDialogNode node)
    {
        var button = Instantiate(buttonPrefab);
        button.gameObject.transform.SetParent(buttonsPanel.transform);
        button.GetComponentInChildren<TextMeshProUGUI>().text = 
            node.NextNode == null ? "Finish" : "Next";
        button.onClick.AddListener(() => HandleNextButton(node));

        buttons.Add(button);
    }

    private void CreateButton(ChoiceNode node)
    {
        var button = Instantiate(buttonPrefab);
        button.transform.SetParent(buttonsPanel.transform);
        button.GetComponentInChildren<TextMeshProUGUI>().text = node.Preview;
        button.onClick.AddListener(() => HandleChoiceButton(node));

        buttons.Add(button);
    }

    private void ClearButtons()
    {
        foreach (var button in buttons)
        {
            button.onClick.RemoveAllListeners();
            Destroy(button.gameObject);
        }

        buttons.Clear();
    }

    public void Visit(ChoiceDialogNode node)
    {
        ClearButtons();
        foreach (var choice in node.Choices)
        {
            CreateButton(choice);
        }
    }

    public void Visit(LinearDialogNode node)
    {
        ClearButtons();
        CreateButton(node);
    }

    private void HandleNextButton(LinearDialogNode node) => OnDialogButtonClick(node.NextNode);

    private void HandleChoiceButton(ChoiceNode choice) => OnDialogButtonClick(choice.NextNode);

    private void OnDialogButtonClick(DialogNode nextNode)
    {
        if (nextNode == null)
        {
            dialogChanel.RaiseDialogEnd();
        }
        else
        {
            dialogChanel.RaiseRequestNode(nextNode);
        }
    }
}
