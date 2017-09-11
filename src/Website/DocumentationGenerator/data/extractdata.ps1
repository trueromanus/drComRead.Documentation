# *********************************************
# 
# Extract documention data and
# transform it in website-ready pages
# version 1.0.2
# 
# Copyright (c) 2017 RomanAsylum
# 
# *********************************************

Write-Host "Extract documention data version 1.0.2"

Write-Host "Cloning repository....."

& git clone https://github.com/trueromanus/drComRead.Documentation.git
if ($LASTEXITCODE -ne 0) {
    Write-Host "Error while running clone command"
    exit 1
}

Write-Host "Completed"

Write-Host "Moving data....."

Copy-Item -Path (Join-Path $PSScriptRoot "drComRead.Documentation\src\UWP\ru-ru\*")  -Destination $PSScriptRoot -Recurse -Force

Write-Host "Completed"

Write-Host "Clear data....."

Remove-Item -Recurse -Force (Join-Path $PSScriptRoot  "drComRead.Documentation")

Write-Host "Completed"