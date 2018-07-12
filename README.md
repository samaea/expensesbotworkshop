# Expenses Bot Workshop
Expenses Bot Workshop demonstrates how you can use the Bot Framework with LUIS (Language Understanding)[1] to understand the intent of the user, which falls back to QnAMaker[2] (knowledge base consisting of a pair of questions and answers) when LUIS does not understand the intent. The workshop is trained using one intent "NewExpense", where the user can upload a receipt and extract the Merchant Name and Price with the help of Azure Computer Vision (OCR) API[3].</br></br>
\[1\] https://www.luis.ai  
\[2\] https://www.qnamaker.ai  
\[3\] https://azure.microsoft.com/en-gb/services/cognitive-services/computer-vision/  
</br>

## Before you start...
Please use this link "OFFICIAL LAB SET UP LINK HAS TO BE PASTED" to set up your lab environment and get your Demo Lab credentials you will use throughout the workshop.

![On demand lab](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/ondemandlab.png)


## User Guide  
This guide will help you step by step to perform the tasks that are necessary to implement your Chatbot.  


### 1. Create a Bot Service Resource  

 Navigate to the website www.portal.azure.com and log in with your Demo Lab credentials. On the start screen, in the left upper corner, you find the button “Create a resource” (as shown in the screenshot below).  

 ![Create a resource](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/1_create%20a%20resource.png)  

 After clicking on that icon, enter in the search field: <b>“bot service”</b> and select the resource <b>“Web App Bot”</b>.  

 ![Search for bot](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/2_search%20for%20bot.png)  

 The bot wizard window will pop up and to continue, press <b>“Create”</b>
 ![Create bot img1](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/5_1_Create%20Bot%20Wizard.png)  

 In the next step, the wizard will give you fields you need to fill out with some information:
 *	<b>Bot name</b>: Enter a unique bot name. For example “ContosoExpenses + ‘your alias’”  
     * Note: The name must be globally unique, therefore add your alias.
 *	<b>Resource Group</b>: Use <b>existing resource group</b> and select the resource group that will be proposed in the drop-down bar
 *	<b>Location</b>: select <b>Central US</b>
 *	<b>Pricing Tier</b>: <b>S1</b>
 * <b>App Name</b>: This should automatically be populated based on the Bot name you entered already: “ContosoExpenses-‘youralias’”
 *	Click on the Bot template which will open the selection of available templates. Use the <b>“Language understanding”</b> template and <b>make sure to have selected the SDKv3 and C#</b> modules at the top. Finally, click <b>Select</b> before clicking <b>Create</b>, otherwise the bot template will not be selected.
 *	<b>LUIS App location</b>: West US (default)
 *	<b>Leave App service plan/Location as is</b>
 *	Create <b>a New Azure Storage</b> leaving the name as it is automatically entered
 *	<b>Application Insights Location</b>: default (East US)
 *	<b>Leave Microsoft App ID and password as is</b>
 *	Check the box “I confirm I have read….”

 ![Create bot img2](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/5_2_Create%20Bot%20Wizard.png)

 Then, click on <b>“Create”</b> for starting the deployment process of your bot service. A notification on the top bar, as the screenshot shows, will inform you about the progress:  

 ![Create bot Deployment](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/6_Deployment.png)  

 After the resource is deployed, you will get a green checkmark. Click on: “Go to resource”:  

 ![Go to resource](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/7_Go%20to%20resource.png)  



### 2. Test your Bot Service

 In your resource on the left panel, scroll to <b>“Test in Web Chat”</b> to test if your bot is running and type “Hello”. The bot will respond with “You have reached Greeting. You said: Hello”. This confirms that the bot has received your message and passed it to a default LUIS app. This LUIS app detected the default “Greeting” intent.  

 ![Webchat](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/8_Webchat.png)  



 ### 3. View and modify your bot’s code using App Service Editor
 
 In the left pane, under Development Tools, click on All App service settings to open the App Service Editor (Preview).
 
  ![App Service](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/9_allappservice.png)  
  
  Next, click on the “Go” button to start the editor. A new tap will open.  
  
   ![App Service Editor](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/9_allappserviceeditor.png)
   
 The Editor will open the LUIS C# template that you selected when creating the bot service. This shows all your source code files for your newly created bot.
 On the left pane, look for <b>“Dialogs”</b> and open the <b>BasicLuisDialog.cs tab</b>. You will see the default code with the LUIS intents “None”, “Greeting”, “Cancel” and “Help”. Each one points to “this.ShowLuisResult” which will output the intent along with the utterance said. 
When performing a change to the source code, <b>it is important to right-click on the tab “build.cmd” on the left pane and run it to compile and transform it to executable code</b>. If not, your changes will not be reflected in the chatbot conversation.


![App Service Editor](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/10_appserviceeditor.png)  
   
Now that you have explored the code, <b>right-click on “build.cmd” under Properties and click “Run from console”</b>. You should receive the following message, stating a successful run:  

![App Service Editor - Build](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/10-3_appserviceeditor.png)

 ### 4.	Use LUIS to train intents
 
 To explore the preconfigured default intents and utterances, switch to the LUIS dashboard. (<b>NOTE: Leave the tab you just used open, you will need it later</b>):

1. Open a new web browser tab and navigate to https://www.luis.ai
1. Click on Sign In and log in with your Azure credentials (same as for the Azure Portal in the first step)  

    ![LUIS Login on homepage](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/luis_0_login.png)

1.	Click <b>“My Apps”</b> and find your (on the Azure portal created) <b>bot service “ContosoExpenses-“youralias”</b>:

    ![LUIS Apps](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/luis_2-1_intents.PNG)  
    
1.	You should now see all the preconfigured intents, which match the intents stated in the App Code Editor under the “BasicLuisDialog.cs” tab. Feel free to click on the intents and those along with the utterances associated with each intent. The utterances are sample sentences/questions that train LUIS to understand how to map sentences (utterances) to a specific intent.  

    ![LUIS Intents](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/luis_3_intents.PNG)  
    
 1.	In the next step we will create a new intent: <b>click on “Create a new intent”</b>
 
     ![LUIS Create a new intent](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/luis_4_intents.png)  
     
 1. <b>Name it “NewExpense”</b>
     * </b>Note</b>: It is important to spell it correctly (case-sensitive), otherwise the code you will copy later may not work.  
     
     ![LUIS Create a new intent](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/luis_5_intents.png)  
     
 1.	<b>Add the two example sentences</b> (utterances) to help LUIS understand the user intent to add a “NewExpense”:
     * “create an expense”
     * “add a new expense”  

     ![LUIS Create utterances](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/luis_6_utterance.png)  
     
 1.	We will now train the “None” intent to help LUIS better identify which user questions/sentences it cannot understand. <b>Click on intents</b> in the left pane and <b>navigate to the “None” intent</b>.
 
      ![LUIS None Intent](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/luis_7_None.png)
      
 1.	<b>Add the following 7 utterances</b> to the “None” intent:
     * “how to apply for a corporate amex card?”
     * “i have issues with my expense report”
     * “when do i submit an expense report?”
     * “i do not understand the different expense report statuses”
     * 	“missing expense category”
     * “what are unreconciled expenses in expenses?”
     * “do you have recommendations, tips and tricks for expenses?”  
     
 1. <b>Click on “Train”</b> (right upper corner) to train your LUIS based on the utterances you have provided  
     
      ![LUIS None Utterances](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/luis_8_None-utterances.png)  
      
      ![LUIS None Utterances](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/luis_9_train.png)  
      
      You will receive a notification when the training is successfully performed. You will now configure your bot in order to reflect the new “NewExpense” intent that you just trained.

      Now that you have trained LUIS based on the utterances, you will need to publish it in order for the changes to be reflective when you call LUIS from the bot.

 1. Click on <b>Publish</b>, and once the Publish page finishes loading, click on the <b>"Publish"</b> button.
 
      ![LUIS Publish](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/luis_10_publish.png)  
      ![LUIS Publish](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/luis_11_publish.png)  
      ![LUIS Publish](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/luis_12_publish.png)  
      
 1. Click on the previous tab you were in (Azure Portal), with the “App Service Editor” opened. Copy the code that uses one of the Azure Cognitive Services called Computer Vision API into the “Basic.Luis.Dialog.cs” tab. This will allow you to read characters off an image:
      1. Delete all the code statements that start with “using” listed at the beginning lines (1-7) and replace with the following:
            ```csharp
            using System;
            using System.Configuration;
            using System.Threading.Tasks;
            using Microsoft.Bot.Builder.Dialogs;
            using Microsoft.Bot.Builder.Luis;
            using Microsoft.Bot.Builder.Luis.Models;

            using Microsoft.Bot.Connector;
            using System.Net.Http;
            using System.IO;
            using System.Net;
            using System.Text;
            using Newtonsoft.Json;
            using System.Collections.Generic;
            using System.Linq;
            using System.Threading;
            ```  

            <b>It should now look like this:</b>  
            
            ![App Editor Using statements](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/10-1_appserviceeditor.png)  
            
      1. Within the code, find the following statement:  
            ```csharp
            public class BasicLuisDialog : LuisDialog<object>
                {
            ```  
            
            And add directly in the next line underneath:  
            
            ```csharp
            List<String> ocrList;
            List<decimal> foundNumList;
            decimal userSelectedPrice;
            string userSelectedMerchantName;
            string urlOfUploadedImg;
            ```  
      
          ![App Editor Global Variables](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/10-2_appserviceeditor.png)
          
      1. Stay in the same code and look for this statement:  
            ```csharp
            private async Task ShowLuisResult(IDialogContext context, LuisResult result) 
            {
                await context.PostAsync($"You have reached {result.Intents[0].Intent}. You said: {result.Query}");
                context.Wait(MessageReceived);
            }
            ```  
            
            And add underneath it:  
            
            ```csharp
            [LuisIntent("NewExpense")]
                    public async Task NewExpenseIntent(IDialogContext context, LuisResult result)
                    {

                        // Ask the user to uploads an attachment
                        PromptDialog.Attachment(
                               context: context,
                               resume: ResumeAfterExpenseUpload,
                               prompt: "I see you are trying to add an expense. Please upload a picture of your expense and I will try to perform character recognition (OCR) on it.",
                               retry: "Sorry, I didn't understand that. Please try again."
                           );





                    }

                    private async Task ResumeAfterExpenseUpload(IDialogContext context, IAwaitable<IEnumerable<Attachment>> result)
                    {
                        var attachment = await result as IEnumerable<Attachment>;
                        var attachmentList = attachment.GetEnumerator();
                        if (attachmentList.MoveNext())
                        {
                            string tempStorage = Path.GetTempPath() + attachmentList.Current.Name;
                            urlOfUploadedImg = attachmentList.Current.ContentUrl;

                            // Create a request using a URL that can receive a post.   
                            WebRequest request = WebRequest.Create("https://westeurope.api.cognitive.microsoft.com/vision/v2.0/recognizeText?mode=Printed");
                            // Set the Method property of the request to POST.  
                            request.Method = "POST";
                            string postData = "{\"url\":\""+urlOfUploadedImg+"\"}";
                            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                            // Set the ContentType property of the WebRequest.  
                            request.ContentType = "application/json";
                            request.Headers.Add("Ocp-Apim-Subscription-Key", "127766f23d2640af84d85e25f1d49b85");
                            // Set the ContentLength property of the WebRequest.  
                            request.ContentLength = byteArray.Length;
                            // Get the request stream.  
                            Stream dataStream = request.GetRequestStream();
                            // Write the data to the request stream.  
                            dataStream.Write(byteArray, 0, byteArray.Length);
                            // Close the Stream object.  
                            dataStream.Close();
                            // Get the response.  
                            WebResponse response = request.GetResponse();
                            // Display the status.  
                            //Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                            // Get the stream containing content returned by the server.  
                            dataStream = response.GetResponseStream();
                            string header;
                            bool foundOCRResult = false;
                            StreamReader reader = new StreamReader(dataStream);
                            dynamic jsonObject;
                            string responseFromServer = "";
                            header = response.Headers["Operation-Location"];
                            while (!foundOCRResult) {
                                await Task.Delay(3000);
                                request = WebRequest.Create(header);
                                request.Headers.Add("Ocp-Apim-Subscription-Key", "127766f23d2640af84d85e25f1d49b85");
                                response = request.GetResponse();
                                dataStream = response.GetResponseStream();
                                // Open the stream using a StreamReader for easy access.  
                                reader = new StreamReader(dataStream);
                                // Read the content.  
                                // Get the request stream.  


                                // Close the Stream object.  

                                responseFromServer = reader.ReadToEnd();
                                dataStream.Close();
                                jsonObject = JsonConvert.DeserializeObject(responseFromServer);
                                string status = jsonObject.status;
                                if (status == "Failed")
                                {

                                    await context.PostAsync("OCR failed response when attempting to use Operation-Location header to obtain results.");
                                    return;
                                }else if (status == "Succeeded")
                                {

                                    foundOCRResult = true;
                                }
                            }

                            reader.Close();
                            response.Headers.Keys.Get(1);
                            WebHeaderCollection headers = response.Headers;

                            dataStream.Close();
                            response.Close();

                            //response.Headers;

                            jsonObject = JsonConvert.DeserializeObject(responseFromServer);

                            ocrList = new List<String>();
                            foundNumList = new List<decimal>();


                            foreach (dynamic line in jsonObject.recognitionResult.lines)
                            {
                                string lineStr = line.text.ToString();

                                //Console.WriteLine(lineStr);
                                ocrList.Add(lineStr);




                            }

                            ocrList.Reverse();

                            int j = 1; // counter for how many times it found a number (execution will stop when it has found three numbers)
                            int k = 1; // counter for how many iterations it performed to find at least three numbers
                            decimal foundNum;
                            char[] foundChars;
                            bool breakLoop = false;

                            for (int i = 0; i < ocrList.Count - 1 && !breakLoop; i++)
                            {


                                if (ocrList[i].ToLower().Contains("total") || ocrList[i].ToLower().Contains("amount") && ocrList[i].ToLower().Contains("total"))
                                {
                                    while (j < 3 && ocrList.Count > i + k)
                                    {
                                        int searchIndex = i - k;
                                        if (searchIndex < 0)
                                        {
                                            breakLoop = true;
                                            break;

                                        }
                                        foundChars = ocrList[searchIndex].Where(Char.IsDigit).ToArray();
                                        string foundStr = "";
                                        if (foundChars.Count() != 0)
                                        {
                                            foreach (char c in foundChars)
                                            {
                                                foundStr = foundStr + c;
                                            }

                                            foundStr = foundStr.Insert(foundStr.Count() - 2, ".");

                                            if (decimal.TryParse(foundStr, out foundNum))
                                            {
                                                foundNumList.Add(foundNum);
                                                j++;
                                            }
                                        }
                                        k++;

                                    }
                                    j = 1;
                                    k = 1;

                                }


                            }

                            userSelectedMerchantName = ocrList[ocrList.Count - 1];
                           await context.PostAsync("Based on OCR, I have detected " + userSelectedMerchantName + " to be the Merchant Name.");



                            HeroCard card = new HeroCard { Text = "Is that correct? If not, please type in the merchant name.", Buttons = new List<CardAction> { new CardAction(ActionTypes.ImBack, title: "Yes", value: "Yes") } };
                            var message = context.MakeMessage();
                            message.Attachments.Add(card.ToAttachment());
                            await context.PostAsync(message);

                            context.Wait(ResumeAfterMerchantName);






                        }
                        else
                        {
                            await context.PostAsync("Sorry, no attachments found!");
                            return;
                        }




                    }

            private async Task ResumeAfterMerchantName(IDialogContext context, IAwaitable<object> result)
                    {
                        var activity = await result as Activity;

                        if (activity.Text.ToLower().Contains("yes"))
                        {


                        }
                        else
                        {
                            userSelectedMerchantName = activity.Text;
                        }

                        List<CardAction> listofCards = new List<CardAction>();
                        listofCards.Add(new CardAction(ActionTypes.ImBack, title: "Yes", value: "Yes"));
                        foreach (decimal foundNum in foundNumList)
                        {

                            listofCards.Add(new CardAction(ActionTypes.ImBack, title: foundNum.ToString(), value: foundNum.ToString()));
                        }


                        userSelectedPrice = foundNumList.FirstOrDefault();
                        HeroCard card = new HeroCard { Title = "Numbers found on the expense", Text = "Is the total **" + userSelectedPrice + "**? If not, feel free to select from the other numbers I have found above, or just type it in!", Buttons = listofCards };

                        var message = context.MakeMessage();
                        message.Attachments.Add(card.ToAttachment());
                        await context.PostAsync(message);

                        context.Wait(ResumeAfterPrice);

                    }

                    private async Task ResumeAfterPrice(IDialogContext context, IAwaitable<object> result)
                    {
                        var activity = await result as Activity;

                        if (activity.Text.ToLower().Contains("yes"))
                        {
                            await ResumeAfterReceipt(context, result);

                        }
                        else
                        {

                            decimal n;
                            if(decimal.TryParse(activity.Text, out n))
                            {
                                userSelectedPrice = n;
                                await ResumeAfterReceipt(context, result);
                            }
                            else
                            {
                                await context.PostAsync("Sorry, but your input does not appear to be a number. Please try again.");
                                context.Wait(ResumeAfterPrice);
                            }
                        }


                    }

                    private async Task ResumeAfterReceipt(IDialogContext context, IAwaitable<object> result)
                    {

                        var thumbnailCard = new ThumbnailCard
                        {
                            // title of the card  
                            Title = "Your expense",
                            //subtitle of the card  
                            Subtitle = "Company Name: **"+userSelectedMerchantName+"**",

                            //Detail Text  
                            Text = "Total: " + userSelectedPrice,
                            // smallThumbnailCard  Image  
                            Images = new List<CardImage> { new CardImage(urlOfUploadedImg) },
                        };
                        var message = context.MakeMessage();
                        message.Attachments.Add(thumbnailCard.ToAttachment());
                        await context.PostAsync(message);
                        await context.PostAsync("Your expense has been saved! Is there anything else I can help you with?");
                        context.Done("");
                        //return thumbnailCard.ToAttachment();


                    }
            ```  
      1. In order to reflect your new changes, <b>right-click in the panel on the left on “build.cmd”</b> which is found under “Properties” and <b>click “Run from console”</b>. You should receive the following success message:

      ![App Editor Using statements](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/10-3_appserviceeditor.png)  
      
      
 ### 5.	Test your Chatbot  
 
 Switch back to the Azure Portal you have still opened in another Tab or open a new one navigating to https://portal.azure.com  
 
 1.	On your left, <b>click on “Resource Groups”</b> and <b>select the resource group that hosts your bot</b> (you should only see one resource group). Click on your Web App Bot Service <b>(“ContosoExpenses-‘youralias’”)</b> and find on the panel that will <b>open on your left “Test in Web Chat”</b>  
 
 ![Azure Portal Resource Groups](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/10-4_azurerg.png)  
 ![Azure Portal Bot Web App](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/10-5_botservice.png)  
 ![Azure Portal Test Bot](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/10-6_botservicetest.png)  
 
 1.  <b>Test the bot</b> by starting a chat with <b>the input “I would like to create an expense”</b>. You should be prompted to upload an image. Click on the small image icon next to the message input field to upload a sample image provided at:- https://github.com/samaea/expensesbotworkshop/tree/master/receipts.  
 
  ![Azure Portal Test Bot Upload Receipt](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/10-7_botserviceuploadimg.png)  
  ![Azure Portal Test Bot OCR Merchant Name](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/10-8_botserviceuploadimg.png)  
  
  The bot will use optical character recognition to identify information of the receipt image. It will provide you with the numbers it found and ask you to confirm or change the total number of the purchase:
  
  ![Azure Portal Test Bot OCR Prices](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/10-9_botserviceuploadimg.png)  
