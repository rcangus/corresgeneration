$JSON = @'
{"log_date_time": "2020-09-05T09:16:35.214Z",
 "log_level": 3,
 "server": "DEVIQ-SB02",
 "application_name": "TestApp2",
 "application_version": "1.0.3",
 "gs_schedule_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
 "jg_schedule_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
 "js_schedule_id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
 "batch_id": 12333,
 "exceptionMessage": "",
 "exceptionStackTracce": "",
 "message": "This is the message"
 }
'@

# $JSON = @'
# {"@type":"login",
#  "username":"xxx@gmail.com",
#  "password":"yyy"
# }
# '@
Write-Host "Start at : " (Get-Date).DateTime
for ($i = 0; $i -lt 100000; $i++) {
    $response = Invoke-RestMethod -Uri "http://localhost:9000/api/DCSLogger/LogMessage" -Method Post -Body $JSON -ContentType "application/json"  -DisableKeepAlive:$false
}
Write-Host "Finsihed - " (Get-Date).DateTime