$resourceGroup = "rg-demoTodoApi"
$appPlan = "plan-demoTodoApi"
$frontendNgAppName = "demoTodoApi-frontendng"
az webapp create --resource-group $resourceGroup --plan $appPlan --name $frontendNgAppName --runtime "DOTNETCORE:6.0" --deployment-local-git --query deploymentLocalGitUrl
az webapp config appsettings set --name $frontendNgAppName --resource-group $resourceGroup --settings DEPLOYMENT_BRANCH=frontendng