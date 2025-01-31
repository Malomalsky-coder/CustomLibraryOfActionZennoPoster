using System;
using ZennoLab.CommandCenter;
using ZennoLab.InterfacesLibrary.Enums.Http;
using ZennoLab.InterfacesLibrary.ProjectModel;

namespace CustomLibraryOfActionZennoPoster
{
    /// <summary>
    /// Метод действия: HTTP
    /// </summary>
    public class HTTP
    {
        private readonly ICookieContainer _cookieContainer;

        /// <summary>
        /// Метод действия: HTTP
        /// </summary>
        /// <param name="cookieContainer"></param>
        /// <remarks>
        /// Для выполнения HTTP запроса, можно использовать <see cref="ICookieContainer"/>, иначе null/>.
        /// Подробнее см. <see href="https://help.zennolab.com/en/v7/zennoposter/7.1.4/webframe.html#topic1105.html"/>.
        /// Для работы с <see cref="ICookieContainer"/> доступны методы, подробнее см. <see href="https://help.zennolab.com/en/v7/zennoposter/7.1.4/webframe.html#topic1106.html"/>
        /// </remarks>
        public HTTP(ICookieContainer cookieContainer)
        {
            _cookieContainer = cookieContainer;
        }

        /// <summary>
        /// Выполняет GET-запрос.
        /// </summary>
        /// <param name="url">Целевой URL-адрес запроса.</param>
        /// <param name="proxy">Прокси-сервер (например, "socks5://login:pass@8.5.6.7:8080").</param>
        /// <param name="encoding">Кодировка (по умолчанию "UTF-8").</param>
        /// <param name="timeout">Таймаут запроса в миллисекундах (по умолчанию 30000).</param>
        /// <param name="cookies">Cookies для запроса.</param>
        /// <param name="userAgent">Значение заголовка "User-Agent".</param>
        /// <param name="useRedirect">Следовать ли редиректам (по умолчанию true).</param>
        /// <param name="maxRedirectCount">Максимальное количество редиректов (по умолчанию 5).</param>
        /// <param name="additionalHeaders">Дополнительные заголовки запроса.</param>
        /// <param name="useOriginalUrl">Использовать ли оригинальный URL (по умолчанию false).</param>
        /// <param name="throwExceptionOnError">Выбрасывать ли исключение при ошибке (по умолчанию true).</param>
        /// <returns>Ответ сервера в виде строки.</returns>
        public string Get(
            string url,
            string proxy = null,
            string encoding = "UTF-8",
            int timeout = 30000,
            string cookies = null,
            string userAgent = null,
            bool useRedirect = true,
            int maxRedirectCount = 5,
            string[] additionalHeaders = null,
            bool useOriginalUrl = false,
            bool throwExceptionOnError = true
        )
        {
            return Request(
                HttpMethod.GET,
                url,
                proxy: proxy,
                encoding: encoding,
                timeout: timeout,
                cookies: cookies,
                userAgent: userAgent,
                useRedirect: useRedirect,
                maxRedirectCount: maxRedirectCount,
                additionalHeaders: additionalHeaders,
                useOriginalUrl: useOriginalUrl,
                throwExceptionOnError: throwExceptionOnError
            );
        }

        /// <summary>
        /// Выполняет POST-запрос.
        /// </summary>
        /// <param name="url">Целевой URL-адрес запроса.</param>
        /// <param name="content">Содержимое запроса.</param>
        /// <param name="contentPostingType">MIME-тип содержимого (например, "application/json").</param>
        /// <param name="proxy">Прокси-сервер (например, "socks5://login:pass@8.5.6.7:8080").</param>
        /// <param name="encoding">Кодировка (по умолчанию "UTF-8").</param>
        /// <param name="timeout">Таймаут запроса в миллисекундах (по умолчанию 30000).</param>
        /// <param name="cookies">Cookies для запроса.</param>
        /// <param name="userAgent">Значение заголовка "User-Agent".</param>
        /// <param name="useRedirect">Следовать ли редиректам (по умолчанию true).</param>
        /// <param name="maxRedirectCount">Максимальное количество редиректов (по умолчанию 5).</param>
        /// <param name="additionalHeaders">Дополнительные заголовки запроса.</param>
        /// <param name="useOriginalUrl">Использовать ли оригинальный URL (по умолчанию false).</param>
        /// <param name="throwExceptionOnError">Выбрасывать ли исключение при ошибке (по умолчанию true).</param>
        /// <returns>Ответ сервера в виде строки.</returns>
        public string Post(
            string url,
            string content,
            string contentPostingType = "application/x-www-form-urlencoded",
            string proxy = null,
            string encoding = "UTF-8",
            int timeout = 30000,
            string cookies = null,
            string userAgent = null,
            bool useRedirect = true,
            int maxRedirectCount = 5,
            string[] additionalHeaders = null,
            bool useOriginalUrl = false,
            bool throwExceptionOnError = true
        )
        {
            return Request(
                HttpMethod.POST,
                url,
                content,
                contentPostingType,
                proxy,
                encoding,
                timeout: timeout,
                cookies: cookies,
                userAgent: userAgent,
                useRedirect: useRedirect,
                maxRedirectCount: maxRedirectCount,
                additionalHeaders: additionalHeaders,
                useOriginalUrl: useOriginalUrl,
                throwExceptionOnError: throwExceptionOnError
            );
        }

        /// <summary>
        /// Выполняет HTTP-запрос.
        /// </summary>
        /// <param name="method">HTTP-метод (GET, POST, PUT и т.д.).</param>
        /// <param name="url">Целевой URL-адрес запроса.</param>
        /// <param name="content">Содержимое запроса для POST, PUT или PATCH.</param>
        /// <param name="contentPostingType">MIME-тип содержимого (например, "application/json").</param>
        /// <param name="proxy">Прокси-сервер (например, "socks5://login:pass@8.5.6.7:8080").</param>
        /// <param name="encoding">Кодировка (по умолчанию "UTF-8").</param>
        /// <param name="respType">Тип ответа (например, BodyOnly, HeaderOnly).</param>
        /// <param name="timeout">Таймаут запроса в миллисекундах (по умолчанию 30000).</param>
        /// <param name="cookies">Cookies для запроса.</param>
        /// <param name="userAgent">Значение заголовка "User-Agent".</param>
        /// <param name="useRedirect">Следовать ли редиректам (по умолчанию true).</param>
        /// <param name="maxRedirectCount">Максимальное количество редиректов (по умолчанию 5).</param>
        /// <param name="additionalHeaders">Дополнительные заголовки запроса.</param>
        /// <param name="downloadPath">Путь для сохранения файла (если требуется).</param>
        /// <param name="useOriginalUrl">Использовать ли оригинальный URL (по умолчанию false).</param>
        /// <param name="throwExceptionOnError">Выбрасывать ли исключение при ошибке (по умолчанию true).</param>
        /// <returns>Ответ сервера в виде строки.</returns>
        private string Request(
            HttpMethod method,
            string url,
            string content = "",
            string contentPostingType = "application/x-www-form-urlencoded",
            string proxy = null,
            string encoding = "UTF-8",
            ResponceType respType = ResponceType.BodyOnly,
            int timeout = 30000,
            string cookies = null,
            string userAgent = null,
            bool useRedirect = true,
            int maxRedirectCount = 5,
            string[] additionalHeaders = null,
            string downloadPath = null,
            bool useOriginalUrl = false,
            bool throwExceptionOnError = true
        )
        {
            try
            {
                return ZennoPoster.HTTP.Request(
                    method,
                    url,
                    content,
                    contentPostingType,
                    proxy,
                    encoding,
                    respType,
                    timeout,
                    cookies,
                    userAgent,
                    useRedirect,
                    maxRedirectCount,
                    additionalHeaders,
                    downloadPath,
                    useOriginalUrl,
                    throwExceptionOnError,
                    _cookieContainer
                );
            }
            catch (Exception ex)
            {
                if (throwExceptionOnError)
                {
                    throw ex;
                }
            }

            return string.Empty;
        }
    }
}
