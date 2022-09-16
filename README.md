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

## Contributing

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
  
