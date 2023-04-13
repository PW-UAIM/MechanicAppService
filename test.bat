echo off
set url=http://localhost:5010

CALL:curl_test "Poprawne logowanie" GET /mechanic/1/login 

CALL:curl_test "Niepoprawne logowanie" GET /mechanic/2000/login

CALL:curl_test "Zakoñcz wizytê" POST /visit/1/update^
	-d '{^
		"ServiceStatus": "Naprawiono"^
	}'^

CALL:curl_test "Wizyty mechanika o ID 1" GET /visit/mechanic/1

CALL:curl_test "Wizyty mechanika o ID 1 w dniu 01.01.2023" GET /visit/mechanic/1/date/2023/1/1

CALL:curl_test "Wszystkie auta" GET /car/all

CALL:curl_test "Dane auta nr 1" GET /car/1

CALL:curl_test "Dane wizyty nr 1" GET /visit/1

:curl_test
echo Nazwa testu: %~1
echo Testowany url: %url%%~3
curl -X '%~2' ^
	 %url%%~3 ^
	 -H 'accept: text/plain'
echo:
EXIT /B 0
