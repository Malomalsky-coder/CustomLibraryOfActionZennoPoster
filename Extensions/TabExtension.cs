using System;
using System.Threading;
using System.Threading.Tasks;
using ZennoLab.CommandCenter;

namespace CustomLibraryOfActionZennoPoster.Extensions
{
    /// <summary>
    /// Расширяющиме методы для класса <see cref="ZennoLab.CommandCenter.Tab"/>
    /// </summary>
    public static class TabExtension
    {
        /// <summary>
        /// Установить значение
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="value"></param>
        /// <param name="attribute"></param>
        /// <param name="xPath"></param>
        /// <param name="millisecondsDelayMin"></param>
        /// <param name="millisecondsDelayMax"></param>
        /// <param name="secondWaitingElement"></param>
        /// <param name="emulationLevel"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// 
        /// </code>
        /// </example>
        public static bool SetValue(
            this Tab tab,
            string value,
            string attribute,
            string xPath,
            int xPathToPosition = 0,
            int millisecondsDelayMin = 0,
            int millisecondsDelayMax = 0,
            int secondWaitingElement = 0)
        {
            WaitingBeforeExecution(millisecondsDelayMin, millisecondsDelayMax);
            var waitElResult = tab.WaitElementToAppear(xPath, xPathToPosition, secondWaitingElement);

            if (waitElResult.Item1)
            {
                HtmlElement he = waitElResult.Item2;
                he.SetAttribute(attribute, value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Установить значение
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="value"></param>
        /// <param name="attribute"></param>
        /// <param name="xPath"></param>
        /// <param name="millisecondsDelayMin"></param>
        /// <param name="millisecondsDelayMax"></param>
        /// <param name="secondWaitingElement"></param>
        /// <param name="emulationLevel"></param>
        /// <returns></returns>
        /// <example>
        /// <code>
        /// 
        /// </code>
        /// </example>
        public static async Task<bool> SetValueAsync(
            this Tab tab,
            string value,
            string attribute,
            string xPath,
            int xPathToPosition = 0,
            int millisecondsDelayMin = 0,
            int millisecondsDelayMax = 0,
            int secondWaitingElement = 0)
        {
            WaitingBeforeExecution(millisecondsDelayMin, millisecondsDelayMax);
            var waitElResult = await tab.WaitElementToAppearAsync(xPath, xPathToPosition, secondWaitingElement);

            if (waitElResult.Item1)
            {
                HtmlElement he = waitElResult.Item2;
                he.SetAttribute(attribute, value);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        /// <summary>
        /// Выполнить событие
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="event">Событие</param>
        /// <param name="xPath">Запрос</param>
        /// <param name="xPathToPosition">Позиция в дереве элементов</param>
        /// <param name="millisecondsDelayMin">Подождать перед выполнением, минимально в миллисекундах</param>
        /// <param name="millisecondsDelayMax">Подождать перед выполнением, максимально в миллисекундах</param>
        /// <param name="secondWaitingElement">Ждать элемент не более</param>
        /// <param name="emulationLevel">Уровень эмуляции</param>
        /// <returns>Ответ, содержащий истину в случае успеха.</returns>
        /// <example>
        /// <code>
        /// var result = instance.ActiveTab.ExecuteEvent("click", "//button");
        /// project.SendInfoToLog(result.ToString());
        /// </code>
        /// </example>
        public static bool ExecuteEvent(
            this Tab tab,
            string @event,
            string xPath,
            int xPathToPosition = 0,
            int millisecondsDelayMin = 0,
            int millisecondsDelayMax = 0,
            int secondWaitingElement = 0,
            string emulationLevel = "SuperEmulation")
        {
            if (0 > secondWaitingElement)
            {
                secondWaitingElement = 0;
            }

            WaitingBeforeExecution(millisecondsDelayMin, millisecondsDelayMax);
            var waitElResult = tab.WaitElementToAppear(xPath, xPathToPosition, secondWaitingElement);

            if (waitElResult.Item1)
            {
                HtmlElement he = waitElResult.Item2;
                he.RiseEvent(@event, emulationLevel);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Выполнить событие
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="event">Событие</param>
        /// <param name="xPath">Запрос</param>
        /// <param name="xPathToPosition">Позиция в дереве элементов</param>
        /// <param name="millisecondsDelayMin">Подождать перед выполнением, минимально в миллисекундах</param>
        /// <param name="millisecondsDelayMax">Подождать перед выполнением, максимально в миллисекундах</param>
        /// <param name="secondWaitingElement">Ждать элемент не более</param>
        /// <param name="emulationLevel">Уровень эмуляции</param>
        /// <returns>Ответ, содержащий истину в случае успеха.</returns>
        /// <example>
        /// <code>
        /// Task<bool> result = Task.Run(async () => {
	    ///     return await instance.ActiveTab.ExecuteEventAsync("click", "//div[starts-with(@class,'sign-in-page')]").ConfigureAwait(false);
        /// });
        /// project.SendInfoToLog(result.Result.ToString());
        /// </code>
        /// </example>
        public static async Task<bool> ExecuteEventAsync(
            this Tab tab,
            string @event,
            string xPath,
            int xPathToPosition = 0,
            int millisecondsDelayMin = 0,
            int millisecondsDelayMax = 0,
            int secondWaitingElement = 0,
            string emulationLevel = "SuperEmulation")
        {
            await WaitingBeforeExecutionAsync(millisecondsDelayMin, millisecondsDelayMax);
            var waitElResult = await tab.WaitElementToAppearAsync(xPath, xPathToPosition, secondWaitingElement);

            if (waitElResult.Item1)
            {
                HtmlElement he = waitElResult.Item2;
                he.RiseEvent(@event, emulationLevel);
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }

        /// <summary>
        /// Дождаться появления элемента не более (сек)
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="xPath"></param>
        /// <param name="xPathToPosition"></param>
        /// <param name="secondWaitingElement"></param>
        /// <returns></returns>
        private static (bool, HtmlElement) WaitElementToAppear(this Tab tab, string xPath, int xPathToPosition, int secondWaitingElement)
        {
            if (0 > secondWaitingElement)
            {
                secondWaitingElement = 0;
            }

            HtmlElement he = null;

            //Ждать жлемент не более
            for (int i = 0; i <= secondWaitingElement; i++)
            {
                he = tab.FindElementByXPath(xPath, xPathToPosition);

                if (he.IsVoid) Thread.Sleep(1000);
                else break;
            }

            if (he.IsVoid) return (false, null);
            return (true, he);
        }

        /// <summary>
        /// Дождаться появления элемента не более (сек)
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="xPath"></param>
        /// <param name="xPathToPosition"></param>
        /// <param name="secondWaitingElement"></param>
        /// <returns></returns>
        private static async Task<(bool, HtmlElement)> WaitElementToAppearAsync(this Tab tab, string xPath, int xPathToPosition, int secondWaitingElement)
        {
            if (0 > secondWaitingElement)
            {
                secondWaitingElement = 0;
            }

            HtmlElement he = null;

            //Ждать жлемент не более
            for (int i = 0; i <= secondWaitingElement; i++)
            {
                he = tab.FindElementByXPath(xPath, xPathToPosition);

                if (he.IsVoid) await Task.Delay(1000);
                else break;
            }

            if (he.IsVoid) return (false, null);
            return (true, he);
        }

        /// <summary>
        /// Подождать перед выполнением
        /// </summary>
        /// <param name="millisecondsDelayMin"></param>
        /// <param name="millisecondsDelayMax"></param>
        private static void WaitingBeforeExecution(int millisecondsDelayMin, int millisecondsDelayMax)
        {
            if (0 > millisecondsDelayMin)
            {
                millisecondsDelayMin = 0;
            }

            if (0 > millisecondsDelayMax)
            {
                millisecondsDelayMax = 0;
            }

            Thread.Sleep(new Random().Next(millisecondsDelayMin, millisecondsDelayMax));
        }

        /// <summary>
        /// Подождать перед выполнением
        /// </summary>
        /// <param name="millisecondsDelayMin"></param>
        /// <param name="millisecondsDelayMax"></param>
        /// <returns></returns>
        private static async Task WaitingBeforeExecutionAsync(int millisecondsDelayMin, int millisecondsDelayMax)
        {
            if (0 > millisecondsDelayMin)
            {
                millisecondsDelayMin = 0;
            }

            if (0 > millisecondsDelayMax)
            {
                millisecondsDelayMax = 0;
            }

            await Task.Delay(new Random().Next(millisecondsDelayMin, millisecondsDelayMax));
        }
    }
}
