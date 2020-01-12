[System.Console]::WriteLine("---Start test performanta---")
# Deschidere site
$stepName = "1. Deschidere site"
Write-Output -InputObject $stepName 

for($i = 0; $i -lt 5; ++$i)
{
    $executioTime += Measure-Command { Invoke-RestMethod -Method Get -Uri https://localhost:44310/ -UseBasicParsing }
}

[System.Console]::WriteLine($stepName + " a durat " + $($executioTime.Seconds / 5) + " secunde - medie 5 iteratii"); Remove-Variable executioTime