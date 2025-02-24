using System.Globalization;

namespace MeuLivroDeReceitas.API.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;

        public CultureMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);
            var culture = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            // Pegando apenas a primeira cultura válida
            var cultureName = culture.Split(',')
                .Select(lang => lang.Split(';')[0]) // Remove os pesos (q=0.9, etc.)
                .FirstOrDefault(CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Select(c => c.Name)
                .Contains);

            var cultureInfo = new CultureInfo("en");

            if (string.IsNullOrWhiteSpace(cultureName) == false &&
                supportedLanguages.Any(c => c.Name.Equals(cultureName)))
            {
                cultureInfo = new CultureInfo(cultureName);
            }

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            await _next(context);
        }
    }
}
