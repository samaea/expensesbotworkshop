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

      

