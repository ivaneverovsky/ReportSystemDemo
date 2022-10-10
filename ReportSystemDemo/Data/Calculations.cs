using ReportSystemDemo.UIModels;
using System;
using System.Collections.Generic;

namespace ReportSystemDemo.Data
{
    internal class Calculations
    {
        Storage _s = new Storage();

        //count requests details for Requests
        public Requests RequestsBuilder(List<object> dbDataValues, string dateType)
        {
            int counter = dbDataValues.Count;
            int closed = 0;
            int crisis = 0;
            int brokenSLA = 0;

            for (int i = 0; i < dbDataValues.Count; i++)
            {
                object[] guf = (object[])dbDataValues[i];

                if (guf[7].ToString() == "Закрыто")
                    closed++;

                if (guf[6].ToString() == "True")
                    crisis++;

                if (guf[13].ToString() != "")
                    brokenSLA++;
            }

            double SLA = Math.Round((1 - brokenSLA / (double)counter) * 100, 2);

            var request = new Requests(counter, closed, SLA, crisis, dateType);
            _s.AddRequest(request);

            return request;
        }

        //count contracts details for Contract
        public Report ReportBuilder(List<object> dbData, string contract)
        {
            bool status = true;
            string color = "Green";
            string contractName = contract;
            double targetSLA = 89;
            int counter = 0;
            int requests = 0;
            int incidents = 0;
            int crisisCounter = 0;
            double five = 0;
            double four = 0;
            double three = 0;
            double two = 0;
            double noMark = 0;
            double restart = 0;
            int SLABreakCounter = 0;

            for (int i = 0; i < dbData.Count; i++)
            {
                object[] guf = (object[])dbData[i];

                if (contractName == "АйЭмТи")
                {
                    if (guf[11].ToString() == "ITSM 4IT" || guf[11].ToString() == "ООО \"АйЭмТи\"" || guf[11].ToString() == "Неавторизованные пользователи" || guf[11].ToString() == "Регламентные работы (ППР)" || guf[11].ToString() == "Выполнение не ИТ-запросов CLOUDDC")
                    {
                        counter++;

                        if (guf[3].ToString() == "Инцидент" || guf[3].ToString() == "Инцидент ИБ")
                            incidents++;
                        else
                            requests++;

                        if (guf[13].ToString() != "")
                            SLABreakCounter++;

                        if (guf[6].ToString() == "True")
                        {
                            crisisCounter++;
                            color = "Red";
                            status = false;
                        }

                        if (guf[18].ToString() == "0")
                            noMark++;
                        else if (guf[18].ToString() == "5")
                            five++;
                        else if (guf[18].ToString() == "4")
                            four++;
                        else if (guf[18].ToString() == "3")
                            three++;
                        else if (guf[18].ToString() == "2")
                            two++;

                        if (guf[32].ToString() != "0")
                            restart++;
                    }
                }
                else if (contractName == "ИК Сибинтек (СН и УСИТО)")
                {
                    if (guf[11].ToString() == "Сибинтек Софт" || guf[11].ToString() == "ИК Сибинтек СН" || guf[11].ToString() == "ИК Сибинтек УСИТО" || guf[11].ToString() == "ИК Сибинтек ДИТиАВП СН" || guf[11].ToString() == "Снегирь Софт" || guf[11].ToString() == "РБС" || guf[11].ToString() == "ЭКСПЕРТЕК ИБС" || guf[11].ToString() == "ЛВ Сфера")
                    {
                        counter++;

                        if (guf[3].ToString() == "Инцидент" || guf[3].ToString() == "Инцидент ИБ")
                            incidents++;
                        else
                            requests++;

                        if (guf[13].ToString() != "")
                            SLABreakCounter++;

                        if (guf[6].ToString() == "True")
                        {
                            crisisCounter++;
                            color = "Red";
                            status = false;
                        }

                        if (guf[18].ToString() == "0")
                            noMark++;
                        else if (guf[18].ToString() == "5")
                            five++;
                        else if (guf[18].ToString() == "4")
                            four++;
                        else if (guf[18].ToString() == "3")
                            three++;
                        else if (guf[18].ToString() == "2")
                            two++;

                        if (guf[32].ToString() != "0")
                            restart++;
                    }
                }
                else if (contractName == "РН-IaaS")
                {
                    if (guf[11].ToString() == "ДС8 ИК \"Сибинтек\" РН-IaaS")
                    {
                        counter++;

                        if (guf[3].ToString() == "Инцидент" || guf[3].ToString() == "Инцидент ИБ")
                            incidents++;
                        else
                            requests++;

                        if (guf[13].ToString() != "")
                            SLABreakCounter++;

                        if (guf[6].ToString() == "True")
                        {
                            crisisCounter++;
                            color = "Red";
                            status = false;
                        }

                        if (guf[18].ToString() == "0")
                            noMark++;
                        else if (guf[18].ToString() == "5")
                            five++;
                        else if (guf[18].ToString() == "4")
                            four++;
                        else if (guf[18].ToString() == "3")
                            three++;
                        else if (guf[18].ToString() == "2")
                            two++;

                        if (guf[32].ToString() != "0")
                            restart++;
                    }
                }
                else if (contractName == "РН-Предикс")
                {
                    if (guf[11].ToString() == "ДС9 ИК «Сибинтек» ИС Predix")
                    {
                        counter++;

                        if (guf[3].ToString() == "Инцидент" || guf[3].ToString() == "Инцидент ИБ")
                            incidents++;
                        else
                            requests++;

                        if (guf[13].ToString() != "")
                            SLABreakCounter++;

                        if (guf[6].ToString() == "True")
                        {
                            crisisCounter++;
                            color = "Red";
                            status = false;
                        }

                        if (guf[18].ToString() == "0")
                            noMark++;
                        else if (guf[18].ToString() == "5")
                            five++;
                        else if (guf[18].ToString() == "4")
                            four++;
                        else if (guf[18].ToString() == "3")
                            three++;
                        else if (guf[18].ToString() == "2")
                            two++;

                        if (guf[32].ToString() != "0")
                            restart++;
                    }
                }
                else if (contractName == "ГеоПАК")
                {
                    if (guf[11].ToString() == "ДС7 ИК \"Сибинтек\" ИС ГеоПАК")
                    {
                        counter++;

                        if (guf[3].ToString() == "Инцидент" || guf[3].ToString() == "Инцидент ИБ")
                            incidents++;
                        else
                            requests++;

                        if (guf[13].ToString() != "")
                            SLABreakCounter++;

                        if (guf[6].ToString() == "True")
                        {
                            crisisCounter++;
                            color = "Red";
                            status = false;
                        }

                        if (guf[18].ToString() == "0")
                            noMark++;
                        else if (guf[18].ToString() == "5")
                            five++;
                        else if (guf[18].ToString() == "4")
                            four++;
                        else if (guf[18].ToString() == "3")
                            three++;
                        else if (guf[18].ToString() == "2")
                            two++;

                        if (guf[32].ToString() != "0")
                            restart++;
                    }
                }
                else if (contractName == "SAP HANA")
                {
                    if (guf[11].ToString() == "ДС13 ИК \"Сибинтек\" SAP HANA")
                    {
                        counter++;

                        if (guf[3].ToString() == "Инцидент" || guf[3].ToString() == "Инцидент ИБ")
                            incidents++;
                        else
                            requests++;

                        if (guf[13].ToString() != "")
                            SLABreakCounter++;

                        if (guf[6].ToString() == "True")
                        {
                            crisisCounter++;
                            color = "Red";
                            status = false;
                        }

                        if (guf[18].ToString() == "0")
                            noMark++;
                        else if (guf[18].ToString() == "5")
                            five++;
                        else if (guf[18].ToString() == "4")
                            four++;
                        else if (guf[18].ToString() == "3")
                            three++;
                        else if (guf[18].ToString() == "2")
                            two++;

                        if (guf[32].ToString() != "0")
                            restart++;
                    }
                }
            }

            double actualSLA = Math.Round((1 - SLABreakCounter / (double)counter) * 100, 2);

            var report = new Report(status, color, contractName, counter, crisisCounter, targetSLA, actualSLA, requests, incidents, five, four, three, two, noMark, restart);
            _s.AddReport(report);

            return report;
        }

        //collect reports for user
        public List<Report> CollectReports()
        {
            return _s.Reports;
        }

        //collect requests for user
        public List<Requests> CollectRequests()
        {
            return _s.Requests;
        }

        //clear lists
        public void ClearData()
        {
            _s.ClearLists();
        }
    }
}
