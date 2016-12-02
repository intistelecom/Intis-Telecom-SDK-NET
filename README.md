Intis-Telecom-SDK-NET
=====================

The Intis telecom gateway lets you send SMS messages worldwide via its API. This program sends HTTP(s) requests and receives information as a response in JSON and/or XML. The main functions of our API include:

* sending SMS messages (including scheduling options);
* receiving status reports about messages that have been sent previously;
* requesting lists of authorised sender names;
* requesting lists of incoming SMS messages;
* requesting current balance status;
* requesting lists of databases;
* requesting lists of numbers within particular contact list;
* searching for a particular number in a stop list;
* requesting lists of templates;
* adding new templates;
* requesting monthly statistics;
* making HLR request;
* HLR запрос
* receiving HLR request statistics;
* requesting an operator’s name by phone number;

To begin using our API please [apply](https://go.intistele.com/external/client/register/) for your account at our website where you can get your login and API key.

Install
---------------------------

```
PM> Install-Package Intis
```

Usage
---------------------------

class IntisClient - The main class for SMS sending and getting API information

There are three mandatory parameters that you have to provide the constructor in order to initialize. They are:
* login - user login
* apiKey - user API key
* apiHost - API address

```net

using Intis.SDK;

var client = new IntisClient(login, apiKey, apiHost);
```

This class includes the following methods:
------------------------------------------

Use the `getBalance()` method to request your balance status
```net
var balance = client.getBalance();

var amount = balance.Amount;     // Getting amount of money
var currency = balance.Currency; // Getting name of currency
```

To get a list of all the contact databases you have use the function `getPhoneBases()`
```net
var balance = client.GetPhoneBases();

foreach (var item in balance)
{
    item.BaseId;                           // Getting list ID
    item.Title;                            // Getting list name
    item.Count;                            // Getting number of contacts in list
    item.Pages;                            // Getting number of pages in list

    var s = item.BirthdayGreetingSettings; // Getting settings of birthday greetings
    s.Enabled;                             // Getting key that is responsible for sending greetings, 0 - do not send, 1 - send
    s.DaysBefore;                          // Getting the number of days to send greetings before
    s.Originator;                          // Getting name of sender for greeting SMS
    s.TimeToSend;                          // Getting time for sending greetings. All SMS will be sent at this time.
    s.UseLocalTime;                        // Getting variable that indicates using of local time while SMS sending.
    s.Template;                            // Getting text template that will be used in the messages.
}
```

Our gateway supports the option of having unlimited sender’s names. To see a list of all senders’ names use the method `getOriginators()`
```net
var originators = client.GetOriginators();

foreach (var item in originators)
{
    item.Name;                  // Getting sender name
    item.State;                 // Getting sender status
}
```
To get a list of phone numbers from a certain contact list you need the `getPhoneBaseItems(baseId, page)` method. For your convenience, the entire list is split into separate pages.
The parameters are: `baseId` - the ID of a particular database (mandator), and `page` - a page number in a particular database (optional).
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

To receive status info for an SMS you have already sent, use the function `getDeliveryStatus(messageId)` where `messageId` - is an array of sent message IDs.
```net
var status = client.GetDeliveryStatus(messageId);

foreach (var one in status)
{
    item.MessageId;     // Getting message ID
    item.MessageStatus; // Getting a message status
    item.CreatedAt;     // Getting a time of message
}
```

To send a message (to one or several recipients), use the function `sendMessage(phone, originator, text)`,
where `phone` - is a set of numbers you send your messages to,
`originator` is a sender’s name, `text` stands for the content of the message and
sendingTime - Example: 2014-05-30 14:06 (an optional parameter, it is used when it is necessary to schedule SMS messages).
An array includes `MessageSendingSuccess` if the message was successfully sent or `MessageSendingError` in case of failure.
```net
var status = client.SendMessage(phones, originator, text, sendingTime).ToArray();

foreach (var one in status)
{
	if (one.IsOk)                             // А flag of successful dispatch of a message
	{ 
	    var item = (MessageSendingSuccess)one;
        item.Phone;                           // Getting phone number
        item.MessageId;                       // Getting message ID
        item.Cost;                            // Getting price for message
        item.Currency;                        // Getting name of currency
        item.MessagesCount;                   // Getting number of message parts
    }
    else{
	    var item = (MessageSendingError)one;
        item.Phone;                           // Getting phone number
        item.Message;                         // Getting error message
        item.Code;                            // Getting code error in SMS sending
    }
}
```

To add a number to a stoplist run `addToStopList(phone)` where `phone` is an individual phone number
```net
var id = client.AddToStopList(phone); // return ID in stop list
```

To check if a particular phone number is listed within a stop list use the function `checkStopList(phone)`, where `phone` is an individual phone number.
```net
var check = client.CheckStopList(phone);

check.Id;          // Getting ID in stop list
check.Description; // Getting reason of adding to stop list
check.TimeAddedAt; // Getting time of adding to stop list
```

Our gateway supports the option of creating multiple templates of SMS messages. To get a list of templates use the function `getTemplates()`.
As a response you will get a list of all the messages that a certain login has set up.
```net
var templates = client.GetTemplates();

foreach (var one in templates)
{
    item.Id;                  // Getting template ID
    item.Title;               // Getting template name
    item.template;            // Getting text of template
    item.CreatedAt;           // Getting the date and time when a particular template was created
}
```

To add a new template to a system run the function `AddTemplate(title, template)` where `title` is a name of a template, and `template` is the text content of a template
```net
var template = client.AddTemplate(title, text); // return ID user template
```

To Edit a template to a system run the function `EditTemplate(title, template)` where `title` is a name of a template, and `template` is the text content of a template
```net
var template = client.EditTemplate(title, text); // return ID user template
```

To get stats about messages you have sent during a particular month use the function `getDailyStatsByMonth(year, month)` where `year` and `month` - are the particular date you need statistics for.
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

HLR (Home Location Register) - is the centralised databas that provides detailed information regarding the GSM mobile network of every mobile user.
HLR requests let you check the availability of a single phone number or a list of numbers for further clean up of unavailable numbers from a contact list.
To perform an HLR request, our system supports the function `makeHLRRequest(phone)` where `phone` is the array of phone numbers.
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

Besides, you can can get HLR requests statistics regarding a certain time range. To do that,  use the function `getHlrStats(from, to)` where `from` and `to` are the beginning and end of a time period.
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

To get information regarding which mobile network a certain phone number belongs to, use the function `getNetworkByPhone(phone)`, where `phone` is a phone number.
```net
var network = client.GetNetworkByPhone(phone);

network.Title; // Getting operator of subscriber
```

Please bear in mind that this method has less accuracy than HLR requests as it uses our internal database to check which mobile operator a phone numbers belongs to.

To get a list of incoming messages please use the function `getIncomingMessages(date)`, where `date` stands for a particular day in YYYY-mm-dd format.
Or use the function `getIncomingMessages(from, to)`, where 
from - date of start in the format YYYY-MM-DD HH:II:SS (Example: 2014-05-01 14:06:00) and
to - date of end in the format YYYY-MM-DD HH:II:SS (Example: 2014-05-30 23:59:59)
```net
var messages = client.GetIncomingMessages(data);

foreach (var one in messages)
{
    item.MessageId;   // Getting message ID
    item.Originator;  // Getting sender name of the incoming message
    item.Prefix;      // Getting prefix of the incoming message
    item.ReceivedAt;  // Getting date of the incoming message
    item.Text;        // Getting text of the incoming message
	item.Destination; // Get message destination
}
```
