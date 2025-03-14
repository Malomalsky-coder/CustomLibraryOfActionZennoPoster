﻿using System;
using System.Threading;
using ZennoLab.CommandCenter;

namespace CustomLibraryOfActionZennoPoster.Extensions
{
    /// <summary>
    /// Расширяющиме методы для класса <see cref="ZennoLab.CommandCenter.Tab"/>
    /// </summary>
    public static class TabExtension
    {
        /// <summary>
        /// Установка значения
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="value">Что</param>
        /// <param name="attribute">Куда</param>
        /// <param name="xPath">Запрос</param>
        /// <param name="xPathToPosition">Позиция в дереве элементов</param>
        /// <param name="millisecondsDelayMin">Подождать перед выполнением, минимально в миллисекундах</param>
        /// <param name="millisecondsDelayMax">Подождать перед выполнением, максимально в миллисекундах</param>
        /// <param name="secondWaitingElement">Ждать элемент не более</param>
        /// <returns>Ответ, содержащий истину в случае успеха.</returns>
        /// <example>
        /// <code>
        /// var result = instance.ActiveTab.SetValue("0", "value", "//*[@id='text']");
        /// project.SendInfoToLog(result.ToString());
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
            var waitElResult = tab.WaitElementByXPath(xPath, xPathToPosition, secondWaitingElement);

            if (waitElResult.Item1)
            {
                HtmlElement he = waitElResult.Item2;
                he.SetAttribute(attribute, value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Получение значения
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="attribute">Что брать</param>
        /// <param name="xPath">Запрос</param>
        /// <param name="xPathToPosition">Позиция в дереве элементов</param>
        /// <param name="millisecondsDelayMin">Подождать перед выполнением, минимально в миллисекундах</param>
        /// <param name="millisecondsDelayMax">Подождать перед выполнением, максимально в миллисекундах</param>
        /// <param name="secondWaitingElement">Ждать элемент не более</param>
        /// <returns>Ответ, содержащий значение атрибута.</returns>
        /// <example>
        /// <code>
        /// var result = instance.ActiveTab.GetValue("value", "//*[@id='text']");
        /// project.SendInfoToLog(result.ToString());
        /// </code>
        /// </example>
        public static string GetValue(
            this Tab tab,
            string attribute,
            string xPath,
            int xPathToPosition = 0,
            int millisecondsDelayMin = 0,
            int millisecondsDelayMax = 0,
            int secondWaitingElement = 0)
        {
            WaitingBeforeExecution(millisecondsDelayMin, millisecondsDelayMax);
            var waitElResult = tab.WaitElementByXPath(xPath, xPathToPosition, secondWaitingElement);

            if (waitElResult.Item1)
            {
                HtmlElement he = waitElResult.Item2;
                var result = he.GetAttribute(attribute);
                return result;
            }

            return null;
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
            WaitingBeforeExecution(millisecondsDelayMin, millisecondsDelayMax);
            var waitElResult = tab.WaitElementByXPath(xPath, xPathToPosition, secondWaitingElement);

            if (waitElResult.Item1)
            {
                HtmlElement he = waitElResult.Item2;
                he.RiseEvent(@event, emulationLevel);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Дождаться появления элемента не более (сек)
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="xPath">xPath выражение</param>
        /// <param name="xPathToPosition">Позиция элемента</param>
        /// <param name="secondWaitingElement">Ждать элемент не более (сек)</param>
        /// <returns></returns>
        public static (bool, HtmlElement) WaitElementByXPath(this Tab tab, string xPath, int xPathToPosition = 0, int secondWaitingElement = 0)
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
        /// <param name="xPath">xPath выражение</param>
        /// <param name="xPathToPosition">Позиция элемента</param>
        /// <param name="waitBeforeExecuting">Подождать перед выполнением</param>
        /// <param name="secondWaitingElement">Ждать элемент не более (сек)</param>
        /// <returns></returns>
        public static (bool, HtmlElement) WaitElementByXPath(this Tab tab, string xPath, int xPathToPosition = 0, int waitBeforeExecuting = 0, int secondWaitingElement = 0)
        {
            if (0 > waitBeforeExecuting)
            {
                waitBeforeExecuting = 0;
            }

            if (waitBeforeExecuting > 0)
            {
                Thread.Sleep(waitBeforeExecuting * 1000);
            }

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
        /// Подождать перед выполнением
        /// </summary>
        /// <param name="millisecondsDelayMin">От</param>
        /// <param name="millisecondsDelayMax">До</param>
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
    }
}
