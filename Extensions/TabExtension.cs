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
            if (0 > millisecondsDelayMin)
            {
                millisecondsDelayMin = 0;
            }

            if (0 > millisecondsDelayMax)
            {
                millisecondsDelayMax = 0;
            }

            if (0 > secondWaitingElement)
            {
                secondWaitingElement = 0;
            }

            //Подождать перед выполнением
            Thread.Sleep(new Random().Next(millisecondsDelayMin, millisecondsDelayMax));

            HtmlElement he = null;

            //Ждать жлемент не более
            for (int i = 0; i < secondWaitingElement; i++)
            {
                he = tab.FindElementByXPath(xPath, xPathToPosition);

                if (he.IsVoid) Thread.Sleep(1000);
                else break;
            }

            if (he.IsVoid) return false;

            he.RiseEvent(@event, emulationLevel);
            return true;
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
            if (0 > millisecondsDelayMin)
            {
                millisecondsDelayMin = 0;
            }

            if (0 > millisecondsDelayMax)
            {
                millisecondsDelayMax = 0;
            }

            if (0 > secondWaitingElement)
            {
                secondWaitingElement = 0;
            }

            //Подождать перед выполнением
            await Task.Delay(new Random().Next(millisecondsDelayMin, millisecondsDelayMax));

            HtmlElement he = null;

            //Ждать жлемент не более
            for (int i = 0; i < secondWaitingElement; i++)
            {
                he = tab.FindElementByXPath(xPath, xPathToPosition);

                if (he.IsVoid) await Task.Delay(1000);
                else break;
            }

            if (he.IsVoid) return await Task.FromResult(false);

            he.RiseEvent(@event, emulationLevel);
            return await Task.FromResult(true);
        }
    }
}
