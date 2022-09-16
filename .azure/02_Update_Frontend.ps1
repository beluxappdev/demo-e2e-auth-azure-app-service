$resourceGroup = "rg-demoTodoApi"
$frontendAppName = "demoTodoApi-frontend"
az webapp config appsettings set --name $frontendAppName --resource-group $resourceGroup --settings DEPLOYMENT_BRANCH=frontend