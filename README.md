---
languages:
- csharp
- aspx-csharp
page_type: sample
description: "This is a sample application that you can use to follow along with the Run a RESTful API with CORS in Azure App Service tutorial."
products:
- azure
- aspnet-core
- azure-app-service
---

# ASP.NET Core API sample for Azure App Service

This is a sample application that you can use to follow along with the tutorial at [Tutorial: Authenticate and authorize users end-to-end in Azure App Service](https://docs.microsoft.com/en-us/azure/app-service/tutorial-auth-aad?pivots=platform-windows).

## License

See [LICENSE](https://github.com/Azure-Samples/dotnet-core-api/blob/master/LICENSE.md).

## Setup
The setup of the front-end and backend can be done using the PowerShell script _01_Create_Resource.ps1_. This script will create the following resources:
- A resource group in the chosen location
- An App Service Plan in the resource group with SKU Name: B1 and SKU Tier: Basic and Linux OS
- A front-end Web App in the resource group and App Service Plan created above. This front-end Web App is configured to use the main branch in the first step of the tutorial
- A back-end Web App in the resource group and App Service Plan created above. This back-end Web App is configured to use the main branch
>**Note**
>
>Update the name and the location of the resource group, the name of the App Service Plan, the name of the Web Apps to be unique.

## Call backend API from front-end
The first modification of the [tutorial](https://docs.microsoft.com/en-us/azure/app-service/tutorial-auth-aad?pivots=platform-windows#call-back-end-api-from-front-end) is to modify the .Net code of the frontend to call the backend, to add the authentication and [call the API securely from browser code](https://docs.microsoft.com/en-us/azure/app-service/tutorial-auth-aad?pivots=platform-windows#call-api-securely-from-browser-code).

The result of this step is available in the branch _frontend_. To deploy it, you need to run the script of this branch _02_Update_Frontend.ps1_.

>**Note**
>* Update the name in the script to match the name of the front-end Web App and the resource group created in the previous step.
>* In _TodoController.cs_, the attribute __remoteUrl_ needs to be updated with the URL of the back-end Web App.

Then you can push the frontend code of the front-end remote repository using:
```
git checkout frontend
git push frontend frontend
```

## Call backend API from browser code
The second modification of the [tutorial](https://docs.microsoft.com/en-us/azure/app-service/tutorial-auth-aad?pivots=platform-windows#call-api-securely-from-browser-code) is to update the Angular front-end to call the backend API from browser code. It retrieves the token and set it in the service.

The result of this step is available in the branch _frontendng_. To deploy it, you need to run the script of this branch _03_Update_Frontend_NG.ps1_.

>**Note**
>* Update the name in the script to match the name of the front-end-ng Web App and the resource group created in the previous step.
>* In _index.html_, updae the URL of the back-end Web App (_apiEndpoint_) to your backend URL.

Then you can push the frontendng code of the front-end-ng remote repository using:
```
git remote add frontendng <your-front-end-ng-git-repository>
git checkout frontendng
git push frontendng frontendng
```

Go back to the previous steps of the tutorial to setup the authorization for front-end-ng the same way it was done for front-end. Do not forget to enable CORS for front-end-ng.

## Use Spring Boot as backend
The backend is available here: https://github.com/beluxappdev/demo-e2e-auth-azure-app-service-spring. You deploy the backend and add the authorization the same way it is done for _Call backend API from browser code_.

The front-end adapted to Spring backend is available in branch _frontendngspring_. The main differences are the endpoint URL and the name of the variable in the POST request of the UI controller.

For the rest, authentication and CORS is setup in the same way as with the ASP.NET Core backend.

## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
