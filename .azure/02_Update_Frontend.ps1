$resourceGroup = "rg-demoTodoApi"
$appPlan = "plan-demoTodoApi"
$frontendAppName = "demoTodoApi-frontend"
az webapp delete --resource-group $resourceGroup --name $frontendAppName
az webapp create --resource-group $resourceGroup --plan $appPlan --name $frontendAppName --runtime "DOTNETCORE:6.0" --deployment-local-git --query deploymentLocalGitUrl
az webapp config appsettings set --name $frontendAppName --resource-group $resourceGroup --settings DEPLOYMENT_BRANCH=frontend