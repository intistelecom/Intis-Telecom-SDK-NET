Intis-Telecom-SDK-NET
=====================

Компания Интис Телеком позволяет отправлять СМС по всему миру, используя API. Он основан на отправке HTTP(s) запросов и получения ответной информации в JSON или XML. Основной функционал, поддерживаемый API:

* отправка СМС, в том числе, в назначенное время
* получение отчета о доставке ранее отправленной СМС
* запрос списка разрешенных отправителей
* запрос списка входящих СМС
* запрос баланса
* запрос списка баз
* запрос номеров из базы
* поиск номера в стоп-листе
* добавление номера в стоп-лист
* запрос списка шаблонов
* добавление шаблона
* общая статистика за месяц
* HLR запрос
* статистика HLR запросов
* запрос оператора по номеру телефона

Для начала работы с сервисом, Вам необходимо зарегестрироваться на сайте https://go.intistele.com/external/client/register/. Получить login и API ключ


Usage
---------------------------

class IntisClient - The main class for SMS sending and getting API information

Для инициализации необходимо передать в конструктор три обязательных параметра
login - user login
apiKey - user API key
apiHost - API address

```net

using Intis.SDK;

var client = new IntisClient(login, apiKey, apiHost);
```

Класс содержит следующие методы:
--------------------------------

Для запроса баланса Вашего лицевого счета в сервисе используется метод `getBalance()`
```net
var balance = client.getBalance();

var amount = balance.Amount;     // Getting amount of money
var currency = balance.Currency; // Getting name of currency
```

Запросить список всех имеющихся в Вашей системе телефонных баз `getPhoneBases()`
```net
var balance = client.GetPhoneBases();

foreach (var item in balance)
{
    item.BaseId; // Getting list ID
    item.Title;  // Getting list name
    item.Count;  // Getting number of contacts in list
    item.Pages;  // Getting number of pages in list

    var s = item.BirthdayGreetingSettings; // Getting settings of birthday greetings
    s.Enabled;       // Getting key that is responsible for sending greetings, 0 - do not send, 1 - send
    s.DaysBefore;    // Getting the number of days to send greetings before
    s.Originator;    // Getting name of sender for greeting SMS
    s.TimeToSend;    // Getting time for sending greetings. All SMS will be sent at this time.
    s.UseLocalTime;  // Getting variable that indicates using of local time while SMS sending.
    s.Template;      // Getting text template that will be used in the messages.
}
```

В системе предусмотрена возможность создать неограниченное количество имен отправителей СМС.
Для получения списка отправителей используется метод `getOriginators()`
```net
var originators = client.GetOriginators();

foreach (var item in originators)
{
    item.Name;  // Getting sender name
    item.State; // Getting sender status
}
```

Для получения списка номеров телефонов из определенной базы абонентов в личном кабинете используется метод `getPhoneBaseItems(baseId, page)`. Для удобства весь список разбит на страницы.
Параметры: baseId - ID телефонной базы в системе (обязательный параметр), page - Номер страницы в базе (необязательный параметр)
```net
var bases = client.GetPhoneBaseItems(baseId, page);

foreach (var item in bases)
{
    item.Phone;      // Getting subscriber number
    item.FirstName;  // Getting subscriber first name
    item.MiddleName; // Getting subscriber middle name
    item.LastName;   // Getting subscriber last name
    item.BirthDay;   // Getting subscriber birthday
    item.Gender;     // Getting gender of subscriber
    item.Network;    // Getting operator of subscriber
    item.Area;       // Getting region of subscriber
    item.Note1;      // Getting subscriber note 1
    item.Note2;      // Getting subscriber note 2
}
```

Для получения информации по статусам отправленных СМС используется функция `getDeliveryStatus(messageId)` messageId - массив ID отправленных сообщений.
```net
var status = client.GetDeliveryStatus(messageId);

foreach (var one in status)
{
    item.MessageId;     // Getting message ID
    item.MessageStatus; // Getting a message status
    item.CreatedAt;     // Getting a time of message
}
```

Для отправки СМС (в том числе и нескольким абонентам) используется функция `sendMessage(phone, originator, text)`.
Где phone - массив телефонных номеров на которые необходимо отправить сообщение,
originator - имя отправителя от имени которого идет рассылка, text - текст смс.
Массив содержит `MessageSendingSuccess` если сообщение успешно отправлено или `MessageSendingError` если возникла ошибка
```net
var status = client.SendMessage(phones, originator, text).ToArray();

foreach (var one in status)
{
	if (one.IsOk)           // флаг успешной отправки сообщения
	{ 
	    var item = (MessageSendingSuccess)one;
        item.Phone;         // Getting phone number
        item.MessageId;     // Getting message ID
        item.Cost;          // Getting price for message
        item.Currency;      // Getting name of currency
        item.MessagesCount; // Getting number of message parts
    }
    else{
	    var item = (MessageSendingError)one;
        item.Phone;         // Getting phone number
        item.Message;       // Getting error message
        item.Code;          // Getting code error in SMS sending
    }
}
```

Добавить номер в СТОП-лист `addToStopList(phone)` phone - phone number
```net
var id = client.AddToStopList(phone); // return ID in stop list
```

Для проверки наличия телефонного номера в СТОП-листе необходимо воспользоваться функцией `checkStopList(phone)`. Где phone - phone number
```net
var check = client.CheckStopList(phone);

check.Id;          // Getting ID in stop list
check.Description; // Getting reason of adding to stop list
check.TimeAddedAt; // Getting time of adding to stop list
```

В системе предусмотрена возможность создания множества шаблонов СМС сообщений. Для получения списка таких шаблонов используется функция `getTemplates()`.
В ответ возвращается список всех имеющихся в данной учетной записи шаблонов.
```net
var templates = client.GetTemplates();

foreach (var one in templates)
{
    item.Id;        // Getting template ID
    item.Title;     // Getting template name
    item.template;  // Getting text of template
    item.CreatedAt; // Получение времени создания шаблона
}
```

Для добавления нового шаблона в систему используется функция `addTemplate(title, template)`. Где title - template name, template - text of template
```net
var template = client.AddTemplate(title, text); // return ID user template
```

Для получения статистики отправки сообщения за определенный месяц используется функция `getDailyStatsByMonth(year, month)`.
Где year - год и month - месяц за который необходимо получить статистику.
```net
var stats = client.GetDailyStatsByMonth(year, month);

foreach (var item in stats)
{
    item.Day;                    // Getting day of month

    var stats = item.Stats;      // Getting daily statistics
    foreach (var entry in stats)
	{
        entry.State;             // Getting status of message
        entry.Cost;              // Getting prices of message
        entry.Currency;          // Getting name of currency
        entry.Count;             // Getting number of message parts
    }
}
```

HLR (Home Location Register) — это централизованная база данных, которая содержит подробную информацию о каждом абоненте мобильных сетей GSM-операторов.
HLR запрос позволяет выполнить проверку телефонных номеров (в том числе и списком), определяя доступность абонентов для дальнейшей очистки базы данных от неактуальных номеров.
Для осуществления HLR запроса в системе предусмотрена функция `makeHLRRequest(phone)`.
Где phone - массив телефонов.
```net
var hlrResponse = client.MakeHlrRequest(phones);

foreach (var item in hlrResponse)
{
    item.Id;                    // Getting ID
    item.Destination;           // Getting recipient
    item.IMSI;                  // Getting IMSI
    item.MCC;                   // Getting MCC of subscriber
    item.MNC;                   // Getting MNC of subscriber
    item.OriginalCountryName;   // Getting the original name of the subscriber's country
    item.OriginalCountryCode;   // Getting the original code of the subscriber's country
    item.OriginalNetworkName;   // Getting the original name of the subscriber's operator
    item.OriginalNetworkPrefix; // Getting the original prefix of the subscriber's operator
    item.PortedCountryName;     // Getting name of country if subscriber's phone number is ported
    item.PortedCountryPrefix;   // Getting prefix of country if subscriber's phone number is ported
    item.PortedNetworkName;     // Getting name of operator if subscriber's phone number is ported
    item.PortedNetworkPrefix;   // Getting prefix of operator if subscriber's phone number is ported
    item.RoamingCountryName;    // Getting name of country if the subscriber is in roaming
    item.RoamingCountryPrefix;  // Getting prefix of country if the subscriber is in roaming
    item.RoamingNetworkName;    // Getting name of operator if the subscriber is in roaming
    item.RoamingNetworkPrefix;  // Getting prefix of operator if the subscriber is in roaming
    item.Status;                // Getting status of subscriber
    item.PricePerMessage;       // Getting price for message
    item.IsInRoaming;           // Determining if the subscriber is in roaming
    item.IsPorted;              // Identification of ported number
}
```

Кроме того, возможно получить статистику HLR запросов за определенный период времени `getHlrStats(from, to)`.
Где from - дата начала периода, to - дата конца периода
```net
var hlrStatItem = client.GetHlrStats(from, to);

foreach (var item in hlrStatItem)
{
        item.Id;                    // Getting ID
        item.Phone;                 // Getting phone number
        item.MessageId;             // Getting message ID
        item.TotalPrice;            // Getting final price of request
        item.Destination;           // Getting recipient
        item.IMSI;                  // Getting IMSI
        item.MCC;                   // Getting MCC of subscriber
        item.MNC;                   // Getting MNC of subscriber
        item.OriginalCountryName;   // Getting the original name of the subscriber's country
        item.OriginalCountryCode;   // Getting the original code of the subscriber's country
        item.OriginalNetworkName;   // Getting the original name of the subscriber's operator
        item.OriginalNetworkPrefix; // Getting the original prefix of the subscriber's operator
        item.PortedCountryName;     // Getting name of country if subscriber's phone number is ported
        item.PortedCountryPrefix;   // Getting prefix of country if subscriber's phone number is ported
        item.PortedNetworkName;     // Getting name of operator if subscriber's phone number is ported
        item.PortedNetworkPrefix;   // Getting prefix of operator if subscriber's phone number is ported
        item.RoamingCountryName;    // Getting name of country if the subscriber is in roaming
        item.RoamingCountryPrefix;  // Getting prefix of country if the subscriber is in roaming
        item.RoamingNetworkName;    // Getting name of operator if the subscriber is in roaming
        item.RoamingNetworkPrefix;  // Getting prefix of operator if the subscriber is in roaming
        item.Status;                // Getting status of subscriber
        item.PricePerMessage;       // Getting price for message
        item.isInRoaming;           // Determining if the subscriber is in roaming
        item.isPorted;              // Identification of ported number
        item.RequestId;             // Getting request ID
        item.RequestTime;           // Getting time of request
    }
```

Для получения информации о пренадлежности определенного номера какому-либо оператору используется функция `getNetworkByPhone(phone)`. Где phone - номер телефона
```net
var network = client.GetNetworkByPhone(phone);

network.Title; // Getting operator of subscriber
```
Следует отметить, что данный метод является менее точным, чем HLR запрос, т.к. использует внутреннюю базу данных компании Интис Телеком о пренадлежности абонентов определенному оператору.

Для получения списка входящих сообщений необходимо воспользоваться функцией `getIncomingMessages(date)`. Где date - интересующая Вас дата (format date YYYY-mm-dd)
```net
var messages = client.GetIncomingMessages(data);

foreach (var one in messages)
{
    item.MessageId;  // Getting message ID
    item.Originator; // Getting sender name of the incoming message
    item.Prefix;     // Getting prefix of the incoming message
    item.ReceivedAt; // Getting date of the incoming message
    item.Text;       // Getting text of the incoming message
}
```