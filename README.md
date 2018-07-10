# Expenses Bot Workshop
Expenses Bot Workshop demonstrates how you can use the Bot Framework with LUIS (Language Understanding)[1] to understand the intent of the user, which falls back to QnAMaker[2] (knowledge base consisting of a pair of questions and answers) when LUIS does not understand the intent. The workshop is trained using one intent "NewExpense", where the user can upload a receipt and extract the Merchant Name and Price with the help of Azure Computer Vision (OCR) API[3].</br></br>
\[1\] https://www.luis.ai  
\[2\] https://www.qnamaker.ai  
\[3\] https://azure.microsoft.com/en-gb/services/cognitive-services/computer-vision/  
</br>

## User Guide  
This guide will help you step by step to perform the tasks that are necessary to implement your Chatbot.  

### 1. Create a Bot Service Resource  

 Navigate to the website www.portal.azure.com and log in with your Microsoft AD credentials. On the start screen, in the left upper corner, you find the button “Create a resource” (as shown in the screenshot below).  

 ![Create a resource](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/1_create%20a%20resource.png)  

 After clicking on that icon, enter in the search field: <b>“bot service”</b> and select the resource <b>“Web App Bot”</b>.  

 ![Search for bot](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/2_search%20for%20bot.png)  

 The bot wizard window will pop up and to continue, press <b>“Create”</b>

 ![Create bot img1](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/5_1_Create%20Bot%20Wizard.png)  

 In the next step, the wizard will give you fields you need to fill out with some information:
 *	<b>Bot name</b>: Enter a unique bot name. For example “ContosoExpenses + ‘your alias’”  
     * Note: The name must be globally unique, therefore adding your alias.
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


### 2. Test you Bot Service

 In your resource on the left panel, scroll to <b>“Test in Web Chat”</b> to test if your bot is running and type “Hello”. The bot will respond with “You have reached Greeting. You said: Hello”. This confirms that the bot has received your message and passed it to a default LUIS app. This LUIS app detected the default “Greeting” intent.  

 ![Webchat](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/8_Webchat.png)  
 
 ### 3. View and Modify your bot’s code using App Service Editor
 
 In the left pane, under Development Tools, click on All App service settings to open the App Service Editor (Preview).
 
  ![App Service](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/9_allappservice.png)  
  
  Next, click on the “Go” button to start the editor. A new tap will open.  
  
   ![App Service Editor](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/9_allappserviceeditor.png)
   
 The Editor will open the LUIS C# template that you selected when creating the bot service. This shows all your source code files for your newly created bot.
 On the left pane, look for <b>“Dialogs”</b> and open the <b>BasicLuisDialog.cs tab</b>. You will see the default code with the LUIS intents “None”, “Greeting”, “Cancel” and “Help”. Each one points to “this.ShowLuisResult” which will output the intent along with the utterance said. 
When performing a change to the source code, <b>it is important to right-click on the tab “build.cmd” on the left pane and run it to compile and transform it to executable code</b>. If not, your changes will not be reflected in the chatbot conversation.


   ![App Service Editor](https://raw.githubusercontent.com/samaea/expensesbotworkshop/master/images/10_appserviceeditor.png)

   
