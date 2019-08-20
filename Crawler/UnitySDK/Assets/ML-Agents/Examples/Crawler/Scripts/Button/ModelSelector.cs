using UnityEngine;
using UnityEngine.UI;
using MLAgents;
using Barracuda;

public class ModelSelector : MonoBehaviour
{
    public LearningBrain brain;
    public Academy academy;
    public Agent targetAgent;
    public Button modelSelector;
    public Button badModelButton;
    public NNModel badModel;
    public Button fairModelButton;
    public NNModel fairModel;
    public Button goodModelButton;
    public NNModel goodModel;
    private bool showModel = false;
    public Text modelNameText;
    public Text rewardText;
    public Text stepsText;
    public Text episodeText;


    public void Start()
    {
        EnableModelSelectionButton(false);
        InvokeRepeating("OutputTime", 0f, .2f);  // no delay, repeat every 0.2s
        if (academy.IsCommunicatorOn())
        {
            modelSelector.interactable = false;
            modelNameText.text = "";
        }
        else
        {
            EnableModelSelectionButton(false);
            UpdateModel(badModel);
        }
    }

    public void ToggleSelectionMenu()
    {
        if (showModel)
        {
            EnableModelSelectionButton(false);
            showModel = false;
        }
        else
        {
            EnableModelSelectionButton(true);
            showModel = true;
        }
    }

    private void EnableModelSelectionButton(bool enabled)
    {
        badModelButton.gameObject.SetActive(enabled);
        fairModelButton.gameObject.SetActive(enabled);
        goodModelButton.gameObject.SetActive(enabled);
    }

    public void PrintModel()
    {
        print(brain.model);
    }

    public void LoadBadModel()
    {
        UpdateModel(badModel);
        ToggleSelectionMenu();
    }

    public void LoadFairModel()
    {
        UpdateModel(fairModel);
        ToggleSelectionMenu();
    }

    public void LoadGoodModell()
    {
        UpdateModel(goodModel);
        ToggleSelectionMenu();
    }

    private void UpdateModel(NNModel model)
    {
        brain.SetModel(model);
        brain.ReloadModel();
        modelNameText.text = model.ToString();
    }

    private void OutputTime()
    {
        rewardText.text = "Reward: " + targetAgent.GetReward();
        stepsText.text = "Steps: " + academy.GetStepCount();
        episodeText.text  = "Episode: " + academy.GetEpisodeCount();
    }
}
