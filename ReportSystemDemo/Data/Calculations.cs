using ReportSystemDemo.UIModels;
using System;
using System.Collections.Generic;

namespace ReportSystemDemo.Data
{
    internal class Calculations
    {
        ReportStorage _rs = new ReportStorage();

        //number of requests
        public int SumRequests(List<object> dbData)
        {
            int counter = dbData.Count;

            return counter;
        }

        //number of closed requests
        public int SumClosedRequests(List<object> dbData)
        {
            int counter = 0;

            for (int i = 0; i < dbData.Count; i++)
            {
                object[] guf = (object[])dbData[i];

                if (guf[7].ToString() == "Закрыто")
                    counter++;
            }

            return counter;
        }

        //Count SLA percentage
        public double SumSLA(List<object> dbData, int sumRequests)
        {
            int counter = 0;

            for (int i = 0; i < dbData.Count; i++)
            {
                object[] guf = (object[])dbData[i];

                if (guf[13].ToString() != "")
                    counter++;
            }
            
            double SLA = Math.Round((1 - counter / (double)sumRequests) * 100, 2);

            return SLA;
        }

        //count crisis incidents
        public int SumCrisis(List<object> dbData)
        {
            int counter = 0;

            for (int i = 0; i < dbData.Count; i++)
            {
                object[] guf = (object[])dbData[i];

                if (guf[6].ToString() == "True")
                    counter++;
            }

            return counter;
        }

        //count contracts details for Contract
        public Report ReportBuilder(List<object> dbData, string contract)
        {
            bool status = true;
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
                    if (guf[11].ToString() == "Сибинтек Софт" || guf[11].ToString() == "ИК Сибинтек СН" || guf[11].ToString() == "Снегирь Софт_архив" || guf[11].ToString() == "ИК Сибинтек УСИТО" || guf[11].ToString() == "ИК Сибинтек ДИТиАВП СН" || guf[11].ToString() == "РБС_архив" || guf[11].ToString() == "1С: ЕИСУП" || guf[11].ToString() == "Снегирь Софт" || guf[11].ToString() == "РБС" || guf[11].ToString() == "ЭКСПЕРТЕК ИБС" || guf[11].ToString() == "ЛВ Сфера")
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

            double actualSLA = Math.Round((1 - SLABreakCounter/(double)counter) * 100, 2);

            //optional and useless
            var report = new Report(status, contractName, counter, crisisCounter, targetSLA, actualSLA, requests, incidents, five, four, three, two, noMark, restart);
            _rs.AddReport(report);
            //

            return report;
        }

        //collect reports for user
        public List<Report> CollectReports()
        {
            return _rs.Reports;
        }

        //clear report list
        public void ClearReports()
        {
            _rs.ClearReportList();
        }
    }
}
