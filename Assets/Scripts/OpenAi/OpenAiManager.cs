using UnityEngine;
using OpenAI;
using OpenAI.Chat;
using OpenAI.Models;
using OpenAI.Images;
using System.Collections.Generic;
using UnityEngine.Assertions;


public class OpenAiManager : MonoBehaviour
{



    void Start()
    {
        GetImage();
    }

    public async void GetModels()
    {
        var api = new OpenAIClient();
        var models = await api.ModelsEndpoint.GetModelsAsync();

        foreach (var model in models)
        {
            Debug.Log(model.ToString());
        }
    }


    public async void GetModelDetails()
    {
        var api = new OpenAIClient();
        var model = await api.ModelsEndpoint.GetModelDetailsAsync("gpt-4o");
        Debug.Log(model.ToString());
    }


    public async void GetChatAnswer()
    {
        var api = new OpenAIClient();
        var messages = new List<Message>
{
    new Message(Role.System, "You are a helpful assistant."),
    new Message(Role.User, "Who won the world series in 2020?"),

};
        var chatRequest = new ChatRequest(messages, Model.GPT3_5_Turbo);
        var response = await api.ChatEndpoint.GetCompletionAsync(chatRequest);
        var choice = response.FirstChoice;
        Debug.Log($"[{choice.Index}] {choice.Message.Role}: {choice.Message} | Finish Reason: {choice.FinishReason}");
    }

    public async void GetImage()
    {
        var api = new OpenAIClient();
        var request = new ImageGenerationRequest("A house riding a velociraptor", Model.DallE_3);
        var imageResults = await api.ImagesEndPoint.GenerateImageAsync(request);

        foreach (var result in imageResults)
        {
            Debug.Log(result.ToString());
            Assert.IsNotNull(result.Texture);
        }
    }
}