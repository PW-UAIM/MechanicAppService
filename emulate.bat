echo off
set url=https://localhost:5011

echo "Mechanik loguje sie swoim identyfikatorem"
CALL:curl_test GET /mechanic/1/login 
echo "Widzi w panelu wszystkie auta"
CALL:curl_test GET /car/all
echo "Moze zobaczyc szczegoly konkretnego auta"
CALL:curl_test GET /car/1
CALL:curl_test GET /visit/1
echo "Moze zmienic status wizyty na naprawione"
CALL:curl_test PATCH /visit/1/update/W_trakcie
echo:
echo:
echo "A nastepnie sprawdzic czy stasus sie zmienil"
CALL:curl_test GET /visit/1
echo "A takze sprawdzic swoj grafik na konkretny dzien"
CALL:curl_test GET /visit/mechanic/1/date/2022/3/1
echo "Albo wszystkie dni, w ktore pracuje"
CALL:curl_test GET /visit/mechanic/1

EXIT /B 0

:curl_test
echo Testowany url: %url%%~2
curl -X %~1 ^
	 %url%%~2 ^
	 -H 'accept:application/json'
echo:
echo:
EXIT /B 0
