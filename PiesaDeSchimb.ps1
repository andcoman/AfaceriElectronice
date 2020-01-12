[System.Console]::WriteLine("---Start test performanta---")
# Deschidere site
$stepName = "1. Deschidere site"
Write-Output -InputObject $stepName 

for($i = 0; $i -lt 5; ++$i)
{
    $executioTime += Measure-Command { Invoke-RestMethod -Method Get -Uri https://piesadeschimb20200112022454.azurewebsites.net/ -UseBasicParsing }
}

[System.Console]::WriteLine($stepName + " a durat " + $($executioTime.TotalMilliseconds / 5) + " milisecunde - medie 5 iteratii"); Remove-Variable executioTime

$stepName = "2. Vizualizare produs"
Write-Output -InputObject $stepName 

for($i = 0; $i -lt 5; ++$i)
{
    $executioTime += Measure-Command { Invoke-RestMethod -Method Get -Uri https://piesadeschimb20200112022454.azurewebsites.net/Product/Details/5e10cd3ca5f6d05a68d533e1 -UseBasicParsing }
}

[System.Console]::WriteLine($stepName + " a durat " + $($executioTime.TotalMilliseconds / 5) + " millisecunde - medie 5 iteratii"); Remove-Variable executioTime

$stepName = "3. Creare produs"
Write-Output -InputObject $stepName 

for($i = 0; $i -lt 5; ++$i)
{
    $executioTime += Measure-Command { Invoke-RestMethod -Method Post -Uri https://piesadeschimb20200112022454.azurewebsites.net/Product/Create -UseBasicParsing }
}

[System.Console]::WriteLine($stepName + " a durat " + $($executioTime.TotalMilliseconds / 5) + " milisecunde - medie 5 iteratii"); Remove-Variable executioTime
