using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AgentsMenuData : MonoBehaviour
{
    [SerializeField] Agents agents =null;
    [SerializeField] Transform scrollViewTransform = null;
    [SerializeField] IconAgentButton toSpawn = null;
    [SerializeField] List<IconAgentButton> allButtonAgent = null;

    [SerializeField] RawImage background;
    [SerializeField] RawImage pictureAgent;
    [SerializeField] TextMeshProUGUI agentName;
    [SerializeField] GameObject infoAgentPanel;
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        DataFetcher.OnAgentsDataReceived += UpdateAgentsList;
        StartCoroutine(DataFetcher.GetAgentsData());
    }

    void  UpdateAgentsList(Agents _agents)
    {
        if (_agents == null || _agents.Data == null || _agents.Data.Count <= 0)
        {
            //Debug.LogError("Error : Agents is null or Agents.Data is null or empty");
        }
        agents = _agents;
        UpdateScrollViewAgents();
    }

    void UpdateScrollViewAgents()
    {
        RectTransform _viewport = scrollViewTransform.parent.GetComponent<RectTransform>();
        float _iconSize = _viewport.rect.height;

        foreach (Agent _agent in agents.Data)
        {
            if (!_agent.IsPlayableCharacter)
                continue;
            IconAgentButton _button = Instantiate(toSpawn, scrollViewTransform);

            RectTransform _rectTransfomr = _button.GetComponent<RectTransform>();
            _rectTransfomr.sizeDelta = new Vector2(_iconSize, _iconSize);

            if (_agent.DisplayIcon== null)
            {
                //Debug.Log($"DisplayName {_agent.DisplayName} DisplayIcon is null");
                return;
            }
            _button.Agent = _agent;
            allButtonAgent.Add(_button);
        }
        InitButtonAgents();
    }

    void InitButtonAgents()
    {
        int _size = allButtonAgent.Count;
        for (int i = 0; i < _size; i++)
        {
            allButtonAgent[i].InitPicture();
            allButtonAgent[i].BackgroundToSet = background;
            allButtonAgent[i].PictureAgentToSet = pictureAgent;
            allButtonAgent[i].AgentNameToSet = agentName;
            allButtonAgent[i].BackGroundColor = GetComponent<Image>();
            allButtonAgent[i].infoAgentPanel = infoAgentPanel;
        }
    }

}
