//TRY PARSE with TERNARY OPERATION

int input = 28;
bool validInteger= int.tryParse(input, out inputTemperature)

if(validInteger)
{
    string temperatureMessage = inputTemperature <= 15 ? "Frio" : 
    (inputTemperature > 15 && inputTemperature < 28) ? "Normal" : 
    (inputTemperature > 28) ? "Calor" : "";
}
else
{
    return "you need to provide an int";
}
