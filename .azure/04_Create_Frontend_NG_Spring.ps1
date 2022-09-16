$resourceGroup = "rg-demoTodoApi"
$appPlan = "plan-demoTodoApi"
$frontendNgSpringAppName = "demoTodoApi-frontendngspring"
az webapp create --resource-group $resourceGroup --plan $appPlan --name $frontendNgSpringAppName --runtime "DOTNETCORE:6.0" --deployment-local-git --query deploymentLocalGitUrl
az webapp config appsettings set --name $frontendNgSpringAppName --resource-group $resourceGroup --settings DEPLOYMENT_BRANCH=frontendngspring