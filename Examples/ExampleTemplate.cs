using Intis.SDK;
using Intis.SDK.Exceptions;

namespace Examples
{
    class ExampleTemplate
    {
        static void GetTemplates()
        {
            const string login = "your api login";
            const string apiKey = "your api key here";
            const string apiHost = "http://api.host.com/get/";
            var client = new IntisClient(login, apiKey, apiHost);

            try
            {
                var templates = client.GetTemplates();
                foreach (var one in templates)
                {
                    var id = one.Id;
                    var title = one.Title;
                    var template = one.template;
                    var createdAt = one.CreatedAt;
                }
            }
            catch (TemplateException ex)
            {
                var message = ex.Message;
                var parameters = ex.Parameters;
            }
            catch (SdkException ex)
            {
                var message = ex.Message;
                var code = ex.Code;
            }
        }
    }
}
