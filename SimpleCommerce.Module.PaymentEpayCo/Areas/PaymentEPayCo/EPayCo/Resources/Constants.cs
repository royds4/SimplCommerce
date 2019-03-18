using System.Collections.Generic;

namespace SimplCommerce.Module.PaymentEPayCo.Areas.PaymentEPayCo.EPayCo.Resources
{
    public static class Constants
    {
        public enum CashType
        {
            Efecty,
            Baloto,
            Gana,
            Default
        }

        public static Dictionary<string, Dictionary<string, string>> Errors = new Dictionary<string, Dictionary<string, string>>() {
            { "100", new Dictionary<string,string>(){
                    { "ES", @"[100] Error inicializando el sdk, compruebe que los parametros son correctos" },
                    { "EN", @"[100] Error initializing the sdk, please check the supplied parameters are correct" }
    } },
    {"101", new Dictionary<string,string>(){
        {"ES", "[101] Error de comunicación con el servicio"},
        {"EN", "[101] Error communicating with the service"}
    }},
    {"102", new Dictionary<string,string>(){
        {"ES", "[101] Error desconocido, verifique con soporte"},
        {"EN", "[101] Unknown error, please verify with support"}
    }},
    {"103", new Dictionary<string,string>(){
        {"ES", "[103] La información suministrada es erronea, verifique con la documentación"},
        {"EN", "[103] The given information is not correct, please verify your call with the documentation"}
    }},
    {"104", new Dictionary<string,string>(){
        {"ES", "[104] El servicio no se puede autenticar, verifique su llave pública"},
        {"EN", "[104] The service cannot be authenticated, please verify your public key"}
    }},
    {"105", new Dictionary<string,string>(){
        {"ES", "[105] No de puede obtener comunicación con el servicio"},
        {"EN", "[105] Cannot establish a communication with the service"}
    }},
    {"106", new Dictionary<string,string>(){
        {"ES", "[106] Llave pública inválida, compruebela"},
        {"EN", "[106] The public key is not valid, please validate"}
    }},
    {"107", new Dictionary<string,string>(){
        {"ES", "[107] Método no válido, compruebe la petición"},
        {"EN", "[107] Unsupported method, please check your request."}
    }},
    {"108", new Dictionary<string,string>(){
        {"ES", "[108] Error al encriptar los datos, re intente la operación"},
        {"EN", "[108] Error encrypting the data, please retry the operation"}
    }},
    {"109", new Dictionary<string,string>(){
        {"ES", "[109] Método de pago en efectivo no válido, unicamnete soportados {efecty - baloto - gana}"},
        {"EN", "[109] Unsupported payment method, we only support {efecty - baloto - gana}"}
    }}
        };

    }
}
