#### Register the service app (WebFormsADAuth)

1. Navigate to the Microsoft identity platform for developers [App registrations](https://go.microsoft.com/fwlink/?linkid=2083908) page.
1. Select **New registration**.
1. When the **Register an application page** appears, enter your application's registration information:
   - In the **Name** section, enter a meaningful application name that will be displayed to users of the app, for example `WebFormsADAuth`.
   - Change **Supported account types** to **Accounts in any organizational directory and personal Microsoft accounts (e.g. Skype, Xbox, Outlook.com)**.
   - In the Redirect URI (optional) section, select **Web** in the combo-box and enter the following redirect URIs: `https://localhost:44326/Account/Profile`.
1. Select **Register** to create the application.
1. On the app **Overview** page, find the **Application (client) ID** value and record it for later. You'll need it to configure the Visual Studio configuration file for this project.
1. Select **Save**.
1. From the **Certificates & secrets** page, in the **Client secrets** section, choose **New client secret**:

   - Type a key description (of instance `app secret`),
   - Select a key duration of either **In 1 year**, **In 2 years**, or **Never Expires**.
   - When you press the **Add** button, the key value will be displayed, copy, and save the value in a safe location.
   - You'll need this key later to configure the project in Visual Studio. This key value will not be displayed again, nor retrievable by any other means,
     so record it as soon as it is visible from the Azure portal.
1. Select the **API permissions** section
   - Click the **Add a permission** button and then,
   - Ensure that the **Microsoft APIs** tab is selected
   - In the *Commonly used Microsoft APIs* section, click on **Microsoft Graph**
   - In the **Delegated permissions** section, ensure that the right permissions are checked: **openid**, **profile**, **User.Read**. Use the search box if necessary.
   - Select the **Add permissions** button

#### Configure the project

> Note: if you used the setup scripts, the changes below will have been applied for you

1. Open the solution in Visual Studio.
1. Open the `web.config` file.
1. Find the app key `ida:ClientId` and replace the existing value with the application ID (clientId) of the `WebFormsADAuth` application copied from the Azure portal.
1. Find the app key `ida:ClientSecret` and replace the existing value with the key you saved during the creation of the `WebFormsADAuth` app, in the Azure portal.
1. Find the TenantID `ida:TenantId` and Domain `ida:Domain` and replace the existing value with the Tenant ID(directoryid), AD Domain of the `WebFormsADAuth` application copied from the Azure portal.

### Step 5:  Run the sample

Clean the solution, rebuild the solution, and run it.
