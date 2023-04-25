echo off
set url=https://localhost:5011

CALL:curl_test "Poprawne logowanie" GET /login/1

CALL:curl_test "Niepoprawne logowanie" GET /login/2000

CALL:curl_test "Dane wizyty nr 1" GET /getVisit/1

CALL:curl_test "Zakoncz wizyte" PATCH /updateVisitStatus/1/Naprawiono

CALL:curl_test "Dane wizyty nr 1" GET /getVisit/1

CALL:curl_test "Wizyty mechanika o ID 1" GET /getAllVisitsByMechanic/1

CALL:curl_test "Wizyty mechanika o ID 1 w dniu 01.01.2023" GET /getAllVisitsByMechanicInDay/1/2022/3/1

CALL:curl_test "Wszystkie auta" GET /getAllCars

CALL:curl_test "Dane auta nr 1" GET /getCar/1

CALL:curl_test "Dane wizyty nr 1" GET /getVisit/1

EXIT /B 0

:curl_test
echo Nazwa testu: %~1
echo Testowany url: %url%%~3
curl -X %~2 ^
	 %url%%~3 ^
	 -H 'accept:application/json'
echo:
echo:
EXIT /B 0
