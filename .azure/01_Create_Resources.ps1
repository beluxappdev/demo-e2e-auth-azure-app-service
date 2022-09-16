$resourceGroup = "rg-demoTodoApi"
$appPlan = "plan-demoTodoApi"
$frontendAppName = "demoTodoApi-frontend"
$backendAppName = "demoTodoApi-backend"
$location = "centralus"
az group create --name $resourceGroup --location $location
az appservice plan create --name $appPlan --resource-group $resourceGroup --sku B1 --is-linux
az webapp create --resource-group $resourceGroup --plan $appPlan --name $frontendAppName --runtime "DOTNETCORE:6.0" --deployment-local-git --query deploymentLocalGitUrl
az webapp create --resource-group $resourceGroup --plan $appPlan --name $backendAppName --runtime "DOTNETCORE:6.0" --deployment-local-git --query deploymentLocalGitUrl
az webapp config appsettings set --name $frontendAppName --resource-group $resourceGroup --settings DEPLOYMENT_BRANCH=main
az webapp config appsettings set --name $backendAppName --resource-group $resourceGroup --settings DEPLOYMENT_BRANCH=main