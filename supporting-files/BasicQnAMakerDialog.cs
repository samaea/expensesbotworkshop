using System;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using System.Configuration;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Azure;

namespace Microsoft.Bot.Sample.LuisBot
{
    [Serializable]
    public class BasicQnAMakerDialog : QnAMakerDialog
    {
        // Go to https://qnamaker.ai and feed data, train & publish your QnA Knowledgebase.
        // Parameters to QnAMakerService are:
        // Required: qnaAuthKey, knowledgebaseId, endpointHostName
        // Optional: defaultMessage, scoreThreshold[Range 0.0 – 1.0]
        public BasicQnAMakerDialog() : base(new QnAMakerService(new QnAMakerAttribute(ConfigurationManager.AppSettings["QnAAuthKey"], ConfigurationManager.AppSettings["QnAKnowledgebaseId"], "No good match in FAQ.", 0.5, 1, ConfigurationManager.AppSettings["QnAEndpointHostName"])))
        { }

    }
}




